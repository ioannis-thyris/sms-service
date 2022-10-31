using DataTransferObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsVendors.Vendors.Rest
{
    public class SmsValidatorRest : SmsValidatorBase, ISmsValidatorRest
    {
        public SmsValidatorRest() : base()
        {
        }
    }
}
