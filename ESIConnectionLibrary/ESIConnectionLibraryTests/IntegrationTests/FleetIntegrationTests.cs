using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class FleetIntegrationTests
    {
        [Fact]
        public void GetFleet_successfully_returns_a_Fleet()
        {

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            FleetScopes scopes = FleetScopes.esi_fleets_read_fleet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, FleetScopesFlags = scopes };
 
            LatestFleetsEndpoints internalLatestFleets = new LatestFleetsEndpoints(string.Empty, true);

            V1GetFleet v1GetFleet = internalLatestFleets.GetFleet(inputToken, long.MinValue);

            Assert.False(v1GetFleet.IsFreeMove);
            Assert.False(v1GetFleet.IsRegistered);
            Assert.False(v1GetFleet.IsVoiceEnabled);
        }

        [Fact]
        public async Task GetFleetAsync_successfully_returns_a_Fleet()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            FleetScopes scopes = FleetScopes.esi_fleets_read_fleet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, FleetScopesFlags = scopes };

            LatestFleetsEndpoints internalLatestFleets = new LatestFleetsEndpoints(string.Empty, true);

            V1GetFleet v1GetFleet = await internalLatestFleets.GetFleetAsync(inputToken, long.MinValue);

            Assert.False(v1GetFleet.IsFreeMove);
            Assert.False(v1GetFleet.IsRegistered);
            Assert.False(v1GetFleet.IsVoiceEnabled);
        }
    }
}
