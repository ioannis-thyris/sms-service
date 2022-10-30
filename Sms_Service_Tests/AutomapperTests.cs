using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataTransferObjects;
using Domain.Models;

namespace Sms_Service_Tests
{
    public class AutomapperTests
    {
        public MapperConfiguration configuration = new MapperConfiguration(cfg => cfg.AddProfile<SmsProfile>());

        private IMapper _mapper;

        public AutomapperTests()
        {
            _mapper = configuration.CreateMapper();
        }

        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            configuration.AssertConfigurationIsValid();
        }


        [Fact]
        public SmsDto Map_SmsToDto_ReturnsTrue()
        {
            // Arrage
            Sms sms = new Sms() { Number = "+30224107775", Text = "Pizza", DateSent = DateTime.Now };

            // Act
            return _mapper.Map<Sms, SmsDto>(sms);

            // Assert

            //Assert.Equal(dto, new SmsDto { Number = "+30224107775", Text = "Pizza" });
        }

    }
}
