using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestInsuranceEndpoints : ILatestInsuranceEndpoints
    {
        private readonly IInternalLatestInsurance _internalLatestInsurance;

        public LatestInsuranceEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestInsurance = new InternalLatestInsurance(null, userAgent, testing);
        }

        public IList<V1InsuranceInsurance> Insurance()
        {
            return _internalLatestInsurance.Insurance();
        }

        public async Task<IList<V1InsuranceInsurance>> InsuranceAsync()
        {
            return await _internalLatestInsurance.InsuranceAsync();
        }
    }
}
