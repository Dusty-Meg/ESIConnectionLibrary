using System.Collections.Generic;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalInsurance
    {
        IList<InsuranceShipPrices> GetInsurancePrices();
    }
}