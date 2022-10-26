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

namespace SmsVendors.Vendors.CY
{
    public class SmsVendorCY : SmsVendorBase, ISmsVendorCY
    {
        public SmsVendorCY(ISmsRepository repo, ISmsValidatorCY validator) 
            : base(repo, validator)
        {
        }
    }
}
