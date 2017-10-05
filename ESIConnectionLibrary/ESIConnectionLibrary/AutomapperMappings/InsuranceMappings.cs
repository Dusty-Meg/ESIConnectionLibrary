using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class InsuranceShipPricesMappings : Profile
    {
        public InsuranceShipPricesMappings()
        {
            CreateMap<EsiInsuranceShipPrices, InsuranceShipPrices>()
                .ForMember(x => x.TypeId, m => m.MapFrom(a => a.type_id))
                .ForMember(x => x.Levels, m => m.MapFrom(a => a.levels))
                ;
        }
    }

    internal class InsuranceShipPriceLevelsMappings : Profile
    {
        public InsuranceShipPriceLevelsMappings()
        {
            CreateMap<EsiInsuranceShipPriceLevels, InsuranceShipPriceLevels>()
                .ForMember(x => x.Cost, m => m.MapFrom(a => a.cost))
                .ForMember(x => x.Name, m => m.MapFrom(a => a.name))
                .ForMember(x => x.Payout, m => m.MapFrom(a => a.payout))
                ;
        }
    }
}
