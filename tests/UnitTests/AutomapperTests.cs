using AutoMapper;
using DataTransferObjects;

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

    }
}
