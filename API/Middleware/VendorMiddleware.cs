namespace API.Middleware
{
    public class VendorMiddleware
    {
        private readonly ISmsVendorSelector _selector;
        private readonly IConfiguration _configuration;

        private readonly RequestDelegate _next;

        public VendorMiddleware(RequestDelegate next, ISmsVendorSelector selector, IConfiguration configuration)
        {
            _next = next;
            _selector = selector;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var vendor = _selector.Select(context);

            _configuration.

            // Pass the request to the next delegate in the pipeline
            await _next(context);
        }

    }
}
