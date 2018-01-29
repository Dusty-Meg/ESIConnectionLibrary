using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class InsuranceShipPricesMappings : Profile
    {
        public InsuranceShipPricesMappings()
        {
            CreateMap<EsiInsuranceShipPrices, InsuranceShipPrices>();
        }
    }

    internal class InsuranceShipPriceLevelsMappings : Profile
    {
        public InsuranceShipPriceLevelsMappings()
        {
            CreateMap<EsiInsuranceShipPriceLevels, InsuranceShipPriceLevels>();
        }
    }
}
