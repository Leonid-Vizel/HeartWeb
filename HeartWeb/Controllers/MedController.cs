using HeartWeb.Data;
using HeartWeb.Instruments;
using HeartWeb.Instruments.Filters;
using HeartWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace HeartWeb.Controllers
{
    public class MedController : Controller
    {
        public const int pageCapacity = 10;
        private readonly ApplicationDbContext db;

        public MedController(ApplicationDbContext db)
        {
            this.db = db;
        }

        #region Index
        [Auth]
        public IActionResult Index() => View();
        #endregion

        #region Form
        [Auth]
        public IActionResult Form() => View();

        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Form(FormModel model, CancellationToken token = default)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Login = Authenticator.GetLogin(ViewData);
            model.SaveTime = DateTime.Now;
            await db.FormResults.AddAsync(model, token);
            await db.SaveChangesAsync(token);
            return RedirectToAction("Result", new { id = model.Id });
        }
        #endregion

        #region Edit
        [Auth]
        public async Task<IActionResult> Edit(int id, CancellationToken token = default)
        {
            FormModel? foundModel = await db.FormResults.FirstOrDefaultAsync(x => x.Id == id, token);
            if (foundModel == null)
            {
                return RedirectToAction("Error", "NotFound");
            }
            return View(foundModel);
        }

        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FormModel model, CancellationToken token = default)
        {
            FormModel? foundModel = await db.FormResults.FirstOrDefaultAsync(x => x.Id == model.Id, token);
            if (foundModel == null)
            {
                return RedirectToAction("Error", "NotFound");
            }
            foundModel.Update(model);
            if (db.Entry(foundModel).State == EntityState.Modified)
            {
                db.Update(foundModel);
                await db.SaveChangesAsync(token);
            }
            return RedirectToAction("Result", new { id = model.Id });
        }
        #endregion

        #region Results
        [Auth]
        public async Task<IActionResult> Result(int id, CancellationToken token = default)
        {
            FormModel? foundModel = await db.FormResults.FirstOrDefaultAsync(x => x.Id == id, token);
            if (foundModel == null)
            {
                return RedirectToAction("Error", "NotFound");
            }
            return View(foundModel);
        }

        [AuthAdmin]
        public async Task<IActionResult> Results(CancellationToken token = default)
        {
            int count = await db.FormResults.CountAsync(token);
            return View(count);
        }

        [Auth]
        public async Task<IActionResult> FullResult(int id, CancellationToken token = default)
        {
            FormModel? foundModel = await db.FormResults.FirstOrDefaultAsync(x => x.Id == id, token);
            if (foundModel == null)
            {
                return RedirectToAction("Error", "NotFound");
            }
            return View(foundModel);
        }

        [Auth]
        public async Task<IActionResult> MyResults(int page = 1, CancellationToken token = default)
        {
            page = page < 1 ? 1 : page;
            string login = Authenticator.GetLogin(ViewData);
            var query = await db.FormResults.Where(x => x.Login.Equals(login))
                                            .Select(x => new Tuple<int, DateTime>(x.Id, x.SaveTime))
                                            .ToPagedListAsync(page, pageCapacity, token);
            return View(query);
        }
        #endregion

        #region Export
        [AuthAdmin]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Export(CancellationToken token = default)
        {
            var results = await db.FormResults.ToListAsync(token);
            return File(Exporter.ExportResults(results),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Результаты.xlsx");
        }
        #endregion

        #region Literature
        [Auth]
        public async Task<IActionResult> Literature() => View();
        #endregion
    }
}
