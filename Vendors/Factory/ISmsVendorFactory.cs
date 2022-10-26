using SmsVendors.Contracts;

namespace SmsVendors.Factory
{
    public interface ISmsVendorFactory
    {
        ISmsVendor Create(string countryCode);
    }
}