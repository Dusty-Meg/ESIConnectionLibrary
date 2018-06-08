using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class CloneIntergrationTests
    {
        [Fact]
        public void GetCharactersClones_successfully_returns_a_charactersClones()
        {
            CloneScopes scopes = CloneScopes.esi_clones_read_clones_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 828658, CharacterName = "ThisIsACharacter", CloneScopesFlags = scopes };

            LatestCloneEndpoints internalLatestClones = new LatestCloneEndpoints(string.Empty, true);

            V3CharactersClones getClones = internalLatestClones.GetCharactersClones(inputToken);

            Assert.Equal(1021348135816, getClones.HomeLocation.LocationId);
            Assert.Equal(V3CharactersClonesLocationType.structure, getClones.HomeLocation.LocationType);
            Assert.Equal(22118, getClones.JumpClones.First().Implants.First());
            Assert.Equal(12345, getClones.JumpClones.First().JumpCloneId);
            Assert.Equal(60003463, getClones.JumpClones.First().LocationId);
            Assert.Equal(V3CharactersClonesLocationType.station, getClones.JumpClones.First().LocationType);
        }

        [Fact]
        public async Task GetCharactersClonesAsync_successfully_returns_a_charactersClones()
        {
            CloneScopes scopes = CloneScopes.esi_clones_read_clones_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 828658, CharacterName = "ThisIsACharacter", CloneScopesFlags = scopes };

            LatestCloneEndpoints internalLatestClones = new LatestCloneEndpoints(string.Empty, true);

            V3CharactersClones getClones = await internalLatestClones.GetCharactersClonesAsync(inputToken);

            Assert.Equal(1021348135816, getClones.HomeLocation.LocationId);
            Assert.Equal(V3CharactersClonesLocationType.structure, getClones.HomeLocation.LocationType);
            Assert.Equal(22118, getClones.JumpClones.First().Implants.First());
            Assert.Equal(12345, getClones.JumpClones.First().JumpCloneId);
            Assert.Equal(60003463, getClones.JumpClones.First().LocationId);
            Assert.Equal(V3CharactersClonesLocationType.station, getClones.JumpClones.First().LocationType);
        }

        [Fact]
        public void GetCharactersActiveImplants_successfully_returns_a_listInt()
        {
            CloneScopes scopes = CloneScopes.esi_clones_read_implants_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 828658, CharacterName = "ThisIsACharacter", CloneScopesFlags = scopes };

            LatestCloneEndpoints internalLatestClones = new LatestCloneEndpoints(string.Empty, true);

            IList<int> getImplants = internalLatestClones.GetCharactersActiveImplants(inputToken);

            Assert.Equal(1, getImplants[0]);
            Assert.Equal(2, getImplants[1]);
            Assert.Equal(3, getImplants[2]);
        }

        [Fact]
        public async Task GetCharactersActiveImplantsAsync_successfully_returns_a_listInt()
        {
            CloneScopes scopes = CloneScopes.esi_clones_read_implants_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 828658, CharacterName = "ThisIsACharacter", CloneScopesFlags = scopes };

            LatestCloneEndpoints internalLatestClones = new LatestCloneEndpoints(string.Empty, true);

            IList<int> getImplants = await internalLatestClones.GetCharactersActiveImplantsAsync(inputToken);

            Assert.Equal(1, getImplants[0]);
            Assert.Equal(2, getImplants[1]);
            Assert.Equal(3, getImplants[2]);
        }
    }
}
