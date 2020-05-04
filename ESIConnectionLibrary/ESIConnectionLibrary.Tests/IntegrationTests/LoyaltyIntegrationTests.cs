using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibrary.Tests.IntegrationTests
{
    public class LoyaltyIntegrationTests
    {
        [Fact]
        public void Points_successfully_returns_a_listV1LoyaltyPoint()
        {
            int characterId = 8976562;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_loyalty_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestLoyaltyEndpoints internalLatestLoyalty = new LatestLoyaltyEndpoints(string.Empty, true);

            IList<V1LoyaltyPoint> returnModel = internalLatestLoyalty.Points(inputToken);

            Assert.NotNull(returnModel);

            Assert.Single(returnModel);

            Assert.Equal(123, returnModel[0].CorporationId);
            Assert.Equal(100, returnModel[0].LoyaltyPoints);
        }

        [Fact]
        public async Task PointsAsync_successfully_returns_a_listV1LoyaltyPoint()
        {
            int characterId = 8976562;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_loyalty_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestLoyaltyEndpoints internalLatestLoyalty = new LatestLoyaltyEndpoints(string.Empty, true);

            IList<V1LoyaltyPoint> returnModel = await internalLatestLoyalty.PointsAsync(inputToken);

            Assert.NotNull(returnModel);

            Assert.Single(returnModel);

            Assert.Equal(123, returnModel[0].CorporationId);
            Assert.Equal(100, returnModel[0].LoyaltyPoints);
        }

        [Fact]
        public void Offers_successfully_returns_a_listV1LoyaltyOffer()
        {
            LatestLoyaltyEndpoints internalLatestLoyalty = new LatestLoyaltyEndpoints(string.Empty, true);

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
            LatestLoyaltyEndpoints internalLatestLoyalty = new LatestLoyaltyEndpoints(string.Empty, true);

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
