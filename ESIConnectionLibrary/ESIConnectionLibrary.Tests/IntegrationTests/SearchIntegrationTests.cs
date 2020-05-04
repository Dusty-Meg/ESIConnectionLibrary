using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibrary.Tests.IntegrationTests
{
    public class SearchIntegrationTests
    {
        [Fact]
        public void CharacterSearch_successfully_returns_a_V3SearchAuthSearch()
        {
            int characterId = 8976562;
            SearchScopes scopes = SearchScopes.esi_search_search_structures_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, SearchScopesFlags = scopes };

            LatestSearchEndpoints internalLatestSearch = new LatestSearchEndpoints(string.Empty, true);

            V3SearchAuthSearch returnModel = internalLatestSearch.CharacterSearch(inputToken, new List<V3SearchAuthSearchCategories>(), "search", false);

            Assert.NotNull(returnModel);

            Assert.Single(returnModel.SolarSystem);

            Assert.Equal(30002510, returnModel.SolarSystem[0]);

            Assert.Equal(7, returnModel.Station.Count);

            Assert.Equal(60004588, returnModel.Station[0]);
            Assert.Equal(60004594, returnModel.Station[1]);
            Assert.Equal(60005725, returnModel.Station[2]);
            Assert.Equal(60009106, returnModel.Station[3]);
            Assert.Equal(60012721, returnModel.Station[4]);
            Assert.Equal(60012724, returnModel.Station[5]);
            Assert.Equal(60012727, returnModel.Station[6]);
        }

        [Fact]
        public async Task CharacterSearchAsync_successfully_returns_a_V3SearchAuthSearch()
        {
            int characterId = 8976562;
            SearchScopes scopes = SearchScopes.esi_search_search_structures_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, SearchScopesFlags = scopes };

            LatestSearchEndpoints internalLatestSearch = new LatestSearchEndpoints(string.Empty, true);

            V3SearchAuthSearch returnModel = await internalLatestSearch.CharacterSearchAsync(inputToken, new List<V3SearchAuthSearchCategories>(), "search", false);

            Assert.NotNull(returnModel);

            Assert.Single(returnModel.SolarSystem);

            Assert.Equal(30002510, returnModel.SolarSystem[0]);

            Assert.Equal(7, returnModel.Station.Count);

            Assert.Equal(60004588, returnModel.Station[0]);
            Assert.Equal(60004594, returnModel.Station[1]);
            Assert.Equal(60005725, returnModel.Station[2]);
            Assert.Equal(60009106, returnModel.Station[3]);
            Assert.Equal(60012721, returnModel.Station[4]);
            Assert.Equal(60012724, returnModel.Station[5]);
            Assert.Equal(60012727, returnModel.Station[6]);
        }

        [Fact]
        public void Search_successfully_returns_a_V2SearchSearch()
        {
            LatestSearchEndpoints internalLatestSearch = new LatestSearchEndpoints(string.Empty, true);

            V2SearchSearch returnModel = internalLatestSearch.Search(new List<V2SearchSearchCategories>(), "search", false);

            Assert.NotNull(returnModel);

            Assert.Single(returnModel.SolarSystem);

            Assert.Equal(30002510, returnModel.SolarSystem[0]);

            Assert.Equal(7, returnModel.Station.Count);

            Assert.Equal(60004588, returnModel.Station[0]);
            Assert.Equal(60004594, returnModel.Station[1]);
            Assert.Equal(60005725, returnModel.Station[2]);
            Assert.Equal(60009106, returnModel.Station[3]);
            Assert.Equal(60012721, returnModel.Station[4]);
            Assert.Equal(60012724, returnModel.Station[5]);
            Assert.Equal(60012727, returnModel.Station[6]);
        }

        [Fact]
        public async Task SearchAsync_successfully_returns_a_V2SearchSearch()
        {
            LatestSearchEndpoints internalLatestSearch = new LatestSearchEndpoints(string.Empty, true);

            V2SearchSearch returnModel = await internalLatestSearch.SearchAsync(new List<V2SearchSearchCategories>(), "search", false);

            Assert.NotNull(returnModel);

            Assert.Single(returnModel.SolarSystem);

            Assert.Equal(30002510, returnModel.SolarSystem[0]);

            Assert.Equal(7, returnModel.Station.Count);

            Assert.Equal(60004588, returnModel.Station[0]);
            Assert.Equal(60004594, returnModel.Station[1]);
            Assert.Equal(60005725, returnModel.Station[2]);
            Assert.Equal(60009106, returnModel.Station[3]);
            Assert.Equal(60012721, returnModel.Station[4]);
            Assert.Equal(60012724, returnModel.Station[5]);
            Assert.Equal(60012727, returnModel.Station[6]);
        }
    }
}
