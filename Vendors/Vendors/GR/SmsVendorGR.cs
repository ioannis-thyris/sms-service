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

namespace SmsVendors.Vendors.GR
{
    public class SmsVendorGR : SmsVendorBase, ISmsVendorGR
    {
        public SmsVendorGR(ISmsRepository repo, ISmsValidatorGR validator) 
            : base(repo, validator)
        {
        }
    }
}
