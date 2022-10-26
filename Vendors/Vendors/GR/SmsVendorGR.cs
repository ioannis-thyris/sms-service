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

namespace SmsVendors.Vendors.GR
{
    public class SmsVendorGR : ISmsVendorGR
    {
        private readonly IValidator<SmsDto> _validator;

        public SmsVendorGR(IValidator<SmsDto> validator)
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
