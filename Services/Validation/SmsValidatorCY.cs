using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validation
{
    public class SmsValidatorCY : SmsValidatorBase
    {
        public SmsValidatorCY() : base()
        {
            RuleFor(m => m.Text).MaximumLength(160);
        }

    }
}
