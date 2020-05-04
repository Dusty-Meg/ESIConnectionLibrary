using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibrary.Tests
{
    public class SearchTests
    {
        [Fact]
        public void CharacterSearch_successfully_returns_a_V3SearchAuthSearch()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;
            SearchScopes scopes = SearchScopes.esi_search_search_structures_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, SearchScopesFlags = scopes };

            string json = "{\r\n  \"solar_system\": [\r\n    30002510\r\n  ],\r\n  \"station\": [\r\n    60004588,\r\n    60004594,\r\n    60005725,\r\n    60009106,\r\n    60012721,\r\n    60012724,\r\n    60012727\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestSearch internalLatestSearch = new InternalLatestSearch(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;
            SearchScopes scopes = SearchScopes.esi_search_search_structures_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, SearchScopesFlags = scopes };

            string json = "{\r\n  \"solar_system\": [\r\n    30002510\r\n  ],\r\n  \"station\": [\r\n    60004588,\r\n    60004594,\r\n    60005725,\r\n    60009106,\r\n    60012721,\r\n    60012724,\r\n    60012727\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestSearch internalLatestSearch = new InternalLatestSearch(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"solar_system\": [\r\n    30002510\r\n  ],\r\n  \"station\": [\r\n    60004588,\r\n    60004594,\r\n    60005725,\r\n    60009106,\r\n    60012721,\r\n    60012724,\r\n    60012727\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestSearch internalLatestSearch = new InternalLatestSearch(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"solar_system\": [\r\n    30002510\r\n  ],\r\n  \"station\": [\r\n    60004588,\r\n    60004594,\r\n    60005725,\r\n    60009106,\r\n    60012721,\r\n    60012724,\r\n    60012727\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestSearch internalLatestSearch = new InternalLatestSearch(mockedWebClient.Object, string.Empty);

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
