using SmsVendors.Contracts;

namespace SmsVendors.Factory
{
    public class SmsVendorFactory : ISmsVendorFactory
    {
        private readonly Dictionary<Country, ISmsVendor> _vendorList;
        private readonly IServiceProvider _serviceProvider;

        public SmsVendorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _vendorList = new Dictionary<Country, ISmsVendor>();

            AddVendor<ISmsVendorRest>(Country.Rest);
            AddVendor<ISmsVendorGR>(Country.GR);
            AddVendor<ISmsVendorCY>(Country.CY);
        }


        public ISmsVendor Create(Country country)
        {
            return _vendorList.ContainsKey(country) ? _vendorList[country] : _vendorList[Country.Rest];
        }


        private T GetVendor<T>() where T : ISmsVendor
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }


        private void AddVendor<T>(Country country) where T : ISmsVendor
        {
            _vendorList.Add(country, GetVendor<T>());
        }


    }
}
