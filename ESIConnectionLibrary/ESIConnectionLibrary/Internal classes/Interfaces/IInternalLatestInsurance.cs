using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestInsurance
    {
        IList<V1InsuranceShipPrices> GetInsurancePrices();
        Task<IList<V1InsuranceShipPrices>> GetInsurancePricesAsync();
    }
}