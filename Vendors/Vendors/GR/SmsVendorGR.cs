using DataAccessLayer;
using SmsVendors.Contracts;

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
