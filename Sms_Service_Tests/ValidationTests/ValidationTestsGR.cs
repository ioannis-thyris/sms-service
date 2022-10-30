using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using FluentValidation;
using FluentValidation.TestHelper;
using SmsVendors.Vendors.CY;
using SmsVendors.Vendors.GR;
using SmsVendors.Vendors.Rest;

namespace Sms_Service_Tests.ValidationTests
{
    public class ValidationTestsGR
    {
        private SmsValidatorGR validatorGR = new();

        [Fact]
        public void ShouldHaveError_When_TextIsEmpty()
        {
            // Arrange
            var smsDto = new SmsDto() { Text = "", Number = "+129298287743" };

            // Act
            var result = validatorGR.TestValidate(smsDto);

            // Assert
            result.ShouldHaveValidationErrorFor(dto => dto.Text);
        }

        [Fact]
        public void ShouldHaveError_When_TextNotInGreek()
        {
            // Arrange
            var smsDto = new SmsDto() { Text = "Hello there!", Number = "+305454545454" };

            // Act
            var result = validatorGR.TestValidate(smsDto);

            // Assert
            result.ShouldHaveValidationErrorFor(dto => dto.Text);
        }

        [Fact]
        public void ShouldNotHaveError_When_TextInGreek()
        {
            // Arrange
            var smsDto = new SmsDto() { Text = "Τι κάνουμε;", Number = "+305454545454" };

            // Act
            var result = validatorGR.TestValidate(smsDto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(dto => dto.Text);
        }


        [Fact]
        public void ShouldHaveError_When_NumberLessThanSevenDigits()
        {
            // Arrange
            var smsDto = new SmsDto() { Text = "Τι κάνουμε;", Number = "+3054" };

            // Act
            var result = validatorGR.TestValidate(smsDto);

            // Assert
            result.ShouldHaveValidationErrorFor(dto => dto.Number);
        }

        [Fact]
        public void ShouldHaveError_When_NumberMoreThanThirteenDigits()
        {
            // Arrange
            var smsDto = new SmsDto() { Text = "Τι κάνουμε;", Number = "+3069462398981" };

            // Act
            var result = validatorGR.TestValidate(smsDto);

            // Assert
            result.ShouldHaveValidationErrorFor(dto => dto.Number);
        }

        [Fact]
        public void ShouldHaveError_When_NumberNotInE164Format()
        {
            // Arrange
            var smsDto = new SmsDto() { Text = "Τι κάνουμε;", Number = "302241075905" };

            // Act
            var result = validatorGR.TestValidate(smsDto);

            // Assert
            result.ShouldHaveValidationErrorFor(dto => dto.Number);
        }

        [Fact]
        public void ShouldHaveError_When_NumberNotWithGreekCode()
        {
            // Arrange
            var smsDto = new SmsDto() { Text = "Τι κάνουμε;", Number = "+357258754454" };

            // Act
            var result = validatorGR.TestValidate(smsDto);

            // Assert
            result.ShouldHaveValidationErrorFor(dto => dto.Number);
        }

        [Fact]
        public void ShouldNotHaveError_When_NumberIsValidGreekNumber()
        {
            // Arrange
            var smsDto = new SmsDto() { Text = "Τι κάνουμε;", Number = "+306946239898" };

            // Act
            var result = validatorGR.TestValidate(smsDto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(dto => dto.Number);
        }

    }
}
