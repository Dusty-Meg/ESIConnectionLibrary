using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class ContactIntegrationTests
    {
        [Fact]
        public void GetCharactersContacts_successfully_returns_a_pagedModelV2ContactsGetContacts()
        {
            int characterId = 88823;
            int page = 1;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestContactEndpoints internalLatestContacts = new LatestContactEndpoints(string.Empty, true);

            PagedModel<V2ContactsGetContacts> getCharacterContacts = internalLatestContacts.GetCharactersContacts(inputToken, page);

            Assert.Equal(1, getCharacterContacts.Model.Count);
            Assert.Equal(V2ContactsContactType.character, getCharacterContacts.Model[0].ContactType);
            Assert.Equal(9.9f, getCharacterContacts.Model[0].Standing);
            Assert.True(getCharacterContacts.Model[0].IsWatched);
            Assert.True(getCharacterContacts.Model[0].IsBlocked);
        }

        [Fact]
        public async Task GetCharactersContactsAsync_successfully_returns_a_pagedModelV2ContactsGetContacts()
        {
            int characterId = 88823;
            int page = 1;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestContactEndpoints internalLatestContacts = new LatestContactEndpoints(string.Empty, true);

            PagedModel<V2ContactsGetContacts> getCharacterContacts = await internalLatestContacts.GetCharactersContactsAsync(inputToken, page);

            Assert.Equal(1, getCharacterContacts.Model.Count);
            Assert.Equal(V2ContactsContactType.character, getCharacterContacts.Model[0].ContactType);
            Assert.Equal(9.9f, getCharacterContacts.Model[0].Standing);
            Assert.True(getCharacterContacts.Model[0].IsWatched);
            Assert.True(getCharacterContacts.Model[0].IsBlocked);
        }
    }
}
