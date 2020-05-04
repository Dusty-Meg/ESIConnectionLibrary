using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibrary.Tests
{
    public class LoyaltyTests
    {
        [Fact]
        public void Points_successfully_returns_a_listV1LoyaltyPoint()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_loyalty_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            string json = "[\r\n  {\r\n    \"corporation_id\": 123,\r\n    \"loyalty_points\": 100\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestLoyalty internalLatestLoyalty = new InternalLatestLoyalty(mockedWebClient.Object, string.Empty);

            IList<V1LoyaltyPoint> returnModel = internalLatestLoyalty.Points(inputToken);

            Assert.NotNull(returnModel);

            Assert.Single(returnModel);

            Assert.Equal(123, returnModel[0].CorporationId);
            Assert.Equal(100, returnModel[0].LoyaltyPoints);
        }

        [Fact]
        public async Task PointsAsync_successfully_returns_a_listV1LoyaltyPoint()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_loyalty_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            string json = "[\r\n  {\r\n    \"corporation_id\": 123,\r\n    \"loyalty_points\": 100\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestLoyalty internalLatestLoyalty = new InternalLatestLoyalty(mockedWebClient.Object, string.Empty);

            IList<V1LoyaltyPoint> returnModel = await internalLatestLoyalty.PointsAsync(inputToken);

            Assert.NotNull(returnModel);

            Assert.Single(returnModel);

            Assert.Equal(123, returnModel[0].CorporationId);
            Assert.Equal(100, returnModel[0].LoyaltyPoints);
        }

        [Fact]
        public void Offers_successfully_returns_a_listV1LoyaltyOffer()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"ak_cost\": 35000,\r\n    \"isk_cost\": 0,\r\n    \"lp_cost\": 100,\r\n    \"offer_id\": 1,\r\n    \"quantity\": 1,\r\n    \"required_items\": [],\r\n    \"type_id\": 123\r\n  },\r\n  {\r\n    \"isk_cost\": 1000,\r\n    \"lp_cost\": 100,\r\n    \"offer_id\": 2,\r\n    \"quantity\": 10,\r\n    \"required_items\": [\r\n      {\r\n        \"quantity\": 10,\r\n        \"type_id\": 1234\r\n      }\r\n    ],\r\n    \"type_id\": 1235\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestLoyalty internalLatestLoyalty = new InternalLatestLoyalty(mockedWebClient.Object, string.Empty);

            IList<V1LoyaltyOffer> returnModel = internalLatestLoyalty.Offers(22);

            Assert.NotNull(returnModel);

            Assert.Equal(2, returnModel.Count);

            Assert.Equal(35000, returnModel[0].AkCost);
            Assert.Equal(0, returnModel[0].IskCost);
            Assert.Equal(100, returnModel[0].LpCost);
            Assert.Equal(1, returnModel[0].OfferId);
            Assert.Equal(1, returnModel[0].Quantity);
            Assert.Empty(returnModel[0].RequiredItems);
            Assert.Equal(123, returnModel[0].TypeId);

            Assert.Equal(1000, returnModel[1].IskCost);
            Assert.Equal(100, returnModel[1].LpCost);
            Assert.Equal(2, returnModel[1].OfferId);
            Assert.Equal(10, returnModel[1].Quantity);

            Assert.Single(returnModel[1].RequiredItems);

            Assert.Equal(10, returnModel[1].RequiredItems[0].Quantity);
            Assert.Equal(1234, returnModel[1].RequiredItems[0].TypeId);

            Assert.Equal(1235, returnModel[1].TypeId);
        }

        [Fact]
        public async Task OffersAsync_successfully_returns_a_listV1LoyaltyOffer()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"ak_cost\": 35000,\r\n    \"isk_cost\": 0,\r\n    \"lp_cost\": 100,\r\n    \"offer_id\": 1,\r\n    \"quantity\": 1,\r\n    \"required_items\": [],\r\n    \"type_id\": 123\r\n  },\r\n  {\r\n    \"isk_cost\": 1000,\r\n    \"lp_cost\": 100,\r\n    \"offer_id\": 2,\r\n    \"quantity\": 10,\r\n    \"required_items\": [\r\n      {\r\n        \"quantity\": 10,\r\n        \"type_id\": 1234\r\n      }\r\n    ],\r\n    \"type_id\": 1235\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestLoyalty internalLatestLoyalty = new InternalLatestLoyalty(mockedWebClient.Object, string.Empty);

            IList<V1LoyaltyOffer> returnModel = await internalLatestLoyalty.OffersAsync(22);

            Assert.NotNull(returnModel);

            Assert.Equal(2, returnModel.Count);

            Assert.Equal(35000, returnModel[0].AkCost);
            Assert.Equal(0, returnModel[0].IskCost);
            Assert.Equal(100, returnModel[0].LpCost);
            Assert.Equal(1, returnModel[0].OfferId);
            Assert.Equal(1, returnModel[0].Quantity);
            Assert.Empty(returnModel[0].RequiredItems);
            Assert.Equal(123, returnModel[0].TypeId);

            Assert.Equal(1000, returnModel[1].IskCost);
            Assert.Equal(100, returnModel[1].LpCost);
            Assert.Equal(2, returnModel[1].OfferId);
            Assert.Equal(10, returnModel[1].Quantity);

            Assert.Single(returnModel[1].RequiredItems);

            Assert.Equal(10, returnModel[1].RequiredItems[0].Quantity);
            Assert.Equal(1234, returnModel[1].RequiredItems[0].TypeId);

            Assert.Equal(1235, returnModel[1].TypeId);
        }
    }
}
