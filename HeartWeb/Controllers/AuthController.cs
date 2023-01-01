using HeartWeb.Data;
using HeartWeb.Instruments;
using HeartWeb.Instruments.Filters;
using HeartWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeartWeb.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext db;

        public AuthController(ApplicationDbContext db) => this.db = db;

        #region Login
        [Auth(false)]
        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AuthModel model, CancellationToken token = default)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (!await Authenticator.Login(HttpContext.Session, db, model, token))
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
        [AuthAdmin]
        public async Task<IActionResult> Users(CancellationToken token = default)
        {
            var users = await db.Users.ToListAsync(token);
            return View(users);
        }
        #endregion

        #region Self
        [Auth]
        public async Task<IActionResult> SelfData(CancellationToken token = default)
        {
            int id = Authenticator.GetId(ViewData);
            User? foundUser = await db.Users.FirstOrDefaultAsync(x => x.Id == id, token);
            if (foundUser == null)
            {
                return NotFound();
            }
            return View(foundUser);
        }
        #endregion

        #region Register
        [AuthAdmin]
        public IActionResult Register() => View();

        [AuthAdmin]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model, CancellationToken token = default)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (!await Authenticator.Register(db, model, token))
            {
                ModelState.AddModelError("Login", "Аккаунт на эту почту уже зарегистрирован!");
                return View(model);
            }
            return RedirectToAction("Users");
        }
        #endregion

        #region Edit
        [AuthAdmin]
        public async Task<IActionResult> Edit(int id, CancellationToken token = default)
        {
            User? foundUser = await db.Users.FirstOrDefaultAsync(x => x.Id == id, token);
            if (foundUser == null)
            {
                return NotFound();
            }
            return View(foundUser.ToEditModel());
        }

        [AuthAdmin]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserEditModel model, CancellationToken token = default)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User? foundUser = await db.Users.FirstOrDefaultAsync(x => x.Id == model.Id, token);
            if (foundUser == null)
            {
                return NotFound();
            }
            foundUser.Update(model.ToUser());
            if (db.Entry(foundUser).State == EntityState.Modified)
            {
                db.Update(foundUser);
                await BetterSession.EndSessionsByLogin(HttpContext.Session, foundUser.Login, token);
                await db.SaveChangesAsync(token);
            }
            return RedirectToAction("Users");
        }
        #endregion

        #region Delete
        [AuthAdmin]
        public async Task<IActionResult> Delete(int id, CancellationToken token = default)
        {
            User? foundUser = await db.Users.FirstOrDefaultAsync(x => x.Id == id, token);
            if (foundUser == null)
            {
                return NotFound();
            }
            if (foundUser.Login.ToLower().Equals(ViewData["login"]))
            {
                return RedirectToAction("SelfDelete", "Error");
            }
            db.Users.Remove(foundUser);
            await db.SaveChangesAsync(token);
            await BetterSession.EndSessionsByLogin(HttpContext.Session, foundUser.Login, token);
            return RedirectToAction("Users");
        }
        #endregion
    }
}
