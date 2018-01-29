using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class UniverseNamesMappings : Profile
    {
        public UniverseNamesMappings()
        {
            CreateMap<EsiUniverseNames, UniverseNames>();
        }
    }

    internal class UniverseGetTypeMappings : Profile
    {
        public UniverseGetTypeMappings()
        {
            CreateMap<EsiUniverseGetType, UniverseGetType>();
        }
    }

    internal class UniverseGetTypeDogmaAttributeMappings : Profile
    {
        public UniverseGetTypeDogmaAttributeMappings()
        {
            CreateMap<EsiUniverseGetTypeDogmaAttribute, UniverseGetTypeDogmaAttribute>();
        }
    }

    internal class UniverseGetTypeDogmaEffectMappings : Profile
    {
        public UniverseGetTypeDogmaEffectMappings()
        {
            CreateMap<EsiUniverseGetTypeDogmaEffect, UniverseGetTypeDogmaEffect>();
        }
    }
}
