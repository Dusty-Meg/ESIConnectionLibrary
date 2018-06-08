using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class MarketIntegrationTests
    {
        [Fact]
        public void GetMarketGroupInformation_Sucessfully_returns_a_MarketGroupInformation()
        {
            int marketGroupId = 8976562;

            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            V1MarketGroupInformation v1MarketGroupInformation = internalLatestMarket.GetMarketGroupInformation(marketGroupId);

            Assert.Equal(5, v1MarketGroupInformation.MarketGroupId);
            Assert.Equal(2, v1MarketGroupInformation.Types.Count);
            Assert.Equal(582, v1MarketGroupInformation.Types.First());
            Assert.Equal(1361, v1MarketGroupInformation.ParentGroupId);
        }

        [Fact]
        public async Task GetMarketGroupInformationAsync_Sucessfully_returns_a_MarketGroupInformation()
        {
            int marketGroupId = 8976562;

            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            V1MarketGroupInformation v1MarketGroupInformation = await internalLatestMarket.GetMarketGroupInformationAsync(marketGroupId);

            Assert.Equal(5, v1MarketGroupInformation.MarketGroupId);
            Assert.Equal(2, v1MarketGroupInformation.Types.Count);
            Assert.Equal(582, v1MarketGroupInformation.Types.First());
            Assert.Equal(1361, v1MarketGroupInformation.ParentGroupId);
        }

        [Fact]
        public void GetCharactersMarketOrders_successfully_returns_a_ListV2MarketCharactersOrders()
        {
            int characterId = 98772;
            MarketScopes scopes = MarketScopes.esi_markets_read_character_orders_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MarketScopesFlags = scopes };

            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            IList<V2MarketCharactersOrders> getCharactersMarketOrders = internalLatestMarket.GetCharactersMarketOrders(inputToken);

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
            Assert.Equal(MarketRange.station, getCharactersMarketOrders[0].Range);
            Assert.Equal(123, getCharactersMarketOrders[0].RegionId);
            Assert.Equal(456, getCharactersMarketOrders[0].TypeId);
            Assert.Equal(4422, getCharactersMarketOrders[0].VolumeRemain);
            Assert.Equal(123456, getCharactersMarketOrders[0].VolumeTotal);
        }

        [Fact]
        public async Task GetCharactersMarketOrdersAsync_successfully_returns_a_ListV2MarketCharactersOrders()
        {
            int characterId = 98772;
            MarketScopes scopes = MarketScopes.esi_markets_read_character_orders_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MarketScopesFlags = scopes };

            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

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
            Assert.Equal(MarketRange.station, getCharactersMarketOrders[0].Range);
            Assert.Equal(123, getCharactersMarketOrders[0].RegionId);
            Assert.Equal(456, getCharactersMarketOrders[0].TypeId);
            Assert.Equal(4422, getCharactersMarketOrders[0].VolumeRemain);
            Assert.Equal(123456, getCharactersMarketOrders[0].VolumeTotal);
        }

        [Fact]
        public void GetCharactersMarketHistoricOrders_successfully_returns_a_PagedModelV1MarketCharacterHistoricOrders()
        {
            int characterId = 98772;
            int page = 1;
            MarketScopes scopes = MarketScopes.esi_markets_read_character_orders_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MarketScopesFlags = scopes };

            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            PagedModel<V1MarketCharacterHistoricOrders> getCharacterHistoricOrders = internalLatestMarket.GetCharactersMarketHistoricOrders(inputToken, page);

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
            Assert.Equal(MarketRange.station, getCharacterHistoricOrders.Model[0].Range);
            Assert.Equal(123, getCharacterHistoricOrders.Model[0].RegionId);
            Assert.Equal(MarketState.expired, getCharacterHistoricOrders.Model[0].State);
            Assert.Equal(456, getCharacterHistoricOrders.Model[0].TypeId);
            Assert.Equal(4422, getCharacterHistoricOrders.Model[0].VolumeRemain);
            Assert.Equal(123456, getCharacterHistoricOrders.Model[0].VolumeTotal);
        }

        [Fact]
        public async Task GetCharactersMarketHistoricOrdersAsync_successfully_returns_a_PagedModelV1MarketCharacterHistoricOrders()
        {
            int characterId = 98772;
            int page = 1;
            MarketScopes scopes = MarketScopes.esi_markets_read_character_orders_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MarketScopesFlags = scopes };

            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            PagedModel<V1MarketCharacterHistoricOrders> getCharacterHistoricOrders = await internalLatestMarket.GetCharactersMarketHistoricOrdersAsync(inputToken, page);

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
            Assert.Equal(MarketRange.station, getCharacterHistoricOrders.Model[0].Range);
            Assert.Equal(123, getCharacterHistoricOrders.Model[0].RegionId);
            Assert.Equal(MarketState.expired, getCharacterHistoricOrders.Model[0].State);
            Assert.Equal(456, getCharacterHistoricOrders.Model[0].TypeId);
            Assert.Equal(4422, getCharacterHistoricOrders.Model[0].VolumeRemain);
            Assert.Equal(123456, getCharacterHistoricOrders.Model[0].VolumeTotal);
        }
    }
}
