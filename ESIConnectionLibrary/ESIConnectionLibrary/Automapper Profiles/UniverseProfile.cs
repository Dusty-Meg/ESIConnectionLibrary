using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class UniverseProfile : Profile
    {
        public UniverseProfile()
        {
            CreateMap<EsiV3UniverseType, V3UniverseType>();
            CreateMap<EsiV3UniverseTypeDogmaAttribute, V3UniverseTypeDogmaAttribute>();
            CreateMap<EsiV3UniverseTypeDogmaEffect, V3UniverseTypeDogmaEffect>();
            CreateMap<EsiV4UniverseSystem, V4UniverseSystem>();
            CreateMap<EsiV4UniverseSystemPlanets, V4UniverseSystemPlanets>();
            CreateMap<EsiV2UniverseSystemKills, V2UniverseSystemKills>();
            CreateMap<EsiV1UniverseSystemJumps, V1UniverseSystemJumps>();
            CreateMap<EsiV2UniverseStructure, V2UniverseStructure>();
            CreateMap<EsiPosition, Position>();
            CreateMap<EsiV2UniverseStation, V2UniverseStation>();
            CreateMap<EsiV1UniverseStar, V1UniverseStar>();
            CreateMap<EsiV1UniverseStargate, V1UniverseStargate>();
            CreateMap<EsiV1UniverseStargateDestination, V1UniverseStargateDestination>();
            CreateMap<EsiV1UniverseRegion, V1UniverseRegion>();
            CreateMap<EsiV1UniverseRaces, V1UniverseRaces>();
            CreateMap<EsiV1UniversePlanet, V1UniversePlanet>();
            CreateMap<EsiV3UniverseNames, V3UniverseNames>();
            CreateMap<EsiV1UniverseMoon, V1UniverseMoon>();
            CreateMap<EsiV1UniverseNamesToIds, V1UniverseNamesToIds>();
            CreateMap<EsiV1UniverseIds, V1UniverseIds>();
            CreateMap<EsiV1UniverseGroup, V1UniverseGroup>();
            CreateMap<EsiV1UniverseGraphic, V1UniverseGraphic>();
            CreateMap<EsiV2UniverseFactions, V2UniverseFactions>();
            CreateMap<EsiV1UniverseConstellation, V1UniverseConstellation>();
            CreateMap<EsiV1UniverseCategory, V1UniverseCategory>();
            CreateMap<EsiV1UniverseBloodlines, V1UniverseBloodlines>();
            CreateMap<EsiV1UniverseAsteroidBelt, V1UniverseAsteroidBelt>();
            CreateMap<EsiV1UniverseAncestries, V1UniverseAncestries>();
        }
    }
}
