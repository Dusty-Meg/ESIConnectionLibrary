using System;
using System.Net;
using ESIConnectionLibrary.Exceptions;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibrary.Tests
{
    public class AuthenticationTests
    {
        [Fact]
        public void MakeToken_successfully_returns_a_SsoLogicToken()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IkpXVC1TaWduYXR1cmUtS2V5IiwidHlwIjoiSldUIn0.eyJzY3AiOlsiZXNpLXNraWxscy5yZWFkX3NraWxscy52MSIsImVzaS1za2lsbHMucmVhZF9za2lsbHF1ZXVlLnYxIiwiZXNpLXVpLm9wZW5fd2luZG93LnYxIiwiZXNpLW1hcmtldHMuc3RydWN0dXJlX21hcmtldHMudjEiLCJlc2ktaW5kdXN0cnkucmVhZF9jaGFyYWN0ZXJfam9icy52MSIsImVzaS1jaGFyYWN0ZXJzLnJlYWRfYmx1ZXByaW50cy52MSJdLCJqdGkiOiJjMWJjY2I0Ni1iNzdlLTRjMDUtOTIxYy1jODA0MGExNGJmNDciLCJraWQiOiJKV1QtU2lnbmF0dXJlLUtleSIsInN1YiI6IkNIQVJBQ1RFUjpFVkU6OTU2NjQyNDgwIiwiYXpwIjoiNGQzYmRkYmE3MjA4NDhkMjg1YTNiZjQwZWM4ZDQ2YWYiLCJuYW1lIjoiRHVzdHkgTWVnIiwib3duZXIiOiJZOWRPbm1vWDk4RkZ4bSs3QUc4N1BRQTk5U289IiwiZXhwIjoxNTU5Njc4Mzk0LCJpc3MiOiJsb2dpbi5ldmVvbmxpbmUuY29tIn0.GzMyNAm91zpngql_5EWDgjDcmM2ahgPSaWOLSRpsdKen1KtLMddJqXfJAhKh5807j82TJXOqGedKUJ-tAXt3yA7u0KS0bTbraAiQCNMxeMiCq9ha6_kR-wujGbS-0BxKQyr5CtN7h8hbQ9zKmPwPXBHFLBRZY4QfedNKHFbCcDgoKXfr5T6YMP7GdPvbeemlmNXjw4JsJTP0IadzrAR8ShyPqV8J2aTC0pWeyzgX9nJEu-3m6yeXcxghOlcE0nmDjs9hT_yb2iQB1ejQcDhy2PUoe-4V5mvy95nDDhCg1-Y5ojR_3No1MMjCmXhb20vVV4KXxap15WkOPW3_LBqIlg";
            string refreshToken = "ThisIsARefreshToken";
            int characterId = 956642480;
            string characterName = "Dusty Meg";
            string tokenJson = "{\"access_token\":\"" + accessToken + "\",\"token_type\":\"Bearer\",\"expires_in\":1200,\"refresh_token\":\"" + refreshToken + "\"}";
            Guid userId = Guid.NewGuid();

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), "https://login.eveonline.com/v2/oauth/token/", It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = tokenJson });

            InternalAuthentication internalAuthentication = new InternalAuthentication(mockedWebClient.Object, string.Empty);

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

            InternalAuthentication internalAuthentication = new InternalAuthentication(mockedWebClient.Object, string.Empty);

            Exception ex = Assert.Throws<EsiException>(() => internalAuthentication.MakeToken(null, null, userId));

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

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), "https://login.eveonline.com/v2/oauth/token/", It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = tokenJson });

            InternalAuthentication internalAuthentication = new InternalAuthentication(mockedWebClient.Object, string.Empty);

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName };

            SsoToken token = internalAuthentication.RefreshToken(inputToken, "Blah");

            Assert.Equal(token.AccessToken, accessToken);
            Assert.Equal(token.RefreshToken, refreshToken);
        }

        [Fact]
        public void Passing_in_a_null_as_token_to_RefreshToken_will_be_caught_successfully()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            InternalAuthentication internalAuthentication = new InternalAuthentication(mockedWebClient.Object, string.Empty);

            Exception ex = Assert.Throws<EsiException>(() => internalAuthentication.RefreshToken(null, null));

            Assert.Equal("Token or EVESSOKey is null or empty", ex.Message);
            Assert.Null(ex.InnerException);
        }
    }
}
