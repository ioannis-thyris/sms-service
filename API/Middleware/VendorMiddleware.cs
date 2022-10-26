using SmsVendors.Vendors;

namespace API.Middleware
{
    public class VendorMiddleware
    {
        private readonly ISmsVendorSelector _selector;
        private readonly ISmsVendorFactory _factory;

        private readonly RequestDelegate _next;

        public VendorMiddleware(RequestDelegate next, ISmsVendorSelector selector, ISmsVendorFactory factory)
        {
            _next = next;
            _selector = selector;
            _factory = factory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var countryCode = _selector.Select(context);

            // Since the vendors are registered as scoped, this instance will be injected
            // to the controller during construction.
            var vendor = _factory.Create(countryCode); 

            // Pass the request to the next delegate in the pipeline
            await _next(context);
        }

    }
}
