using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibrary.Tests.IntegrationTests
{
    public class MarketIntegrationTests
    {
        [Fact]
        public void CharacterOrders_successfully_returns_a_ListV2MarketCharactersOrders()
        {
            int characterId = 98772;
            MarketScopes scopes = MarketScopes.esi_markets_read_character_orders_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MarketScopesFlags = scopes };

            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            IList<V2MarketCharactersOrders> result = internalLatestMarket.CharacterOrders(inputToken);

            Assert.Equal(1, result.Count);
            Assert.Equal(30, result[0].Duration);
            Assert.Equal(45.6, result[0].Escrow);
            Assert.True(result[0].IsBuyOrder);
            Assert.False(result[0].IsCorporation);
            Assert.Equal(new DateTime(2016, 09, 03, 05, 12, 25), result[0].Issued);
            Assert.Equal(456, result[0].LocationId);
            Assert.Equal(1, result[0].MinVolume);
            Assert.Equal(123, result[0].OrderId);
            Assert.Equal(33.3, result[0].Price);
            Assert.Equal(MarketRange.Station, result[0].Range);
            Assert.Equal(123, result[0].RegionId);
            Assert.Equal(456, result[0].TypeId);
            Assert.Equal(4422, result[0].VolumeRemain);
            Assert.Equal(123456, result[0].VolumeTotal);
        }

        [Fact]
        public async Task CharacterOrdersAsync_successfully_returns_a_ListV2MarketCharactersOrders()
        {
            int characterId = 98772;
            MarketScopes scopes = MarketScopes.esi_markets_read_character_orders_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MarketScopesFlags = scopes };

            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            IList<V2MarketCharactersOrders> result = await internalLatestMarket.CharacterOrdersAsync(inputToken);

            Assert.Equal(1, result.Count);
            Assert.Equal(30, result[0].Duration);
            Assert.Equal(45.6, result[0].Escrow);
            Assert.True(result[0].IsBuyOrder);
            Assert.False(result[0].IsCorporation);
            Assert.Equal(new DateTime(2016, 09, 03, 05, 12, 25), result[0].Issued);
            Assert.Equal(456, result[0].LocationId);
            Assert.Equal(1, result[0].MinVolume);
            Assert.Equal(123, result[0].OrderId);
            Assert.Equal(33.3, result[0].Price);
            Assert.Equal(MarketRange.Station, result[0].Range);
            Assert.Equal(123, result[0].RegionId);
            Assert.Equal(456, result[0].TypeId);
            Assert.Equal(4422, result[0].VolumeRemain);
            Assert.Equal(123456, result[0].VolumeTotal);
        }

        [Fact]
        public void CharacterOrdersHistoric_successfully_returns_a_PagedModelV1MarketCharacterHistoricOrders()
        {
            int characterId = 98772;
            int page = 1;
            MarketScopes scopes = MarketScopes.esi_markets_read_character_orders_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MarketScopesFlags = scopes };

            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            PagedModel<V1MarketCharacterHistoricOrders> result = internalLatestMarket.CharacterOrdersHistoric(inputToken, page);

            Assert.Equal(1, result.Model.Count);
            Assert.Equal(30, result.Model[0].Duration);
            Assert.Equal(45.6, result.Model[0].Escrow);
            Assert.True(result.Model[0].IsBuyOrder);
            Assert.False(result.Model[0].IsCorporation);
            Assert.Equal(new DateTime(2016, 09, 03, 05, 12, 25), result.Model[0].Issued);
            Assert.Equal(456, result.Model[0].LocationId);
            Assert.Equal(1, result.Model[0].MinVolume);
            Assert.Equal(123, result.Model[0].OrderId);
            Assert.Equal(33.3, result.Model[0].Price);
            Assert.Equal(MarketRange.Station, result.Model[0].Range);
            Assert.Equal(123, result.Model[0].RegionId);
            Assert.Equal(MarketState.Expired, result.Model[0].State);
            Assert.Equal(456, result.Model[0].TypeId);
            Assert.Equal(4422, result.Model[0].VolumeRemain);
            Assert.Equal(123456, result.Model[0].VolumeTotal);
        }

        [Fact]
        public async Task CharacterOrdersHistoricAsync_successfully_returns_a_PagedModelV1MarketCharacterHistoricOrders()
        {
            int characterId = 98772;
            int page = 1;
            MarketScopes scopes = MarketScopes.esi_markets_read_character_orders_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MarketScopesFlags = scopes };

            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            PagedModel<V1MarketCharacterHistoricOrders> result = await internalLatestMarket.CharacterOrdersHistoricAsync(inputToken, page);

            Assert.Equal(1, result.Model.Count);
            Assert.Equal(30, result.Model[0].Duration);
            Assert.Equal(45.6, result.Model[0].Escrow);
            Assert.True(result.Model[0].IsBuyOrder);
            Assert.False(result.Model[0].IsCorporation);
            Assert.Equal(new DateTime(2016, 09, 03, 05, 12, 25), result.Model[0].Issued);
            Assert.Equal(456, result.Model[0].LocationId);
            Assert.Equal(1, result.Model[0].MinVolume);
            Assert.Equal(123, result.Model[0].OrderId);
            Assert.Equal(33.3, result.Model[0].Price);
            Assert.Equal(MarketRange.Station, result.Model[0].Range);
            Assert.Equal(123, result.Model[0].RegionId);
            Assert.Equal(MarketState.Expired, result.Model[0].State);
            Assert.Equal(456, result.Model[0].TypeId);
            Assert.Equal(4422, result.Model[0].VolumeRemain);
            Assert.Equal(123456, result.Model[0].VolumeTotal);
        }

        [Fact]
        public void CorporationOrders_successfully_returns_a_PagedModelV3MarketCorporationOrders()
        {
            int characterId = 98772;
            MarketScopes scopes = MarketScopes.esi_markets_read_corporation_orders_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MarketScopesFlags = scopes };

            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            PagedModel<V3MarketCorporationOrders> result = internalLatestMarket.CorporationOrders(inputToken, 1, 1);

            Assert.Equal(1, result.Model.Count);
            Assert.Equal(30, result.Model[0].Duration);
            Assert.Equal(45.6, result.Model[0].Escrow);
            Assert.True(result.Model[0].IsBuyOrder);
            Assert.Equal(new DateTime(2016, 09, 03, 05, 12, 25), result.Model[0].Issued);
            Assert.Equal(2112625428, result.Model[0].IssuedBy);
            Assert.Equal(456, result.Model[0].LocationId);
            Assert.Equal(1, result.Model[0].MinVolume);
            Assert.Equal(123, result.Model[0].OrderId);
            Assert.Equal(33.3, result.Model[0].Price);
            Assert.Equal(MarketRange.Station, result.Model[0].Range);
            Assert.Equal(123, result.Model[0].RegionId);
            Assert.Equal(456, result.Model[0].TypeId);
            Assert.Equal(4422, result.Model[0].VolumeRemain);
            Assert.Equal(123456, result.Model[0].VolumeTotal);
            Assert.Equal(1, result.Model[0].WalletDivision);
        }

        [Fact]
        public async Task CorporationOrdersAsync_successfully_returns_a_PagedModelV3MarketCorporationOrders()
        {
            int characterId = 98772;
            MarketScopes scopes = MarketScopes.esi_markets_read_corporation_orders_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MarketScopesFlags = scopes };

            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            PagedModel<V3MarketCorporationOrders> result = await internalLatestMarket.CorporationOrdersAsync(inputToken, 1, 1);

            Assert.Equal(1, result.Model.Count);
            Assert.Equal(30, result.Model[0].Duration);
            Assert.Equal(45.6, result.Model[0].Escrow);
            Assert.True(result.Model[0].IsBuyOrder);
            Assert.Equal(new DateTime(2016, 09, 03, 05, 12, 25), result.Model[0].Issued);
            Assert.Equal(2112625428, result.Model[0].IssuedBy);
            Assert.Equal(456, result.Model[0].LocationId);
            Assert.Equal(1, result.Model[0].MinVolume);
            Assert.Equal(123, result.Model[0].OrderId);
            Assert.Equal(33.3, result.Model[0].Price);
            Assert.Equal(MarketRange.Station, result.Model[0].Range);
            Assert.Equal(123, result.Model[0].RegionId);
            Assert.Equal(456, result.Model[0].TypeId);
            Assert.Equal(4422, result.Model[0].VolumeRemain);
            Assert.Equal(123456, result.Model[0].VolumeTotal);
            Assert.Equal(1, result.Model[0].WalletDivision);
        }

        [Fact]
        public void CorporationOrdersHistoric_successfully_returns_a_PagedModelV3MarketCorporationOrdersHistoric()
        {
            int characterId = 98772;
            MarketScopes scopes = MarketScopes.esi_markets_read_corporation_orders_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MarketScopesFlags = scopes };

            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            PagedModel<V3MarketCorporationOrdersHistoric> result = internalLatestMarket.CorporationOrdersHistoric(inputToken, 1, 1);

            Assert.Equal(1, result.Model.Count);
            Assert.Equal(30, result.Model[0].Duration);
            Assert.Equal(45.6, result.Model[0].Escrow);
            Assert.True(result.Model[0].IsBuyOrder);
            Assert.Equal(new DateTime(2016, 09, 03, 05, 12, 25), result.Model[0].Issued);
            Assert.Equal(2112625428, result.Model[0].IssuedBy);
            Assert.Equal(456, result.Model[0].LocationId);
            Assert.Equal(1, result.Model[0].MinVolume);
            Assert.Equal(123, result.Model[0].OrderId);
            Assert.Equal(33.3, result.Model[0].Price);
            Assert.Equal(MarketRange.Station, result.Model[0].Range);
            Assert.Equal(123, result.Model[0].RegionId);
            Assert.Equal(MarketState.Expired, result.Model[0].State);
            Assert.Equal(456, result.Model[0].TypeId);
            Assert.Equal(4422, result.Model[0].VolumeRemain);
            Assert.Equal(123456, result.Model[0].VolumeTotal);
            Assert.Equal(1, result.Model[0].WalletDivision);
        }

        [Fact]
        public async Task CorporationOrdersHistoricAsync_successfully_returns_a_PagedModelV3MarketCorporationOrdersHistoric()
        {
            int characterId = 98772;
            MarketScopes scopes = MarketScopes.esi_markets_read_corporation_orders_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MarketScopesFlags = scopes };

            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            PagedModel<V3MarketCorporationOrdersHistoric> result = await internalLatestMarket.CorporationOrdersHistoricAsync(inputToken, 1, 1);

            Assert.Equal(1, result.Model.Count);
            Assert.Equal(30, result.Model[0].Duration);
            Assert.Equal(45.6, result.Model[0].Escrow);
            Assert.True(result.Model[0].IsBuyOrder);
            Assert.Equal(new DateTime(2016, 09, 03, 05, 12, 25), result.Model[0].Issued);
            Assert.Equal(2112625428, result.Model[0].IssuedBy);
            Assert.Equal(456, result.Model[0].LocationId);
            Assert.Equal(1, result.Model[0].MinVolume);
            Assert.Equal(123, result.Model[0].OrderId);
            Assert.Equal(33.3, result.Model[0].Price);
            Assert.Equal(MarketRange.Station, result.Model[0].Range);
            Assert.Equal(123, result.Model[0].RegionId);
            Assert.Equal(MarketState.Expired, result.Model[0].State);
            Assert.Equal(456, result.Model[0].TypeId);
            Assert.Equal(4422, result.Model[0].VolumeRemain);
            Assert.Equal(123456, result.Model[0].VolumeTotal);
            Assert.Equal(1, result.Model[0].WalletDivision);
        }

        [Fact]
        public void History_successfully_returns_a_IListV1MarketHistory()
        {
            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            IList<V1MarketHistory> result = internalLatestMarket.History(1, 1);

            Assert.Equal(1, result.Count);
            Assert.Equal(5.25, result[0].Average);
            Assert.Equal(new DateTime(2015, 05, 01), result[0].Date);
            Assert.Equal(5.27, result[0].Highest);
            Assert.Equal(5.11, result[0].Lowest);
            Assert.Equal(2267, result[0].OrderCount);
            Assert.Equal(16276782035, result[0].Volume);
        }

        [Fact]
        public async Task HistoryAsync_successfully_returns_a_IListV1MarketHistory()
        {
            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            IList<V1MarketHistory> result = await internalLatestMarket.HistoryAsync(1, 1);

            Assert.Equal(1, result.Count);
            Assert.Equal(5.25, result[0].Average);
            Assert.Equal(new DateTime(2015, 05, 01), result[0].Date);
            Assert.Equal(5.27, result[0].Highest);
            Assert.Equal(5.11, result[0].Lowest);
            Assert.Equal(2267, result[0].OrderCount);
            Assert.Equal(16276782035, result[0].Volume);
        }

        [Fact]
        public void Orders_successfully_returns_a_PagedModelV1MarketOrders()
        {
            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            PagedModel<V1MarketOrders> result = internalLatestMarket.Orders(1, OrderType.All, 1, null);

            Assert.Equal(1, result.Model.Count);
            Assert.Equal(90, result.Model[0].Duration);
            Assert.False(result.Model[0].IsBuyOrder);
            Assert.Equal(new DateTime(2016, 09, 03, 05, 12, 25), result.Model[0].Issued);
            Assert.Equal(60005599, result.Model[0].LocationId);
            Assert.Equal(1, result.Model[0].MinVolume);
            Assert.Equal(4623824223, result.Model[0].OrderId);
            Assert.Equal(9.9, result.Model[0].Price);
            Assert.Equal(MarketRange.Region, result.Model[0].Range);
            Assert.Equal(30000053, result.Model[0].SystemId);
            Assert.Equal(34, result.Model[0].TypeId);
            Assert.Equal(1296000, result.Model[0].VolumeRemain);
            Assert.Equal(2000000, result.Model[0].VolumeTotal);
        }

        [Fact]
        public async Task OrdersAsync_successfully_returns_a_PagedModelV1MarketOrders()
        {
            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            PagedModel<V1MarketOrders> result = await internalLatestMarket.OrdersAsync(1, OrderType.All, 1, null);

            Assert.Equal(1, result.Model.Count);
            Assert.Equal(90, result.Model[0].Duration);
            Assert.False(result.Model[0].IsBuyOrder);
            Assert.Equal(new DateTime(2016, 09, 03, 05, 12, 25), result.Model[0].Issued);
            Assert.Equal(60005599, result.Model[0].LocationId);
            Assert.Equal(1, result.Model[0].MinVolume);
            Assert.Equal(4623824223, result.Model[0].OrderId);
            Assert.Equal(9.9, result.Model[0].Price);
            Assert.Equal(MarketRange.Region, result.Model[0].Range);
            Assert.Equal(30000053, result.Model[0].SystemId);
            Assert.Equal(34, result.Model[0].TypeId);
            Assert.Equal(1296000, result.Model[0].VolumeRemain);
            Assert.Equal(2000000, result.Model[0].VolumeTotal);
        }

        [Fact]
        public void Types_successfully_returns_a_PagedModelint()
        {
            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            PagedModel<int> result = internalLatestMarket.Types(1, 1);

            Assert.Equal(3, result.Model.Count);
            Assert.Equal(587, result.Model[0]);
            Assert.Equal(593, result.Model[1]);
            Assert.Equal(597, result.Model[2]);
        }

        [Fact]
        public async Task TypesAsync_successfully_returns_a_PagedModelint()
        {
            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            PagedModel<int> result = await internalLatestMarket.TypesAsync(1, 1);

            Assert.Equal(3, result.Model.Count);
            Assert.Equal(587, result.Model[0]);
            Assert.Equal(593, result.Model[1]);
            Assert.Equal(597, result.Model[2]);
        }

        [Fact]
        public void Groups_successfully_returns_a_IListint()
        {
            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            IList<int> result = internalLatestMarket.Groups();

            Assert.Equal(3, result.Count);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
        }

        [Fact]
        public async Task GroupsAsync_successfully_returns_a_IListint()
        {
            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            IList<int> result = await internalLatestMarket.GroupsAsync();

            Assert.Equal(3, result.Count);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
        }

        [Fact]
        public void GetMarketGroupInformation_Sucessfully_returns_a_MarketGroupInformation()
        {
            int marketGroupId = 8976562;

            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            V1MarketGroupInformation v1MarketGroupInformation = internalLatestMarket.Group(marketGroupId);

            Assert.Equal("Small, fast vessels suited to a variety of purposes.", v1MarketGroupInformation.Description);
            Assert.Equal(5, v1MarketGroupInformation.MarketGroupId);
            Assert.Equal("Standard Frigates", v1MarketGroupInformation.Name);
            Assert.Equal(1361, v1MarketGroupInformation.ParentGroupId);
            Assert.Equal(2, v1MarketGroupInformation.Types.Count);
            Assert.Equal(582, v1MarketGroupInformation.Types[0]);
            Assert.Equal(583, v1MarketGroupInformation.Types[1]);
        }

        [Fact]
        public async Task GetMarketGroupInformationAsync_Sucessfully_returns_a_MarketGroupInformation()
        {
            int marketGroupId = 8976562;

            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            V1MarketGroupInformation v1MarketGroupInformation = await internalLatestMarket.GroupAsync(marketGroupId);

            Assert.Equal("Small, fast vessels suited to a variety of purposes.", v1MarketGroupInformation.Description);
            Assert.Equal(5, v1MarketGroupInformation.MarketGroupId);
            Assert.Equal("Standard Frigates", v1MarketGroupInformation.Name);
            Assert.Equal(1361, v1MarketGroupInformation.ParentGroupId);
            Assert.Equal(2, v1MarketGroupInformation.Types.Count);
            Assert.Equal(582, v1MarketGroupInformation.Types[0]);
            Assert.Equal(583, v1MarketGroupInformation.Types[1]);
        }

        [Fact]
        public void Prices_successfully_returns_a_IListV1MarketPrice()
        {
            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            IList<V1MarketPrice> result = internalLatestMarket.Prices();

            Assert.Equal(1, result.Count);
            Assert.Equal(306988.09, result[0].AdjustedPrice);
            Assert.Equal(306292.67, result[0].AveragePrice);
            Assert.Equal(32772, result[0].TypeId);
        }

        [Fact]
        public async Task PricesAsync_successfully_returns_a_IListV1MarketPrice()
        {
            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            IList<V1MarketPrice> result = await internalLatestMarket.PricesAsync();

            Assert.Equal(1, result.Count);
            Assert.Equal(306988.09, result[0].AdjustedPrice);
            Assert.Equal(306292.67, result[0].AveragePrice);
            Assert.Equal(32772, result[0].TypeId);
        }

        [Fact]
        public void Structure_successfully_returns_a_PagedModelV1MarketStructure()
        {
            int characterId = 98772;
            MarketScopes scopes = MarketScopes.esi_markets_structure_markets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MarketScopesFlags = scopes };

            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            PagedModel<V1MarketStructure> result = internalLatestMarket.Structure(inputToken, 1, 1);

            Assert.Equal(1, result.Model.Count);
            Assert.Equal(90, result.Model[0].Duration);
            Assert.False(result.Model[0].IsBuyOrder);
            Assert.Equal(new DateTime(2016, 09, 03, 05, 12, 25), result.Model[0].Issued);
            Assert.Equal(1020988381992, result.Model[0].LocationId);
            Assert.Equal(1, result.Model[0].MinVolume);
            Assert.Equal(4623824223, result.Model[0].OrderId);
            Assert.Equal(9.9, result.Model[0].Price);
            Assert.Equal(MarketRange.Region, result.Model[0].Range);
            Assert.Equal(34, result.Model[0].TypeId);
            Assert.Equal(1296000, result.Model[0].VolumeRemain);
            Assert.Equal(2000000, result.Model[0].VolumeTotal);
        }

        [Fact]
        public async Task StructureAsync_successfully_returns_a_PagedModelV1MarketStructure()
        {
            int characterId = 98772;
            MarketScopes scopes = MarketScopes.esi_markets_structure_markets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MarketScopesFlags = scopes };

            LatestMarketEndpoints internalLatestMarket = new LatestMarketEndpoints(string.Empty, true);

            PagedModel<V1MarketStructure> result = await internalLatestMarket.StructureAsync(inputToken, 1, 1);

            Assert.Equal(1, result.Model.Count);
            Assert.Equal(90, result.Model[0].Duration);
            Assert.False(result.Model[0].IsBuyOrder);
            Assert.Equal(new DateTime(2016, 09, 03, 05, 12, 25), result.Model[0].Issued);
            Assert.Equal(1020988381992, result.Model[0].LocationId);
            Assert.Equal(1, result.Model[0].MinVolume);
            Assert.Equal(4623824223, result.Model[0].OrderId);
            Assert.Equal(9.9, result.Model[0].Price);
            Assert.Equal(MarketRange.Region, result.Model[0].Range);
            Assert.Equal(34, result.Model[0].TypeId);
            Assert.Equal(1296000, result.Model[0].VolumeRemain);
            Assert.Equal(2000000, result.Model[0].VolumeTotal);
        }
    }
}
