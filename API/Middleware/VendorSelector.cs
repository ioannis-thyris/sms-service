using SmsVendors.Contracts;

namespace API.Middleware
{
    public class VendorSelector : ISmsVendorSelector
    {
        public string Select(HttpContext context)
        {
            return "GR";
        }
    }
}
