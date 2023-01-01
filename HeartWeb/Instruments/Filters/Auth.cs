using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace HeartWeb.Instruments.Filters
{
    public class AuthAttribute : Attribute, IAsyncActionFilter
    {
        private readonly bool redirectToLogin;
        public AuthAttribute(bool redirectToLogin = true)
        {
            this.redirectToLogin = redirectToLogin;
        }

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
            bool authResult = Authenticator.Check(session, data);
            if (!authResult && redirectToLogin)
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
