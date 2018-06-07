using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class AssetsIntegrationTests
    {
        [Fact]
        public void GetCharacterAssets_successfully_returns_a_pagedModelCharacterAssets()
        {
            int characterId = 88823;
            int page = 1;
            AssetScopes scopes = AssetScopes.esi_assets_read_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };

            LatestAssetsEndpoints internalLatestAssets = new LatestAssetsEndpoints(string.Empty, true);

            PagedModel<V3GetCharacterAssets> getCharacterAssets = internalLatestAssets.GetCharactersAssets(inputToken, page);

            Assert.Equal(1, getCharacterAssets.CurrentPage);
            Assert.Equal(1, getCharacterAssets.Model.Count);
            Assert.Equal(LocationFlagCharacter.Hangar, getCharacterAssets.Model.First().LocationFlag);
        }

        [Fact]
        public async Task GetCharacterAssetsAsync_successfully_returns_a_pagedModelCharacterAssets()
        {
            int characterId = 88823;
            int page = 1;
            AssetScopes scopes = AssetScopes.esi_assets_read_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };

            LatestAssetsEndpoints internalLatestAssets = new LatestAssetsEndpoints(string.Empty, true);

            PagedModel<V3GetCharacterAssets> getCharacterAssets = await internalLatestAssets.GetCharactersAssetsAsync(inputToken, page);

            Assert.Equal(1, getCharacterAssets.CurrentPage);
            Assert.Equal(1, getCharacterAssets.Model.Count);
            Assert.Equal(LocationFlagCharacter.Hangar, getCharacterAssets.Model.First().LocationFlag);
        }

        [Fact]
        public void GetCharactersAssetsLocations_successfully_returns_a_ListV2GetCharactersAssetsLocations()
        {
            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };

            LatestAssetsEndpoints internalLatestAssets = new LatestAssetsEndpoints(string.Empty, true);

            IList<V2GetCharactersAssetsLocations> getCharactersAssetsLocations = internalLatestAssets.GetCharactersAssetsLocations(inputToken, ids);

            Assert.Equal(1, getCharactersAssetsLocations.Count);
            Assert.Equal(12345, getCharactersAssetsLocations.First().ItemId);
        }

        [Fact]
        public async Task GetCharactersAssetsLocationsAsync_successfully_returns_a_ListV2GetCharactersAssetsLocations()
        {
            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };

            LatestAssetsEndpoints internalLatestAssets = new LatestAssetsEndpoints(string.Empty, true);

            IList<V2GetCharactersAssetsLocations> getCharactersAssetsLocations = await internalLatestAssets.GetCharactersAssetsLocationsAsync(inputToken, ids);

            Assert.Equal(1, getCharactersAssetsLocations.Count);
            Assert.Equal(12345, getCharactersAssetsLocations.First().ItemId);
        }

        [Fact]
        public void GetCharactersAssetsNames_successfully_returns_a_ListV1GetCharactersAssetsNames()
        {
            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };

            LatestAssetsEndpoints internalLatestAssets = new LatestAssetsEndpoints(string.Empty, true);

            IList<V1GetCharactersAssetsNames> getCharactersAssetsNames = internalLatestAssets.GetCharactersAssetsNames(inputToken, ids);

            Assert.Equal(1, getCharactersAssetsNames.Count);
            Assert.Equal(12345, getCharactersAssetsNames.First().ItemId);
            Assert.Equal("Awesome Name", getCharactersAssetsNames.First().Name);
        }

        [Fact]
        public async Task GetCharactersAssetsNamesAsync_successfully_returns_a_ListV1GetCharactersAssetsNames()
        {
            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };

            LatestAssetsEndpoints internalLatestAssets = new LatestAssetsEndpoints(string.Empty, true);

            IList<V1GetCharactersAssetsNames> getCharactersAssetsNames = await internalLatestAssets.GetCharactersAssetsNamesAsync(inputToken, ids);

            Assert.Equal(1, getCharactersAssetsNames.Count);
            Assert.Equal(12345, getCharactersAssetsNames.First().ItemId);
            Assert.Equal("Awesome Name", getCharactersAssetsNames.First().Name);
        }

        [Fact]
        public void GetCorporationsAssets_successfully_returns_a_pagedModelCorporationsAssets()
        {
            int characterId = 88823;
            int corporationId = 888233;
            int page = 1;
            AssetScopes scopes = AssetScopes.esi_assets_read_corporation_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };

            LatestAssetsEndpoints internalLatestAssets = new LatestAssetsEndpoints(string.Empty, true);

            PagedModel<V3GetCorporationsAssets> getCorporationAssets = internalLatestAssets.GetCorporationsAssets(inputToken, corporationId, page);

            Assert.Equal(1, getCorporationAssets.CurrentPage);
            Assert.Equal(1, getCorporationAssets.Model.Count);
            Assert.Equal(LocationFlagCorporation.Hangar, getCorporationAssets.Model.First().LocationFlag);
        }

        [Fact]
        public async Task GetCorporationsAssetsAsync_successfully_returns_a_pagedModelCorporationsAssets()
        {
            int characterId = 88823;
            int corporationId = 888233;
            int page = 1;
            AssetScopes scopes = AssetScopes.esi_assets_read_corporation_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };

            LatestAssetsEndpoints internalLatestAssets = new LatestAssetsEndpoints(string.Empty, true);

            PagedModel<V3GetCorporationsAssets> getCorporationAssets = await internalLatestAssets.GetCorporationsAssetsAsync(inputToken, corporationId, page);

            Assert.Equal(1, getCorporationAssets.CurrentPage);
            Assert.Equal(1, getCorporationAssets.Model.Count);
            Assert.Equal(LocationFlagCorporation.Hangar, getCorporationAssets.Model.First().LocationFlag);
        }

        [Fact]
        public void GetCorporationsAssetsLocations_successfully_returns_a_ListV2GetCorporationsAssetsLocations()
        {
            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_corporation_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            LatestAssetsEndpoints internalLatestAssets = new LatestAssetsEndpoints(string.Empty, true);

            IList<V2GetCorporationsAssetsLocations> getCorporationAssetsLocations = internalLatestAssets.GetCorporationsAssetsLocations(inputToken, characterId, ids);

            Assert.Equal(1, getCorporationAssetsLocations.Count);
            Assert.Equal(12345, getCorporationAssetsLocations.First().ItemId);
        }

        [Fact]
        public async Task GetCorporationsAssetsLocationsAsync_successfully_returns_a_ListV2GetCorporationsAssetsLocations()
        {
            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_corporation_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };
            LatestAssetsEndpoints internalLatestAssets = new LatestAssetsEndpoints(string.Empty, true);

            IList<V2GetCorporationsAssetsLocations> getCorporationAssetsLocations = await internalLatestAssets.GetCorporationsAssetsLocationsAsync(inputToken, characterId, ids);

            Assert.Equal(1, getCorporationAssetsLocations.Count);
            Assert.Equal(12345, getCorporationAssetsLocations.First().ItemId);
        }

        [Fact]
        public void GetCorporationsAssetsNames_successfully_returns_a_ListV1GetCorporationsAssetsNames()
        {
            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_corporation_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };

            LatestAssetsEndpoints internalLatestAssets = new LatestAssetsEndpoints(string.Empty, true);

            IList<V1GetCorporationsAssetsNames> getCorporationsAssetsNames = internalLatestAssets.GetCorporationsAssetsNames(inputToken, characterId, ids);

            Assert.Equal(1, getCorporationsAssetsNames.Count);
            Assert.Equal(12345, getCorporationsAssetsNames.First().ItemId);
            Assert.Equal("Awesome Name", getCorporationsAssetsNames.First().Name);
        }

        [Fact]
        public async Task GetCorporationsAssetsNamesAsync_successfully_returns_a_ListV1GetCorporationsAssetsNames()
        {
            int characterId = 88823;
            IList<long> ids = new List<long> { 3, 5, 6 };
            AssetScopes scopes = AssetScopes.esi_assets_read_corporation_assets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AssetScopesFlags = scopes };

            LatestAssetsEndpoints internalLatestAssets = new LatestAssetsEndpoints(string.Empty, true);

            IList<V1GetCorporationsAssetsNames> getCorporationsAssetsNames = await internalLatestAssets.GetCorporationsAssetsNamesAsync(inputToken, characterId, ids);

            Assert.Equal(1, getCorporationsAssetsNames.Count);
            Assert.Equal(12345, getCorporationsAssetsNames.First().ItemId);
            Assert.Equal("Awesome Name", getCorporationsAssetsNames.First().Name);
        }
    }
}
