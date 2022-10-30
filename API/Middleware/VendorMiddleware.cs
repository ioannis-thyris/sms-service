using DataTransferObjects;
using SmsVendors;
using SmsVendors.Contracts;
using SmsVendors.Factory;
using System.Text;
using System.Text.Json;

namespace API.Middleware
{
    public class VendorMiddleware
    {
        private Dictionary<string, Country> countryNumbers = new()
        {
            {"+30", Country.GR},
            {"+357", Country.CY},
        };

        private readonly RequestDelegate _next;

        public VendorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ISmsVendorFactory factory)
        {
            context.Request.EnableBuffering();

            var country = await GetCountry(context);

            var vendor = factory.Create(country);

            context.Items["Vendor"] = vendor;

            // Pass the request to the next delegate in the pipeline
            await _next(context);
        }



        private async Task<Country> GetCountry(HttpContext context)
        {
            var dto = await ReadRequestBody(context.Request.Body);
            string countryTelCode;

            for (int i = 2; i <= 4; i++)
            {
                countryTelCode = dto.Number.Substring(0, i);

                if (countryNumbers.ContainsKey(countryTelCode))
                    return countryNumbers[countryTelCode];
            }

            return Country.Rest; // Avoid adding a value to the enum with zero value.
        }

        private async Task<SmsDto> ReadRequestBody(Stream body)
        {
            // Leave the body open so the next middleware can read it.
            using (var reader = new StreamReader(body, leaveOpen: true))
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var dto = await JsonSerializer.DeserializeAsync<SmsDto>(body, options);

                // Reset the request body stream position so the next middleware can read it
                body.Position = 0;

                return dto;
            }
        }


    }
}
