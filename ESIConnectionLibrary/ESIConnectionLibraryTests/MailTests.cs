using System.Collections.Generic;
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
        public void Character_successfully_return_a_pagedModelV1MailCharacter()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int lastId = 222222;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };
            string json = "[{\"from\": 90000001,\"is_read\": true,\"labels\": [3],\"mail_id\": 7,\"recipients\": [{\"recipient_id\": 90000002,\"recipient_type\": \"character\"}],\"subject\": \"Title for EVE Mail\",\"timestamp\": \"2015-09-30T16:07:00Z\"}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestMail internalLatestMail = new InternalLatestMail(mockedWebClient.Object, string.Empty);

            PagedModel<V1MailCharacter> getCharacterMail = internalLatestMail.Character(inputToken, lastId);

            Assert.Equal(1, getCharacterMail.Model.Count);
            Assert.Equal(MailRecipientType.Character, getCharacterMail.Model[0].Recipients[0].MailRecipientType);
            Assert.Equal(90000001, getCharacterMail.Model[0].From);
        }

        [Fact]
        public async Task CharacterAsync_successfully_return_a_pagedModelV1MailCharacter()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int lastId = 222222;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };
            string json = "[{\"from\": 90000001,\"is_read\": true,\"labels\": [3],\"mail_id\": 7,\"recipients\": [{\"recipient_id\": 90000002,\"recipient_type\": \"character\"}],\"subject\": \"Title for EVE Mail\",\"timestamp\": \"2015-09-30T16:07:00Z\"}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestMail internalLatestMail = new InternalLatestMail(mockedWebClient.Object, string.Empty);

            PagedModel<V1MailCharacter> getCharacterMail = await internalLatestMail.CharacterAsync(inputToken, lastId);

            Assert.Equal(1, getCharacterMail.Model.Count);
            Assert.Equal(MailRecipientType.Character, getCharacterMail.Model[0].Recipients[0].MailRecipientType);
            Assert.Equal(90000001, getCharacterMail.Model[0].From);
        }

        [Fact]
        public void Mail_successfully_returns_a_V1MailMail()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int mailId = 222222;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };
            string json = "{\"body\": \"blah blah blah\",\"from\": 90000001,\"labels\": [2,32],\"read\": true,\"subject\": \"test\",\"timestamp\": \"2015-09-30T16:07:00Z\"}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestMail internalLatestMail = new InternalLatestMail(mockedWebClient.Object, string.Empty);

            V1MailMail mail = internalLatestMail.Mail(inputToken, mailId);

            Assert.Equal(90000001, mail.From);
            Assert.Equal(2, mail.Labels.Count);
            Assert.True(mail.Read);
        }

        [Fact]
        public async Task MailAsync_successfully_returns_a_V1MailMail()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int mailId = 222222;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };
            string json = "{\"body\": \"blah blah blah\",\"from\": 90000001,\"labels\": [2,32],\"read\": true,\"subject\": \"test\",\"timestamp\": \"2015-09-30T16:07:00Z\"}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestMail internalLatestMail = new InternalLatestMail(mockedWebClient.Object, string.Empty);

            V1MailMail mail = await internalLatestMail.MailAsync(inputToken, mailId);

            Assert.Equal(90000001, mail.From);
            Assert.Equal(2, mail.Labels.Count);
            Assert.True(mail.Read);
        }

        [Fact]
        public void LabelsAndUnreadCount_successfully_returns_a_V3MailLabelsAndUnreadCount()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };
            string json = "{\r\n  \"labels\": [\r\n    {\r\n      \"color\": \"#660066\",\r\n      \"label_id\": 16,\r\n      \"name\": \"PINK\",\r\n      \"unread_count\": 4\r\n    },\r\n    {\r\n      \"color\": \"#ffffff\",\r\n      \"label_id\": 17,\r\n      \"name\": \"WHITE\",\r\n      \"unread_count\": 1\r\n    }\r\n  ],\r\n  \"total_unread_count\": 5\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestMail internalLatestMail = new InternalLatestMail(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };
            string json = "{\r\n  \"labels\": [\r\n    {\r\n      \"color\": \"#660066\",\r\n      \"label_id\": 16,\r\n      \"name\": \"PINK\",\r\n      \"unread_count\": 4\r\n    },\r\n    {\r\n      \"color\": \"#ffffff\",\r\n      \"label_id\": 17,\r\n      \"name\": \"WHITE\",\r\n      \"unread_count\": 1\r\n    }\r\n  ],\r\n  \"total_unread_count\": 5\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestMail internalLatestMail = new InternalLatestMail(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"mailing_list_id\": 1,\r\n    \"name\": \"test_mailing_list\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestMail internalLatestMail = new InternalLatestMail(mockedWebClient.Object, string.Empty);

            IList<V1MailMailingList> mail = internalLatestMail.MailingLists(inputToken);

            Assert.Single(mail);

            Assert.Equal(1, mail[0].MailingListId);
            Assert.Equal("test_mailing_list", mail[0].Name);
        }

        [Fact]
        public async Task MailingListsAsync_successfully_returns_a_list_of_V1MailMailingList()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            MailScopes scopes = MailScopes.esi_mail_read_mail_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, MailScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"mailing_list_id\": 1,\r\n    \"name\": \"test_mailing_list\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestMail internalLatestMail = new InternalLatestMail(mockedWebClient.Object, string.Empty);

            IList<V1MailMailingList> mail = await internalLatestMail.MailingListsAsync(inputToken);

            Assert.Single(mail);

            Assert.Equal(1, mail[0].MailingListId);
            Assert.Equal("test_mailing_list", mail[0].Name);
        }
    }
}
