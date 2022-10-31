using SmsVendors.Contracts;

namespace SmsVendors.Factory
{
    public interface ISmsVendorFactory
    {
        ISmsVendor Create(Country country);
    }
}