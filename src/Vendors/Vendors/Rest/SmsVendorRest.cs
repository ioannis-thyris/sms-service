using DataAccessLayer;
using SmsVendors.Contracts;

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
