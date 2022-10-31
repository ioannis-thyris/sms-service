using DataTransferObjects;
using System.Net.Http.Json;

namespace IntegrationTests
{
    public class SendSmsTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;

        public SendSmsTests(TestingWebAppFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async void ShouldReturnSuccess_When_SendingAValidSms()
        {
            // Arrange
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/sms");

            var dto = new SmsDto() { Text = "Hi there!", Number = "+1652589852" };

            postRequest.Content = JsonContent.Create(dto);

            // Act
            var response = await _client.SendAsync(postRequest);

            // Assert
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("The message was sent successfully.", responseString);
        }

        [Fact]
        public async void ShouldReturnValidationErrorOfVendorGR_When_SendingAnInvalidSmsToGreekNumber()
        {
            // Arrange
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/sms");

            var dto = new SmsDto() { Text = "Hi there!", Number = "+302241075333" };

            postRequest.Content = JsonContent.Create(dto);

            // Act
            var response = await _client.SendAsync(postRequest);

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("Greek", responseString);
        }

        [Fact]
        public async void ShouldReturnValidationErrorOfVendorCY_When_SendingAnInvalidSmsToCypriotNumber()
        {
            // Arrange
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/sms");

            var dto = new SmsDto() { Text = "Hi there!", Number = "+3579958631" };

            postRequest.Content = JsonContent.Create(dto);

            // Act
            var response = await _client.SendAsync(postRequest);

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("not a valid CY number", responseString);
        }



    }
}
