using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibrary.Tests.IntegrationTests
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

        [Fact]
        public void LabelsAndUnreadCount_successfully_returns_a_V3MailLabelsAndUnreadCount()
        {
            int characterId = 88823;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };

            LatestMailEndpoints internalLatestMail = new LatestMailEndpoints(string.Empty, true);

            V3MailLabelsAndUnreadCount mail = internalLatestMail.LabelsAndUnreadCount(inputToken);

            Assert.Equal(2, mail.Labels.Count);

            Assert.Equal(MailLabelColor.Purple, mail.Labels[0].Color);
            Assert.Equal(16, mail.Labels[0].LabelId);
            Assert.Equal("PINK", mail.Labels[0].Name);
            Assert.Equal(4, mail.Labels[0].UnreadCount);

            Assert.Equal(MailLabelColor.White, mail.Labels[1].Color);
            Assert.Equal(17, mail.Labels[1].LabelId);
            Assert.Equal("WHITE", mail.Labels[1].Name);
            Assert.Equal(1, mail.Labels[1].UnreadCount);

            Assert.Equal(5, mail.TotalUnreadCount);
        }

        [Fact]
        public async Task LabelsAndUnreadCountAsync_successfully_returns_a_V3MailLabelsAndUnreadCount()
        {
            int characterId = 88823;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };

            LatestMailEndpoints internalLatestMail = new LatestMailEndpoints(string.Empty, true);

            V3MailLabelsAndUnreadCount mail = await internalLatestMail.LabelsAndUnreadCountAsync(inputToken);

            Assert.Equal(2, mail.Labels.Count);

            Assert.Equal(MailLabelColor.Purple, mail.Labels[0].Color);
            Assert.Equal(16, mail.Labels[0].LabelId);
            Assert.Equal("PINK", mail.Labels[0].Name);
            Assert.Equal(4, mail.Labels[0].UnreadCount);

            Assert.Equal(MailLabelColor.White, mail.Labels[1].Color);
            Assert.Equal(17, mail.Labels[1].LabelId);
            Assert.Equal("WHITE", mail.Labels[1].Name);
            Assert.Equal(1, mail.Labels[1].UnreadCount);

            Assert.Equal(5, mail.TotalUnreadCount);
        }

        [Fact]
        public void MailingLists_successfully_returns_a_list_of_V1MailMailingList()
        {
            int characterId = 88823;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };

            LatestMailEndpoints internalLatestMail = new LatestMailEndpoints(string.Empty, true);

            IList<V1MailMailingList> mail = internalLatestMail.MailingLists(inputToken);

            Assert.Single(mail);

            Assert.Equal(1, mail[0].MailingListId);
            Assert.Equal("test_mailing_list", mail[0].Name);
        }

        [Fact]
        public async Task MailingListsAsync_successfully_returns_a_list_of_V1MailMailingList()
        {
            int characterId = 88823;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };
            
            LatestMailEndpoints internalLatestMail = new LatestMailEndpoints(string.Empty, true);

            IList<V1MailMailingList> mail = await internalLatestMail.MailingListsAsync(inputToken);

            Assert.Single(mail);

            Assert.Equal(1, mail[0].MailingListId);
            Assert.Equal("test_mailing_list", mail[0].Name);
        }
    }
}
