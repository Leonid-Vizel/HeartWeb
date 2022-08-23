using HeartWeb.Data;
using HeartWeb.Instruments;
using Microsoft.AspNetCore.Mvc;

namespace HeartWeb.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ApplicationDbContext db;

        public ErrorController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public new async Task<IActionResult> NotFound()
        {
            await Authenticator.Check(HttpContext.Session, db, ViewData);
            return View();
        }

        public async Task<IActionResult> Forbidden()
        {
            await Authenticator.Check(HttpContext.Session, db, ViewData);
            return View();
        }

        public async Task<IActionResult> SelfDelete()
        {
            await Authenticator.Check(HttpContext.Session, db, ViewData);
            return View();
        }
    }
}
