using HeartWeb.Instruments.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HeartWeb.Controllers
{
    public class ErrorController : Controller
    {

        [AuthLoad]
        public IActionResult Code(string id) => View($"~/Views/Error/{id}.cshtml");

        [AuthLoad]
        public IActionResult SelfDelete() => View();
    }
}
