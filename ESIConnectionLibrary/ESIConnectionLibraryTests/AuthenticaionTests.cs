using System;
using System.Net;
using ESIConnectionLibrary.Exceptions;
using Moq;
using Xunit;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibraryTests
{
    public class AuthenticaionTests
    {
        [Fact]
        public void MakeToken_successfully_returns_a_SsoLogicToken()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string accessToken = "ThisIsAToken";
            string refreshToken = "ThisIsARefreshToken";
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            string tokenJson = "{\"access_token\":\"" + accessToken + "\",\"token_type\":\"Bearer\",\"expires_in\":1200,\"refresh_token\":\"" + refreshToken + "\"}";
            string verifyJson = "{\"CharacterID\":" + characterId + ",\"CharacterName\": \"" + characterName + "\",\"ExpiresOn\": \"2014-05-23T15:01:15.182864Z\",\"Scopes\": \" \",\"TokenType\": \"Character\",\"CharacterOwnerHash\": \"ThisIsAHash = \"}";
            Guid userId = Guid.NewGuid();

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), "https://login-tq.eveonline.com/oauth/token/", It.IsAny<string>(), It.IsAny<int>())).Returns(tokenJson);
            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), "https://login.eveonline.com/oauth/verify", It.IsAny<int>())).Returns(verifyJson);

            InternalAuthentication internalAuthentication = new InternalAuthentication(mockedWebClient.Object);

            SsoToken token = internalAuthentication.MakeToken("Blah", "blahblah", userId);

            Assert.Equal(token.AccessToken, accessToken);
            Assert.Equal(token.CharacterId, characterId);
            Assert.Equal(token.CharacterName, characterName);
            Assert.Equal(token.RefreshToken, refreshToken);
        }

        [Fact]
        public void Passing_in_a_null_as_code_and_evessokey_to_MakeToken_will_be_caught_successfully()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            Guid userId = Guid.NewGuid();

            InternalAuthentication internalAuthentication = new InternalAuthentication(mockedWebClient.Object);

            Exception ex = Assert.Throws<ESIException>(() => internalAuthentication.MakeToken(null, null, userId));

            Assert.Equal("Code or EVESSOKey is null or empty", ex.Message);
            Assert.Null(ex.InnerException);
        }

        [Fact]
        public void RefreshToken_successfully_returns_a_SsoLogicToken()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string accessToken = "ThisIsAToken";
            string refreshToken = "ThisIsARefreshToken";
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            string tokenJson = "{\"access_token\":\"" + accessToken + "\",\"token_type\":\"Bearer\",\"expires_in\":1200,\"refresh_token\":\"" + refreshToken + "\"}";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), "https://login-tq.eveonline.com/oauth/token/", It.IsAny<string>(), It.IsAny<int>())).Returns(tokenJson);

            InternalAuthentication internalAuthentication = new InternalAuthentication(mockedWebClient.Object);

            SsoToken inputToken = new SsoToken {AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName};

            SsoToken token = internalAuthentication.RefreshToken(inputToken, "Blah");

            Assert.Equal(token.AccessToken, accessToken);
            Assert.Equal(token.RefreshToken, refreshToken);
        }

        [Fact]
        public void Passing_in_a_null_as_token_to_RefreshToken_will_be_caught_successfully()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            InternalAuthentication internalAuthentication = new InternalAuthentication(mockedWebClient.Object);

            Exception ex = Assert.Throws<ESIException>(() => internalAuthentication.RefreshToken(null, null));

            Assert.Equal("Token or EVESSOKey is null or empty", ex.Message);
            Assert.Null(ex.InnerException);
        }

        //[Fact]
        public void Test()
        {
            InternalAuthentication internalAuthentication = new InternalAuthentication(null);

            internalAuthentication.MakeToken("test", "test", Guid.Empty);
        }
    }
}
