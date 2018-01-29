using System.Collections.Generic;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestInsurance
    {
        IList<V1InsuranceShipPrices> GetInsurancePrices();
    }
}