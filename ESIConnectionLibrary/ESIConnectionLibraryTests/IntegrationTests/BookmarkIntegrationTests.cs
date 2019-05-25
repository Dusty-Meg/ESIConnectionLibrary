using System;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class BookmarkIntegrationTests
    {
        [Fact]
        public void CharacterBookmarks_successully_returns_a_list_of_V2BookmarksCharacter()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            BookmarkScopes scopes = BookmarkScopes.esi_bookmarks_read_character_bookmarks_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, BookmarkScopesFlags = scopes };

            LatestBookmarksEndpoints internalLatestBookmarks = new LatestBookmarksEndpoints(string.Empty, true);

            PagedModel<V2BookmarksCharacter> returnModel = internalLatestBookmarks.CharacterBookmarks(inputToken, 1);

            Assert.Equal(2, returnModel.Model.Count);

            Assert.Equal(4, returnModel.Model[0].BookmarkId);
            Assert.Equal(new DateTime(2016, 08, 09, 11, 57, 47), returnModel.Model[0].Created);
            Assert.Equal(2112625428, returnModel.Model[0].CreatorId);
            Assert.Equal(5, returnModel.Model[0].FolderId);
            Assert.Equal(50006722, returnModel.Model[0].Item.ItemId);
            Assert.Equal(29633, returnModel.Model[0].Item.TypeId);
            Assert.Equal("Stargate", returnModel.Model[0].Label);
            Assert.Equal(30003430, returnModel.Model[0].LocationId);
            Assert.Equal("This is a stargate", returnModel.Model[0].Notes);

            Assert.Equal(5, returnModel.Model[1].BookmarkId);
            Assert.Equal(-2958928814000, returnModel.Model[1].Coordinates.X);
            Assert.Equal(-338367275823, returnModel.Model[1].Coordinates.Y);
            Assert.Equal(2114538075090, returnModel.Model[1].Coordinates.Z);
            Assert.Equal(new DateTime(2016, 08, 09, 11, 57, 47), returnModel.Model[1].Created);
            Assert.Equal(2112625428, returnModel.Model[1].CreatorId);
            Assert.Equal(5, returnModel.Model[1].FolderId);
            Assert.Equal("Random location", returnModel.Model[1].Label);
            Assert.Equal(30003430, returnModel.Model[1].LocationId);
            Assert.Equal("This is a random location in space", returnModel.Model[1].Notes);
        }

        [Fact]
        public async Task CharacterBookmarksAsync_successully_returns_a_list_of_V2BookmarksCharacter()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            BookmarkScopes scopes = BookmarkScopes.esi_bookmarks_read_character_bookmarks_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, BookmarkScopesFlags = scopes };

            LatestBookmarksEndpoints internalLatestBookmarks = new LatestBookmarksEndpoints(string.Empty, true);

            PagedModel<V2BookmarksCharacter> returnModel = await internalLatestBookmarks.CharacterBookmarksAsync(inputToken, 1);

            Assert.Equal(2, returnModel.Model.Count);

            Assert.Equal(4, returnModel.Model[0].BookmarkId);
            Assert.Equal(new DateTime(2016, 08, 09, 11, 57, 47), returnModel.Model[0].Created);
            Assert.Equal(2112625428, returnModel.Model[0].CreatorId);
            Assert.Equal(5, returnModel.Model[0].FolderId);
            Assert.Equal(50006722, returnModel.Model[0].Item.ItemId);
            Assert.Equal(29633, returnModel.Model[0].Item.TypeId);
            Assert.Equal("Stargate", returnModel.Model[0].Label);
            Assert.Equal(30003430, returnModel.Model[0].LocationId);
            Assert.Equal("This is a stargate", returnModel.Model[0].Notes);

            Assert.Equal(5, returnModel.Model[1].BookmarkId);
            Assert.Equal(-2958928814000, returnModel.Model[1].Coordinates.X);
            Assert.Equal(-338367275823, returnModel.Model[1].Coordinates.Y);
            Assert.Equal(2114538075090, returnModel.Model[1].Coordinates.Z);
            Assert.Equal(new DateTime(2016, 08, 09, 11, 57, 47), returnModel.Model[1].Created);
            Assert.Equal(2112625428, returnModel.Model[1].CreatorId);
            Assert.Equal(5, returnModel.Model[1].FolderId);
            Assert.Equal("Random location", returnModel.Model[1].Label);
            Assert.Equal(30003430, returnModel.Model[1].LocationId);
            Assert.Equal("This is a random location in space", returnModel.Model[1].Notes);
        }

        [Fact]
        public void CharacterBookmarkFolders_successully_returns_a_list_of_V2BookmarksCharacterFolder()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            BookmarkScopes scopes = BookmarkScopes.esi_bookmarks_read_character_bookmarks_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, BookmarkScopesFlags = scopes };

            LatestBookmarksEndpoints internalLatestBookmarks = new LatestBookmarksEndpoints(string.Empty, true);

            PagedModel<V2BookmarksCharacterFolder> returnModel = internalLatestBookmarks.CharacterBookmarkFolders(inputToken, 1);

            Assert.Single(returnModel.Model);

            Assert.Equal(5, returnModel.Model[0].FolderId);
            Assert.Equal("Icecream", returnModel.Model[0].Name);
        }

        [Fact]
        public async Task CharacterBookmarkFoldersAsync_successully_returns_a_list_of_V2BookmarksCharacterFolder()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            BookmarkScopes scopes = BookmarkScopes.esi_bookmarks_read_character_bookmarks_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, BookmarkScopesFlags = scopes };

            LatestBookmarksEndpoints internalLatestBookmarks = new LatestBookmarksEndpoints(string.Empty, true);

            PagedModel<V2BookmarksCharacterFolder> returnModel = await internalLatestBookmarks.CharacterBookmarkFoldersAsync(inputToken, 1);

            Assert.Single(returnModel.Model);

            Assert.Equal(5, returnModel.Model[0].FolderId);
            Assert.Equal("Icecream", returnModel.Model[0].Name);
        }

        [Fact]
        public void CorporationBookmarks_successully_returns_a_list_of_V1BookmarksCorporation()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            BookmarkScopes scopes = BookmarkScopes.esi_bookmarks_read_corporation_bookmarks_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, BookmarkScopesFlags = scopes };

            LatestBookmarksEndpoints internalLatestBookmarks = new LatestBookmarksEndpoints(string.Empty, true);

            PagedModel<V1BookmarksCorporation> returnModel = internalLatestBookmarks.CorporationBookmarks(inputToken, 22, 1);

            Assert.Equal(2, returnModel.Model.Count);

            Assert.Equal(4, returnModel.Model[0].BookmarkId);
            Assert.Equal(new DateTime(2016, 08, 09, 11, 57, 47), returnModel.Model[0].Created);
            Assert.Equal(2112625428, returnModel.Model[0].CreatorId);
            Assert.Equal(5, returnModel.Model[0].FolderId);
            Assert.Equal(50006722, returnModel.Model[0].Item.ItemId);
            Assert.Equal(29633, returnModel.Model[0].Item.TypeId);
            Assert.Equal("Stargate", returnModel.Model[0].Label);
            Assert.Equal(30003430, returnModel.Model[0].LocationId);
            Assert.Equal("This is a stargate", returnModel.Model[0].Notes);

            Assert.Equal(5, returnModel.Model[1].BookmarkId);
            Assert.Equal(-2958928814000, returnModel.Model[1].Coordinates.X);
            Assert.Equal(-338367275823, returnModel.Model[1].Coordinates.Y);
            Assert.Equal(2114538075090, returnModel.Model[1].Coordinates.Z);
            Assert.Equal(new DateTime(2016, 08, 09, 11, 57, 47), returnModel.Model[1].Created);
            Assert.Equal(2112625428, returnModel.Model[1].CreatorId);
            Assert.Equal(5, returnModel.Model[1].FolderId);
            Assert.Equal("Random location", returnModel.Model[1].Label);
            Assert.Equal(30003430, returnModel.Model[1].LocationId);
            Assert.Equal("This is a random location in space", returnModel.Model[1].Notes);
        }

        [Fact]
        public async Task CorporationBookmarksAsync_successully_returns_a_list_of_V1BookmarksCorporation()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            BookmarkScopes scopes = BookmarkScopes.esi_bookmarks_read_corporation_bookmarks_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, BookmarkScopesFlags = scopes };

            LatestBookmarksEndpoints internalLatestBookmarks = new LatestBookmarksEndpoints(string.Empty, true);

            PagedModel<V1BookmarksCorporation> returnModel = await internalLatestBookmarks.CorporationBookmarksAsync(inputToken, 22, 1);

            Assert.Equal(2, returnModel.Model.Count);

            Assert.Equal(4, returnModel.Model[0].BookmarkId);
            Assert.Equal(new DateTime(2016, 08, 09, 11, 57, 47), returnModel.Model[0].Created);
            Assert.Equal(2112625428, returnModel.Model[0].CreatorId);
            Assert.Equal(5, returnModel.Model[0].FolderId);
            Assert.Equal(50006722, returnModel.Model[0].Item.ItemId);
            Assert.Equal(29633, returnModel.Model[0].Item.TypeId);
            Assert.Equal("Stargate", returnModel.Model[0].Label);
            Assert.Equal(30003430, returnModel.Model[0].LocationId);
            Assert.Equal("This is a stargate", returnModel.Model[0].Notes);

            Assert.Equal(5, returnModel.Model[1].BookmarkId);
            Assert.Equal(-2958928814000, returnModel.Model[1].Coordinates.X);
            Assert.Equal(-338367275823, returnModel.Model[1].Coordinates.Y);
            Assert.Equal(2114538075090, returnModel.Model[1].Coordinates.Z);
            Assert.Equal(new DateTime(2016, 08, 09, 11, 57, 47), returnModel.Model[1].Created);
            Assert.Equal(2112625428, returnModel.Model[1].CreatorId);
            Assert.Equal(5, returnModel.Model[1].FolderId);
            Assert.Equal("Random location", returnModel.Model[1].Label);
            Assert.Equal(30003430, returnModel.Model[1].LocationId);
            Assert.Equal("This is a random location in space", returnModel.Model[1].Notes);
        }

        [Fact]
        public void CorporationBookmarkFolders_successully_returns_a_list_of_V1BookmarksCorporationFolder()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            BookmarkScopes scopes = BookmarkScopes.esi_bookmarks_read_corporation_bookmarks_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, BookmarkScopesFlags = scopes };

            LatestBookmarksEndpoints internalLatestBookmarks = new LatestBookmarksEndpoints(string.Empty, true);

            PagedModel<V1BookmarksCorporationFolder> returnModel = internalLatestBookmarks.CorporationBookmarkFolders(inputToken, 22, 1);

            Assert.Single(returnModel.Model);

            Assert.Equal(5, returnModel.Model[0].FolderId);
            Assert.Equal("Important Locations", returnModel.Model[0].Name);
        }

        [Fact]
        public async Task CorporationBookmarkFoldersAsync_successully_returns_a_list_of_V1BookmarksCorporationFolder()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            BookmarkScopes scopes = BookmarkScopes.esi_bookmarks_read_corporation_bookmarks_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, BookmarkScopesFlags = scopes };

            LatestBookmarksEndpoints internalLatestBookmarks = new LatestBookmarksEndpoints(string.Empty, true);

            PagedModel<V1BookmarksCorporationFolder> returnModel = await internalLatestBookmarks.CorporationBookmarkFoldersAsync(inputToken, 22, 1);

            Assert.Single(returnModel.Model);

            Assert.Equal(5, returnModel.Model[0].FolderId);
            Assert.Equal("Important Locations", returnModel.Model[0].Name);
        }
    }
}
