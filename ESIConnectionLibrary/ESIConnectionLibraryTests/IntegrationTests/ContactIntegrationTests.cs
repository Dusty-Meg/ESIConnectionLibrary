using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class ContactIntegrationTests
    {
        [Fact]
        public void Alliance_successfully_returns_a_pagedModelV2ContactAlliance()
        {
            int characterId = 88823;
            int page = 1;
            AllianceScopes scopes = AllianceScopes.esi_alliances_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AllianceScopesFlags = scopes };

            LatestContactsEndpoints internalLatestContacts = new LatestContactsEndpoints(string.Empty, true);

            PagedModel<V2ContactAlliance> returnModel = internalLatestContacts.Alliance(inputToken, 9923, page);

            Assert.Equal(2112625428, returnModel.Model.First().ContactId);
            Assert.Equal(V2ContactAllianceContactTypes.Character, returnModel.Model[0].ContactType);
            Assert.Equal(9.9f, returnModel.Model[0].Standing);
        }

        [Fact]
        public async Task AllianceAsync_successfully_returns_a_pagedModelV2ContactAlliance()
        {
            int characterId = 88823;
            int page = 1;
            AllianceScopes scopes = AllianceScopes.esi_alliances_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AllianceScopesFlags = scopes };

            LatestContactsEndpoints internalLatestContacts = new LatestContactsEndpoints(string.Empty, true);

            PagedModel<V2ContactAlliance> returnModel = await internalLatestContacts.AllianceAsync(inputToken, 9923, page);

            Assert.Equal(2112625428, returnModel.Model.First().ContactId);
            Assert.Equal(V2ContactAllianceContactTypes.Character, returnModel.Model[0].ContactType);
            Assert.Equal(9.9f, returnModel.Model[0].Standing);
        }

        [Fact]
        public void AllianceLabels_successfully_returns_a_IListV1ContactAllianceLabel()
        {
            int characterId = 88823;
            AllianceScopes scopes = AllianceScopes.esi_alliances_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AllianceScopesFlags = scopes };

            LatestContactsEndpoints internalLatestContacts = new LatestContactsEndpoints(string.Empty, true);

            IList<V1ContactAllianceLabel> returnModel = internalLatestContacts.AllianceLabels(inputToken, 9923);

            Assert.Equal(1, returnModel.First().LabelId);
            Assert.Equal("Alliance Friends", returnModel.First().LabelName);
        }

        [Fact]
        public async Task AllianceLabelsAsync_successfully_returns_a_IListV1ContactAllianceLabel()
        {
            int characterId = 88823;
            AllianceScopes scopes = AllianceScopes.esi_alliances_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, AllianceScopesFlags = scopes };

            LatestContactsEndpoints internalLatestContacts = new LatestContactsEndpoints(string.Empty, true);

            IList<V1ContactAllianceLabel> returnModel = await internalLatestContacts.AllianceLabelsAsync(inputToken, 9923);

            Assert.Equal(1, returnModel.First().LabelId);
            Assert.Equal("Alliance Friends", returnModel.First().LabelName);
        }

        [Fact]
        public void CharacterDelete_successfully_returns_nothing()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_write_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestContactsEndpoints internalLatestContacts = new LatestContactsEndpoints(string.Empty, true);

            internalLatestContacts.CharacterDelete(inputToken, new List<int>());
        }

        [Fact]
        public async Task CharacterDeleteAsync_successfully_returns_nothing()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_write_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestContactsEndpoints internalLatestContacts = new LatestContactsEndpoints(string.Empty, true);

            await internalLatestContacts.CharacterDeleteAsync(inputToken, new List<int>());
        }

        [Fact]
        public void Character_successfully_returns_a_PagedModelV2ContactCharacter()
        {
            int characterId = 88823;
            int page = 1;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestContactsEndpoints internalLatestContacts = new LatestContactsEndpoints(string.Empty, true);

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
            int characterId = 88823;
            int page = 1;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestContactsEndpoints internalLatestContacts = new LatestContactsEndpoints(string.Empty, true);

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
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_write_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestContactsEndpoints internalLatestContacts = new LatestContactsEndpoints(string.Empty, true);

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
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_write_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestContactsEndpoints internalLatestContacts = new LatestContactsEndpoints(string.Empty, true);

            V2ContactCharacterAdd model = new V2ContactCharacterAdd
            {
                Standing = 9.9f
            };

            IList<int> returnModel = await internalLatestContacts.CharacterAddAsync(inputToken, model);

            Assert.Equal(123, returnModel[0]);
            Assert.Equal(456, returnModel[1]);
        }

        [Fact]
        public void CharacterEdit_successfully_returns_nothing()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_write_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestContactsEndpoints internalLatestContacts = new LatestContactsEndpoints(string.Empty, true);

            V2ContactCharacterEdit model = new V2ContactCharacterEdit
            {
                Standing = 9.9f
            };

            internalLatestContacts.CharacterEdit(inputToken, model);
        }

        [Fact]
        public async Task CharacterEditAsync_successfully_returns_nothing()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_write_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestContactsEndpoints internalLatestContacts = new LatestContactsEndpoints(string.Empty, true);

            V2ContactCharacterEdit model = new V2ContactCharacterEdit
            {
                Standing = 9.9f
            };

            await internalLatestContacts.CharacterEditAsync(inputToken, model);
        }

        [Fact]
        public void CharacterLabels_successfully_returns_a_IListV1ContactCharacterLabel()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestContactsEndpoints internalLatestContacts = new LatestContactsEndpoints(string.Empty, true);

            IList<V1ContactCharacterLabel> returnModel = internalLatestContacts.CharacterLabels(inputToken);

            Assert.Equal(123, returnModel.First().LabelId);
            Assert.Equal("Friends", returnModel.First().LabelName);
        }

        [Fact]
        public async Task CharacterLabelsAsync_successfully_returns_a_IListV1ContactCharacterLabel()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestContactsEndpoints internalLatestContacts = new LatestContactsEndpoints(string.Empty, true);

            IList<V1ContactCharacterLabel> returnModel = await internalLatestContacts.CharacterLabelsAsync(inputToken);

            Assert.Equal(123, returnModel.First().LabelId);
            Assert.Equal("Friends", returnModel.First().LabelName);
        }

        [Fact]
        public void Corporation_successfully_returns_a_PagedModelV2ContactCorporation()
        {
            int characterId = 88823;
            int page = 1;
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CorporationScopesFlags = scopes };

            LatestContactsEndpoints internalLatestContacts = new LatestContactsEndpoints(string.Empty, true);

            PagedModel<V2ContactCorporation> returnModel = internalLatestContacts.Corporation(inputToken, 88, page);

            Assert.Equal(123, returnModel.Model.First().ContactId);
            Assert.Equal(V2ContactCorporationContactTypes.Character, returnModel.Model[0].ContactType);
            Assert.True(returnModel.Model[0].IsWatched);
            Assert.Equal(9.9f, returnModel.Model[0].Standing);
        }

        [Fact]
        public async Task CorporationAsync_successfully_returns_a_PagedModelV2ContactCorporation()
        {
            int characterId = 88823;
            int page = 1;
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CorporationScopesFlags = scopes };

            LatestContactsEndpoints internalLatestContacts = new LatestContactsEndpoints(string.Empty, true);

            PagedModel<V2ContactCorporation> returnModel = await internalLatestContacts.CorporationAsync(inputToken, 88, page);

            Assert.Equal(123, returnModel.Model.First().ContactId);
            Assert.Equal(V2ContactCorporationContactTypes.Character, returnModel.Model[0].ContactType);
            Assert.True(returnModel.Model[0].IsWatched);
            Assert.Equal(9.9f, returnModel.Model[0].Standing);
        }

        [Fact]
        public void CorporationLabels_successfully_returns_a_IListV1ContactCorporationLabel()
        {
            int characterId = 88823;
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CorporationScopesFlags = scopes };

            LatestContactsEndpoints internalLatestContacts = new LatestContactsEndpoints(string.Empty, true);

            IList<V1ContactCorporationLabel> returnModel = internalLatestContacts.CorporationLabels(inputToken, 22);

            Assert.Equal(2, returnModel.First().LabelId);
            Assert.Equal("Corporation Friends", returnModel.First().LabelName);
        }

        [Fact]
        public async Task CorporationLabelsAsync_successfully_returns_a_IListV1ContactCorporationLabel()
        {
            int characterId = 88823;
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CorporationScopesFlags = scopes };

            LatestContactsEndpoints internalLatestContacts = new LatestContactsEndpoints(string.Empty, true);

            IList<V1ContactCorporationLabel> returnModel = await internalLatestContacts.CorporationLabelsAsync(inputToken, 22);

            Assert.Equal(2, returnModel.First().LabelId);
            Assert.Equal("Corporation Friends", returnModel.First().LabelName);
        }
    }
}
