using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibrary.Tests
{
    public class CharacterTests
    {
        [Fact]
        public void PublicInfo_Successfully_returns_a_V4CharactersPublicInfo()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;

            string json = "{\"corporation_id\": 109299958,\"birthday\": \"2015-03-24T11:37:00Z\",\"name\": \"CCP Bartender\",\"gender\": \"male\",\"race_id\": 2,\"description\": \"\",\"bloodline_id\": 3,\"ancestry_id\": 19}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            V4CharactersPublicInfo v4CharactersPublicInfo = internalLatestCharacter.PublicInfo(characterId);

            Assert.Equal(Gender.Male, v4CharactersPublicInfo.Gender);
            Assert.Equal(109299958, v4CharactersPublicInfo.CorporationId);
            Assert.Equal(new DateTime(2015, 03, 24, 11, 37, 0), v4CharactersPublicInfo.Birthday);
        }

        [Fact]
        public async Task PublicInfoAsync_Successfully_returns_a_V4CharactersPublicInfo()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;

            string json = "{\"corporation_id\": 109299958,\"birthday\": \"2015-03-24T11:37:00Z\",\"name\": \"CCP Bartender\",\"gender\": \"male\",\"race_id\": 2,\"description\": \"\",\"bloodline_id\": 3,\"ancestry_id\": 19}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            V4CharactersPublicInfo v4CharactersPublicInfo = await internalLatestCharacter.PublicInfoAsync(characterId);

            Assert.Equal(Gender.Male, v4CharactersPublicInfo.Gender);
            Assert.Equal(109299958, v4CharactersPublicInfo.CorporationId);
            Assert.Equal(new DateTime(2015, 03, 24, 11, 37, 0), v4CharactersPublicInfo.Birthday);
        }

        [Fact]
        public void ResearchAgents_successfully_returns_a_list_of_V1CharactersResearchAgents()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_agents_research_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[{\"agent_id\": 3009358,\"skill_type_id\": 11450,\"started_at\": \"2017-03-23T14:47:00Z\",\"points_per_day\": 53.5346162146776,\"remainder_points\": 53604.0634303189}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V1CharactersResearchAgents> getCharactersResearchAgents = internalLatestCharacter.ResearchAgents(inputToken);

            Assert.Equal(1, getCharactersResearchAgents.Count);
            Assert.Equal(3009358, getCharactersResearchAgents.First().AgentId);
            Assert.Equal(new DateTime(2017, 03, 23, 14, 47, 00), getCharactersResearchAgents.First().StartedAt);
        }

        [Fact]
        public async Task ResearchAgentsAsync_successfully_returns_a_list_of_V1CharactersResearchAgents()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_agents_research_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[{\"agent_id\": 3009358,\"skill_type_id\": 11450,\"started_at\": \"2017-03-23T14:47:00Z\",\"points_per_day\": 53.5346162146776,\"remainder_points\": 53604.0634303189}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V1CharactersResearchAgents> getCharactersResearchAgents = await internalLatestCharacter.ResearchAgentsAsync(inputToken);

            Assert.Equal(1, getCharactersResearchAgents.Count);
            Assert.Equal(3009358, getCharactersResearchAgents.First().AgentId);
            Assert.Equal(new DateTime(2017, 03, 23, 14, 47, 00), getCharactersResearchAgents.First().StartedAt);
        }

        [Fact]
        public void Blueprints_successfully_returns_a_list_of_V2CharactersBlueprints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_blueprints_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[{\"item_id\": 1000000010495,\"type_id\": 691,\"location_id\": 60014719,\"location_flag\": \"Hangar\",\"quantity\": 1,\"time_efficiency\": 0,\"material_efficiency\": 0,\"runs\": -1}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V2CharactersBlueprints> getCharactersBlueprint = internalLatestCharacter.Blueprints(inputToken);

            Assert.Equal(1, getCharactersBlueprint.Count);
            Assert.Equal(1000000010495, getCharactersBlueprint.First().ItemId);
            Assert.Equal(LocationFlagCharacter.Hangar, getCharactersBlueprint.First().LocationFlag);
            Assert.Equal(-1, getCharactersBlueprint.First().Runs);
        }

        [Fact]
        public async Task BlueprintsAsync_successfully_returns_a_list_of_V2CharactersBlueprints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_blueprints_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[{\"item_id\": 1000000010495,\"type_id\": 691,\"location_id\": 60014719,\"location_flag\": \"Hangar\",\"quantity\": 1,\"time_efficiency\": 0,\"material_efficiency\": 0,\"runs\": -1}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V2CharactersBlueprints> getCharactersBlueprint = await internalLatestCharacter.BlueprintsAsync(inputToken);

            Assert.Equal(1, getCharactersBlueprint.Count);
            Assert.Equal(1000000010495, getCharactersBlueprint.First().ItemId);
            Assert.Equal(LocationFlagCharacter.Hangar, getCharactersBlueprint.First().LocationFlag);
            Assert.Equal(-1, getCharactersBlueprint.First().Runs);
        }

        [Fact]
        public void CorporationHistory_successfully_returns_a_list_of_V2CharactersCorporationHistory()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;

            string json = "[{\"start_date\": \"2016-06-26T20:00:00Z\",\"corporation_id\": 90000001,\"is_deleted\": true,\"record_id\": 500},{\"start_date\": \"2016-07-26T20:00:00Z\",\"corporation_id\": 90000002,\"record_id\": 501}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V2CharactersCorporationHistory> getCharactersCorporationHistory = internalLatestCharacter.CorporationHistory(characterId);

            Assert.Equal(2, getCharactersCorporationHistory.Count);
            Assert.Equal(90000001, getCharactersCorporationHistory.First().CorporationId);
            Assert.True(getCharactersCorporationHistory.First().IsDeleted);
            Assert.Equal(new DateTime(2016, 06, 26, 20, 00, 00), getCharactersCorporationHistory.First().StartDate);
        }

        [Fact]
        public async Task CorporationHistoryAsync_successfully_returns_a_list_of_V2CharactersCorporationHistory()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;

            string json = "[{\"start_date\": \"2016-06-26T20:00:00Z\",\"corporation_id\": 90000001,\"is_deleted\": true,\"record_id\": 500},{\"start_date\": \"2016-07-26T20:00:00Z\",\"corporation_id\": 90000002,\"record_id\": 501}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V2CharactersCorporationHistory> getCharactersCorporationHistory = await internalLatestCharacter.CorporationHistoryAsync(characterId);

            Assert.Equal(2, getCharactersCorporationHistory.Count);
            Assert.Equal(90000001, getCharactersCorporationHistory.First().CorporationId);
            Assert.True(getCharactersCorporationHistory.First().IsDeleted);
            Assert.Equal(new DateTime(2016, 06, 26, 20, 00, 00), getCharactersCorporationHistory.First().StartDate);
        }

        [Fact]
        public void CspaCost_successfully_returns_a_float()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_contacts_v1;
            IList<int> characters = new List<int>(2);

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "2950";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            float getCharactersCspaCost = internalLatestCharacter.CspaCost(inputToken, characters);

            Assert.Equal(2950, getCharactersCspaCost);
        }

        [Fact]
        public async Task CspaCostAsync_successfully_returns_a_float()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_contacts_v1;
            IList<int> characters = new List<int>(2);

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "2950";

            mockedWebClient.Setup(x => x.PostAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            float getCharactersCspaCost = await internalLatestCharacter.CspaCostAsync(inputToken, characters);

            Assert.Equal(2950, getCharactersCspaCost);
        }

        [Fact]
        public void Fatigue_successfully_returns_a_V1CharactersFatigue()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_fatigue_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "{\"last_jump_date\": \"2017-07-05T15:47:00Z\",\"jump_fatigue_expire_date\": \"2017-07-06T15:47:00Z\",\"last_update_date\": \"2017-07-05T15:42:00Z\"}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            V1CharactersFatigue getCharactersFatigue = internalLatestCharacter.Fatigue(inputToken);

            Assert.Equal(new DateTime(2017, 07, 05, 15, 47, 00), getCharactersFatigue.LastJumpDate);
            Assert.Equal(new DateTime(2017, 07, 06, 15, 47, 00), getCharactersFatigue.JumpFatigueExpireDate);
            Assert.Equal(new DateTime(2017, 07, 05, 15, 42, 00), getCharactersFatigue.LastUpdateDate);
        }

        [Fact]
        public async Task FatigueAsync_successfully_returns_a_V1CharactersFatigue()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_fatigue_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "{\"last_jump_date\": \"2017-07-05T15:47:00Z\",\"jump_fatigue_expire_date\": \"2017-07-06T15:47:00Z\",\"last_update_date\": \"2017-07-05T15:42:00Z\"}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            V1CharactersFatigue getCharactersFatigue = await internalLatestCharacter.FatigueAsync(inputToken);

            Assert.Equal(new DateTime(2017, 07, 05, 15, 47, 00), getCharactersFatigue.LastJumpDate);
            Assert.Equal(new DateTime(2017, 07, 06, 15, 47, 00), getCharactersFatigue.JumpFatigueExpireDate);
            Assert.Equal(new DateTime(2017, 07, 05, 15, 42, 00), getCharactersFatigue.LastUpdateDate);
        }

        [Fact]
        public void Medals_successfully_returns_a_list_of_V1CharactersMedals()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_medals_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[{\"medal_id\": 3,\"title\": \"33 tester medal\",\"description\": \"For 33 corp!\",\"corporation_id\": 98000001,\"issuer_id\": 2112000002,\"date\": \"2017-03-16T15:01:45Z\",\"reason\": \"Thanks!\",\"status\": \"private\",\"graphics\": [{\"part\": 1,\"layer\": 0,\"graphic\": \"caldari.1_1\",\"color\": -1},{\"part\": 1,\"layer\": 1,\"graphic\": \"caldari.1_2\",\"color\": -330271},{\"part\": 2,\"layer\": 0,\"graphic\": \"compass.1_2\",\"color\": -1}]}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_medals_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[{\"medal_id\": 3,\"title\": \"33 tester medal\",\"description\": \"For 33 corp!\",\"corporation_id\": 98000001,\"issuer_id\": 2112000002,\"date\": \"2017-03-16T15:01:45Z\",\"reason\": \"Thanks!\",\"status\": \"private\",\"graphics\": [{\"part\": 1,\"layer\": 0,\"graphic\": \"caldari.1_1\",\"color\": -1},{\"part\": 1,\"layer\": 1,\"graphic\": \"caldari.1_2\",\"color\": -330271},{\"part\": 2,\"layer\": 0,\"graphic\": \"compass.1_2\",\"color\": -1}]}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_notifications_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[{\"notification_id\": 1,\"type\": \"InsurancePayoutMsg\",\"sender_id\": 1000132,\"sender_type\": \"corporation\",\"timestamp\": \"2017-08-16T10:08:00Z\",\"is_read\": true,\"text\": \"amount: 3731016.4000000004\\\\nitemID: 1024881021663\\\\npayout: 1\\\\n\"}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_notifications_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[{\"notification_id\": 1,\"type\": \"InsurancePayoutMsg\",\"sender_id\": 1000132,\"sender_type\": \"corporation\",\"timestamp\": \"2017-08-16T10:08:00Z\",\"is_read\": true,\"text\": \"amount: 3731016.4000000004\\\\nitemID: 1024881021663\\\\npayout: 1\\\\n\"}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_notifications_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[{\"notification_id\": 1,\"sender_character_id\": 95465499,\"send_date\": \"2017-08-16T10:08:00Z\",\"standing_level\": 1.5,\"message\": \"hello friend :3\"}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_notifications_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[{\"notification_id\": 1,\"sender_character_id\": 95465499,\"send_date\": \"2017-08-16T10:08:00Z\",\"standing_level\": 1.5,\"message\": \"hello friend :3\"}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;

            string json = "{\"px64x64\": \"https://images.evetech.net/Character/95465499_64.jpg\",\"px128x128\": \"https://images.evetech.net/Character/95465499_128.jpg\",\"px256x256\": \"https://images.evetech.net/Character/95465499_256.jpg\",\"px512x512\": \"https://images.evetech.net/Character/95465499_512.jpg\"}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel{Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            V2CharactersPortrait getCharactersPortrait = internalLatestCharacter.Portrait(characterId);

            Assert.Equal("https://images.evetech.net/Character/95465499_64.jpg", getCharactersPortrait.Px64X64);
            Assert.Equal("https://images.evetech.net/Character/95465499_128.jpg", getCharactersPortrait.Px128X128);
            Assert.Equal("https://images.evetech.net/Character/95465499_256.jpg", getCharactersPortrait.Px256X256);
            Assert.Equal("https://images.evetech.net/Character/95465499_512.jpg", getCharactersPortrait.Px512X512);
        }

        [Fact]
        public async Task PortraitAsync_successfully_returns_a_V2CharactersPortrait()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;

            string json = "{\"px64x64\": \"https://imageserver.eveonline.com/Character/95465499_64.jpg\",\"px128x128\": \"https://imageserver.eveonline.com/Character/95465499_128.jpg\",\"px256x256\": \"https://imageserver.eveonline.com/Character/95465499_256.jpg\",\"px512x512\": \"https://imageserver.eveonline.com/Character/95465499_512.jpg\"}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            V2CharactersPortrait getCharactersPortrait = await internalLatestCharacter.PortraitAsync(characterId);

            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_64.jpg", getCharactersPortrait.Px64X64);
            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_128.jpg", getCharactersPortrait.Px128X128);
            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_256.jpg", getCharactersPortrait.Px256X256);
            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_512.jpg", getCharactersPortrait.Px512X512);
        }

        [Fact]
        public void Roles_successfully_returns_a_V3CharacterRoles()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_corporation_roles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "{\"roles\": [\"Director\",\"Station_Manager\"]}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_corporation_roles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "{\"roles\": [\"Director\",\"Station_Manager\"]}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_standings_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[{\"from_id\": 3009841,\"from_type\": \"agent\",\"standing\": 0.1},{\"from_id\": 1000061,\"from_type\": \"npc_corp\",\"standing\": 0},{\"from_id\": 500003,\"from_type\": \"faction\",\"standing\": -1}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_standings_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[{\"from_id\": 3009841,\"from_type\": \"agent\",\"standing\": 0.1},{\"from_id\": 1000061,\"from_type\": \"npc_corp\",\"standing\": 0},{\"from_id\": 500003,\"from_type\": \"faction\",\"standing\": -1}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[{\"title_id\": 1,\"name\": \"Awesome Title\"}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V2CharacterTitles> getCharactersTitles = internalLatestCharacter.Titles(inputToken);

            Assert.Equal(1, getCharactersTitles.Count);
            Assert.Equal(1, getCharactersTitles.First().TitleId);
            Assert.Equal("Awesome Title", getCharactersTitles.First().Name);
        }

        [Fact]
        public async Task TitlesAsync_successfully_returns_a_list_of_V2CharacterTitles()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            CharacterScopes scopes = CharacterScopes.esi_characters_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterScopesFlags = scopes };
            string json = "[{\"title_id\": 1,\"name\": \"Awesome Title\"}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V2CharacterTitles> getCharactersTitles = await internalLatestCharacter.TitlesAsync(inputToken);

            Assert.Equal(1, getCharactersTitles.Count);
            Assert.Equal(1, getCharactersTitles.First().TitleId);
            Assert.Equal("Awesome Title", getCharactersTitles.First().Name);
        }

        [Fact]
        public void Affiliations_successfully_returns_a_list_of_V2CharacterAffiliations()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            IList<int> characterIds = new List<int>(23);

            string json = "[{\"character_id\": 95538921,\"corporation_id\": 109299958,\"alliance_id\": 434243723}]";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V2CharacterAffiliations> getCharactersAffiliation = internalLatestCharacter.Affiliations(characterIds);

            Assert.Equal(1, getCharactersAffiliation.Count);
            Assert.Equal(95538921, getCharactersAffiliation.First().CharacterId);
            Assert.Equal(109299958, getCharactersAffiliation.First().CorporationId);
            Assert.Equal(434243723, getCharactersAffiliation.First().AllianceId);
        }

        [Fact]
        public async Task AffiliationsAsync_successfully_returns_a_list_of_V2CharacterAffiliations()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            IList<int> characterIds = new List<int>(23);

            string json = "[{\"character_id\": 95538921,\"corporation_id\": 109299958,\"alliance_id\": 434243723}]";

            mockedWebClient.Setup(x => x.PostAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V2CharacterAffiliations> getCharactersAffiliation = await internalLatestCharacter.AffiliationsAsync(characterIds);

            Assert.Equal(1, getCharactersAffiliation.Count);
            Assert.Equal(95538921, getCharactersAffiliation.First().CharacterId);
            Assert.Equal(109299958, getCharactersAffiliation.First().CorporationId);
            Assert.Equal(434243723, getCharactersAffiliation.First().AllianceId);
        }
    }
}
