using DataAccessLayer;
using DataTransferObjects;
using Domain.Models;
using FluentValidation;
using Moq;
using SmsVendors.Contracts;
using SmsVendors.Vendors;
using SmsVendors.Vendors.CY;
using SmsVendors.Vendors.GR;
using SmsVendors.Vendors.Rest;
using System;
using System.Text;
using Xunit.Sdk;

namespace Sms_Service_Tests
{
    public class VendorTests
    {
        private static Mock<ISmsRepository> _mockRepo;
        private static Mock<ISmsRepository> MockRepo
        {
            get
            {
                _mockRepo = new();
                _mockRepo.Setup(repo => repo.Create(It.IsAny<Sms>()))
                         .ReturnsAsync(true);

                return _mockRepo;
            }
        }

        private static Mock<ISmsValidatorGR> ValidatorGR => new();
        private static Mock<ISmsValidatorCY> ValidatorCY => new();
        private static Mock<ISmsValidatorRest> ValidatorRest => new();

        public static IEnumerable<object[]> VendorList =>
        new List<object[]>
        {
                new object[] { new SmsVendorGR(MockRepo.Object, ValidatorGR.Object) },
                new object[] { new SmsVendorCY(MockRepo.Object, ValidatorCY.Object) },
                new object[] { new SmsVendorRest(MockRepo.Object, ValidatorRest.Object) },
        };


        private Sms sms;
        private string _shortText = "Hello there!";
        private string _longText;

        public VendorTests()
        {
            StringBuilder sb = new();

            for (int i = 0; i < 1000; i++)
            {
                sb.Append("c");
            }

            _longText = sb.ToString();
        }



        [Theory]
        [MemberData(nameof(VendorList))]
        public async Task SendsOneMessage_When_MessageTextLessThanMaxChars(SmsVendorBase vendor)
        {
            // Arrange
            sms = new() { Text = _shortText, Number = "+306946235952", DateSent = DateTime.Now };

            // Act
            var sendResult = await vendor.Send(sms);

            // Assert
            Assert.True(sendResult.Successful);
            Assert.Equal(1, sendResult.MessagesSent);
        }

        [Theory]
        [MemberData(nameof(VendorList))]
        public async Task SendsMultipleMessages_When_MessageTextMoreThanMaxChars(SmsVendorBase vendor)
        {
            // Arrange
            sms = new() { Text = _longText, Number = "+306946235952", DateSent = DateTime.Now };

            // Act
            var sendResult = await vendor.Send(sms);

            // Assert
            int smsNumberToSend = (int)Math.Ceiling((double)sms.Text.Length / vendor.MaxChars);

            Assert.True(sendResult.Successful);
            Assert.Equal(smsNumberToSend, sendResult.MessagesSent);
        }



    }
}
