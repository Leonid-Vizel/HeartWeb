using HeartWeb.Data;
using HeartWeb.Instruments;
using HeartWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return RedirectToAction("Index", "Med");
        }
        #endregion

        public async Task<IActionResult> Migrate()
        {
            if ((await db.Database.GetPendingMigrationsAsync()).Count() > 0)
            {
                await db.Database.MigrateAsync();
            }
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            Authenticator.Logout(HttpContext.Session);
            return RedirectToAction("Login", "Auth");
        }

        public IActionResult Users()
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
            return View(db.Users.ToList());
        }

        public async Task<IActionResult> SelfData()
        {
            #region Auth
            if (!Authenticator.Check(HttpContext.Session, db, ViewData))
            {
                return RedirectToAction("Login", "Auth");
            }
            #endregion
            string login = Authenticator.GetLogin(ViewData).ToLower();
            User? foundUser = await db.Users.FirstOrDefaultAsync(x => x.Login.Equals(login));
            if (foundUser == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(foundUser);
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
        public async Task<IActionResult> Register(RegisterModel model)
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
            if (!await Authenticator.Register(db, model))
            {
                ModelState.AddModelError("Login", "Аккаунт на эту почту уже зарегистрирован!");
                return View(model);
            }
            return RedirectToAction("Index", "Med");
        }
        #endregion
    }
}
