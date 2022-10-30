using DataTransferObjects;
using FluentValidation.TestHelper;
using SmsVendors.Vendors.CY;
using SmsVendors.Vendors.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms_Service_Tests.ValidationTests
{
    public class ValidationTestsRest
    {
        private SmsValidatorRest validatorRest = new();

        [Fact]
        public void ShouldHaveError_When_TextIsEmpty()
        {
            // Arrange
            var smsDto = new SmsDto() { Text = "", Number = "+129298287743" };

            // Act
            var result = validatorRest.TestValidate(smsDto);

            // Assert
            result.ShouldHaveValidationErrorFor(dto => dto.Text);
        }

        [Fact]
        public void ShouldHaveError_When_NumberLessThanSevenDigits()
        {
            // Arrange
            var smsDto = new SmsDto() { Text = "Hello there!", Number = "+4454" };

            // Act
            var result = validatorRest.TestValidate(smsDto);

            // Assert
            result.ShouldHaveValidationErrorFor(dto => dto.Number);
        }

        [Fact]
        public void ShouldHaveError_When_NumberMoreThanFifteenDigits()
        {
            // Arrange
            var smsDto = new SmsDto() { Text = "Hello there!", Number = "+4422410768054545" };

            // Act
            var result = validatorRest.TestValidate(smsDto);

            // Assert
            result.ShouldHaveValidationErrorFor(dto => dto.Number);
        }

        [Fact]
        public void ShouldHaveError_When_NumberNotInE164Format()
        {
            // Arrange
            var smsDto = new SmsDto() { Text = "Hello there!", Number = "442241075905" };

            // Act
            var result = validatorRest.TestValidate(smsDto);

            // Assert
            result.ShouldHaveValidationErrorFor(dto => dto.Number);
        }
    }
}
