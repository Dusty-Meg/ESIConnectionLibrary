using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class BookmarksProfile : Profile
    {
        public BookmarksProfile()
        {
            CreateMap<EsiV2BookmarksCharacter, V2BookmarksCharacter>();
            CreateMap<EsiV2BookmarksCharacterItem, V2BookmarksCharacterItem>();
            CreateMap<EsiPosition, Position>();
            CreateMap<EsiV2BookmarksCharacterFolder, V2BookmarksCharacterFolder>();
            CreateMap<EsiV1BookmarksCorporation, V1BookmarksCorporation>();
            CreateMap<EsiV1BookmarksCorporationFolder, V1BookmarksCorporationFolder>();
            CreateMap<EsiV1BookmarksCorporationItem, V1BookmarksCorporationItem>();
        }
    }
}
