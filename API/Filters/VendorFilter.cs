using API.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using SmsVendors.Contracts;
using System.Numerics;

namespace API.Filters
{
    public class VendorFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Items.TryGetValue("Vendor", out object vendor);

            if (vendor == null)
                throw new Exception("Error with assigning a SMS vendor.");

            var controller = (SmsController)context.Controller;
            
            controller.Vendor = (ISmsVendor)vendor;
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
