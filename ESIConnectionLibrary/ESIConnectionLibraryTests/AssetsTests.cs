using System.Collections.Generic;
using System.Linq;
using System.Net;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class AssetsTests
    {
        [Fact]
        public void GetCharacterAssets_successfully_returns_a_pagedModelCharacterAssets()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int page = 1;
            AssetScopes scopes = AssetScopes.esi_assets_read_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            string getCharacterAssetsJson = "[{\"location_flag\": \"Hangar\",\"location_id\": 60002959,\"is_singleton\": true,\"type_id\": 3516,\"item_id\": 1000000016835,\"location_type\": \"station\",\"quantity\": 1}]";

            PagedJson pagedJson = new PagedJson { Response = getCharacterAssetsJson, MaxPages = 2 };

            mockedWebClient.Setup(x => x.GetPaged(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(pagedJson);

            InternalLatestAssets internalLatestAssets = new InternalLatestAssets(mockedWebClient.Object, string.Empty);

            PagedModel<V3GetCharacterAssets> getCharacterAssets = internalLatestAssets.GetCharactersAssets(inputToken, characterId, page);

            Assert.Equal(2, getCharacterAssets.MaxPages);
            Assert.Equal(1, getCharacterAssets.CurrentPage);
            Assert.Equal(1, getCharacterAssets.Model.Count);
            Assert.Equal(LocationFlagCharacter.Hangar, getCharacterAssets.Model.First().LocationFlag);
        }

        [Fact]
        public void GetCharactersAssetsLocations_successfully_returns_a_ListV2GetCharactersAssetsLocations()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            string getCharactersAssetsLocationsJson = "[{\"item_id\": 12345,\"position\": {\"x\": 1.2,\"y\": 2.3,\"z\": -3.4}}]";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersAssetsLocationsJson);

            InternalLatestAssets internalLatestAssets = new InternalLatestAssets(mockedWebClient.Object, string.Empty);

            IList<V2GetCharactersAssetsLocations> getCharactersAssetsLocations = internalLatestAssets.GetCharactersAssetsLocations(inputToken, characterId, ids);

            Assert.Equal(1, getCharactersAssetsLocations.Count);
            Assert.Equal(12345, getCharactersAssetsLocations.First().ItemId);
        }

        [Fact]
        public void GetCharactersAssetsNames_successfully_returns_a_ListV1GetCharactersAssetsNames()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            string getCharactersAssetsNamesJson = "[{\"item_id\": 12345,\"name\": \"Awesome Name\"}]";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersAssetsNamesJson);

            InternalLatestAssets internalLatestAssets = new InternalLatestAssets(mockedWebClient.Object, string.Empty);

            IList<V1GetCharactersAssetsNames> getCharactersAssetsNames = internalLatestAssets.GetCharactersAssetsNames(inputToken, characterId, ids);

            Assert.Equal(1, getCharactersAssetsNames.Count);
            Assert.Equal(12345, getCharactersAssetsNames.First().ItemId);
            Assert.Equal("Awesome Name", getCharactersAssetsNames.First().Name);
        }

        [Fact]
        public void GetCorporationsAssets_successfully_returns_a_pagedModelCorporationsAssets()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int corporationId = 888233;
            int page = 1;
            AssetScopes scopes = AssetScopes.esi_assets_read_corporation_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            string getCorporationAssetsJson = "[{\"location_flag\": \"Hangar\",\"location_id\": 60002959,\"is_singleton\": true,\"type_id\": 3516,\"item_id\": 1000000016835,\"location_type\": \"station\",\"quantity\": 1}]";

            PagedJson pagedJson = new PagedJson { Response = getCorporationAssetsJson, MaxPages = 2 };

            mockedWebClient.Setup(x => x.GetPaged(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(pagedJson);

            InternalLatestAssets internalLatestAssets = new InternalLatestAssets(mockedWebClient.Object, string.Empty);

            PagedModel<V2GetCorporationsAssets> getCorporationAssets = internalLatestAssets.GetCorporationsAssets(inputToken, corporationId, page);

            Assert.Equal(2, getCorporationAssets.MaxPages);
            Assert.Equal(1, getCorporationAssets.CurrentPage);
            Assert.Equal(1, getCorporationAssets.Model.Count);
            Assert.Equal(LocationFlagCorporation.Hangar, getCorporationAssets.Model.First().LocationFlag);
        }

        [Fact]
        public void GetCorporationsAssetsLocations_successfully_returns_a_ListV2GetCorporationsAssetsLocations()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_corporation_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            string getCorporationAssetsLocationsJson = "[{\"item_id\": 12345,\"position\": {\"x\": 1.2,\"y\": 2.3,\"z\": -3.4}}]";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCorporationAssetsLocationsJson);

            InternalLatestAssets internalLatestAssets = new InternalLatestAssets(mockedWebClient.Object, string.Empty);

            IList<V2GetCorporationsAssetsLocations> getCorporationAssetsLocations = internalLatestAssets.GetCorporationsAssetsLocations(inputToken, characterId, ids);

            Assert.Equal(1, getCorporationAssetsLocations.Count);
            Assert.Equal(12345, getCorporationAssetsLocations.First().ItemId);
        }

        [Fact]
        public void GetCorporationsAssetsNames_successfully_returns_a_ListV1GetCorporationsAssetsNames()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_corporation_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            string getCorporationsAssetsNamesJson = "[{\"item_id\": 12345,\"name\": \"Awesome Name\"}]";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCorporationsAssetsNamesJson);

            InternalLatestAssets internalLatestAssets = new InternalLatestAssets(mockedWebClient.Object, string.Empty);

            IList<V1GetCorporationsAssetsNames> getCorporationsAssetsNames = internalLatestAssets.GetCorporationsAssetsNames(inputToken, characterId, ids);

            Assert.Equal(1, getCorporationsAssetsNames.Count);
            Assert.Equal(12345, getCorporationsAssetsNames.First().ItemId);
            Assert.Equal("Awesome Name", getCorporationsAssetsNames.First().Name);
        }
    }
}
