using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HeartWeb.Instruments.Filters
{
    public class AuthLoad : Attribute, IAsyncActionFilter
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
            Authenticator.Check(session, controller.ViewData);
            await next();
        }
    }
}
