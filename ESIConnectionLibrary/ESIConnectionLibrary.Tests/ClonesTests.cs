using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibrary.Tests
{
    public class ClonesTests
    {
        [Fact]
        public void Clones_successfully_returns_a_charactersClones()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            CloneScopes scopes = CloneScopes.esi_clones_read_clones_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 828658, CharacterName = "ThisIsACharacter", CloneScopesFlags = scopes };
            string json = "{\r\n  \"home_location\": {\r\n    \"location_id\": 1021348135816,\r\n    \"location_type\": \"structure\"\r\n  },\r\n  \"jump_clones\": [\r\n    {\r\n      \"implants\": [\r\n        22118\r\n      ],\r\n      \"jump_clone_id\": 12345,\r\n      \"location_id\": 60003463,\r\n      \"location_type\": \"station\"\r\n    }\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestClones internalLatestClones = new InternalLatestClones(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            CloneScopes scopes = CloneScopes.esi_clones_read_clones_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 828658, CharacterName = "ThisIsACharacter", CloneScopesFlags = scopes };
            string json = "{\"home_location\": {\"location_id\": 1021348135816,\"location_type\": \"structure\"},\"jump_clones\": [{\"implants\": [22118],\"jump_clone_id\": 12345,\"location_id\": 60003463,\"location_type\": \"station\"}]}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestClones internalLatestClones = new InternalLatestClones(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            CloneScopes scopes = CloneScopes.esi_clones_read_implants_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 828658, CharacterName = "ThisIsACharacter", CloneScopesFlags = scopes };
            string json = "[\r\n  1,\r\n  2,\r\n  3\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestClones internalLatestClones = new InternalLatestClones(mockedWebClient.Object, string.Empty);

            IList<int> getImplants = internalLatestClones.ActiveImplants(inputToken);

            Assert.Equal(1, getImplants[0]);
            Assert.Equal(2, getImplants[1]);
            Assert.Equal(3, getImplants[2]);
        }

        [Fact]
        public async Task ActiveImplantsAsync_successfully_returns_a_listInt()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            CloneScopes scopes = CloneScopes.esi_clones_read_implants_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 828658, CharacterName = "ThisIsACharacter", CloneScopesFlags = scopes };
            string json = "[\r\n  1,\r\n  2,\r\n  3\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestClones internalLatestClones = new InternalLatestClones(mockedWebClient.Object, string.Empty);

            IList<int> getImplants = await internalLatestClones.ActiveImplantsAsync(inputToken);

            Assert.Equal(1, getImplants[0]);
            Assert.Equal(2, getImplants[1]);
            Assert.Equal(3, getImplants[2]);
        }
    }
}
