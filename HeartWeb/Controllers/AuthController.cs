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

        #region Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AuthModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }    
            if (!Authenticator.Login(HttpContext.Session, db, model.Login, model.Password))
            {
                ModelState.AddModelError("Login", "Неверные почта или пароль!");
                return View(model);
            }
            return RedirectToAction("Index","Med");
        }
        #endregion

        public IActionResult Logout()
        {
            Authenticator.Logout(HttpContext.Session);
            return RedirectToAction("Login","Auth");
        }

        #region Register
        public IActionResult Register()
        {
            #region Auth Admin
            bool? value = Authenticator.CheckAdmin(HttpContext.Session, db, ViewData);
            if (value == null)
            {
                return RedirectToAction("Forbidden", "Error");
            }
            if (!value.Value)
            {
                return RedirectToAction("Login", "Auth");
            }
            #endregion
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AuthModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            #region Auth Admin
            bool? value = Authenticator.CheckAdmin(HttpContext.Session, db, ViewData);
            if (value == null)
            {
                return RedirectToAction("Forbidden", "Error");
            }
            if (!value.Value)
            {
                return RedirectToAction("Login", "Auth");
            }
            #endregion
            if (!await Authenticator.Register(db, model.Login, model.Password))
            {
                ModelState.AddModelError("Login","Аккаунт на эту почту уже зарегистрирован!");
                return View(model);
            }
            return RedirectToAction("Index", "Med");
        }
        #endregion
    }
}
