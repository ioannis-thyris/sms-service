using DataAccessLayer;
using Database.AppContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmsVendors;
using SmsVendors.Contracts;
using SmsVendors.Factory;
using SmsVendors.Vendors.CY;
using SmsVendors.Vendors.GR;
using SmsVendors.Vendors.Rest;

namespace Sms_Service_Tests
{
    // This class should be configured with the TestingWebAppFactory as well.
    public class VendorFactoryTests : IClassFixture<DependencySetupFixture>
    {
        private readonly ISmsVendorFactory _factory;

        public VendorFactoryTests(DependencySetupFixture fixture)
        {
            _factory = new SmsVendorFactory(fixture.ServiceProvider);
        }

        [Fact]
        public void ShouldReturnVendorGR_ForCountryGR()
        {
            // Arrange
            var gr = Country.GR;

            // Act
            var vendor = _factory.Create(gr);

            // Assert
            Assert.IsType<SmsVendorGR>(vendor);
        }

        [Fact]
        public void ShouldReturnVendorCY_ForCountryCY()
        {
            // Arrange
            var cy = Country.CY;

            // Act
            var vendor = _factory.Create(cy);

            // Assert
            Assert.IsType<SmsVendorCY>(vendor);
        }

        [Fact]
        public void ShouldReturnVendorRest_ForCountryRest()
        {
            // Arrange
            var rest = Country.Rest;

            // Act
            var vendor = _factory.Create(rest);

            // Assert
            Assert.IsType<SmsVendorRest>(vendor);
        }

        [Fact]
        public void ShouldReturnVendorRest_ForOtherCountry()
        {
            // Arrange
            var other = (Country)5000;

            // Act
            var vendor = _factory.Create(other);

            // Assert
            Assert.IsType<SmsVendorRest>(vendor);
        }
    }

    public class DependencySetupFixture
    {

        public DependencySetupFixture()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<ISmsValidatorGR, SmsValidatorGR>();
            serviceCollection.AddScoped<ISmsValidatorCY, SmsValidatorCY>();
            serviceCollection.AddScoped<ISmsValidatorRest, SmsValidatorRest>();

            serviceCollection.AddDbContext<Context>(options =>
                                            options.UseInMemoryDatabase("Test")
                                        );

            serviceCollection.AddScoped<ISmsRepository, SmsRepository>();
            serviceCollection.AddScoped<ISmsVendorGR, SmsVendorGR>();
            serviceCollection.AddScoped<ISmsVendorCY, SmsVendorCY>();
            serviceCollection.AddScoped<ISmsVendorRest, SmsVendorRest>();
            serviceCollection.AddScoped<ISmsVendorFactory>(provider => new SmsVendorFactory(provider));
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }

}
