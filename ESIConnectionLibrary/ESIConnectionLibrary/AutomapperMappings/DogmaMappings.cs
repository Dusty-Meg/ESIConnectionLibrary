using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class DogmaMappings : Profile
    {
        public DogmaMappings()
        {
            CreateMap<EsiV1DogmaAttribute, V1DogmaAttribute>();
            CreateMap<EsiV1DogmaDynamicItem, V1DogmaDynamicItem>();
            CreateMap<EsiV1DogmaDynamicItemAttribute, V1DogmaDynamicItemAttribute>();
            CreateMap<EsiV1DogmaDynamicItemEffect, V1DogmaDynamicItemEffect>();
            CreateMap<EsiV2DogmaEffect, V2DogmaEffect>();
            CreateMap<EsiV2DogmaEffectModifiers, V2DogmaEffectModifiers>();
        }
    }
}
