using API.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters
{
    public class VendorFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = (SmsController)context.Controller;

            //controller._vendor = 
        }

        public void OnActionExecuting(ActionExecutingContext context) {}
    }
}
