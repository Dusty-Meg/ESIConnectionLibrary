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
        public void GetCharactersContacts_successfully_returns_a_pagedModelV1ContactsGetContacts()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int page = 1;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string getCharactersContactsJson = "[{\"standing\": 9.9,\"contact_type\": \"corporation\",\"contact_id\": 123,\"is_watched\": true,\"is_blocked\": true}]";

            PagedJson pagedJson = new PagedJson{ Response = getCharactersContactsJson, MaxPages = 2 };

            mockedWebClient.Setup(x => x.GetPaged(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(pagedJson);

            InternalLatestContacts internalLatestContacts = new InternalLatestContacts(mockedWebClient.Object, string.Empty);

            PagedModel<V1ContactsGetContacts> getCharacterContacts = internalLatestContacts.GetCharactersContacts(inputToken, characterId, page);

            Assert.Equal(1, getCharacterContacts.Model.Count);
            Assert.Equal(2, getCharacterContacts.MaxPages);
            Assert.Equal(V1ContactsContactType.corporation, getCharacterContacts.Model[0].ContactType);
            Assert.Equal(9.9f, getCharacterContacts.Model[0].Standing);
            Assert.True(getCharacterContacts.Model[0].IsWatched);
            Assert.True(getCharacterContacts.Model[0].IsBlocked);
        }

        [Fact]
        public async Task GetCharactersContactsAsync_successfully_returns_a_pagedModelV1ContactsGetContacts()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int page = 1;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_contacts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string getCharactersContactsJson = "[{\"standing\": 9.9,\"contact_type\": \"corporation\",\"contact_id\": 123,\"is_watched\": true,\"is_blocked\": true}]";

            PagedJson pagedJson = new PagedJson { Response = getCharactersContactsJson, MaxPages = 2 };

            mockedWebClient.Setup(x => x.GetPagedAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(pagedJson);

            InternalLatestContacts internalLatestContacts = new InternalLatestContacts(mockedWebClient.Object, string.Empty);

            PagedModel<V1ContactsGetContacts> getCharacterContacts = await internalLatestContacts.GetCharactersContactsAsync(inputToken, characterId, page);

            Assert.Equal(1, getCharacterContacts.Model.Count);
            Assert.Equal(2, getCharacterContacts.MaxPages);
            Assert.Equal(V1ContactsContactType.corporation, getCharacterContacts.Model[0].ContactType);
            Assert.Equal(9.9f, getCharacterContacts.Model[0].Standing);
            Assert.True(getCharacterContacts.Model[0].IsWatched);
            Assert.True(getCharacterContacts.Model[0].IsBlocked);
        }
    }
}
