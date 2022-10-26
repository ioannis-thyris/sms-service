using Domain.DataTransferObjects;
using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsVendors.Vendors.CY
{
    public class SmsValidatorCY : AbstractValidator<SmsDto>, ISmsValidatorCY
    {
        public SmsValidatorCY() : base()
        {
            RuleFor(m => m.Text).NotEmpty()
                                .WithMessage("Cannot send an empty message.");

            RuleFor(m => m.Number).NotEmpty()
                                  .Matches(@"^\+[1-9]\d{1,14}$")
                .WithMessage("Wrong Telephone number format, please use '+(country code)(Subscriber number)'. Check: https://en.wikipedia.org/wiki/E.164");
        }

    }
}
