using System;
using System.Net;
using ESIConnectionLibrary.Exceptions;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class FleetsTests
    {
        [Fact]
        public void GetFleet_successfully_returns_a_Fleet()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            FleetScopes scopes = FleetScopes.esi_fleets_read_fleet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, FleetScopesFlags = scopes };
            string getFleetsJson = "{\"is_free_move\": false,\"is_registered\": false,\"is_voice_enabled\": false,\"motd\": \"This is an <b>awesome</b> fleet!\"}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getFleetsJson);

            InternalLatestFleets internalLatestFleets = new InternalLatestFleets(mockedWebClient.Object, string.Empty);

            V1GetFleet v1GetFleet = internalLatestFleets.GetFleet(inputToken, long.MinValue);

            Assert.False(v1GetFleet.IsFreeMove);
            Assert.False(v1GetFleet.IsRegistered);
            Assert.False(v1GetFleet.IsVoiceEnabled);
        }

        [Fact]
        public void Passing_in_a_null_as_token_to_GetSkillQueue_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            InternalLatestFleets internalLatestFleets = new InternalLatestFleets(mockedWebClient.Object, string.Empty);

            Exception ex = Assert.Throws<ESIException>(() => internalLatestFleets.GetFleet(null, long.MinValue));

            Assert.Equal("Token can not be null", ex.Message);
            Assert.Null(ex.InnerException);
        }

        [Fact]
        public void Passing_in_a_token_without_the_needed_scope_to_GetSkillQueue_will_be_handled_correctly()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            SsoToken inputToken = new SsoToken();

            InternalLatestFleets internalLatestFleets = new InternalLatestFleets(mockedWebClient.Object, string.Empty);

            Exception ex = Assert.Throws<ESIException>(() => internalLatestFleets.GetFleet(inputToken, long.MinValue));

            Assert.Equal("This token does not have esi_fleets_read_fleet_v1 it has: None", ex.Message);
            Assert.Null(ex.InnerException);
        }
    }
}
