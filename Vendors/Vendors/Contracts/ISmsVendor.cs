using DataTransferObjects;
using Domain.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsVendors.Contracts
{
    public interface ISmsVendor
    {
        public Task<(bool Successful, int MessagesSent)> Send(Sms sms);

        public ValidationResult Validate(SmsDto smsDto);
    }
}
