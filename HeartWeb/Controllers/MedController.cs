using HeartWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeartWeb.Controllers
{
    public class MedController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet]
        public IActionResult Form() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Form(FormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return RedirectToAction("Result", new { id = model.ToString() });
        }

        [HttpGet]
        public IActionResult Result(string id) => View(FormModel.FromString(id));

        [HttpGet]
        public IActionResult FullResult(string id) => View(FormModel.FromString(id));

        [HttpGet]
        public IActionResult Literature() => View();
    }
}
