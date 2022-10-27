using Domain.DataTransferObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsVendors.Vendors.Rest
{
    public class SmsValidatorRest : AbstractValidator<SmsDto>, ISmsValidatorRest
    {
        public SmsValidatorRest() : base()
        {
            RuleFor(m => m.Text).NotEmpty()
                                .WithMessage("Cannot send an empty message.");

            RuleFor(m => m.Number).NotEmpty()
                                  .Matches(@"^\+[1-9]\d{1,14}$")
                                  .MinimumLength(7)
                .WithMessage("Wrong Telephone number format, please use '+(country code)(Subscriber number)'. Check: https://en.wikipedia.org/wiki/E.164");
        }
    }
}
