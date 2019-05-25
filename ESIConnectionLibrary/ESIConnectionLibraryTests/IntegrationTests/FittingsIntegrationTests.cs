using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class FittingsIntegrationTests
    {
        [Fact]
        public void Character_successfully_returns_a_list_of_fittings()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            FittingScopes scopes = FittingScopes.esi_fittings_read_fittings_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, FittingScopesFlags = scopes };

            LatestFittingsEndpoints internalLatestFittings = new LatestFittingsEndpoints(string.Empty, true);

            IList<V1FittingsCharacter> model = internalLatestFittings.Character(inputToken);

            Assert.Single(model);
            Assert.Equal("Awesome Vindi fitting", model[0].Description);
            Assert.Equal(1, model[0].FittingId);

            Assert.Single(model[0].Items);
            Assert.Equal(12, model[0].Items[0].Flag);
            Assert.Equal(1, model[0].Items[0].Quantity);
            Assert.Equal(1234, model[0].Items[0].TypeId);

            Assert.Equal("Best Vindicator", model[0].Name);
            Assert.Equal(123, model[0].ShipTypeId);
        }
        [Fact]
        public async Task CharacterAsync_successfully_returns_a_list_of_fittings()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            FittingScopes scopes = FittingScopes.esi_fittings_read_fittings_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, FittingScopesFlags = scopes };

            LatestFittingsEndpoints internalLatestFittings = new LatestFittingsEndpoints(string.Empty, true);

            IList<V1FittingsCharacter> model = await internalLatestFittings.CharacterAsync(inputToken);

            Assert.Single(model);
            Assert.Equal("Awesome Vindi fitting", model[0].Description);
            Assert.Equal(1, model[0].FittingId);

            Assert.Single(model[0].Items);
            Assert.Equal(12, model[0].Items[0].Flag);
            Assert.Equal(1, model[0].Items[0].Quantity);
            Assert.Equal(1234, model[0].Items[0].TypeId);

            Assert.Equal("Best Vindicator", model[0].Name);
            Assert.Equal(123, model[0].ShipTypeId);
        }
    }
}
