using System.Collections.Generic;
using System.Linq;
using System.Net;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class CorporationTests
    {
        [Fact]
        public void GetCorporationRoles_successully_returns_a_list_of_CorporationRoles()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            Scopes scopes = Scopes.esi_corporations_read_corporation_membership_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, ScopesFlags = scopes };
            string corporationRolesJson = "[{\"character_id\": 1000171,\"roles\": [\"Director\",\"Station_Manager\"]}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(corporationRolesJson);

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            IList<V1CorporationsRoles> corporationRoles = internalLatestCorporations.GetCorporationRoles(inputToken, 18888888);

            Assert.Equal(1, corporationRoles.Count);
            Assert.Equal(2, corporationRoles.First().Roles.Count);
        }
    }
}
