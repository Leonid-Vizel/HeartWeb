using HeartWeb.Data;
using HeartWeb.Instruments;
using HeartWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeartWeb.Controllers
{
    public class MedController : Controller
    {
        private readonly ApplicationDbContext db;

        public MedController(ApplicationDbContext db)
        {
            this.db = db;
        }

        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            #region Auth
            if (!Authenticator.Check(HttpContext.Session, db, ViewData))
            {
                return RedirectToAction("Login", "Auth");
            }
            #endregion
            return View();
        }
        #endregion

        #region Form
        [HttpGet]
        public IActionResult Form()
        {
            #region Auth
            if (!Authenticator.Check(HttpContext.Session, db, ViewData))
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
            if (!Authenticator.Check(HttpContext.Session, db, ViewData))
            {
                return RedirectToAction("Login", "Auth");
            }
            #endregion
            model.Login = Authenticator.GetLogin(HttpContext.Session);
            await db.FormResults.AddAsync(model);
            await db.SaveChangesAsync();
            return RedirectToAction("Result", new { id = model.Id });
        }
        #endregion

        #region Results
        [HttpGet]
        public IActionResult Result(int id)
        {
            #region Auth
            if (!Authenticator.Check(HttpContext.Session, db, ViewData))
            {
                return RedirectToAction("Login", "Auth");
            }
            #endregion
            FormModel? foundModel = db.FormResults.FirstOrDefault(x => x.Id == id);
            if (foundModel == null)
            {
                return RedirectToAction("Error", "NotFound");
            }
            return View(foundModel);
        }

        [HttpGet]
        public IActionResult FullResult(int id)
        {
            #region Auth
            if (!Authenticator.Check(HttpContext.Session, db, ViewData))
            {
                return RedirectToAction("Login", "Auth");
            }
            #endregion
            FormModel? foundModel = db.FormResults.FirstOrDefault(x => x.Id == id);
            if (foundModel == null)
            {
                return RedirectToAction("Error", "NotFound");
            }
            return View(foundModel);
        }
        #endregion

        #region Literature
        [HttpGet]
        public IActionResult Literature()
        {
            #region Auth
            if (!Authenticator.Check(HttpContext.Session, db, ViewData))
            {
                return RedirectToAction("Login", "Auth");
            }
            #endregion
            return View();
        }
        #endregion
    }
}
