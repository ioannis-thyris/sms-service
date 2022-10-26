using DataAccessLayer;
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

namespace SmsVendors.Vendors
{
    public class SmsVendorBase : ISmsVendor
    {
        private readonly ISmsRepository _repo;
        private readonly IValidator<SmsDto> _validator;

        public SmsVendorBase(ISmsRepository repo, IValidator<SmsDto> validator)
        {
            _repo = repo;
            _validator = validator;
        }


        public Task Send(Sms sms) => _repo.Create(sms);

        public  ValidationResult Validate(SmsDto smsDto) => _validator.Validate(smsDto);
    }
}
