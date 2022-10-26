using SmsVendors.Core;

namespace API.Middleware
{
    public interface ISmsVendorSelector
    {
        public string Select(HttpContext context);
    }
}
