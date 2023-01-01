using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace HeartWeb.Instruments.Filters
{
    public class AuthAdminAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ISession session = context.HttpContext.Session;
            Controller? controller = context.Controller as Controller;
            if (controller == null)
            {
                context.Result = new NotFoundResult();
                return;
            }
            ViewDataDictionary data = controller.ViewData;
            bool? authResult = Authenticator.CheckAdmin(session, data);
            if (authResult == null)
            {
                context.Result = new StatusCodeResult(403);
            }
            else if (!authResult.Value)
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
            }
            else
            {
                await next();
            }
        }
    }
}
