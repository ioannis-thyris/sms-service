using SmsVendors.Core;

namespace SmsVendors.Vendors
{
    public interface ISmsVendorFactory
    {
        ISmsVendor Create(string countryCode);
    }
}