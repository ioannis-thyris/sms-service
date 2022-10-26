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

namespace SmsVendors.Vendors.Rest
{
    public class SmsVendorRest : SmsVendorBase, ISmsVendorRest
    {
        public SmsVendorRest(ISmsRepository repo, ISmsValidatorRest validator) 
            : base(repo, validator)
        {
        }
    }
}
