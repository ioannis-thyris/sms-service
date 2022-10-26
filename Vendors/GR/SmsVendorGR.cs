using Domain.DataTransferObjects;
using Domain.Models;
using FluentValidation.Results;
using SmsVendors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsVendors.GR
{
    public class SmsVendorGR : ISmsVendor
    {
        private readonly ISmsValidator _validator;

        public SmsVendorGR(ISmsValidator validator)
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
