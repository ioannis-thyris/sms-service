using Domain.Models;
using FluentValidation;
using SmsVendors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsVendors.Vendors.CY
{
    public class SmsValidatorCY : SmsValidatorBase
    {
        public SmsValidatorCY() : base()
        {
            RuleFor(m => m.Text).MaximumLength(160);
        }

    }
}
