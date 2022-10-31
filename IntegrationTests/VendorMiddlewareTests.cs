using DataTransferObjects;
using System.Net.Http.Json;

namespace IntegrationTests
{
    public class VendorMiddlewareTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;

        public VendorMiddlewareTests(TestingWebAppFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async void MyMethod()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/sms");

            var dto = new SmsDto() { Text = "Hi there!", Number = "+1652589852" };

            postRequest.Content = JsonContent.Create(dto);

            var response = await _client.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("Account number is required", responseString);

        }

    }
}
