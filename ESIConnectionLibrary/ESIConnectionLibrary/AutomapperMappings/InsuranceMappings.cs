using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class InsuranceShipPricesMappings : Profile
    {
        public InsuranceShipPricesMappings()
        {
            CreateMap<EsiV1InsuranceShipPrices, V1InsuranceShipPrices>();
        }
    }

    internal class InsuranceShipPriceLevelsMappings : Profile
    {
        public InsuranceShipPriceLevelsMappings()
        {
            CreateMap<EsiV1InsuranceShipPriceLevels, V1InsuranceShipPriceLevels>();
        }
    }
}
