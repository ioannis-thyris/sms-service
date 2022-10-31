using DataTransferObjects;
using Domain.Models;
using FluentValidation.Results;

namespace SmsVendors.Contracts
{
    public interface ISmsVendor
    {
        public Task<(bool Successful, int MessagesSent)> Send(Sms sms);

        public ValidationResult Validate(SmsDto smsDto);
    }
}
