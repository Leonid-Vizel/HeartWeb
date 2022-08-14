using Microsoft.AspNetCore.Mvc;

namespace HeartWeb.Controllers
{
    public class ErrorController : Controller
    {
        public new IActionResult NotFound()
        {
            return View();
        }

        public IActionResult Forbidden()
        {
            return View();
        }
    }
}
