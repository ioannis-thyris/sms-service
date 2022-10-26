using SmsVendors.Core;

namespace SmsVendors.Factory
{
    public interface ISmsVendorFactory
    {
        ISmsVendor Create(string countryCode);
    }
}