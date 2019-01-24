using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class CharacterIntegrationTests
    {
        [Fact]
        public void GetCharactersPublicInfo_Successfully_returns_a_characterPublicInfo()
        {
            int characterId = 8976562;

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            V4CharactersPublicInfo v4CharactersPublicInfo = internalLatestCharacter.GetCharactersPublicInfo(characterId);

            Assert.Equal(Gender.Male, v4CharactersPublicInfo.Gender);
            Assert.Equal(109299958, v4CharactersPublicInfo.CorporationId);
            Assert.Equal(new DateTime(2015, 03, 24, 11, 37, 0), v4CharactersPublicInfo.Birthday);
        }

        [Fact]
        public async Task GetCharactersPublicInfoAsync_Successfully_returns_a_characterPublicInfo()
        {
            int characterId = 8976562;

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            V4CharactersPublicInfo v4CharactersPublicInfo = await internalLatestCharacter.GetCharactersPublicInfoAsync(characterId);

            Assert.Equal(Gender.Male, v4CharactersPublicInfo.Gender);
            Assert.Equal(109299958, v4CharactersPublicInfo.CorporationId);
            Assert.Equal(new DateTime(2015, 03, 24, 11, 37, 0), v4CharactersPublicInfo.Birthday);
        }

        [Fact]
        public void GetCharactersResearchAgents_successfully_returns_a_list_of_charactersResearchAgents()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_agents_research_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V1CharactersResearchAgents> getCharactersResearchAgents = internalLatestCharacter.GetCharactersResearchAgents(inputToken);

            Assert.Equal(1, getCharactersResearchAgents.Count);
            Assert.Equal(3009358, getCharactersResearchAgents.First().AgentId);
            Assert.Equal(new DateTime(2017, 03, 23, 14, 47, 00), getCharactersResearchAgents.First().StartedAt);
        }

        [Fact]
        public async Task GetCharactersResearchAgentsAsync_successfully_returns_a_list_of_charactersResearchAgents()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_agents_research_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V1CharactersResearchAgents> getCharactersResearchAgents = await internalLatestCharacter.GetCharactersResearchAgentsAsync(inputToken);

            Assert.Equal(1, getCharactersResearchAgents.Count);
            Assert.Equal(3009358, getCharactersResearchAgents.First().AgentId);
            Assert.Equal(new DateTime(2017, 03, 23, 14, 47, 00), getCharactersResearchAgents.First().StartedAt);
        }

        [Fact]
        public void GetCharactersBlueprint_successfully_returns_a_list_of_charactersBlueprints()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_blueprints_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V2CharactersBlueprints> getCharactersBlueprint = internalLatestCharacter.GetCharactersBlueprint(inputToken);

            Assert.Equal(1, getCharactersBlueprint.Count);
            Assert.Equal(1000000010495, getCharactersBlueprint.First().ItemId);
            Assert.Equal(LocationFlagCharacter.Hangar, getCharactersBlueprint.First().LocationFlag);
            Assert.Equal(-1, getCharactersBlueprint.First().Runs);
        }

        [Fact]
        public async Task GetCharactersBlueprintAsync_successfully_returns_a_list_of_charactersBlueprints()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_blueprints_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V2CharactersBlueprints> getCharactersBlueprint = await internalLatestCharacter.GetCharactersBlueprintAsync(inputToken);

            Assert.Equal(1, getCharactersBlueprint.Count);
            Assert.Equal(1000000010495, getCharactersBlueprint.First().ItemId);
            Assert.Equal(LocationFlagCharacter.Hangar, getCharactersBlueprint.First().LocationFlag);
            Assert.Equal(-1, getCharactersBlueprint.First().Runs);
        }

        [Fact]
        public void GetCharactersCorporationHistory_successfully_returns_a_list_of_charactersCorporationHistory()
        {
            int characterId = 88823;

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V1CharactersCorporationHistory> getCharactersCorporationHistory = internalLatestCharacter.GetCharactersCorporationHistory(characterId);

            Assert.Equal(2, getCharactersCorporationHistory.Count);
            Assert.Equal(90000001, getCharactersCorporationHistory.First().CorporationId);
            Assert.True(getCharactersCorporationHistory.First().IsDeleted);
            Assert.Equal(new DateTime(2016, 06, 26, 20, 00, 00), getCharactersCorporationHistory.First().StartDate);
        }

        [Fact]
        public async Task GetCharactersCorporationHistoryAsync_successfully_returns_a_list_of_charactersCorporationHistory()
        {
            int characterId = 88823;

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V1CharactersCorporationHistory> getCharactersCorporationHistory = await internalLatestCharacter.GetCharactersCorporationHistoryAsync(characterId);

            Assert.Equal(2, getCharactersCorporationHistory.Count);
            Assert.Equal(90000001, getCharactersCorporationHistory.First().CorporationId);
            Assert.True(getCharactersCorporationHistory.First().IsDeleted);
            Assert.Equal(new DateTime(2016, 06, 26, 20, 00, 00), getCharactersCorporationHistory.First().StartDate);
        }

        [Fact]
        public void GetCharactersCspaCost_successfully_returns_a_list_of_charactersCspaCosts()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_contacts_v1;
            IList<int> characters = new List<int>(2);

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            float getCharactersCspaCost = internalLatestCharacter.GetCharactersCspaCost(inputToken, characters);

            Assert.Equal(2950, getCharactersCspaCost);
        }

        [Fact]
        public async Task GetCharactersCspaCostAsync_successfully_returns_a_list_of_charactersCspaCosts()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_contacts_v1;
            IList<int> characters = new List<int>(2);

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            float getCharactersCspaCost = await internalLatestCharacter.GetCharactersCspaCostAsync(inputToken, characters);

            Assert.Equal(2950, getCharactersCspaCost);
        }

        [Fact]
        public void GetCharactersFatigue_successfully_returns_a_charactersFatigue()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_fatigue_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            V1CharactersFatigue getCharactersFatigue = internalLatestCharacter.GetCharactersFatigue(inputToken);

            Assert.Equal(new DateTime(2017, 07, 05, 15, 47, 00), getCharactersFatigue.LastJumpDate);
            Assert.Equal(new DateTime(2017, 07, 06, 15, 47, 00), getCharactersFatigue.JumpFatigueExpireDate);
            Assert.Equal(new DateTime(2017, 07, 05, 15, 42, 00), getCharactersFatigue.LastUpdateDate);
        }

        [Fact]
        public async Task GetCharactersFatigueAsync_successfully_returns_a_charactersFatigue()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_fatigue_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            V1CharactersFatigue getCharactersFatigue = await internalLatestCharacter.GetCharactersFatigueAsync(inputToken);

            Assert.Equal(new DateTime(2017, 07, 05, 15, 47, 00), getCharactersFatigue.LastJumpDate);
            Assert.Equal(new DateTime(2017, 07, 06, 15, 47, 00), getCharactersFatigue.JumpFatigueExpireDate);
            Assert.Equal(new DateTime(2017, 07, 05, 15, 42, 00), getCharactersFatigue.LastUpdateDate);
        }

        [Fact]
        public void GetCharactersMedals_successfully_returns_a_list_of_charactersMedels()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_medals_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V1CharactersMedals> getCharactersMedals = internalLatestCharacter.GetCharactersMedals(inputToken);

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
        public async Task GetCharactersMedalsAsync_successfully_returns_a_list_of_charactersMedels()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_medals_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V1CharactersMedals> getCharactersMedals = await internalLatestCharacter.GetCharactersMedalsAsync(inputToken);

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
        public void GetCharactersNotifications_successfully_returns_a_list_of_charactersNotifications()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_notifications_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V4CharactersNotifications> getCharactersNotifications = internalLatestCharacter.GetCharactersNotifications(inputToken);

            Assert.Equal(1, getCharactersNotifications.Count);
            Assert.Equal(1, getCharactersNotifications.First().NotificationId);
            Assert.Equal(NotificationType.InsurancePayoutMsg, getCharactersNotifications.First().Type);
            Assert.Equal(SenderType.Corporation, getCharactersNotifications.First().SenderType);
            Assert.Equal(new DateTime(2017, 08, 16, 10, 08, 00), getCharactersNotifications.First().Timestamp);
            Assert.True(getCharactersNotifications.First().IsRead);
        }

        [Fact]
        public async Task GetCharactersNotificationsAsync_successfully_returns_a_list_of_charactersNotifications()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_notifications_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V4CharactersNotifications> getCharactersNotifications = await internalLatestCharacter.GetCharactersNotificationsAsync(inputToken);

            Assert.Equal(1, getCharactersNotifications.Count);
            Assert.Equal(1, getCharactersNotifications.First().NotificationId);
            Assert.Equal(NotificationType.InsurancePayoutMsg, getCharactersNotifications.First().Type);
            Assert.Equal(SenderType.Corporation, getCharactersNotifications.First().SenderType);
            Assert.Equal(new DateTime(2017, 08, 16, 10, 08, 00), getCharactersNotifications.First().Timestamp);
            Assert.True(getCharactersNotifications.First().IsRead);
        }

        [Fact]
        public void GetCharactersNotificationsContacts_successfully_returns_a_list_of_charactersNotificationsContacts()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_notifications_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V1CharactersNotificationsContacts> getCharactersNotificationsContacts = internalLatestCharacter.GetCharactersNotificationsContacts(inputToken);

            Assert.Equal(1, getCharactersNotificationsContacts.Count);
            Assert.Equal(1, getCharactersNotificationsContacts.First().NotificationId);
            Assert.Equal(95465499, getCharactersNotificationsContacts.First().SenderCharacterId);
            Assert.Equal(new DateTime(2017, 08, 16, 10, 08, 00), getCharactersNotificationsContacts.First().SendDate);
            Assert.Equal(1.5, getCharactersNotificationsContacts.First().StandingLevel);
        }

        [Fact]
        public async Task GetCharactersNotificationsContactsAsync_successfully_returns_a_list_of_charactersNotificationsContacts()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_notifications_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V1CharactersNotificationsContacts> getCharactersNotificationsContacts = await internalLatestCharacter.GetCharactersNotificationsContactsAsync(inputToken);

            Assert.Equal(1, getCharactersNotificationsContacts.Count);
            Assert.Equal(1, getCharactersNotificationsContacts.First().NotificationId);
            Assert.Equal(95465499, getCharactersNotificationsContacts.First().SenderCharacterId);
            Assert.Equal(new DateTime(2017, 08, 16, 10, 08, 00), getCharactersNotificationsContacts.First().SendDate);
            Assert.Equal(1.5, getCharactersNotificationsContacts.First().StandingLevel);
        }

        [Fact]
        public void GetCharactersPortrait_successfully_returns_a_charactersPortraits()
        {
            int characterId = 88823;

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            V2CharactersPortrait getCharactersPortrait = internalLatestCharacter.GetCharactersPortrait(characterId);

            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_64.jpg", getCharactersPortrait.Px64X64);
            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_128.jpg", getCharactersPortrait.Px128X128);
            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_256.jpg", getCharactersPortrait.Px256X256);
            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_512.jpg", getCharactersPortrait.Px512X512);
        }

        [Fact]
        public async Task GetCharactersPortraitAsync_successfully_returns_a_charactersPortraits()
        {
            int characterId = 88823;

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            V2CharactersPortrait getCharactersPortrait = await internalLatestCharacter.GetCharactersPortraitAsync(characterId);

            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_64.jpg", getCharactersPortrait.Px64X64);
            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_128.jpg", getCharactersPortrait.Px128X128);
            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_256.jpg", getCharactersPortrait.Px256X256);
            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_512.jpg", getCharactersPortrait.Px512X512);
        }

        [Fact]
        public void GetCharactersRoles_successfully_returns_a_characterRoles()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_corporation_roles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            V2CharacterRoles getCharactersRoles = internalLatestCharacter.GetCharactersRoles(inputToken);

            Assert.Equal(2, getCharactersRoles.Roles.Count);
            Assert.Equal(CharacterRoles.Director, getCharactersRoles.Roles[0]);
            Assert.Equal(CharacterRoles.StationManager, getCharactersRoles.Roles[1]);
            Assert.Equal(0, getCharactersRoles.RolesAtHq.Count);
            Assert.Equal(0, getCharactersRoles.RolesAtBase.Count);
            Assert.Equal(0, getCharactersRoles.RolesAtOther.Count);
        }

        [Fact]
        public async Task GetCharactersRolesAsync_successfully_returns_a_characterRoles()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_corporation_roles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            V2CharacterRoles getCharactersRoles = await internalLatestCharacter.GetCharactersRolesAsync(inputToken);

            Assert.Equal(2, getCharactersRoles.Roles.Count);
            Assert.Equal(CharacterRoles.Director, getCharactersRoles.Roles[0]);
            Assert.Equal(CharacterRoles.StationManager, getCharactersRoles.Roles[1]);
            Assert.Equal(0, getCharactersRoles.RolesAtHq.Count);
            Assert.Equal(0, getCharactersRoles.RolesAtBase.Count);
            Assert.Equal(0, getCharactersRoles.RolesAtOther.Count);
        }

        [Fact]
        public void GetCharactersStandings_successfully_returns_a_list_of_charactersStandings()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_standings_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V2CharactersStandings> getCharactersStandings = internalLatestCharacter.GetCharactersStandings(inputToken);

            Assert.Equal(3, getCharactersStandings.Count);
            Assert.Equal(3009841, getCharactersStandings.First().FromId);
            Assert.Equal(StandingFromType.Agent, getCharactersStandings.First().FromType);
            Assert.Equal(0.1f, getCharactersStandings.First().Standing);
            Assert.Equal(StandingFromType.NpcCorp, getCharactersStandings[1].FromType);
            Assert.Equal(StandingFromType.Faction, getCharactersStandings[2].FromType);
        }

        [Fact]
        public async Task GetCharactersStandingsAsync_successfully_returns_a_list_of_charactersStandings()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_standings_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V2CharactersStandings> getCharactersStandings = await internalLatestCharacter.GetCharactersStandingsAsync(inputToken);

            Assert.Equal(3, getCharactersStandings.Count);
            Assert.Equal(3009841, getCharactersStandings.First().FromId);
            Assert.Equal(StandingFromType.Agent, getCharactersStandings.First().FromType);
            Assert.Equal(0.1f, getCharactersStandings.First().Standing);
            Assert.Equal(StandingFromType.NpcCorp, getCharactersStandings[1].FromType);
            Assert.Equal(StandingFromType.Faction, getCharactersStandings[2].FromType);
        }

        [Fact]
        public void GetCharactersStats_successfully_returns_a_list_of_charactersStats()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characterstats_read_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
 
            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V2CharactersStats> getCharactersStats = internalLatestCharacter.GetCharactersStats(inputToken);

            Assert.Equal(2, getCharactersStats.Count);
            Assert.Equal(2014, getCharactersStats.First().Year);
            Assert.Equal(365, getCharactersStats.First().Character.DaysOfActivity);
            Assert.Equal(42, getCharactersStats.First().Combat.KillsLowSec);
            Assert.Equal(365, getCharactersStats[1].Character.DaysOfActivity);
            Assert.Equal(1337, getCharactersStats[1].Combat.KillsNullSec);
        }

        [Fact]
        public async Task GetCharactersStatsAsync_successfully_returns_a_list_of_charactersStats()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characterstats_read_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V2CharactersStats> getCharactersStats = await internalLatestCharacter.GetCharactersStatsAsync(inputToken);

            Assert.Equal(2, getCharactersStats.Count);
            Assert.Equal(2014, getCharactersStats.First().Year);
            Assert.Equal(365, getCharactersStats.First().Character.DaysOfActivity);
            Assert.Equal(42, getCharactersStats.First().Combat.KillsLowSec);
            Assert.Equal(365, getCharactersStats[1].Character.DaysOfActivity);
            Assert.Equal(1337, getCharactersStats[1].Combat.KillsNullSec);
        }

        [Fact]
        public void GetCharactersTitles_successfully_returns_a_list_of_charactersTitles()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V1CharacterTitles> getCharactersTitles = internalLatestCharacter.GetCharactersTitles(inputToken);

            Assert.Equal(1, getCharactersTitles.Count);
            Assert.Equal(1, getCharactersTitles.First().TitleId);
            Assert.Equal("Awesome Title", getCharactersTitles.First().Name);
        }

        [Fact]
        public async Task GetCharactersTitlesAsync_successfully_returns_a_list_of_charactersTitles()
        {
            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V1CharacterTitles> getCharactersTitles = await internalLatestCharacter.GetCharactersTitlesAsync(inputToken);

            Assert.Equal(1, getCharactersTitles.Count);
            Assert.Equal(1, getCharactersTitles.First().TitleId);
            Assert.Equal("Awesome Title", getCharactersTitles.First().Name);
        }

        [Fact]
        public void GetCharactersAffiliation_successfully_returns_a_list_of_charactersAffiliation()
        {
            IList<int> characterIds = new List<int>(23);

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V1CharacterAffiliations> getCharactersAffiliation = internalLatestCharacter.GetCharactersAffiliation(characterIds);

            Assert.Equal(1, getCharactersAffiliation.Count);
            Assert.Equal(95538921, getCharactersAffiliation.First().CharacterId);
            Assert.Equal(109299958, getCharactersAffiliation.First().CorporationId);
            Assert.Equal(434243723, getCharactersAffiliation.First().AllianceId);
        }

        [Fact]
        public async Task GetCharactersAffiliationAsync_successfully_returns_a_list_of_charactersAffiliation()
        {
            IList<int> characterIds = new List<int>(23);

            LatestCharacterEndpoints internalLatestCharacter = new LatestCharacterEndpoints(string.Empty, true);

            IList<V1CharacterAffiliations> getCharactersAffiliation = await internalLatestCharacter.GetCharactersAffiliationAsync(characterIds);

            Assert.Equal(1, getCharactersAffiliation.Count);
            Assert.Equal(95538921, getCharactersAffiliation.First().CharacterId);
            Assert.Equal(109299958, getCharactersAffiliation.First().CorporationId);
            Assert.Equal(434243723, getCharactersAffiliation.First().AllianceId);
        }
    }
}
