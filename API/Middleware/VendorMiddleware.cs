using SmsVendors.Vendors;

namespace API.Middleware
{
    public class VendorMiddleware
    {
        //private readonly ISmsVendorFactory _factory;
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

            // Since the vendors are registered as scoped, this instance will be injected
            // to the controller during construction.
            var vendor = factory.Create(countryCode);

            // Pass the request to the next delegate in the pipeline
            await _next(context);
        }

    }
}
