using DataTransferObjects;
using FluentValidation.TestHelper;
using SmsVendors.Vendors.CY;

namespace Sms_Service_Tests.ValidationTests
{
    public class ValidationTestsCY
    {
        private SmsValidatorCY validatorCY = new();

        [Fact]
        public void ShouldHaveError_When_TextIsEmpty()
        {
            // Arrange
            var smsDto = new SmsDto() { Text = "", Number = "+129298287743" };

            // Act
            var result = validatorCY.TestValidate(smsDto);

            // Assert
            result.ShouldHaveValidationErrorFor(dto => dto.Text);
        }

        [Fact]
        public void ShouldHaveError_When_NumberLessThanElevenDigits()
        {
            // Arrange
            var smsDto = new SmsDto() { Text = "Hello there!", Number = "+3579926587" };

            // Act
            var result = validatorCY.TestValidate(smsDto);

            // Assert
            result.ShouldHaveValidationErrorFor(dto => dto.Number);
        }

        [Fact]
        public void ShouldHaveError_When_NumberMoreThanElevenDigits()
        {
            // Arrange
            var smsDto = new SmsDto() { Text = "Hello there!", Number = "+357997660201" };

            // Act
            var result = validatorCY.TestValidate(smsDto);

            // Assert
            result.ShouldHaveValidationErrorFor(dto => dto.Number);
        }

        [Fact]
        public void ShouldHaveError_When_NumberNotInE164Format()
        {
            // Arrange
            var smsDto = new SmsDto() { Text = "Hello there!", Number = "302241075905" };

            // Act
            var result = validatorCY.TestValidate(smsDto);

            // Assert
            result.ShouldHaveValidationErrorFor(dto => dto.Number);
        }

        [Fact]
        public void ShouldHaveError_When_NumberNotWithCypriotCode()
        {
            // Arrange
            var smsDto = new SmsDto() { Text = "Hello there!", Number = "+3057258754454" };

            // Act
            var result = validatorCY.TestValidate(smsDto);

            // Assert
            result.ShouldHaveValidationErrorFor(dto => dto.Number);
        }

        [Fact]
        public void ShouldNotHaveError_When_NumberIsValidCypriotNumber()
        {
            // Arrange
            var smsDto = new SmsDto() { Text = "Τι κάνουμε;", Number = "+35799766020" };

            // Act
            var result = validatorCY.TestValidate(smsDto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(dto => dto.Number);
        }
    }
}
