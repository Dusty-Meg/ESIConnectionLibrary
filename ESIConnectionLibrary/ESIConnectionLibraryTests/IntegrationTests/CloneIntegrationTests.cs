using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class CloneIntegrationTests
    {
        [Fact]
        public void Clones_successfully_returns_a_charactersClones()
        {
            CloneScopes scopes = CloneScopes.esi_clones_read_clones_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 828658, CharacterName = "ThisIsACharacter", CloneScopesFlags = scopes };

            LatestCloneEndpoints internalLatestClones = new LatestCloneEndpoints(string.Empty, true);

            V3ClonesClone getClonesClone = internalLatestClones.Clones(inputToken);

            Assert.Equal(1021348135816, getClonesClone.HomeLocation.LocationId);
            Assert.Equal(V3ClonesLocationType.Structure, getClonesClone.HomeLocation.LocationType);
            Assert.Equal(22118, getClonesClone.JumpClones.First().Implants.First());
            Assert.Equal(12345, getClonesClone.JumpClones.First().JumpCloneId);
            Assert.Equal(60003463, getClonesClone.JumpClones.First().LocationId);
            Assert.Equal(V3ClonesLocationType.Station, getClonesClone.JumpClones.First().LocationType);
        }

        [Fact]
        public async Task ClonesAsync_successfully_returns_a_charactersClones()
        {
            CloneScopes scopes = CloneScopes.esi_clones_read_clones_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 828658, CharacterName = "ThisIsACharacter", CloneScopesFlags = scopes };

            LatestCloneEndpoints internalLatestClones = new LatestCloneEndpoints(string.Empty, true);

            V3ClonesClone getClonesClone = await internalLatestClones.ClonesAsync(inputToken);

            Assert.Equal(1021348135816, getClonesClone.HomeLocation.LocationId);
            Assert.Equal(V3ClonesLocationType.Structure, getClonesClone.HomeLocation.LocationType);
            Assert.Equal(22118, getClonesClone.JumpClones.First().Implants.First());
            Assert.Equal(12345, getClonesClone.JumpClones.First().JumpCloneId);
            Assert.Equal(60003463, getClonesClone.JumpClones.First().LocationId);
            Assert.Equal(V3ClonesLocationType.Station, getClonesClone.JumpClones.First().LocationType);
        }

        [Fact]
        public void ActiveImplants_successfully_returns_a_listInt()
        {
            CloneScopes scopes = CloneScopes.esi_clones_read_implants_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 828658, CharacterName = "ThisIsACharacter", CloneScopesFlags = scopes };

            LatestCloneEndpoints internalLatestClones = new LatestCloneEndpoints(string.Empty, true);

            IList<int> getImplants = internalLatestClones.ActiveImplants(inputToken);

            Assert.Equal(1, getImplants[0]);
            Assert.Equal(2, getImplants[1]);
            Assert.Equal(3, getImplants[2]);
        }

        [Fact]
        public async Task ActiveImplantsAsync_successfully_returns_a_listInt()
        {
            CloneScopes scopes = CloneScopes.esi_clones_read_implants_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 828658, CharacterName = "ThisIsACharacter", CloneScopesFlags = scopes };

            LatestCloneEndpoints internalLatestClones = new LatestCloneEndpoints(string.Empty, true);

            IList<int> getImplants = await internalLatestClones.ActiveImplantsAsync(inputToken);

            Assert.Equal(1, getImplants[0]);
            Assert.Equal(2, getImplants[1]);
            Assert.Equal(3, getImplants[2]);
        }
    }
}
