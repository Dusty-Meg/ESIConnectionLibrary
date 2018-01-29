using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class UniverseNamesMappings : Profile
    {
        public UniverseNamesMappings()
        {
            CreateMap<EsiV2UniverseNames, V2UniverseNames>();
        }
    }

    internal class UniverseGetTypeMappings : Profile
    {
        public UniverseGetTypeMappings()
        {
            CreateMap<EsiV3UniverseGetType, V3UniverseGetType>();
        }
    }

    internal class UniverseGetTypeDogmaAttributeMappings : Profile
    {
        public UniverseGetTypeDogmaAttributeMappings()
        {
            CreateMap<EsiV3UniverseGetTypeDogmaAttribute, V3UniverseGetTypeDogmaAttribute>();
        }
    }

    internal class UniverseGetTypeDogmaEffectMappings : Profile
    {
        public UniverseGetTypeDogmaEffectMappings()
        {
            CreateMap<EsiV3UniverseGetTypeDogmaEffect, V3UniverseGetTypeDogmaEffect>();
        }
    }
}
