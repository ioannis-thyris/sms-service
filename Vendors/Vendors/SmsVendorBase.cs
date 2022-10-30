using DataAccessLayer;
using DataTransferObjects;
using Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using SmsVendors.Contracts;

namespace SmsVendors.Vendors
{
    public abstract class SmsVendorBase : ISmsVendor
    {
        private readonly ISmsRepository _repo;
        private readonly IValidator<SmsDto> _validator;

        protected virtual int MaxChars { get; set; } = 480;

        public SmsVendorBase(ISmsRepository repo, IValidator<SmsDto> validator)
        {
            _repo = repo;
            _validator = validator;
        }


        public async Task<(bool Successful, int MessagesSent)> Send(Sms sms)
        {
            int smsNumberToSend = (int)Math.Ceiling((double)sms.Text.Length / MaxChars);
            string splitText;
            Sms subSms;
            bool isSuccessful = false;
            int messagesSent = 0;

            while (smsNumberToSend > 0)
            {
                splitText = string.Concat(sms.Text.Skip(messagesSent * MaxChars).Take(MaxChars));

                subSms = new Sms(sms, splitText);

                isSuccessful = await _repo.Create(subSms);

                messagesSent++;
                smsNumberToSend--;
            }

            return (isSuccessful, messagesSent);
        }

        public ValidationResult Validate(SmsDto smsDto) => _validator.Validate(smsDto);


    }
}
