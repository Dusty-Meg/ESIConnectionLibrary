using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class ContactTests
    {
        [Fact]
        public void Alliance_successfully_returns_a_pagedModelV2ContactAlliance()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int page = 1;
            AllianceScopes scopes = AllianceScopes.esi_alliances_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AllianceScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"contact_id\": 2112625428,\r\n    \"contact_type\": \"character\",\r\n    \"standing\": 9.9\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestContacts internalLatestContacts = new InternalLatestContacts(mockedWebClient.Object, string.Empty);

            PagedModel<V2ContactAlliance> returnModel = internalLatestContacts.Alliance(inputToken, 9923, page);

            Assert.Equal(2112625428, returnModel.Model.First().ContactId);
            Assert.Equal(V2ContactAllianceContactTypes.Character, returnModel.Model[0].ContactType);
            Assert.Equal(9.9f, returnModel.Model[0].Standing);
        }

        [Fact]
        public async Task AllianceAsync_successfully_returns_a_pagedModelV2ContactAlliance()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int page = 1;
            AllianceScopes scopes = AllianceScopes.esi_alliances_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AllianceScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"contact_id\": 2112625428,\r\n    \"contact_type\": \"character\",\r\n    \"standing\": 9.9\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestContacts internalLatestContacts = new InternalLatestContacts(mockedWebClient.Object, string.Empty);

            PagedModel<V2ContactAlliance> returnModel = await internalLatestContacts.AllianceAsync(inputToken, 9923, page);

            Assert.Equal(2112625428, returnModel.Model.First().ContactId);
            Assert.Equal(V2ContactAllianceContactTypes.Character, returnModel.Model[0].ContactType);
            Assert.Equal(9.9f, returnModel.Model[0].Standing);
        }

        [Fact]
        public void AllianceLabels_successfully_returns_a_IListV1ContactAllianceLabel()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            AllianceScopes scopes = AllianceScopes.esi_alliances_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AllianceScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"label_id\": 1,\r\n    \"label_name\": \"Alliance Friends\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestContacts internalLatestContacts = new InternalLatestContacts(mockedWebClient.Object, string.Empty);

            IList<V1ContactAllianceLabel> returnModel = internalLatestContacts.AllianceLabels(inputToken, 9923);

            Assert.Equal(1, returnModel.First().LabelId);
            Assert.Equal("Alliance Friends", returnModel.First().LabelName);
        }

        [Fact]
        public async Task AllianceLabelsAsync_successfully_returns_a_IListV1ContactAllianceLabel()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            AllianceScopes scopes = AllianceScopes.esi_alliances_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AllianceScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"label_id\": 1,\r\n    \"label_name\": \"Alliance Friends\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestContacts internalLatestContacts = new InternalLatestContacts(mockedWebClient.Object, string.Empty);

            IList<V1ContactAllianceLabel> returnModel = await internalLatestContacts.AllianceLabelsAsync(inputToken, 9923);

            Assert.Equal(1, returnModel.First().LabelId);
            Assert.Equal("Alliance Friends", returnModel.First().LabelName);
        }

        [Fact]
        public void Character_successfully_returns_a_PagedModelV2ContactCharacter()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int page = 1;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"contact_id\": 123,\r\n    \"contact_type\": \"character\",\r\n    \"is_blocked\": true,\r\n    \"is_watched\": true,\r\n    \"standing\": 9.9\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestContacts internalLatestContacts = new InternalLatestContacts(mockedWebClient.Object, string.Empty);

            PagedModel<V2ContactCharacter> returnModel = internalLatestContacts.Character(inputToken, page);

            Assert.Equal(123, returnModel.Model.First().ContactId);
            Assert.Equal(V2ContactCharacterContactTypes.Character, returnModel.Model[0].ContactType);
            Assert.True(returnModel.Model[0].IsBlocked);
            Assert.True(returnModel.Model[0].IsWatched);
            Assert.Equal(9.9f, returnModel.Model[0].Standing);
        }

        [Fact]
        public async Task CharacterAsync_successfully_returns_a_PagedModelV2ContactCharacter()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int page = 1;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"contact_id\": 123,\r\n    \"contact_type\": \"character\",\r\n    \"is_blocked\": true,\r\n    \"is_watched\": true,\r\n    \"standing\": 9.9\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestContacts internalLatestContacts = new InternalLatestContacts(mockedWebClient.Object, string.Empty);

            PagedModel<V2ContactCharacter> returnModel = await internalLatestContacts.CharacterAsync(inputToken, page);

            Assert.Equal(123, returnModel.Model.First().ContactId);
            Assert.Equal(V2ContactCharacterContactTypes.Character, returnModel.Model[0].ContactType);
            Assert.True(returnModel.Model[0].IsBlocked);
            Assert.True(returnModel.Model[0].IsWatched);
            Assert.Equal(9.9f, returnModel.Model[0].Standing);
        }

        [Fact]
        public void CharacterAdd_successfully_returns_a_IListint()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_write_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[\r\n  123,\r\n  456\r\n]";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestContacts internalLatestContacts = new InternalLatestContacts(mockedWebClient.Object, string.Empty);

            V2ContactCharacterAdd model = new V2ContactCharacterAdd
            {
                Standing = 9.9f
            };

            IList<int> returnModel = internalLatestContacts.CharacterAdd(inputToken, model);

            Assert.Equal(123, returnModel[0]);
            Assert.Equal(456, returnModel[1]);
        }

        [Fact]
        public async Task CharacterAddAsync_successfully_returns_a_IListint()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_write_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[\r\n  123,\r\n  456\r\n]";

            mockedWebClient.Setup(x => x.PostAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestContacts internalLatestContacts = new InternalLatestContacts(mockedWebClient.Object, string.Empty);

            V2ContactCharacterAdd model = new V2ContactCharacterAdd
            {
                Standing = 9.9f
            };

            IList<int> returnModel = await internalLatestContacts.CharacterAddAsync(inputToken, model);

            Assert.Equal(123, returnModel[0]);
            Assert.Equal(456, returnModel[1]);
        }

        [Fact]
        public void CharacterLabels_successfully_returns_a_IListV1ContactCharacterLabel()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"label_id\": 123,\r\n    \"label_name\": \"Friends\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestContacts internalLatestContacts = new InternalLatestContacts(mockedWebClient.Object, string.Empty);

            IList<V1ContactCharacterLabel> returnModel = internalLatestContacts.CharacterLabels(inputToken);

            Assert.Equal(123, returnModel.First().LabelId);
            Assert.Equal("Friends", returnModel.First().LabelName);
        }

        [Fact]
        public async Task CharacterLabelsAsync_successfully_returns_a_IListV1ContactCharacterLabel()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"label_id\": 123,\r\n    \"label_name\": \"Friends\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestContacts internalLatestContacts = new InternalLatestContacts(mockedWebClient.Object, string.Empty);

            IList<V1ContactCharacterLabel> returnModel = await internalLatestContacts.CharacterLabelsAsync(inputToken);

            Assert.Equal(123, returnModel.First().LabelId);
            Assert.Equal("Friends", returnModel.First().LabelName);
        }

        [Fact]
        public void Corporation_successfully_returns_a_PagedModelV2ContactCorporation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int page = 1;
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"contact_id\": 123,\r\n    \"contact_type\": \"character\",\r\n    \"is_watched\": true,\r\n    \"standing\": 9.9\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestContacts internalLatestContacts = new InternalLatestContacts(mockedWebClient.Object, string.Empty);

            PagedModel<V2ContactCorporation> returnModel = internalLatestContacts.Corporation(inputToken, 88, page);

            Assert.Equal(123, returnModel.Model.First().ContactId);
            Assert.Equal(V2ContactCorporationContactTypes.Character, returnModel.Model[0].ContactType);
            Assert.True(returnModel.Model[0].IsWatched);
            Assert.Equal(9.9f, returnModel.Model[0].Standing);
        }

        [Fact]
        public async Task CorporationAsync_successfully_returns_a_PagedModelV2ContactCorporation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int page = 1;
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"contact_id\": 123,\r\n    \"contact_type\": \"character\",\r\n    \"is_watched\": true,\r\n    \"standing\": 9.9\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestContacts internalLatestContacts = new InternalLatestContacts(mockedWebClient.Object, string.Empty);

            PagedModel<V2ContactCorporation> returnModel = await internalLatestContacts.CorporationAsync(inputToken, 88, page);

            Assert.Equal(123, returnModel.Model.First().ContactId);
            Assert.Equal(V2ContactCorporationContactTypes.Character, returnModel.Model[0].ContactType);
            Assert.True(returnModel.Model[0].IsWatched);
            Assert.Equal(9.9f, returnModel.Model[0].Standing);
        }

        [Fact]
        public void CorporationLabels_successfully_returns_a_IListV1ContactCorporationLabel()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"label_id\": 2,\r\n    \"label_name\": \"Corporation Friends\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestContacts internalLatestContacts = new InternalLatestContacts(mockedWebClient.Object, string.Empty);

            IList<V1ContactCorporationLabel> returnModel = internalLatestContacts.CorporationLabels(inputToken, 22);

            Assert.Equal(2, returnModel.First().LabelId);
            Assert.Equal("Corporation Friends", returnModel.First().LabelName);
        }

        [Fact]
        public async Task CorporationLabelsAsync_successfully_returns_a_IListV1ContactCorporationLabel()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"label_id\": 2,\r\n    \"label_name\": \"Corporation Friends\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestContacts internalLatestContacts = new InternalLatestContacts(mockedWebClient.Object, string.Empty);

            IList<V1ContactCorporationLabel> returnModel = await internalLatestContacts.CorporationLabelsAsync(inputToken, 22);

            Assert.Equal(2, returnModel.First().LabelId);
            Assert.Equal("Corporation Friends", returnModel.First().LabelName);
        }
    }
}
