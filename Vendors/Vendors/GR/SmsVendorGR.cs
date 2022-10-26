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

namespace SmsVendors.Vendors.GR
{
    public class SmsVendorGR : SmsVendorBase, ISmsVendorGR
    {
        public SmsVendorGR(ISmsRepository repo, ISmsValidatorGR validator) 
            : base(repo, validator)
        {
        }

        //Task<bool> ISmsVendor.Send(Sms sms)
        //{
        //    throw new NotImplementedException();
        //}


        //public Task<bool> Send(Sms sms)
        //{
        //    throw new NotImplementedException();
        //}

        //public ValidationResult Validate(SmsDto smsDto) => _validator.Validate(smsDto);
    }
}
