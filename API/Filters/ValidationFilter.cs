using API.Controllers;
using Domain.DataTransferObjects;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SmsVendors.Core;
using System.Numerics;

namespace API.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = (SmsController)context.Controller;

            var dto = (SmsDto)context.ActionArguments.FirstOrDefault().Value; // Get the Dto passed

            var validationResults = controller.Vendor.Validate(dto);

            validationResults.AddToModelState(context.ModelState);

            if (!context.ModelState.IsValid)
                context.Result = controller.ValidationProblem(context.ModelState);
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
