using SmsVendors.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsVendors.Factory
{
    public class SmsVendorFactory : ISmsVendorFactory
    {
        private readonly Dictionary<Country, ISmsVendor> _vendorList;
        private readonly IServiceProvider _serviceProvider;
        private readonly ISmsVendorRest smsVendorRest;

        public SmsVendorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            smsVendorRest = GetVendor<ISmsVendorRest>();

            _vendorList = new Dictionary<Country, ISmsVendor>();

            AddVendor<ISmsVendorGR>(Country.GR);
            AddVendor<ISmsVendorCY>(Country.CY);
        }


        public ISmsVendor Create(Country country)
        {
            return _vendorList.ContainsKey(country) ? _vendorList[country] : smsVendorRest;
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
