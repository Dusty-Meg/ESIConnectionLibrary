using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class MailIntegrationTests
    {
        [Fact]
        public void GetCharactersMail_successfully_return_a_pagedModelV1MailGetCharactersMail()
        {
            int characterId = 88823;
            int lastId = 222222;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };

            LatestMailEndpoints internalLatestMail = new LatestMailEndpoints(string.Empty, true);

            PagedModel<V1MailGetCharactersMail> getCharacterMail = internalLatestMail.GetCharactersMail(inputToken, lastId);

            Assert.Equal(1, getCharacterMail.Model.Count);
            Assert.Equal(MailRecipientType.Character, getCharacterMail.Model[0].Recipients[0].MailRecipientType);
            Assert.Equal(90000001, getCharacterMail.Model[0].From);
        }

        [Fact]
        public async Task GetCharactersMailAsync_successfully_return_a_pagedModelV1MailGetCharactersMailAsync()
        {
            int characterId = 88823;
            int lastId = 222222;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };

            LatestMailEndpoints internalLatestMail = new LatestMailEndpoints(string.Empty, true);

            PagedModel<V1MailGetCharactersMail> getCharacterMail = await internalLatestMail.GetCharactersMailAsync(inputToken, lastId);

            Assert.Equal(1, getCharacterMail.Model.Count);
            Assert.Equal(MailRecipientType.Character, getCharacterMail.Model[0].Recipients[0].MailRecipientType);
            Assert.Equal(90000001, getCharacterMail.Model[0].From);
        }

        [Fact]
        public void GetMail_successfully_returns_a_V1MailGetMail()
        {
            int characterId = 88823;
            int mailId = 222222;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };

            LatestMailEndpoints internalLatestMail = new LatestMailEndpoints(string.Empty, true);

            V1MailGetMail getMail = internalLatestMail.GetMail(inputToken, mailId);

            Assert.Equal(90000001, getMail.From);
            Assert.Equal(2, getMail.Labels.Count);
            Assert.True(getMail.Read);
        }

        [Fact]
        public async Task GetMailAsync_successfully_returns_a_V1MailGetMail()
        {
            int characterId = 88823;
            int mailId = 222222;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };

            LatestMailEndpoints internalLatestMail = new LatestMailEndpoints(string.Empty, true);

            V1MailGetMail getMail = await internalLatestMail.GetMailAsync(inputToken, mailId);

            Assert.Equal(90000001, getMail.From);
            Assert.Equal(2, getMail.Labels.Count);
            Assert.True(getMail.Read);
        }
    }
}
