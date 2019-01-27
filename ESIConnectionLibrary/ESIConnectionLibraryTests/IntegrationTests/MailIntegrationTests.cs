using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class MailIntegrationTests
    {
        [Fact]
        public void Characters_successfully_return_a_pagedModelV1MailCharacters()
        {
            int characterId = 88823;
            int lastId = 222222;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };

            LatestMailEndpoints internalLatestMail = new LatestMailEndpoints(string.Empty, true);

            PagedModel<V1MailCharacter> getCharacterMail = internalLatestMail.Character(inputToken, lastId);

            Assert.Equal(1, getCharacterMail.Model.Count);
            Assert.Equal(MailRecipientType.Character, getCharacterMail.Model[0].Recipients[0].MailRecipientType);
            Assert.Equal(90000001, getCharacterMail.Model[0].From);
        }

        [Fact]
        public async Task CharactersAsync_successfully_return_a_pagedModelV1MailCharacters()
        {
            int characterId = 88823;
            int lastId = 222222;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };

            LatestMailEndpoints internalLatestMail = new LatestMailEndpoints(string.Empty, true);

            PagedModel<V1MailCharacter> getCharacterMail = await internalLatestMail.CharacterAsync(inputToken, lastId);

            Assert.Equal(1, getCharacterMail.Model.Count);
            Assert.Equal(MailRecipientType.Character, getCharacterMail.Model[0].Recipients[0].MailRecipientType);
            Assert.Equal(90000001, getCharacterMail.Model[0].From);
        }

        [Fact]
        public void Mail_successfully_returns_a_V1MailMail()
        {
            int characterId = 88823;
            int mailId = 222222;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };

            LatestMailEndpoints internalLatestMail = new LatestMailEndpoints(string.Empty, true);

            V1MailMail mail = internalLatestMail.Mail(inputToken, mailId);

            Assert.Equal(90000001, mail.From);
            Assert.Equal(2, mail.Labels.Count);
            Assert.True(mail.Read);
        }

        [Fact]
        public async Task MailAsync_successfully_returns_a_V1MailMail()
        {
            int characterId = 88823;
            int mailId = 222222;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };

            LatestMailEndpoints internalLatestMail = new LatestMailEndpoints(string.Empty, true);

            V1MailMail mail = await internalLatestMail.MailAsync(inputToken, mailId);

            Assert.Equal(90000001, mail.From);
            Assert.Equal(2, mail.Labels.Count);
            Assert.True(mail.Read);
        }
    }
}
