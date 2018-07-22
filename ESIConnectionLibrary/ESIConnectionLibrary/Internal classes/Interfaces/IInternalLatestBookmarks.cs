using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestBookmarks
    {
        PagedModel<V2BookmarksCharacterFolder> CharacterBookmarkFolders(SsoToken token, int page);
        Task<PagedModel<V2BookmarksCharacterFolder>> CharacterBookmarkFoldersAsync(SsoToken token, int page);
        PagedModel<V2BookmarksCharacter> CharacterBookmarks(SsoToken token, int page);
        Task<PagedModel<V2BookmarksCharacter>> CharacterBookmarksAsync(SsoToken token, int page);
        PagedModel<V1BookmarksCorporationFolder> CorporationBookmarkFolders(SsoToken token, int corporationId, int page);
        Task<PagedModel<V1BookmarksCorporationFolder>> CorporationBookmarkFoldersAsync(SsoToken token, int corporationId, int page);
        PagedModel<V1BookmarksCorporation> CorporationBookmarks(SsoToken token, int corporationId, int page);
        Task<PagedModel<V1BookmarksCorporation>> CorporationBookmarksAsync(SsoToken token, int corporationId, int page);
    }
}