using SmsVendors.Core;
using SmsVendors.Factory;

namespace API.Middleware
{
    public class VendorMiddleware
    {
        private readonly ISmsVendorSelector _selector;

        private readonly RequestDelegate _next;

        public VendorMiddleware(RequestDelegate next, ISmsVendorSelector selector)
        {
            _next = next;
            _selector = selector;
        }

        public async Task InvokeAsync(HttpContext context, ISmsVendorFactory factory)
        {
            var countryCode = _selector.Select(context);

            var vendor = factory.Create(countryCode);

            context.Items["Vendor"] = vendor;

            // Pass the request to the next delegate in the pipeline
            await _next(context);
        }

    }
}
