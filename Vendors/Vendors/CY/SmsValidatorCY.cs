﻿using DataTransferObjects;
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
                                  .Matches(@"^\+[3][5][7]\d{1,8}$")
                                  .MinimumLength(7)
                .WithMessage("Wrong Telephone number format, please use '+(country code)(Subscriber number)'. Check: https://en.wikipedia.org/wiki/E.164");
        }

    }
}
