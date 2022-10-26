using Domain.DataTransferObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validation
{
    public interface ISmsValidator : IValidator<SmsDto>
    {
    }
}
