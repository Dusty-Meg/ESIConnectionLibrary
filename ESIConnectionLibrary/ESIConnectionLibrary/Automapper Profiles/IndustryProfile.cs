using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class IndustryProfile : Profile
    {
        public IndustryProfile()
        {
            CreateMap<EsiV1IndustrySystem, V1IndustrySystem>();
            CreateMap<EsiV1IndustrySystemCostIndices, V1IndustrySystemCostIndices>();
            CreateMap<EsiV1IndustryFacility, V1IndustryFacility>();
            CreateMap<EsiV1IndustryCorporation, V1IndustryCorporation>();
            CreateMap<EsiV1IndustryCorporationObserver, V1IndustryCorporationObserver>();
            CreateMap<EsiV1IndustryCorporationObservers, V1IndustryCorporationObservers>();
            CreateMap<EsiV1IndustryCorporationExtractions, V1IndustryCorporationExtractions>();
            CreateMap<EsiV1IndustryCharacterMining, V1IndustryCharacterMining>();
            CreateMap<EsiV1IndustryCharacter, V1IndustryCharacter>();
        }
    }
}
