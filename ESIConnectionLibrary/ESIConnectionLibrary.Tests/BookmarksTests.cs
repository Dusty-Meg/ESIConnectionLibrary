using System;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibrary.Tests
{
    public class BookmarksTests
    {
        [Fact]
        public void CharacterBookmarks_successully_returns_a_list_of_V2BookmarksCharacter()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            BookmarkScopes scopes = BookmarkScopes.esi_bookmarks_read_character_bookmarks_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, BookmarkScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"bookmark_id\": 4,\r\n    \"created\": \"2016-08-09T11:57:47Z\",\r\n    \"creator_id\": 2112625428,\r\n    \"folder_id\": 5,\r\n    \"item\": {\r\n      \"item_id\": 50006722,\r\n      \"type_id\": 29633\r\n    },\r\n    \"label\": \"Stargate\",\r\n    \"location_id\": 30003430,\r\n    \"notes\": \"This is a stargate\"\r\n  },\r\n  {\r\n    \"bookmark_id\": 5,\r\n    \"coordinates\": {\r\n      \"x\": -2958928814000,\r\n      \"y\": -338367275823,\r\n      \"z\": 2114538075090\r\n    },\r\n    \"created\": \"2016-08-09T11:57:47Z\",\r\n    \"creator_id\": 2112625428,\r\n    \"folder_id\": 5,\r\n    \"label\": \"Random location\",\r\n    \"location_id\": 30003430,\r\n    \"notes\": \"This is a random location in space\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel {Model = json});

            InternalLatestBookmarks internalLatestBookmarks = new InternalLatestBookmarks(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            BookmarkScopes scopes = BookmarkScopes.esi_bookmarks_read_character_bookmarks_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, BookmarkScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"bookmark_id\": 4,\r\n    \"created\": \"2016-08-09T11:57:47Z\",\r\n    \"creator_id\": 2112625428,\r\n    \"folder_id\": 5,\r\n    \"item\": {\r\n      \"item_id\": 50006722,\r\n      \"type_id\": 29633\r\n    },\r\n    \"label\": \"Stargate\",\r\n    \"location_id\": 30003430,\r\n    \"notes\": \"This is a stargate\"\r\n  },\r\n  {\r\n    \"bookmark_id\": 5,\r\n    \"coordinates\": {\r\n      \"x\": -2958928814000,\r\n      \"y\": -338367275823,\r\n      \"z\": 2114538075090\r\n    },\r\n    \"created\": \"2016-08-09T11:57:47Z\",\r\n    \"creator_id\": 2112625428,\r\n    \"folder_id\": 5,\r\n    \"label\": \"Random location\",\r\n    \"location_id\": 30003430,\r\n    \"notes\": \"This is a random location in space\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestBookmarks internalLatestBookmarks = new InternalLatestBookmarks(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            BookmarkScopes scopes = BookmarkScopes.esi_bookmarks_read_character_bookmarks_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, BookmarkScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"folder_id\": 5,\r\n    \"name\": \"Icecream\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestBookmarks internalLatestBookmarks = new InternalLatestBookmarks(mockedWebClient.Object, string.Empty);

            PagedModel<V2BookmarksCharacterFolder> returnModel = internalLatestBookmarks.CharacterBookmarkFolders(inputToken, 1);

            Assert.Single(returnModel.Model);

            Assert.Equal(5, returnModel.Model[0].FolderId);
            Assert.Equal("Icecream", returnModel.Model[0].Name);
        }

        [Fact]
        public async Task CharacterBookmarkFoldersAsync_successully_returns_a_list_of_V2BookmarksCharacterFolder()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            BookmarkScopes scopes = BookmarkScopes.esi_bookmarks_read_character_bookmarks_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, BookmarkScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"folder_id\": 5,\r\n    \"name\": \"Icecream\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestBookmarks internalLatestBookmarks = new InternalLatestBookmarks(mockedWebClient.Object, string.Empty);

            PagedModel<V2BookmarksCharacterFolder> returnModel = await internalLatestBookmarks.CharacterBookmarkFoldersAsync(inputToken, 1);

            Assert.Single(returnModel.Model);

            Assert.Equal(5, returnModel.Model[0].FolderId);
            Assert.Equal("Icecream", returnModel.Model[0].Name);
        }

        [Fact]
        public void CorporationBookmarks_successully_returns_a_list_of_V1BookmarksCorporation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            BookmarkScopes scopes = BookmarkScopes.esi_bookmarks_read_corporation_bookmarks_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, BookmarkScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"bookmark_id\": 4,\r\n    \"created\": \"2016-08-09T11:57:47Z\",\r\n    \"creator_id\": 2112625428,\r\n    \"folder_id\": 5,\r\n    \"item\": {\r\n      \"item_id\": 50006722,\r\n      \"type_id\": 29633\r\n    },\r\n    \"label\": \"Stargate\",\r\n    \"location_id\": 30003430,\r\n    \"notes\": \"This is a stargate\"\r\n  },\r\n  {\r\n    \"bookmark_id\": 5,\r\n    \"coordinates\": {\r\n      \"x\": -2958928814000,\r\n      \"y\": -338367275823,\r\n      \"z\": 2114538075090\r\n    },\r\n    \"created\": \"2016-08-09T11:57:47Z\",\r\n    \"creator_id\": 2112625428,\r\n    \"folder_id\": 5,\r\n    \"label\": \"Random location\",\r\n    \"location_id\": 30003430,\r\n    \"notes\": \"This is a random location in space\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestBookmarks internalLatestBookmarks = new InternalLatestBookmarks(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            BookmarkScopes scopes = BookmarkScopes.esi_bookmarks_read_corporation_bookmarks_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, BookmarkScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"bookmark_id\": 4,\r\n    \"created\": \"2016-08-09T11:57:47Z\",\r\n    \"creator_id\": 2112625428,\r\n    \"folder_id\": 5,\r\n    \"item\": {\r\n      \"item_id\": 50006722,\r\n      \"type_id\": 29633\r\n    },\r\n    \"label\": \"Stargate\",\r\n    \"location_id\": 30003430,\r\n    \"notes\": \"This is a stargate\"\r\n  },\r\n  {\r\n    \"bookmark_id\": 5,\r\n    \"coordinates\": {\r\n      \"x\": -2958928814000,\r\n      \"y\": -338367275823,\r\n      \"z\": 2114538075090\r\n    },\r\n    \"created\": \"2016-08-09T11:57:47Z\",\r\n    \"creator_id\": 2112625428,\r\n    \"folder_id\": 5,\r\n    \"label\": \"Random location\",\r\n    \"location_id\": 30003430,\r\n    \"notes\": \"This is a random location in space\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestBookmarks internalLatestBookmarks = new InternalLatestBookmarks(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            BookmarkScopes scopes = BookmarkScopes.esi_bookmarks_read_corporation_bookmarks_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, BookmarkScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"folder_id\": 5,\r\n    \"name\": \"Important Locations\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestBookmarks internalLatestBookmarks = new InternalLatestBookmarks(mockedWebClient.Object, string.Empty);

            PagedModel<V1BookmarksCorporationFolder> returnModel = internalLatestBookmarks.CorporationBookmarkFolders(inputToken, 22, 1);

            Assert.Single(returnModel.Model);

            Assert.Equal(5, returnModel.Model[0].FolderId);
            Assert.Equal("Important Locations", returnModel.Model[0].Name);
        }

        [Fact]
        public async Task CorporationBookmarkFoldersAsync_successully_returns_a_list_of_V1BookmarksCorporationFolder()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            BookmarkScopes scopes = BookmarkScopes.esi_bookmarks_read_corporation_bookmarks_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, BookmarkScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"folder_id\": 5,\r\n    \"name\": \"Important Locations\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestBookmarks internalLatestBookmarks = new InternalLatestBookmarks(mockedWebClient.Object, string.Empty);

            PagedModel<V1BookmarksCorporationFolder> returnModel = await internalLatestBookmarks.CorporationBookmarkFoldersAsync(inputToken, 22, 1);

            Assert.Single(returnModel.Model);

            Assert.Equal(5, returnModel.Model[0].FolderId);
            Assert.Equal("Important Locations", returnModel.Model[0].Name);
        }
    }
}
