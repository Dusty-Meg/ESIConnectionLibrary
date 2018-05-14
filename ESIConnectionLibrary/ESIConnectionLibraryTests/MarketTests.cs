using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class MarketTests
    {
        [Fact]
        public void GetMarketGroupInformation_Sucessfully_returns_a_MarketGroupInformation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int marketGroupId = 8976562;

            string getMarketGroupInformationJson = "{\"market_group_id\": 5,\"name\": \"Standard Frigates\",\"description\": \"Small, fast vessels suited to a variety of purposes.\",\"types\": [582, 583],\"parent_group_id\": 1361}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getMarketGroupInformationJson);

            InternalLatestMarket internalLatestMarket = new InternalLatestMarket(mockedWebClient.Object, string.Empty);

            V1MarketGroupInformation v1MarketGroupInformation = internalLatestMarket.GetMarketGroupInformation(marketGroupId);

            Assert.Equal(5, v1MarketGroupInformation.MarketGroupId);
            Assert.Equal(2, v1MarketGroupInformation.Types.Count);
            Assert.Equal(582, v1MarketGroupInformation.Types.First());
            Assert.Equal(1361, v1MarketGroupInformation.ParentGroupId);
        }

        [Fact]
        public async Task GetMarketGroupInformationAsync_Sucessfully_returns_a_MarketGroupInformation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int marketGroupId = 8976562;

            string getMarketGroupInformationJson = "{\"market_group_id\": 5,\"name\": \"Standard Frigates\",\"description\": \"Small, fast vessels suited to a variety of purposes.\",\"types\": [582, 583],\"parent_group_id\": 1361}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getMarketGroupInformationJson);

            InternalLatestMarket internalLatestMarket = new InternalLatestMarket(mockedWebClient.Object, string.Empty);

            V1MarketGroupInformation v1MarketGroupInformation = await internalLatestMarket.GetMarketGroupInformationAsync(marketGroupId);

            Assert.Equal(5, v1MarketGroupInformation.MarketGroupId);
            Assert.Equal(2, v1MarketGroupInformation.Types.Count);
            Assert.Equal(582, v1MarketGroupInformation.Types.First());
            Assert.Equal(1361, v1MarketGroupInformation.ParentGroupId);
        }

        [Fact]
        public void GetCharactersMarketOrders_successfully_returns_a_ListV2MarketCharactersOrders()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            MarketScopes scopes = MarketScopes.esi_markets_read_character_orders_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MarketScopesFlags = scopes };
            string getCharactersMarketOrderJson = "[{\"duration\": 30,\"escrow\": 45.6,\"is_buy_order\": true,\"is_corporation\": false,\"issued\": \"2016-09-03T05:12:25Z\",\"location_id\": 456,\"min_volume\": 1,\"order_id\": 123,\"price\": 33.3,\"range\": \"1\",\"region_id\": 123,\"type_id\": 456,\"volume_remain\": 4422,\"volume_total\": 123456}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersMarketOrderJson);

            InternalLatestMarket internalLatestMarket = new InternalLatestMarket(mockedWebClient.Object, string.Empty);

            IList<V2MarketCharactersOrders> getCharactersMarketOrders = internalLatestMarket.GetCharactersMarketOrders(inputToken);

            Assert.Equal(1, getCharactersMarketOrders.Count);
            Assert.Equal(30, getCharactersMarketOrders[0].Duration);
            Assert.Equal(45.6, getCharactersMarketOrders[0].Escrow);
            Assert.True( getCharactersMarketOrders[0].IsBuyOrder);
            Assert.False(getCharactersMarketOrders[0].IsCorporation);
            Assert.Equal(new DateTime(2016,09,03,05,12,25), getCharactersMarketOrders[0].Issued);
            Assert.Equal(456, getCharactersMarketOrders[0].LocationId);
            Assert.Equal(1, getCharactersMarketOrders[0].MinVolume);
            Assert.Equal(123, getCharactersMarketOrders[0].OrderId);
            Assert.Equal(33.3, getCharactersMarketOrders[0].Price);
            Assert.Equal(MarketRange.one, getCharactersMarketOrders[0].Range);
            Assert.Equal(123, getCharactersMarketOrders[0].RegionId);
            Assert.Equal(456, getCharactersMarketOrders[0].TypeId);
            Assert.Equal(4422, getCharactersMarketOrders[0].VolumeRemain);
            Assert.Equal(123456, getCharactersMarketOrders[0].VolumeTotal);
        }

        [Fact]
        public async Task GetCharactersMarketOrdersAsync_successfully_returns_a_ListV2MarketCharactersOrders()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            MarketScopes scopes = MarketScopes.esi_markets_read_character_orders_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MarketScopesFlags = scopes };
            string getCharactersMarketOrderJson = "[{\"duration\": 30,\"escrow\": 45.6,\"is_buy_order\": true,\"is_corporation\": false,\"issued\": \"2016-09-03T05:12:25Z\",\"location_id\": 456,\"min_volume\": 1,\"order_id\": 123,\"price\": 33.3,\"range\": \"1\",\"region_id\": 123,\"type_id\": 456,\"volume_remain\": 4422,\"volume_total\": 123456}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getCharactersMarketOrderJson);

            InternalLatestMarket internalLatestMarket = new InternalLatestMarket(mockedWebClient.Object, string.Empty);

            IList<V2MarketCharactersOrders> getCharactersMarketOrders = await internalLatestMarket.GetCharactersMarketOrdersAsync(inputToken);

            Assert.Equal(1, getCharactersMarketOrders.Count);
            Assert.Equal(30, getCharactersMarketOrders[0].Duration);
            Assert.Equal(45.6, getCharactersMarketOrders[0].Escrow);
            Assert.True(getCharactersMarketOrders[0].IsBuyOrder);
            Assert.False(getCharactersMarketOrders[0].IsCorporation);
            Assert.Equal(new DateTime(2016, 09, 03, 05, 12, 25), getCharactersMarketOrders[0].Issued);
            Assert.Equal(456, getCharactersMarketOrders[0].LocationId);
            Assert.Equal(1, getCharactersMarketOrders[0].MinVolume);
            Assert.Equal(123, getCharactersMarketOrders[0].OrderId);
            Assert.Equal(33.3, getCharactersMarketOrders[0].Price);
            Assert.Equal(MarketRange.one, getCharactersMarketOrders[0].Range);
            Assert.Equal(123, getCharactersMarketOrders[0].RegionId);
            Assert.Equal(456, getCharactersMarketOrders[0].TypeId);
            Assert.Equal(4422, getCharactersMarketOrders[0].VolumeRemain);
            Assert.Equal(123456, getCharactersMarketOrders[0].VolumeTotal);
        }

        [Fact]
        public void GetCharactersMarketHistoricOrders_successfully_returns_a_PagedModelV1MarketCharacterHistoricOrders()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            int page = 1;
            MarketScopes scopes = MarketScopes.esi_markets_read_character_orders_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MarketScopesFlags = scopes };
            string getCharactersHistoricMarketOrderJson = "[{\"duration\": 30,\"escrow\": 45.6,\"is_buy_order\": true,\"is_corporation\": false,\"issued\": \"2016-09-03T05:12:25Z\",\"location_id\": 456,\"min_volume\": 1,\"order_id\": 123,\"price\": 33.3,\"range\": \"1\",\"region_id\": 123,\"state\": \"expired\",\"type_id\": 456,\"volume_remain\": 4422,\"volume_total\": 123456}]";

            PagedJson pagedJson = new PagedJson{ Response = getCharactersHistoricMarketOrderJson, MaxPages = 2 };

            mockedWebClient.Setup(x => x.GetPaged(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(pagedJson);

            InternalLatestMarket internalLatestMarket = new InternalLatestMarket(mockedWebClient.Object, string.Empty);

            PagedModel<V1MarketCharacterHistoricOrders> getCharacterHistoricOrders = internalLatestMarket.GetCharactersMarketHistoricOrders(inputToken, page);

            Assert.Equal(2, getCharacterHistoricOrders.MaxPages);
            Assert.Equal(1, getCharacterHistoricOrders.CurrentPage);
            Assert.Equal(1, getCharacterHistoricOrders.Model.Count);
            Assert.Equal(30, getCharacterHistoricOrders.Model[0].Duration);
            Assert.Equal(45.6, getCharacterHistoricOrders.Model[0].Escrow);
            Assert.True(getCharacterHistoricOrders.Model[0].IsBuyOrder);
            Assert.False(getCharacterHistoricOrders.Model[0].IsCorporation);
            Assert.Equal(new DateTime(2016, 09, 03, 05, 12, 25), getCharacterHistoricOrders.Model[0].Issued);
            Assert.Equal(456, getCharacterHistoricOrders.Model[0].LocationId);
            Assert.Equal(1, getCharacterHistoricOrders.Model[0].MinVolume);
            Assert.Equal(123, getCharacterHistoricOrders.Model[0].OrderId);
            Assert.Equal(33.3, getCharacterHistoricOrders.Model[0].Price);
            Assert.Equal(MarketRange.one, getCharacterHistoricOrders.Model[0].Range);
            Assert.Equal(123, getCharacterHistoricOrders.Model[0].RegionId);
            Assert.Equal(MarketState.expired, getCharacterHistoricOrders.Model[0].State);
            Assert.Equal(456, getCharacterHistoricOrders.Model[0].TypeId);
            Assert.Equal(4422, getCharacterHistoricOrders.Model[0].VolumeRemain);
            Assert.Equal(123456, getCharacterHistoricOrders.Model[0].VolumeTotal);
        }

        [Fact]
        public async Task GetCharactersMarketHistoricOrdersAsync_successfully_returns_a_PagedModelV1MarketCharacterHistoricOrders()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            int page = 1;
            MarketScopes scopes = MarketScopes.esi_markets_read_character_orders_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MarketScopesFlags = scopes };
            string getCharactersHistoricMarketOrderJson = "[{\"duration\": 30,\"escrow\": 45.6,\"is_buy_order\": true,\"is_corporation\": false,\"issued\": \"2016-09-03T05:12:25Z\",\"location_id\": 456,\"min_volume\": 1,\"order_id\": 123,\"price\": 33.3,\"range\": \"1\",\"region_id\": 123,\"state\": \"expired\",\"type_id\": 456,\"volume_remain\": 4422,\"volume_total\": 123456}]";

            PagedJson pagedJson = new PagedJson { Response = getCharactersHistoricMarketOrderJson, MaxPages = 2 };

            mockedWebClient.Setup(x => x.GetPagedAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(pagedJson);

            InternalLatestMarket internalLatestMarket = new InternalLatestMarket(mockedWebClient.Object, string.Empty);

            PagedModel<V1MarketCharacterHistoricOrders> getCharacterHistoricOrders = await internalLatestMarket.GetCharactersMarketHistoricOrdersAsync(inputToken, page);

            Assert.Equal(2, getCharacterHistoricOrders.MaxPages);
            Assert.Equal(1, getCharacterHistoricOrders.CurrentPage);
            Assert.Equal(1, getCharacterHistoricOrders.Model.Count);
            Assert.Equal(30, getCharacterHistoricOrders.Model[0].Duration);
            Assert.Equal(45.6, getCharacterHistoricOrders.Model[0].Escrow);
            Assert.True(getCharacterHistoricOrders.Model[0].IsBuyOrder);
            Assert.False(getCharacterHistoricOrders.Model[0].IsCorporation);
            Assert.Equal(new DateTime(2016, 09, 03, 05, 12, 25), getCharacterHistoricOrders.Model[0].Issued);
            Assert.Equal(456, getCharacterHistoricOrders.Model[0].LocationId);
            Assert.Equal(1, getCharacterHistoricOrders.Model[0].MinVolume);
            Assert.Equal(123, getCharacterHistoricOrders.Model[0].OrderId);
            Assert.Equal(33.3, getCharacterHistoricOrders.Model[0].Price);
            Assert.Equal(MarketRange.one, getCharacterHistoricOrders.Model[0].Range);
            Assert.Equal(123, getCharacterHistoricOrders.Model[0].RegionId);
            Assert.Equal(MarketState.expired, getCharacterHistoricOrders.Model[0].State);
            Assert.Equal(456, getCharacterHistoricOrders.Model[0].TypeId);
            Assert.Equal(4422, getCharacterHistoricOrders.Model[0].VolumeRemain);
            Assert.Equal(123456, getCharacterHistoricOrders.Model[0].VolumeTotal);
        }
    }
}
