using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibrary.Tests.IntegrationTests
{
    public class CharacterIntegrationTests
    {
        [Fact]
        public void PublicInfo_Successfully_returns_a_V4CharactersPublicInfo()
        {
            int characterId = 8976562;

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            V4CharactersPublicInfo v4CharactersPublicInfo = internalLatestCharacter.PublicInfo(characterId);

            Assert.Equal(Gender.Male, v4CharactersPublicInfo.Gender);
            Assert.Equal(109299958, v4CharactersPublicInfo.CorporationId);
            Assert.Equal(new DateTime(2015, 03, 24, 11, 37, 0), v4CharactersPublicInfo.Birthday);
        }

        [Fact]
        public async Task PublicInfoAsync_Successfully_returns_a_V4CharactersPublicInfo()
        {
            int characterId = 8976562;

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            V4CharactersPublicInfo v4CharactersPublicInfo = await internalLatestCharacter.PublicInfoAsync(characterId);

            Assert.Equal(Gender.Male, v4CharactersPublicInfo.Gender);
            Assert.Equal(109299958, v4CharactersPublicInfo.CorporationId);
            Assert.Equal(new DateTime(2015, 03, 24, 11, 37, 0), v4CharactersPublicInfo.Birthday);
        }

        [Fact]
        public void ResearchAgents_successfully_returns_a_list_of_V1CharactersResearchAgents()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_agents_research_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V1CharactersResearchAgents> getCharactersResearchAgents = internalLatestCharacter.ResearchAgents(inputToken);

            Assert.Equal(1, getCharactersResearchAgents.Count);
            Assert.Equal(3009358, getCharactersResearchAgents.First().AgentId);
            Assert.Equal(new DateTime(2017, 03, 23, 14, 47, 00), getCharactersResearchAgents.First().StartedAt);
        }

        [Fact]
        public async Task ResearchAgentsAsync_successfully_returns_a_list_of_V1CharactersResearchAgents()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_agents_research_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V1CharactersResearchAgents> getCharactersResearchAgents = await internalLatestCharacter.ResearchAgentsAsync(inputToken);

            Assert.Equal(1, getCharactersResearchAgents.Count);
            Assert.Equal(3009358, getCharactersResearchAgents.First().AgentId);
            Assert.Equal(new DateTime(2017, 03, 23, 14, 47, 00), getCharactersResearchAgents.First().StartedAt);
        }

        [Fact]
        public void Blueprints_successfully_returns_a_list_of_V3CharactersBlueprints()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_blueprints_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V3CharactersBlueprints> getCharactersBlueprint = internalLatestCharacter.Blueprint(inputToken);

            Assert.Equal(1, getCharactersBlueprint.Count);
            Assert.Equal(1000000010495, getCharactersBlueprint.First().ItemId);
            Assert.Equal(LocationFlagCharacter.Hangar, getCharactersBlueprint.First().LocationFlag);
            Assert.Equal(-1, getCharactersBlueprint.First().Runs);
        }

        [Fact]
        public async Task BlueprintsAsync_successfully_returns_a_list_of_V3CharactersBlueprints()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_blueprints_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V3CharactersBlueprints> getCharactersBlueprint = await internalLatestCharacter.BlueprintAsync(inputToken);

            Assert.Equal(1, getCharactersBlueprint.Count);
            Assert.Equal(1000000010495, getCharactersBlueprint.First().ItemId);
            Assert.Equal(LocationFlagCharacter.Hangar, getCharactersBlueprint.First().LocationFlag);
            Assert.Equal(-1, getCharactersBlueprint.First().Runs);
        }

        [Fact]
        public void CorporationHistory_successfully_returns_a_list_of_V2CharactersCorporationHistory()
        {
            int characterId = 88823;

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V2CharactersCorporationHistory> getCharactersCorporationHistory = internalLatestCharacter.CorporationHistory(characterId);

            Assert.Equal(2, getCharactersCorporationHistory.Count);
            Assert.Equal(90000001, getCharactersCorporationHistory.First().CorporationId);
            Assert.True(getCharactersCorporationHistory.First().IsDeleted);
            Assert.Equal(new DateTime(2016, 06, 26, 20, 00, 00), getCharactersCorporationHistory.First().StartDate);
        }

        [Fact]
        public async Task CorporationHistoryAsync_successfully_returns_a_list_of_V2CharactersCorporationHistory()
        {
            int characterId = 88823;

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V2CharactersCorporationHistory> getCharactersCorporationHistory = await internalLatestCharacter.CorporationHistoryAsync(characterId);

            Assert.Equal(2, getCharactersCorporationHistory.Count);
            Assert.Equal(90000001, getCharactersCorporationHistory.First().CorporationId);
            Assert.True(getCharactersCorporationHistory.First().IsDeleted);
            Assert.Equal(new DateTime(2016, 06, 26, 20, 00, 00), getCharactersCorporationHistory.First().StartDate);
        }

        [Fact]
        public void CspaCost_successfully_returns_a_float()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_contacts_v1;
            IList<int> characters = new List<int>(2);

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            float getCharactersCspaCost = internalLatestCharacter.CspaCost(inputToken, characters);

            Assert.Equal(2950, getCharactersCspaCost);
        }

        [Fact]
        public async Task CspaCostAsync_successfully_returns_a_float()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_contacts_v1;
            IList<int> characters = new List<int>(2);

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            float getCharactersCspaCost = await internalLatestCharacter.CspaCostAsync(inputToken, characters);

            Assert.Equal(2950, getCharactersCspaCost);
        }

        [Fact]
        public void Fatigue_successfully_returns_a_V2CharactersFatigue()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_fatigue_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            V2CharactersFatigue getCharactersFatigue = internalLatestCharacter.Fatigue(inputToken);

            Assert.Equal(new DateTime(2017, 07, 05, 15, 47, 00), getCharactersFatigue.LastJumpDate);
            Assert.Equal(new DateTime(2017, 07, 06, 15, 47, 00), getCharactersFatigue.JumpFatigueExpireDate);
            Assert.Equal(new DateTime(2017, 07, 05, 15, 42, 00), getCharactersFatigue.LastUpdateDate);
        }

        [Fact]
        public async Task FatigueAsync_successfully_returns_a_V2CharactersFatigue()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_fatigue_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            V2CharactersFatigue getCharactersFatigue = await internalLatestCharacter.FatigueAsync(inputToken);

            Assert.Equal(new DateTime(2017, 07, 05, 15, 47, 00), getCharactersFatigue.LastJumpDate);
            Assert.Equal(new DateTime(2017, 07, 06, 15, 47, 00), getCharactersFatigue.JumpFatigueExpireDate);
            Assert.Equal(new DateTime(2017, 07, 05, 15, 42, 00), getCharactersFatigue.LastUpdateDate);
        }

        [Fact]
        public void Medals_successfully_returns_a_list_of_V1CharactersMedals()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_medals_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V1CharactersMedals> getCharactersMedals = internalLatestCharacter.Medals(inputToken);

            Assert.Equal(1, getCharactersMedals.Count);
            Assert.Equal(3, getCharactersMedals.First().MedalId);
            Assert.Equal(new DateTime(2017, 03, 16, 15, 01, 45), getCharactersMedals.First().Date);
            Assert.Equal(MedalsStatus.Private, getCharactersMedals.First().Status);
            Assert.Equal(3, getCharactersMedals.First().Graphics.Count);
            Assert.Equal(1, getCharactersMedals.First().Graphics.First().Part);
            Assert.Equal(0, getCharactersMedals.First().Graphics.First().Layer);
            Assert.Equal("caldari.1_2", getCharactersMedals.First().Graphics[1].Graphic);
            Assert.Equal(-1, getCharactersMedals.First().Graphics[2].Color);
        }

        [Fact]
        public async Task MedalsAsync_successfully_returns_a_list_of_V1CharactersMedals()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_medals_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V1CharactersMedals> getCharactersMedals = await internalLatestCharacter.MedalsAsync(inputToken);

            Assert.Equal(1, getCharactersMedals.Count);
            Assert.Equal(3, getCharactersMedals.First().MedalId);
            Assert.Equal(new DateTime(2017, 03, 16, 15, 01, 45), getCharactersMedals.First().Date);
            Assert.Equal(MedalsStatus.Private, getCharactersMedals.First().Status);
            Assert.Equal(3, getCharactersMedals.First().Graphics.Count);
            Assert.Equal(1, getCharactersMedals.First().Graphics.First().Part);
            Assert.Equal(0, getCharactersMedals.First().Graphics.First().Layer);
            Assert.Equal("caldari.1_2", getCharactersMedals.First().Graphics[1].Graphic);
            Assert.Equal(-1, getCharactersMedals.First().Graphics[2].Color);
        }

        [Fact]
        public void Notifications_successfully_returns_a_list_of_V4CharactersNotifications()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_notifications_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V5CharactersNotifications> getCharactersNotifications = internalLatestCharacter.Notifications(inputToken);

            Assert.Equal(1, getCharactersNotifications.Count);
            Assert.Equal(1, getCharactersNotifications.First().NotificationId);
            Assert.Equal(V5CharactersNotificationType.InsurancePayoutMsg, getCharactersNotifications.First().Type);
            Assert.Equal(SenderType.Corporation, getCharactersNotifications.First().SenderType);
            Assert.Equal(new DateTime(2017, 08, 16, 10, 08, 00), getCharactersNotifications.First().Timestamp);
            Assert.True(getCharactersNotifications.First().IsRead);
        }

        [Fact]
        public async Task NotificationsAsync_successfully_returns_a_list_of_V4CharactersNotifications()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_notifications_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V5CharactersNotifications> getCharactersNotifications = await internalLatestCharacter.NotificationsAsync(inputToken);

            Assert.Equal(1, getCharactersNotifications.Count);
            Assert.Equal(1, getCharactersNotifications.First().NotificationId);
            Assert.Equal(V5CharactersNotificationType.InsurancePayoutMsg, getCharactersNotifications.First().Type);
            Assert.Equal(SenderType.Corporation, getCharactersNotifications.First().SenderType);
            Assert.Equal(new DateTime(2017, 08, 16, 10, 08, 00), getCharactersNotifications.First().Timestamp);
            Assert.True(getCharactersNotifications.First().IsRead);
        }

        [Fact]
        public void ContactNotifications_successfully_returns_a_list_of_V1CharactersNotificationsContacts()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_notifications_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V1CharactersNotificationsContacts> getCharactersNotificationsContacts = internalLatestCharacter.ContactNotifications(inputToken);

            Assert.Equal(1, getCharactersNotificationsContacts.Count);
            Assert.Equal(1, getCharactersNotificationsContacts.First().NotificationId);
            Assert.Equal(95465499, getCharactersNotificationsContacts.First().SenderCharacterId);
            Assert.Equal(new DateTime(2017, 08, 16, 10, 08, 00), getCharactersNotificationsContacts.First().SendDate);
            Assert.Equal(1.5, getCharactersNotificationsContacts.First().StandingLevel);
        }

        [Fact]
        public async Task ContactNotificationsAsync_successfully_returns_a_list_of_V1CharactersNotificationsContacts()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_notifications_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V1CharactersNotificationsContacts> getCharactersNotificationsContacts = await internalLatestCharacter.ContactNotificationsAsync(inputToken);

            Assert.Equal(1, getCharactersNotificationsContacts.Count);
            Assert.Equal(1, getCharactersNotificationsContacts.First().NotificationId);
            Assert.Equal(95465499, getCharactersNotificationsContacts.First().SenderCharacterId);
            Assert.Equal(new DateTime(2017, 08, 16, 10, 08, 00), getCharactersNotificationsContacts.First().SendDate);
            Assert.Equal(1.5, getCharactersNotificationsContacts.First().StandingLevel);
        }

        [Fact]
        public void Portrait_successfully_returns_a_V2CharactersPortrait()
        {
            int characterId = 88823;

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            V2CharactersPortrait getCharactersPortrait = internalLatestCharacter.Portrait(characterId);

            Assert.Equal("https://images.evetech.net/characters/95465499/portrait?tenant=tranquility&size=64", getCharactersPortrait.Px64X64);
            Assert.Equal("https://images.evetech.net/characters/95465499/portrait?tenant=tranquility&size=128", getCharactersPortrait.Px128X128);
            Assert.Equal("https://images.evetech.net/characters/95465499/portrait?tenant=tranquility&size=256", getCharactersPortrait.Px256X256);
            Assert.Equal("https://images.evetech.net/characters/95465499/portrait?tenant=tranquility&size=512", getCharactersPortrait.Px512X512);
        }

        [Fact]
        public async Task PortraitAsync_successfully_returns_a_V2CharactersPortrait()
        {
            int characterId = 88823;

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            V2CharactersPortrait getCharactersPortrait = await internalLatestCharacter.PortraitAsync(characterId);

            Assert.Equal("https://images.evetech.net/characters/95465499/portrait?tenant=tranquility&size=64", getCharactersPortrait.Px64X64);
            Assert.Equal("https://images.evetech.net/characters/95465499/portrait?tenant=tranquility&size=128", getCharactersPortrait.Px128X128);
            Assert.Equal("https://images.evetech.net/characters/95465499/portrait?tenant=tranquility&size=256", getCharactersPortrait.Px256X256);
            Assert.Equal("https://images.evetech.net/characters/95465499/portrait?tenant=tranquility&size=512", getCharactersPortrait.Px512X512);
        }

        [Fact]
        public void Roles_successfully_returns_a_V3CharacterRoles()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_corporation_roles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            V3CharacterRoles getCharactersRoles = internalLatestCharacter.Roles(inputToken);

            Assert.Equal(2, getCharactersRoles.Roles.Count);
            Assert.Equal(CharacterRoles.Director, getCharactersRoles.Roles[0]);
            Assert.Equal(CharacterRoles.StationManager, getCharactersRoles.Roles[1]);
            Assert.Equal(0, getCharactersRoles.RolesAtHq.Count);
            Assert.Equal(0, getCharactersRoles.RolesAtBase.Count);
            Assert.Equal(0, getCharactersRoles.RolesAtOther.Count);
        }

        [Fact]
        public async Task RolesAsync_successfully_returns_a_V3CharacterRoles()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_corporation_roles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            V3CharacterRoles getCharactersRoles = await internalLatestCharacter.RolesAsync(inputToken);

            Assert.Equal(2, getCharactersRoles.Roles.Count);
            Assert.Equal(CharacterRoles.Director, getCharactersRoles.Roles[0]);
            Assert.Equal(CharacterRoles.StationManager, getCharactersRoles.Roles[1]);
            Assert.Equal(0, getCharactersRoles.RolesAtHq.Count);
            Assert.Equal(0, getCharactersRoles.RolesAtBase.Count);
            Assert.Equal(0, getCharactersRoles.RolesAtOther.Count);
        }

        [Fact]
        public void Standings_successfully_returns_a_list_of_V2CharactersStandings()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_standings_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V2CharactersStandings> getCharactersStandings = internalLatestCharacter.Standings(inputToken);

            Assert.Equal(3, getCharactersStandings.Count);
            Assert.Equal(3009841, getCharactersStandings.First().FromId);
            Assert.Equal(StandingFromType.Agent, getCharactersStandings.First().FromType);
            Assert.Equal(0.1f, getCharactersStandings.First().Standing);
            Assert.Equal(StandingFromType.NpcCorp, getCharactersStandings[1].FromType);
            Assert.Equal(StandingFromType.Faction, getCharactersStandings[2].FromType);
        }

        [Fact]
        public async Task StandingsAsync_successfully_returns_a_list_of_V2CharactersStandings()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_standings_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V2CharactersStandings> getCharactersStandings = await internalLatestCharacter.StandingsAsync(inputToken);

            Assert.Equal(3, getCharactersStandings.Count);
            Assert.Equal(3009841, getCharactersStandings.First().FromId);
            Assert.Equal(StandingFromType.Agent, getCharactersStandings.First().FromType);
            Assert.Equal(0.1f, getCharactersStandings.First().Standing);
            Assert.Equal(StandingFromType.NpcCorp, getCharactersStandings[1].FromType);
            Assert.Equal(StandingFromType.Faction, getCharactersStandings[2].FromType);
        }

        [Fact]
        public void Titles_successfully_returns_a_list_of_V2CharacterTitles()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V2CharacterTitles> getCharactersTitles = internalLatestCharacter.Titles(inputToken);

            Assert.Equal(1, getCharactersTitles.Count);
            Assert.Equal(1, getCharactersTitles.First().TitleId);
            Assert.Equal("Awesome Title", getCharactersTitles.First().Name);
        }

        [Fact]
        public async Task TitlesAsync_successfully_returns_a_list_of_V2CharacterTitles()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V2CharacterTitles> getCharactersTitles = await internalLatestCharacter.TitlesAsync(inputToken);

            Assert.Equal(1, getCharactersTitles.Count);
            Assert.Equal(1, getCharactersTitles.First().TitleId);
            Assert.Equal("Awesome Title", getCharactersTitles.First().Name);
        }

        [Fact]
        public void Affiliations_successfully_returns_a_list_of_V2CharacterAffiliations()
        {
            IList<int> characterIds = new List<int>(23);

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V2CharacterAffiliations> getCharactersAffiliation = internalLatestCharacter.Affiliations(characterIds);

            Assert.Equal(1, getCharactersAffiliation.Count);
            Assert.Equal(95538921, getCharactersAffiliation.First().CharacterId);
            Assert.Equal(109299958, getCharactersAffiliation.First().CorporationId);
            Assert.Equal(434243723, getCharactersAffiliation.First().AllianceId);
        }

        [Fact]
        public async Task AffiliationsAsync_successfully_returns_a_list_of_V2CharacterAffiliations()
        {
            IList<int> characterIds = new List<int>(23);

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V2CharacterAffiliations> getCharactersAffiliation = await internalLatestCharacter.AffiliationsAsync(characterIds);

            Assert.Equal(1, getCharactersAffiliation.Count);
            Assert.Equal(95538921, getCharactersAffiliation.First().CharacterId);
            Assert.Equal(109299958, getCharactersAffiliation.First().CorporationId);
            Assert.Equal(434243723, getCharactersAffiliation.First().AllianceId);
        }
    }
}
