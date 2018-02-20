using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class AssetsMappings : Profile
    {
        public AssetsMappings()
        {
            CreateMap<EsiV1GetCharactersAssetsNames, V1GetCharactersAssetsNames>();
            CreateMap<EsiV1GetCorporationsAssetsNames, V1GetCorporationsAssetsNames>();
            CreateMap<EsiV2GetCharactersAssetsLocations, V2GetCharactersAssetsLocations>();
            CreateMap<EsiV2GetCorporationsAssets, V2GetCorporationsAssets>();
            CreateMap<EsiV2GetCorporationsAssetsLocations, V2GetCorporationsAssetsLocations>();
            CreateMap<EsiV3GetCharacterAssets, V3GetCharacterAssets>();
        }
    }
}
