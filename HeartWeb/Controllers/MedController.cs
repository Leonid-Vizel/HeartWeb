using HeartWeb.Data;
using HeartWeb.Instruments;
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
        public async Task<IActionResult> Index()
        {
            #region Auth
            if (!await Authenticator.Check(HttpContext.Session, db, ViewData))
            {
                return RedirectToAction("Login", "Auth");
            }
            #endregion
            return View();
        }
        #endregion

        #region Form
        public async Task<IActionResult> Form()
        {
            #region Auth
            if (!await Authenticator.Check(HttpContext.Session, db, ViewData))
            {
                return RedirectToAction("Login", "Auth");
            }
            #endregion
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Form(FormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            #region Auth
            if (!await Authenticator.Check(HttpContext.Session, db, ViewData))
            {
                return RedirectToAction("Login", "Auth");
            }
            #endregion
            model.Login = Authenticator.GetLogin(ViewData);
            model.SaveTime = DateTime.Now;
            await db.FormResults.AddAsync(model);
            await db.SaveChangesAsync();
            return RedirectToAction("Result", new { id = model.Id });
        }
        #endregion

        #region Edit
        public async Task<IActionResult> Edit(int id)
        {
            #region Auth
            if (!await Authenticator.Check(HttpContext.Session, db, ViewData))
            {
                return RedirectToAction("Login", "Auth");
            }
            #endregion
            FormModel? foundModel = await db.FormResults.FirstOrDefaultAsync(x => x.Id == id);
            if (foundModel == null)
            {
                return RedirectToAction("Error", "NotFound");
            }
            return View(foundModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FormModel model)
        {
            #region Auth
            if (!await Authenticator.Check(HttpContext.Session, db, ViewData))
            {
                return RedirectToAction("Login", "Auth");
            }
            #endregion
            FormModel? foundModel = await db.FormResults.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (foundModel == null)
            {
                return RedirectToAction("Error", "NotFound");
            }
            foundModel.Update(model);
            if (db.Entry(foundModel).State == EntityState.Modified)
            {
                db.Update(foundModel);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Result", new { id = model.Id });
        }
        #endregion

        #region Results
        public async Task<IActionResult> Result(int id)
        {
            #region Auth
            if (!await Authenticator.Check(HttpContext.Session, db, ViewData))
            {
                return RedirectToAction("Login", "Auth");
            }
            #endregion
            FormModel? foundModel = await db.FormResults.FirstOrDefaultAsync(x => x.Id == id);
            if (foundModel == null)
            {
                return RedirectToAction("Error", "NotFound");
            }
            return View(foundModel);
        }

        public async Task<IActionResult> Results()
        {
            #region Auth Admin
            bool? value = await Authenticator.CheckAdmin(HttpContext.Session, db, ViewData);
            if (value == null)
            {
                return RedirectToAction("Forbidden", "Error");
            }
            if (!value.Value)
            {
                return RedirectToAction("Login", "Auth");
            }
            #endregion
            return View(await db.FormResults.CountAsync());
        }

        public async Task<IActionResult> FullResult(int id)
        {
            #region Auth
            if (!await Authenticator.Check(HttpContext.Session, db, ViewData))
            {
                return RedirectToAction("Login", "Auth");
            }
            #endregion
            FormModel? foundModel = await db.FormResults.FirstOrDefaultAsync(x => x.Id == id);
            if (foundModel == null)
            {
                return RedirectToAction("Error", "NotFound");
            }
            return View(foundModel);
        }

        public async Task<IActionResult> MyResults(int page = 1)
        {
            #region Auth
            if (!await Authenticator.Check(HttpContext.Session, db, ViewData))
            {
                return RedirectToAction("Login", "Auth");
            }
            #endregion
            if (page < 1)
            {
                page = 1;
            }
            return View(db.FormResults.Where(x=>x.Login.Equals(Authenticator.GetLogin(ViewData))).Select(x=> new Tuple<int, DateTime>(x.Id,x.SaveTime)).ToPagedList(page, pageCapacity));
        }
        #endregion

        #region Export
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Export()
        {
            #region Auth Admin
            bool? value = await Authenticator.CheckAdmin(HttpContext.Session, db, ViewData);
            if (value == null)
            {
                return RedirectToAction("Forbidden", "Error");
            }
            if (!value.Value)
            {
                return RedirectToAction("Login", "Auth");
            }
            #endregion
            return File(Exporter.ExportResults(db.FormResults.ToList()),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Результаты.xlsx");
        }
        #endregion

        #region Literature
        public async Task<IActionResult> Literature()
        {
            #region Auth
            if (!await Authenticator.Check(HttpContext.Session, db, ViewData))
            {
                return RedirectToAction("Login", "Auth");
            }
            #endregion
            return View();
        }
        #endregion
    }
}
