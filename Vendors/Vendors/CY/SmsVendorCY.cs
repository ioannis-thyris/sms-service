using DataAccessLayer;
using SmsVendors.Contracts;

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
