using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class AssetsProfile : Profile
    {
        public AssetsProfile()
        {
            CreateMap<EsiV2AssetsCharacterLocation, V2AssetsCharacterLocation>();
            CreateMap<EsiPosition, Position>();
            CreateMap<EsiV5AssetsCharacter, V5AssetsCharacter>();
            CreateMap<EsiV1AssetsCharacterNames, V1AssetsCharacterName>();
            CreateMap<EsiV5AssetsCorporations, V5AssetsCorporations>();
            CreateMap<EsiV2AssetsCorporationLocation, V2AssetsCorporationLocation>();
            CreateMap<EsiV1AssetsCorporationName, V1AssetsCorporationName>();
        }
    }
}
