using Domain.DataTransferObjects;
using Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using SmsVendors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsVendors.Vendors.CY
{
    public class SmsVendorCY : ISmsVendorCY
    {
        private readonly IValidator<SmsDto> _validator;

        public SmsVendorCY(IValidator<SmsDto> validator)
        {
            _validator = validator;
        }

        public Task<bool> Send(Sms sms)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Validate(SmsDto smsDto) => _validator.Validate(smsDto);
    }
}
