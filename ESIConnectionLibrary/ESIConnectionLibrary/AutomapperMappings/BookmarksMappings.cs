using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class BookmarksMappings : Profile
    {
        public BookmarksMappings()
        {
            CreateMap<EsiV2BookmarksCharacter, V2BookmarksCharacter>();
            CreateMap<EsiV2BookmarksCharacterItem, V2BookmarksCharacterItem>();
            CreateMap<EsiV2BookmarksCharacterFolder, V2BookmarksCharacterFolder>();
            CreateMap<EsiV1BookmarksCorporation, V1BookmarksCorporation>();
            CreateMap<EsiV1BookmarksCorporationItem, V1BookmarksCorporationItem>();
            CreateMap<EsiV1BookmarksCorporationFolder, V1BookmarksCorporationFolder>();
        }
    }
}
