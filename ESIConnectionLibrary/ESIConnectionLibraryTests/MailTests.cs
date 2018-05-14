using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class MailTests
    {
        [Fact]
        public void GetCharactersMail_successfully_return_a_pagedModelV1MailGetCharactersMail()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int lastId = 222222;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };
            string getCharacterMailJson = "[{\"from\": 90000001,\"is_read\": true,\"labels\": [3],\"mail_id\": 7,\"recipients\": [{\"recipient_id\": 90000002,\"recipient_type\": \"character\"}],\"subject\": \"Title for EVE Mail\",\"timestamp\": \"2015-09-30T16:07:00Z\"}]";

            PagedJson pagedJson = new PagedJson { Response = getCharacterMailJson };

            mockedWebClient.Setup(x => x.GetPaged(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(pagedJson);

            InternalLatestMail internalLatestMail = new InternalLatestMail(mockedWebClient.Object, string.Empty);

            PagedModel<V1MailGetCharactersMail> getCharacterMail = internalLatestMail.GetCharactersMail(inputToken, lastId);

            Assert.Equal(1, getCharacterMail.Model.Count);
            Assert.Equal(MailRecipientType.character, getCharacterMail.Model[0].Recipients[0].MailRecipientType);
            Assert.Equal(90000001, getCharacterMail.Model[0].From);
        }

        [Fact]
        public async Task GetCharactersMailAsync_successfully_return_a_pagedModelV1MailGetCharactersMailAsync()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int lastId = 222222;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };
            string getCharacterMailJson = "[{\"from\": 90000001,\"is_read\": true,\"labels\": [3],\"mail_id\": 7,\"recipients\": [{\"recipient_id\": 90000002,\"recipient_type\": \"character\"}],\"subject\": \"Title for EVE Mail\",\"timestamp\": \"2015-09-30T16:07:00Z\"}]";

            PagedJson pagedJson = new PagedJson { Response = getCharacterMailJson };

            mockedWebClient.Setup(x => x.GetPagedAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(pagedJson);

            InternalLatestMail internalLatestMail = new InternalLatestMail(mockedWebClient.Object, string.Empty);

            PagedModel<V1MailGetCharactersMail> getCharacterMail = await internalLatestMail.GetCharactersMailAsync(inputToken, lastId);

            Assert.Equal(1, getCharacterMail.Model.Count);
            Assert.Equal(MailRecipientType.character, getCharacterMail.Model[0].Recipients[0].MailRecipientType);
            Assert.Equal(90000001, getCharacterMail.Model[0].From);
        }

        [Fact]
        public void GetMail_successfully_returns_a_V1MailGetMail()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int mailId = 222222;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };
            string getMailJson = "{\"body\": \"blah blah blah\",\"from\": 90000001,\"labels\": [2,32],\"read\": true,\"subject\": \"test\",\"timestamp\": \"2015-09-30T16:07:00Z\"}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getMailJson);

            InternalLatestMail internalLatestMail = new InternalLatestMail(mockedWebClient.Object, string.Empty);

            V1MailGetMail getMail = internalLatestMail.GetMail(inputToken, mailId);

            Assert.Equal(90000001, getMail.From);
            Assert.Equal(2, getMail.Labels.Count);
            Assert.True(getMail.Read);
        }

        [Fact]
        public async Task GetMailAsync_successfully_returns_a_V1MailGetMail()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int mailId = 222222;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };
            string getMailJson = "{\"body\": \"blah blah blah\",\"from\": 90000001,\"labels\": [2,32],\"read\": true,\"subject\": \"test\",\"timestamp\": \"2015-09-30T16:07:00Z\"}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getMailJson);

            InternalLatestMail internalLatestMail = new InternalLatestMail(mockedWebClient.Object, string.Empty);

            V1MailGetMail getMail = await internalLatestMail.GetMailAsync(inputToken, mailId);

            Assert.Equal(90000001, getMail.From);
            Assert.Equal(2, getMail.Labels.Count);
            Assert.True(getMail.Read);
        }
    }
}
