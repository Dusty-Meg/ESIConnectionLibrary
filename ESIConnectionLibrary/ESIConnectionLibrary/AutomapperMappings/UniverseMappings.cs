using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class UniverseMappings : Profile
    {
        public UniverseMappings()
        {
            CreateMap<EsiV2UniverseNames, V2UniverseNames>();
            CreateMap<EsiV3UniverseType, V3UniverseType>();
            CreateMap<EsiV1UniverseAncestries, V1UniverseAncestries>();
            CreateMap<EsiV3UniverseTypeDogmaAttribute, V3UniverseTypeDogmaAttribute>();
            CreateMap<EsiV3UniverseTypeDogmaEffect, V3UniverseTypeDogmaEffect>();
            CreateMap<EsiV3UniverseSystemPlanets, V3UniverseSystemPlanets>();
            CreateMap<EsiV4UniverseSystem, V4UniverseSystem>();
            CreateMap<EsiV2UniverseSystemKills, V2UniverseSystemKills>();
            CreateMap<EsiV2UniverseStation, V2UniverseStation>();
            CreateMap<EsiV2UniverseFactions, V2UniverseFactions>();
            CreateMap<EsiV1UniverseSystemJumps, V1UniverseSystemJumps>();
            CreateMap<EsiV2UniverseStructure, V2UniverseStructure>();
            CreateMap<EsiV1UniverseStargateDestination, V1UniverseStargateDestination>();
            CreateMap<EsiV1UniverseStargate, V1UniverseStargate>();
            CreateMap<EsiV1UniverseStar, V1UniverseStar>();
            CreateMap<EsiV1UniverseRegion, V1UniverseRegion>();
            CreateMap<EsiV1UniverseRaces, V1UniverseRaces>();
            CreateMap<EsiV1UniversePlanet, V1UniversePlanet>();
            CreateMap<EsiV1UniverseNamesToIds, V1UniverseNamesToIds>();
            CreateMap<EsiV1UniverseMoon, V1UniverseMoon>();
            CreateMap<EsiV1UniverseIds, V1UniverseIds>();
            CreateMap<EsiV1UniverseGroup, V1UniverseGroup>();
            CreateMap<EsiV1UniverseGraphic, V1UniverseGraphic>();
            CreateMap<EsiV1UniverseConstellation, V1UniverseConstellation>();
            CreateMap<EsiV1UniverseCategory, V1UniverseCategory>();
            CreateMap<EsiV1UniverseBloodlines, V1UniverseBloodlines>();
            CreateMap<EsiV1UniverseAsteroidBelt, V1UniverseAsteroidBelt>();
        }
    }
}
