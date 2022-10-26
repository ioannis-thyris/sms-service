using SmsVendors.Contracts;

namespace API.Middleware
{
    public interface ISmsVendorSelector
    {
        public string Select(HttpContext context);
    }
}
