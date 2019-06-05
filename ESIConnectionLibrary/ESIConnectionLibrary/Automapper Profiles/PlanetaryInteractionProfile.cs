using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class PlanetaryInteractionProfile : Profile
    {
        public PlanetaryInteractionProfile()
        {
            CreateMap<EsiV1PlanetaryInteractionCharactersPlanets, V1PlanetaryInteractionCharactersPlanets>();
            CreateMap<EsiV3PlanetaryInteractionCharactersPlanet, V3PlanetaryInteractionCharactersPlanet>();
            CreateMap<EsiV3PlanetaryInteractionCharactersPlanetLinks,
                V3PlanetaryInteractionCharactersPlanetLinks>();
            CreateMap<EsiV3PlanetaryInteractionCharactersPlanetPins,
                V3PlanetaryInteractionCharactersPlanetPins>();
            CreateMap<EsiV3PlanetaryInteractionCharactersPlanetPinsContent,
                V3PlanetaryInteractionCharactersPlanetPinsContent>();
            CreateMap<EsiV3PlanetaryInteractionCharactersPlanetPinsExtractorDetails,
                V3PlanetaryInteractionCharactersPlanetPinsExtractorDetails>();
            CreateMap<EsiV3PlanetaryInteractionCharactersPlanetPinsExtractorDetailsHeads,
                V3PlanetaryInteractionCharactersPlanetPinsExtractorDetailsHeads>();
            CreateMap<EsiV3PlanetaryInteractionCharactersPlanetPinsExtractorDetailsFactoryDetails,
                V3PlanetaryInteractionCharactersPlanetPinsExtractorDetailsFactoryDetails>();
            CreateMap<EsiV3PlanetaryInteractionCharactersPlanetRoutes,
                V3PlanetaryInteractionCharactersPlanetRoutes>();
            CreateMap<EsiV1PlanetaryInteractionCorporationCustomsOffice,
                V1PlanetaryInteractionCorporationCustomsOffice>();
            CreateMap<EsiV1PlanetaryInteractionSchematic, V1PlanetaryInteractionSchematic>();
        }
    }
}
