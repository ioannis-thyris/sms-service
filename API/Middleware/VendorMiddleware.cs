using Domain.DataTransferObjects;
using SmsVendors.Contracts;
using SmsVendors.Factory;
using System.Text;
using System.Text.Json;

namespace API.Middleware
{
    public class VendorMiddleware
    {
        private readonly IPhoneNumberParser _parser;

        private readonly RequestDelegate _next;

        public VendorMiddleware(RequestDelegate next, IPhoneNumberParser parser)
        {
            _next = next;
            _parser = parser;
        }

        public async Task InvokeAsync(HttpContext context, ISmsVendorFactory factory)
        {
            context.Request.EnableBuffering();

            var countryCode = await _parser.GetCountry(context);

            var vendor = factory.Create(countryCode);

            context.Items["Vendor"] = vendor;

            // Pass the request to the next delegate in the pipeline
            await _next(context);
        }

    }
}
