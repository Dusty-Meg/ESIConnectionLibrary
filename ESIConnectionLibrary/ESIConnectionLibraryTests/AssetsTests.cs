using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class AssetsTests
    {
        [Fact]
        public void Characters_successfully_returns_a_pagedModelV4AssetsCharacter()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int page = 1;
            AssetScopes scopes = AssetScopes.esi_assets_read_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            string json = "[{\"location_flag\": \"Hangar\",\"location_id\": 60002959,\"is_singleton\": true,\"type_id\": 3516,\"item_id\": 1000000016835,\"location_type\": \"station\",\"quantity\": 1}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestAssets internalLatestAssets = new InternalLatestAssets(mockedWebClient.Object, string.Empty);

            PagedModel<V4AssetsCharacter> getCharacterAssets = internalLatestAssets.Characters(inputToken, page);

            Assert.Equal(2, getCharacterAssets.MaxPages);
            Assert.Equal(1, getCharacterAssets.CurrentPage);
            Assert.Equal(1, getCharacterAssets.Model.Count);
            Assert.Equal(LocationFlagCharacter.Hangar, getCharacterAssets.Model.First().LocationFlag);
        }

        [Fact]
        public async Task CharactersAsync_successfully_returns_a_pagedModelV4AssetsCharacter()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int page = 1;
            AssetScopes scopes = AssetScopes.esi_assets_read_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            string json = "[{\"location_flag\": \"Hangar\",\"location_id\": 60002959,\"is_singleton\": true,\"type_id\": 3516,\"item_id\": 1000000016835,\"location_type\": \"station\",\"quantity\": 1}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestAssets internalLatestAssets = new InternalLatestAssets(mockedWebClient.Object, string.Empty);

            PagedModel<V4AssetsCharacter> getCharacterAssets = await internalLatestAssets.CharactersAsync(inputToken, page);

            Assert.Equal(2, getCharacterAssets.MaxPages);
            Assert.Equal(1, getCharacterAssets.CurrentPage);
            Assert.Equal(1, getCharacterAssets.Model.Count);
            Assert.Equal(LocationFlagCharacter.Hangar, getCharacterAssets.Model.First().LocationFlag);
        }

        [Fact]
        public void CharacterLocations_successfully_returns_a_ListV2AssetsCharacterLocation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            string json = "[{\"item_id\": 12345,\"position\": {\"x\": 1.2,\"y\": 2.3,\"z\": -3.4}}]";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestAssets internalLatestAssets = new InternalLatestAssets(mockedWebClient.Object, string.Empty);

            IList<V2AssetsCharacterLocation> getCharactersAssetsLocations = internalLatestAssets.CharacterLocations(inputToken, ids);

            Assert.Equal(1, getCharactersAssetsLocations.Count);
            Assert.Equal(12345, getCharactersAssetsLocations.First().ItemId);
        }

        [Fact]
        public async Task CharacterLocationsAsync_successfully_returns_a_ListV2AssetsCharacterLocation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            string json = "[{\"item_id\": 12345,\"position\": {\"x\": 1.2,\"y\": 2.3,\"z\": -3.4}}]";

            mockedWebClient.Setup(x => x.PostAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestAssets internalLatestAssets = new InternalLatestAssets(mockedWebClient.Object, string.Empty);

            IList<V2AssetsCharacterLocation> getCharactersAssetsLocations = await internalLatestAssets.CharacterLocationAsync(inputToken, ids);

            Assert.Equal(1, getCharactersAssetsLocations.Count);
            Assert.Equal(12345, getCharactersAssetsLocations.First().ItemId);
        }

        [Fact]
        public void CharacterNames_successfully_returns_a_ListV1AssetsCharacterName()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            string json = "[{\"item_id\": 12345,\"name\": \"Awesome Name\"}]";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestAssets internalLatestAssets = new InternalLatestAssets(mockedWebClient.Object, string.Empty);

            IList<V1AssetsCharacterName> getCharactersAssetsNames = internalLatestAssets.CharacterNames(inputToken, ids);

            Assert.Equal(1, getCharactersAssetsNames.Count);
            Assert.Equal(12345, getCharactersAssetsNames.First().ItemId);
            Assert.Equal("Awesome Name", getCharactersAssetsNames.First().Name);
        }

        [Fact]
        public async Task CharacterNamesAsync_successfully_returns_a_ListV1AssetsCharacterName()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            string json = "[{\"item_id\": 12345,\"name\": \"Awesome Name\"}]";

            mockedWebClient.Setup(x => x.PostAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestAssets internalLatestAssets = new InternalLatestAssets(mockedWebClient.Object, string.Empty);

            IList<V1AssetsCharacterName> getCharactersAssetsNames = await internalLatestAssets.CharacterNamesAsync(inputToken, ids);

            Assert.Equal(1, getCharactersAssetsNames.Count);
            Assert.Equal(12345, getCharactersAssetsNames.First().ItemId);
            Assert.Equal("Awesome Name", getCharactersAssetsNames.First().Name);
        }

        [Fact]
        public void Corporations_successfully_returns_a_pagedModelV4AssetsCorporations()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int corporationId = 888233;
            int page = 1;
            AssetScopes scopes = AssetScopes.esi_assets_read_corporation_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            string json = "[{\"location_flag\": \"Hangar\",\"location_id\": 60002959,\"is_singleton\": true,\"type_id\": 3516,\"item_id\": 1000000016835,\"location_type\": \"station\",\"quantity\": 1}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestAssets internalLatestAssets = new InternalLatestAssets(mockedWebClient.Object, string.Empty);

            PagedModel<V4AssetsCorporations> getCorporationAssets = internalLatestAssets.Corporations(inputToken, corporationId, page);

            Assert.Equal(2, getCorporationAssets.MaxPages);
            Assert.Equal(1, getCorporationAssets.CurrentPage);
            Assert.Equal(1, getCorporationAssets.Model.Count);
            Assert.Equal(LocationFlagCorporation.Hangar, getCorporationAssets.Model.First().LocationFlag);
        }

        [Fact]
        public async Task CorporationsAsync_successfully_returns_a_pagedModelV4AssetsCorporations()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int corporationId = 888233;
            int page = 1;
            AssetScopes scopes = AssetScopes.esi_assets_read_corporation_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            string json = "[{\"location_flag\": \"Hangar\",\"location_id\": 60002959,\"is_singleton\": true,\"type_id\": 3516,\"item_id\": 1000000016835,\"location_type\": \"station\",\"quantity\": 1}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestAssets internalLatestAssets = new InternalLatestAssets(mockedWebClient.Object, string.Empty);

            PagedModel<V4AssetsCorporations> getCorporationAssets = await internalLatestAssets.CorporationsAsync(inputToken, corporationId, page);

            Assert.Equal(2, getCorporationAssets.MaxPages);
            Assert.Equal(1, getCorporationAssets.CurrentPage);
            Assert.Equal(1, getCorporationAssets.Model.Count);
            Assert.Equal(LocationFlagCorporation.Hangar, getCorporationAssets.Model.First().LocationFlag);
        }

        [Fact]
        public void CorporationLocations_successfully_returns_a_ListV2AssetsCorporationLocation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_corporation_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            string json = "[{\"item_id\": 12345,\"position\": {\"x\": 1.2,\"y\": 2.3,\"z\": -3.4}}]";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestAssets internalLatestAssets = new InternalLatestAssets(mockedWebClient.Object, string.Empty);

            IList<V2AssetsCorporationLocation> getCorporationAssetsLocations = internalLatestAssets.CorporationLocations(inputToken, characterId, ids);

            Assert.Equal(1, getCorporationAssetsLocations.Count);
            Assert.Equal(12345, getCorporationAssetsLocations.First().ItemId);
        }

        [Fact]
        public async Task CorporationLocationsAsync_successfully_returns_a_ListV2AssetsCorporationLocation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_corporation_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            string json = "[{\"item_id\": 12345,\"position\": {\"x\": 1.2,\"y\": 2.3,\"z\": -3.4}}]";

            mockedWebClient.Setup(x => x.PostAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestAssets internalLatestAssets = new InternalLatestAssets(mockedWebClient.Object, string.Empty);

            IList<V2AssetsCorporationLocation> getCorporationAssetsLocations = await internalLatestAssets.CorporationLocationsAsync(inputToken, characterId, ids);

            Assert.Equal(1, getCorporationAssetsLocations.Count);
            Assert.Equal(12345, getCorporationAssetsLocations.First().ItemId);
        }

        [Fact]
        public void CorporationNames_successfully_returns_a_ListV1AssetsCorporationName()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_corporation_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            string json = "[{\"item_id\": 12345,\"name\": \"Awesome Name\"}]";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestAssets internalLatestAssets = new InternalLatestAssets(mockedWebClient.Object, string.Empty);

            IList<V1AssetsCorporationName> getCorporationsAssetsNames = internalLatestAssets.CorporationNames(inputToken, characterId, ids);

            Assert.Equal(1, getCorporationsAssetsNames.Count);
            Assert.Equal(12345, getCorporationsAssetsNames.First().ItemId);
            Assert.Equal("Awesome Name", getCorporationsAssetsNames.First().Name);
        }

        [Fact]
        public async Task CorporationNamesAsync_successfully_returns_a_ListV1AssetsCorporationName()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_corporation_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            string json = "[{\"item_id\": 12345,\"name\": \"Awesome Name\"}]";

            mockedWebClient.Setup(x => x.PostAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestAssets internalLatestAssets = new InternalLatestAssets(mockedWebClient.Object, string.Empty);

            IList<V1AssetsCorporationName> getCorporationsAssetsNames = await internalLatestAssets.CorporationNamesAsync(inputToken, characterId, ids);

            Assert.Equal(1, getCorporationsAssetsNames.Count);
            Assert.Equal(12345, getCorporationsAssetsNames.First().ItemId);
            Assert.Equal("Awesome Name", getCorporationsAssetsNames.First().Name);
        }
    }
}
