using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestInsuranceEndpoints
    {
        IList<V1InsuranceInsurance> Insurance();
        Task<IList<V1InsuranceInsurance>> InsuranceAsync();
    }
}