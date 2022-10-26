using SmsVendors.Core;

namespace API.Middleware
{
    public class VendorSelector : ISmsVendorSelector
    {
        public ISmsVendor Select(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
