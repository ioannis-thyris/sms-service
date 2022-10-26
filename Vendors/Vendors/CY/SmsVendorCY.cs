using DataAccessLayer;
using Domain.DataTransferObjects;
using Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using SmsVendors.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsVendors.Vendors.CY
{
    public class SmsVendorCY : SmsVendorBase, ISmsVendorCY
    {
        protected override int MaxChars { get; set; } = 160;

        public SmsVendorCY(ISmsRepository repo, ISmsValidatorCY validator) 
            : base(repo, validator)
        {
        }
    }
}
