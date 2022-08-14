using HeartWeb.Data;
using HeartWeb.Instruments;
using HeartWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeartWeb.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext db;

        public AuthController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AuthModel model)
        {
            return View();
        }

        public IActionResult Register()
        {
            #region Auth Admin
            bool? value = Authenticator.CheckAdmin(HttpContext.Session, db);
            if (value == null)
            {
                return RedirectToAction("Error", "Forbidden");
            }
            if (!value.Value)
            {
                return RedirectToAction("Auth", "Login");
            }
            #endregion
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(AuthModel model)
        {
            #region Auth Admin
            bool? value = Authenticator.CheckAdmin(HttpContext.Session, db);
            if (value == null)
            {
                return RedirectToAction("Error", "Forbidden");
            }
            if (!value.Value)
            {
                return RedirectToAction("Auth", "Login");
            }
            #endregion
            return View();
        }
    }
}
