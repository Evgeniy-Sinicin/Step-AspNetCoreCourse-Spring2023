using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Shop.Presentation.Web.Filtres
{
    public class LogUserActivirtyActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<LogUserActivirtyActionFilter>>();
            logger.LogInformation($"User {context.HttpContext.User.Identity.Name} has done something at {DateTime.Now}");
        }
    }
}
