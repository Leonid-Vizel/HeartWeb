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
        public async Task<IActionResult> Login(AuthModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (!await Authenticator.Login(HttpContext.Session, db, model.Login, model.Password))
            {
                ModelState.AddModelError("Login", "Неверные почта или пароль!");
                return View(model);
            }
            return RedirectToAction("Index", "Med");
        }
        #endregion

        #region Migrate
        public async Task<IActionResult> Migrate()
        {
            if ((await db.Database.GetPendingMigrationsAsync()).Count() > 0)
            {
                await db.Database.MigrateAsync();
            }
            return RedirectToAction("Login");
        }
        #endregion

        #region Logout
        public IActionResult Logout()
        {
            Authenticator.Logout(HttpContext.Session);
            return RedirectToAction("Login", "Auth");
        }
        #endregion

        #region Users
        public async Task<IActionResult> Users()
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
            return View(db.Users.ToList());
        }
        #endregion

        #region Self
        public async Task<IActionResult> SelfData()
        {
            #region Auth
            if (!await Authenticator.Check(HttpContext.Session, db, ViewData))
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
        #endregion

        #region Register
        public async Task<IActionResult> Register()
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
            if (!await Authenticator.Register(db, model))
            {
                ModelState.AddModelError("Login", "Аккаунт на эту почту уже зарегистрирован!");
                return View(model);
            }
            return RedirectToAction("Users");
        }
        #endregion

        #region Edit
        public async Task<IActionResult> Edit(int id)
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
            User? foundUser = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (foundUser == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(foundUser.ToEditModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
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
            User? foundUser = await db.Users.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (foundUser == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            foundUser.Update(model.ToUser());
            if (db.Entry(foundUser).State == EntityState.Modified)
            {
                db.Update(foundUser);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Users");
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int id)
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
            User? foundUser = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (foundUser == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            if (foundUser.Login.ToLower().Equals(ViewData["login"]))
            {
                return RedirectToAction("SelfDelete", "Error");
            }
            db.Users.Remove(foundUser);
            await db.SaveChangesAsync();
            return RedirectToAction("Users");
        }
        #endregion
    }
}
