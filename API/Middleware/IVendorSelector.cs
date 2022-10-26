using SmsVendors.Core;

namespace API.Middleware
{
    public interface ISmsVendorSelector
    {
        public ISmsVendor Select(HttpContext context);
    }
}
