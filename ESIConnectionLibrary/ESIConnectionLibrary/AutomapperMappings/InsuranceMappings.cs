using AutoMapper;
using ESIConnectionLibrary.ESIModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class InsuranceShipPricesMappings : Profile
    {
        public InsuranceShipPricesMappings()
        {
            CreateMap<EsiInsuranceShipPrices, EsiInsuranceShipPrices>()
                .ForMember(x => x.type_id, m => m.MapFrom(a => a.type_id))
                .ForMember(x => x.levels, m => m.MapFrom(a => a.levels))
                ;
        }
    }

    internal class InsuranceShipPriceLevelsMappings : Profile
    {
        public InsuranceShipPriceLevelsMappings()
        {
            CreateMap<EsiInsuranceShipPriceLevels, EsiInsuranceShipPriceLevels>()
                .ForMember(x => x.cost, m => m.MapFrom(a => a.cost))
                .ForMember(x => x.name, m => m.MapFrom(a => a.name))
                .ForMember(x => x.payout, m => m.MapFrom(a => a.payout))
                ;
        }
    }
}
