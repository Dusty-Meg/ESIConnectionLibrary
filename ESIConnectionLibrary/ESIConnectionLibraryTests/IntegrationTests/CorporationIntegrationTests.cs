using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class CorporationIntegrationTests
    {
        [Fact]
        public void GetCorporationRoles_successully_returns_a_list_of_CorporationRoles()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_corporation_membership_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            IList<V1CorporationsRoles> corporationRoles = internalLatestCorporations.GetCorporationRoles(inputToken, 18888888);

            Assert.Equal(1, corporationRoles.Count);
            Assert.Equal(2, corporationRoles.First().Roles.Count);
        }

        [Fact]
        public async Task GetCorporationRolesAsync_successully_returns_a_list_of_CorporationRoles()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_corporation_membership_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            IList<V1CorporationsRoles> corporationRoles = await internalLatestCorporations.GetCorporationRolesAsync(inputToken, 18888888);

            Assert.Equal(1, corporationRoles.Count);
            Assert.Equal(2, corporationRoles.First().Roles.Count);
        }

        [Fact]
        public void GetCorporationMemberTitles_successully_returns_a_list_of_V1CorporationMemberTitle()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            IList<V1CorporationMemberTitle> corporationRoles = internalLatestCorporations.GetCorporationMemberTitles(inputToken, 18888888);

            Assert.Equal(1, corporationRoles.Count);
            Assert.Equal(12345, corporationRoles.First().CharacterId);
            Assert.Equal(0, corporationRoles.First().Titles.Count);
        }

        [Fact]
        public async Task GetCorporationMemberTitlesAsync_successully_returns_a_list_of_V1CorporationMemberTitle()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            IList<V1CorporationMemberTitle> corporationRoles = await internalLatestCorporations.GetCorporationMemberTitlesAsync(inputToken, 18888888);

            Assert.Equal(1, corporationRoles.Count);
            Assert.Equal(12345, corporationRoles.First().CharacterId);
            Assert.Equal(0, corporationRoles.First().Titles.Count);
        }

        [Fact]
        public void GetCorporationTitles_successully_returns_a_list_of_V1CorporationTitles()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            IList<V1CorporationTitles> corporationRoles = internalLatestCorporations.GetCorporationTitles(inputToken, 18888888);

            Assert.Equal(1, corporationRoles.Count);
            Assert.Equal("Awesome Title", corporationRoles.First().Name);
            Assert.Equal(1, corporationRoles.First().TitleId);
            Assert.Equal(2, corporationRoles.First().Roles.Count);
            Assert.Equal(CorporationRoles.Hangar_Take_6, corporationRoles.First().Roles.First());
        }

        [Fact]
        public async Task GetCorporationTitlesAsync_successully_returns_a_list_of_V1CorporationTitles()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            IList<V1CorporationTitles> corporationRoles = await internalLatestCorporations.GetCorporationTitlesAsync(inputToken, 18888888);

            Assert.Equal(1, corporationRoles.Count);
            Assert.Equal("Awesome Title", corporationRoles.First().Name);
            Assert.Equal(1, corporationRoles.First().TitleId);
            Assert.Equal(2, corporationRoles.First().Roles.Count);
            Assert.Equal(CorporationRoles.Hangar_Take_6, corporationRoles.First().Roles.First());
        }
    }
}
