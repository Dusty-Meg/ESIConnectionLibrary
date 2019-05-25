using System.Threading.Tasks;
using ESIConnectionLibrary.Exceptions;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestBookmarksEndpoints : ILatestBookmarksEndpoints
    {
        private readonly IInternalLatestBookmarks _internalLatestBookmarks;

        public LatestBookmarksEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestBookmarks = new InternalLatestBookmarks(null, userAgent, testing);
        }

        public PagedModel<V2BookmarksCharacter> CharacterBookmarks(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestBookmarks.CharacterBookmarks(token, page);
        }

        public async Task<PagedModel<V2BookmarksCharacter>> CharacterBookmarksAsync(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestBookmarks.CharacterBookmarksAsync(token, page);
        }

        public PagedModel<V2BookmarksCharacterFolder> CharacterBookmarkFolders(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestBookmarks.CharacterBookmarkFolders(token, page);
        }

        public async Task<PagedModel<V2BookmarksCharacterFolder>> CharacterBookmarkFoldersAsync(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestBookmarks.CharacterBookmarkFoldersAsync(token, page);
        }

        public PagedModel<V1BookmarksCorporation> CorporationBookmarks(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestBookmarks.CorporationBookmarks(token, corporationId, page);
        }

        public async Task<PagedModel<V1BookmarksCorporation>> CorporationBookmarksAsync(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestBookmarks.CorporationBookmarksAsync(token, corporationId, page);
        }

        public PagedModel<V1BookmarksCorporationFolder> CorporationBookmarkFolders(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestBookmarks.CorporationBookmarkFolders(token, corporationId, page);
        }

        public async Task<PagedModel<V1BookmarksCorporationFolder>> CorporationBookmarkFoldersAsync(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestBookmarks.CorporationBookmarkFoldersAsync(token, corporationId, page);
        }
    }
}
