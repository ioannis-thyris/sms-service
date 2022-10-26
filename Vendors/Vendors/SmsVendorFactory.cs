using SmsVendors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsVendors.Vendors
{
    public class SmsVendorFactory : ISmsVendorFactory
    {
        private readonly Dictionary<string, ISmsVendor> _vendorList;
        private readonly IServiceProvider _serviceProvider;
        private readonly ISmsVendorRest smsVendorRest;

        public SmsVendorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            smsVendorRest = GetVendor<ISmsVendorRest>();

            _vendorList = new Dictionary<string, ISmsVendor>();

            AddVendor<ISmsVendorGR>("GR");
            AddVendor<ISmsVendorCY>("CY");
        }


        public ISmsVendor Create(string countryCode)
        {
            return _vendorList.ContainsKey(countryCode) ? _vendorList[countryCode] : smsVendorRest;
        }


        private T GetVendor<T>() where T : ISmsVendor
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }


        private void AddVendor<T>(string countryCode) where T : ISmsVendor
        {
            _vendorList.Add(countryCode, GetVendor<T>());
        }


    }
}
