using Database.AppContext;
using Domain.DataTransferObjects;
using SmsVendors;
using SmsVendors.Contracts;
using System;
using System.Text;
using System.Text.Json;

namespace API.Middleware
{
    public class PhoneNumberParser : IPhoneNumberParser
    {
        private Dictionary<string, Country> countryNumbers = new()
        {
            {"+30", Country.GR},
            {"+357", Country.CY},
        };


        public async Task<Country> GetCountry(HttpContext context)
        {
            var dto = await ReadRequestBody(context.Request.Body);

            string countryTelCode;

            for (int i = 2; i <= 4; i++)
            {
                countryTelCode = dto.Number.Substring(0, i);

                if (countryNumbers.ContainsKey(countryTelCode))
                    return countryNumbers[countryTelCode];
            }

            return default(Country); // Avoid adding a value to the enum with zero value.
        }

        private async Task<SmsDto> ReadRequestBody(Stream body)
        {
            // Leave the body open so the next middleware can read it.
            using (var reader = new StreamReader(
                body,
                encoding: Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                leaveOpen: true))
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
