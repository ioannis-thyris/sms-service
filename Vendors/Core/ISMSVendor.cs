using Domain.DataTransferObjects;
using Domain.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsVendors.Core
{
    public interface ISmsVendor
    {
        public Task Send(Sms sms);

        public ValidationResult Validate(SmsDto smsDto);
    }
}
