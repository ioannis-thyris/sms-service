using Domain.DataTransferObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validation
{
    public class SmsValidatorBase : AbstractValidator<SmsDto>
    {
        public SmsValidatorBase()
        {
            RuleFor(m => m.Text).NotEmpty()
                                .MaximumLength(480);

            RuleFor(m => m.Number).NotEmpty()
                                  .Matches(@"^\+[1-9]\d{1,14}$");

        }
    }
}
