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
            CreateMap<EsiV4AssetsCharacter, V4AssetsCharacter>();
            CreateMap<EsiV1AssetsCharacterNames, V1AssetsCharacterName>();
            CreateMap<EsiV4AssetsCorporations, V4AssetsCorporations>();
            CreateMap<EsiV2AssetsCorporationLocation, V2AssetsCorporationLocation>();
            CreateMap<EsiV1AssetsCorporationName, V1AssetsCorporationName>();
        }
    }
}
