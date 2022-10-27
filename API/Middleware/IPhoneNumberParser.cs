using SmsVendors;
using SmsVendors.Contracts;

namespace API.Middleware
{
    public interface IPhoneNumberParser
    {
        public Task<Country> GetCountry(HttpContext context);
    }
}
