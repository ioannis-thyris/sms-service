using API.Controllers;
using Domain.DataTransferObjects;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = (SmsController)context.Controller;

            var dto = (SmsDto)context.ActionArguments.FirstOrDefault().Value; // Get the Dto passed

            var validationResult = controller.Vendor.Validate(dto);

            validationResult.AddToModelState(context.ModelState);
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
