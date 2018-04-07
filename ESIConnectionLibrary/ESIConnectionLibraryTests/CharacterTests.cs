using System;
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
    public class CharacterTests
    {
        [Fact]
        public void GetCharactersPublicInfo_Successfully_returns_a_characterPublicInfo()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;

            string getCharactersPublicInfoJson = "{\"corporation_id\": 109299958,\"birthday\": \"2015-03-24T11:37:00Z\",\"name\": \"CCP Bartender\",\"gender\": \"male\",\"race_id\": 2,\"description\": \"\",\"bloodline_id\": 3,\"ancestry_id\": 19}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersPublicInfoJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            V4CharactersPublicInfo v4CharactersPublicInfo = internalLatestCharacter.GetCharactersPublicInfo(characterId);

            Assert.Equal(Gender.male, v4CharactersPublicInfo.Gender);
            Assert.Equal(109299958, v4CharactersPublicInfo.CorporationId);
            Assert.Equal(new DateTime(2015, 03, 24, 11, 37, 0), v4CharactersPublicInfo.Birthday);
        }

        [Fact]
        public async Task GetCharactersPublicInfoAsync_Successfully_returns_a_characterPublicInfo()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;

            string getCharactersPublicInfoJson = "{\"corporation_id\": 109299958,\"birthday\": \"2015-03-24T11:37:00Z\",\"name\": \"CCP Bartender\",\"gender\": \"male\",\"race_id\": 2,\"description\": \"\",\"bloodline_id\": 3,\"ancestry_id\": 19}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getCharactersPublicInfoJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            V4CharactersPublicInfo v4CharactersPublicInfo = await internalLatestCharacter.GetCharactersPublicInfoAsync(characterId);

            Assert.Equal(Gender.male, v4CharactersPublicInfo.Gender);
            Assert.Equal(109299958, v4CharactersPublicInfo.CorporationId);
            Assert.Equal(new DateTime(2015, 03, 24, 11, 37, 0), v4CharactersPublicInfo.Birthday);
        }

        [Fact]
        public void GetCharactersResearchAgents_successfully_returns_a_list_of_charactersResearchAgents()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_agents_research_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersResearchAgentsJson = "[{\"agent_id\": 3009358,\"skill_type_id\": 11450,\"started_at\": \"2017-03-23T14:47:00Z\",\"points_per_day\": 53.5346162146776,\"remainder_points\": 53604.0634303189}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersResearchAgentsJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V1CharactersResearchAgents> getCharactersResearchAgents = internalLatestCharacter.GetCharactersResearchAgents(inputToken, characterId);

            Assert.Equal(1, getCharactersResearchAgents.Count);
            Assert.Equal(3009358, getCharactersResearchAgents.First().AgentId);
            Assert.Equal(new DateTime(2017, 03, 23, 14, 47, 00), getCharactersResearchAgents.First().StartedAt);
        }

        [Fact]
        public async Task GetCharactersResearchAgentsAsync_successfully_returns_a_list_of_charactersResearchAgents()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_agents_research_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersResearchAgentsJson = "[{\"agent_id\": 3009358,\"skill_type_id\": 11450,\"started_at\": \"2017-03-23T14:47:00Z\",\"points_per_day\": 53.5346162146776,\"remainder_points\": 53604.0634303189}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getCharactersResearchAgentsJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V1CharactersResearchAgents> getCharactersResearchAgents = await internalLatestCharacter.GetCharactersResearchAgentsAsync(inputToken, characterId);

            Assert.Equal(1, getCharactersResearchAgents.Count);
            Assert.Equal(3009358, getCharactersResearchAgents.First().AgentId);
            Assert.Equal(new DateTime(2017, 03, 23, 14, 47, 00), getCharactersResearchAgents.First().StartedAt);
        }

        [Fact]
        public void GetCharactersBlueprint_successfully_returns_a_list_of_charactersBlueprints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_blueprints_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersBlueprintJson = "[{\"item_id\": 1000000010495,\"type_id\": 691,\"location_id\": 60014719,\"location_flag\": \"Hangar\",\"quantity\": 1,\"time_efficiency\": 0,\"material_efficiency\": 0,\"runs\": -1}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersBlueprintJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V2CharactersBlueprints> getCharactersBlueprint = internalLatestCharacter.GetCharactersBlueprint(inputToken, characterId);

            Assert.Equal(1, getCharactersBlueprint.Count);
            Assert.Equal(1000000010495, getCharactersBlueprint.First().ItemId);
            Assert.Equal(LocationFlagCharacter.Hangar, getCharactersBlueprint.First().LocationFlag);
            Assert.Equal(-1, getCharactersBlueprint.First().Runs);
        }

        [Fact]
        public async Task GetCharactersBlueprintAsync_successfully_returns_a_list_of_charactersBlueprints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_blueprints_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersBlueprintJson = "[{\"item_id\": 1000000010495,\"type_id\": 691,\"location_id\": 60014719,\"location_flag\": \"Hangar\",\"quantity\": 1,\"time_efficiency\": 0,\"material_efficiency\": 0,\"runs\": -1}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getCharactersBlueprintJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V2CharactersBlueprints> getCharactersBlueprint = await internalLatestCharacter.GetCharactersBlueprintAsync(inputToken, characterId);

            Assert.Equal(1, getCharactersBlueprint.Count);
            Assert.Equal(1000000010495, getCharactersBlueprint.First().ItemId);
            Assert.Equal(LocationFlagCharacter.Hangar, getCharactersBlueprint.First().LocationFlag);
            Assert.Equal(-1, getCharactersBlueprint.First().Runs);
        }

        [Fact]
        public void GetCharactersChatChannels_successfully_returns_a_list_of_charactersChatChannels()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_chat_channels_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersChatChannelsJson = "[{\"channel_id\": -69329950,\"name\": \"Players\' Haven\",\"owner_id\": 95578451,\"comparison_key\": \"players\'haven\",\"has_password\": false,\"motd\": \"<b>Feed pineapples to the cats!</b>\",\"allowed\": [],\"operators\": [],\"blocked\": [],\"muted\": []}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersChatChannelsJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V1CharactersChatChannels> getCharactersChatChannels = internalLatestCharacter.GetCharactersChatChannels(inputToken, characterId);

            Assert.Equal(1, getCharactersChatChannels.Count);
            Assert.Equal(-69329950, getCharactersChatChannels.First().ChannelId);
            Assert.False(getCharactersChatChannels.First().HasPassword);
            Assert.Equal(0, getCharactersChatChannels.First().Allowed.Count);
            Assert.Equal(0, getCharactersChatChannels.First().Operators.Count);
            Assert.Equal(0, getCharactersChatChannels.First().Blocked.Count);
            Assert.Equal(0, getCharactersChatChannels.First().Muted.Count);
        }

        [Fact]
        public async Task GetCharactersChatChannelsAsync_successfully_returns_a_list_of_charactersChatChannels()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_chat_channels_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersChatChannelsJson = "[{\"channel_id\": -69329950,\"name\": \"Players\' Haven\",\"owner_id\": 95578451,\"comparison_key\": \"players\'haven\",\"has_password\": false,\"motd\": \"<b>Feed pineapples to the cats!</b>\",\"allowed\": [],\"operators\": [],\"blocked\": [],\"muted\": []}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getCharactersChatChannelsJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V1CharactersChatChannels> getCharactersChatChannels = await internalLatestCharacter.GetCharactersChatChannelsAsync(inputToken, characterId);

            Assert.Equal(1, getCharactersChatChannels.Count);
            Assert.Equal(-69329950, getCharactersChatChannels.First().ChannelId);
            Assert.False(getCharactersChatChannels.First().HasPassword);
            Assert.Equal(0, getCharactersChatChannels.First().Allowed.Count);
            Assert.Equal(0, getCharactersChatChannels.First().Operators.Count);
            Assert.Equal(0, getCharactersChatChannels.First().Blocked.Count);
            Assert.Equal(0, getCharactersChatChannels.First().Muted.Count);
        }

        [Fact]
        public void GetCharactersCorporationHistory_successfully_returns_a_list_of_charactersCorporationHistory()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;

            string getCharactersCorporationHistoryJson = "[{\"start_date\": \"2016-06-26T20:00:00Z\",\"corporation_id\": 90000001,\"is_deleted\": true,\"record_id\": 500},{\"start_date\": \"2016-07-26T20:00:00Z\",\"corporation_id\": 90000002,\"record_id\": 501}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersCorporationHistoryJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V1CharactersCorporationHistory> getCharactersCorporationHistory = internalLatestCharacter.GetCharactersCorporationHistory(characterId);

            Assert.Equal(2, getCharactersCorporationHistory.Count);
            Assert.Equal(90000001, getCharactersCorporationHistory.First().CorporationId);
            Assert.True(getCharactersCorporationHistory.First().IsDeleted);
            Assert.Equal(new DateTime(2016, 06, 26, 20, 00, 00), getCharactersCorporationHistory.First().StartDate);
        }

        [Fact]
        public async Task GetCharactersCorporationHistoryAsync_successfully_returns_a_list_of_charactersCorporationHistory()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;

            string getCharactersCorporationHistoryJson = "[{\"start_date\": \"2016-06-26T20:00:00Z\",\"corporation_id\": 90000001,\"is_deleted\": true,\"record_id\": 500},{\"start_date\": \"2016-07-26T20:00:00Z\",\"corporation_id\": 90000002,\"record_id\": 501}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getCharactersCorporationHistoryJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V1CharactersCorporationHistory> getCharactersCorporationHistory = await internalLatestCharacter.GetCharactersCorporationHistoryAsync(characterId);

            Assert.Equal(2, getCharactersCorporationHistory.Count);
            Assert.Equal(90000001, getCharactersCorporationHistory.First().CorporationId);
            Assert.True(getCharactersCorporationHistory.First().IsDeleted);
            Assert.Equal(new DateTime(2016, 06, 26, 20, 00, 00), getCharactersCorporationHistory.First().StartDate);
        }

        [Fact]
        public void GetCharactersCspaCost_successfully_returns_a_list_of_charactersCspaCosts()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_contacts_v1;
            IList<int> characters = new List<int>(2);

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersCspaCostJson = "2950";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersCspaCostJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            float getCharactersCspaCost = internalLatestCharacter.GetCharactersCspaCost(inputToken, characterId, characters);

            Assert.Equal(2950, getCharactersCspaCost);
        }

        [Fact]
        public async Task GetCharactersCspaCostAsync_successfully_returns_a_list_of_charactersCspaCosts()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_contacts_v1;
            IList<int> characters = new List<int>(2);

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersCspaCostJson = "2950";

            mockedWebClient.Setup(x => x.PostAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getCharactersCspaCostJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            float getCharactersCspaCost = await internalLatestCharacter.GetCharactersCspaCostAsync(inputToken, characterId, characters);

            Assert.Equal(2950, getCharactersCspaCost);
        }

        [Fact]
        public void GetCharactersFatigue_successfully_returns_a_charactersFatigue()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_fatigue_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersFatigueJson = "{\"last_jump_date\": \"2017-07-05T15:47:00Z\",\"jump_fatigue_expire_date\": \"2017-07-06T15:47:00Z\",\"last_update_date\": \"2017-07-05T15:42:00Z\"}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersFatigueJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            V1CharactersFatigue getCharactersFatigue = internalLatestCharacter.GetCharactersFatigue(inputToken, characterId);

            Assert.Equal(new DateTime(2017, 07, 05, 15, 47, 00), getCharactersFatigue.LastJumpDate);
            Assert.Equal(new DateTime(2017, 07, 06, 15, 47, 00), getCharactersFatigue.JumpFatigueExpireDate);
            Assert.Equal(new DateTime(2017, 07, 05, 15, 42, 00), getCharactersFatigue.LastUpdateDate);
        }

        [Fact]
        public async Task GetCharactersFatigueAsync_successfully_returns_a_charactersFatigue()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_fatigue_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersFatigueJson = "{\"last_jump_date\": \"2017-07-05T15:47:00Z\",\"jump_fatigue_expire_date\": \"2017-07-06T15:47:00Z\",\"last_update_date\": \"2017-07-05T15:42:00Z\"}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getCharactersFatigueJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            V1CharactersFatigue getCharactersFatigue = await internalLatestCharacter.GetCharactersFatigueAsync(inputToken, characterId);

            Assert.Equal(new DateTime(2017, 07, 05, 15, 47, 00), getCharactersFatigue.LastJumpDate);
            Assert.Equal(new DateTime(2017, 07, 06, 15, 47, 00), getCharactersFatigue.JumpFatigueExpireDate);
            Assert.Equal(new DateTime(2017, 07, 05, 15, 42, 00), getCharactersFatigue.LastUpdateDate);
        }

        [Fact]
        public void GetCharactersMedals_successfully_returns_a_list_of_charactersMedels()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_medals_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersMedalsJson = "[{\"medal_id\": 3,\"title\": \"33 tester medal\",\"description\": \"For 33 corp!\",\"corporation_id\": 98000001,\"issuer_id\": 2112000002,\"date\": \"2017-03-16T15:01:45Z\",\"reason\": \"Thanks!\",\"status\": \"private\",\"graphics\": [{\"part\": 1,\"layer\": 0,\"graphic\": \"caldari.1_1\",\"color\": -1},{\"part\": 1,\"layer\": 1,\"graphic\": \"caldari.1_2\",\"color\": -330271},{\"part\": 2,\"layer\": 0,\"graphic\": \"compass.1_2\",\"color\": -1}]}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersMedalsJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V1CharactersMedals> getCharactersMedals = internalLatestCharacter.GetCharactersMedals(inputToken, characterId);

            Assert.Equal(1, getCharactersMedals.Count);
            Assert.Equal(3, getCharactersMedals.First().MedalId);
            Assert.Equal(new DateTime(2017, 03, 16, 15, 01, 45), getCharactersMedals.First().Date);
            Assert.Equal(MedalsStatus.@private, getCharactersMedals.First().Status);
            Assert.Equal(3, getCharactersMedals.First().Graphics.Count);
            Assert.Equal(1, getCharactersMedals.First().Graphics.First().Part);
            Assert.Equal(0, getCharactersMedals.First().Graphics.First().Layer);
            Assert.Equal("caldari.1_2", getCharactersMedals.First().Graphics[1].Graphic);
            Assert.Equal(-1, getCharactersMedals.First().Graphics[2].Color);
        }

        [Fact]
        public async Task GetCharactersMedalsAsync_successfully_returns_a_list_of_charactersMedels()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_medals_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersMedalsJson = "[{\"medal_id\": 3,\"title\": \"33 tester medal\",\"description\": \"For 33 corp!\",\"corporation_id\": 98000001,\"issuer_id\": 2112000002,\"date\": \"2017-03-16T15:01:45Z\",\"reason\": \"Thanks!\",\"status\": \"private\",\"graphics\": [{\"part\": 1,\"layer\": 0,\"graphic\": \"caldari.1_1\",\"color\": -1},{\"part\": 1,\"layer\": 1,\"graphic\": \"caldari.1_2\",\"color\": -330271},{\"part\": 2,\"layer\": 0,\"graphic\": \"compass.1_2\",\"color\": -1}]}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getCharactersMedalsJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V1CharactersMedals> getCharactersMedals = await internalLatestCharacter.GetCharactersMedalsAsync(inputToken, characterId);

            Assert.Equal(1, getCharactersMedals.Count);
            Assert.Equal(3, getCharactersMedals.First().MedalId);
            Assert.Equal(new DateTime(2017, 03, 16, 15, 01, 45), getCharactersMedals.First().Date);
            Assert.Equal(MedalsStatus.@private, getCharactersMedals.First().Status);
            Assert.Equal(3, getCharactersMedals.First().Graphics.Count);
            Assert.Equal(1, getCharactersMedals.First().Graphics.First().Part);
            Assert.Equal(0, getCharactersMedals.First().Graphics.First().Layer);
            Assert.Equal("caldari.1_2", getCharactersMedals.First().Graphics[1].Graphic);
            Assert.Equal(-1, getCharactersMedals.First().Graphics[2].Color);
        }

        [Fact]
        public void GetCharactersNotifications_successfully_returns_a_list_of_charactersNotifications()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_notifications_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersNotificationsJson = "[{\"notification_id\": 1,\"type\": \"InsurancePayoutMsg\",\"sender_id\": 1000132,\"sender_type\": \"corporation\",\"timestamp\": \"2017-08-16T10:08:00Z\",\"is_read\": true,\"text\": \"amount: 3731016.4000000004\\\\nitemID: 1024881021663\\\\npayout: 1\\\\n\"}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersNotificationsJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V2CharactersNotifications> getCharactersNotifications = internalLatestCharacter.GetCharactersNotifications(inputToken, characterId);

            Assert.Equal(1, getCharactersNotifications.Count);
            Assert.Equal(1, getCharactersNotifications.First().NotificationId);
            Assert.Equal(NotificationType.InsurancePayoutMsg, getCharactersNotifications.First().Type);
            Assert.Equal(SenderType.corporation, getCharactersNotifications.First().SenderType);
            Assert.Equal(new DateTime(2017, 08, 16, 10, 08, 00), getCharactersNotifications.First().Timestamp);
            Assert.True(getCharactersNotifications.First().IsRead);
        }

        [Fact]
        public async Task GetCharactersNotificationsAsync_successfully_returns_a_list_of_charactersNotifications()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_notifications_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersNotificationsJson = "[{\"notification_id\": 1,\"type\": \"InsurancePayoutMsg\",\"sender_id\": 1000132,\"sender_type\": \"corporation\",\"timestamp\": \"2017-08-16T10:08:00Z\",\"is_read\": true,\"text\": \"amount: 3731016.4000000004\\\\nitemID: 1024881021663\\\\npayout: 1\\\\n\"}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getCharactersNotificationsJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V2CharactersNotifications> getCharactersNotifications = await internalLatestCharacter.GetCharactersNotificationsAsync(inputToken, characterId);

            Assert.Equal(1, getCharactersNotifications.Count);
            Assert.Equal(1, getCharactersNotifications.First().NotificationId);
            Assert.Equal(NotificationType.InsurancePayoutMsg, getCharactersNotifications.First().Type);
            Assert.Equal(SenderType.corporation, getCharactersNotifications.First().SenderType);
            Assert.Equal(new DateTime(2017, 08, 16, 10, 08, 00), getCharactersNotifications.First().Timestamp);
            Assert.True(getCharactersNotifications.First().IsRead);
        }

        [Fact]
        public void GetCharactersNotificationsContacts_successfully_returns_a_list_of_charactersNotificationsContacts()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_notifications_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersNotificationsContactsJson = "[{\"notification_id\": 1,\"sender_character_id\": 95465499,\"send_date\": \"2017-08-16T10:08:00Z\",\"standing_level\": 1.5,\"message\": \"hello friend :3\"}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersNotificationsContactsJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V1CharactersNotificationsContacts> getCharactersNotificationsContacts = internalLatestCharacter.GetCharactersNotificationsContacts(inputToken, characterId);

            Assert.Equal(1, getCharactersNotificationsContacts.Count);
            Assert.Equal(1, getCharactersNotificationsContacts.First().NotificationId);
            Assert.Equal(95465499, getCharactersNotificationsContacts.First().SenderCharacterId);
            Assert.Equal(new DateTime(2017, 08, 16, 10, 08, 00), getCharactersNotificationsContacts.First().SendDate);
            Assert.Equal(1.5, getCharactersNotificationsContacts.First().StandingLevel);
        }

        [Fact]
        public async Task GetCharactersNotificationsContactsAsync_successfully_returns_a_list_of_charactersNotificationsContacts()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_notifications_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersNotificationsContactsJson = "[{\"notification_id\": 1,\"sender_character_id\": 95465499,\"send_date\": \"2017-08-16T10:08:00Z\",\"standing_level\": 1.5,\"message\": \"hello friend :3\"}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getCharactersNotificationsContactsJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V1CharactersNotificationsContacts> getCharactersNotificationsContacts = await internalLatestCharacter.GetCharactersNotificationsContactsAsync(inputToken, characterId);

            Assert.Equal(1, getCharactersNotificationsContacts.Count);
            Assert.Equal(1, getCharactersNotificationsContacts.First().NotificationId);
            Assert.Equal(95465499, getCharactersNotificationsContacts.First().SenderCharacterId);
            Assert.Equal(new DateTime(2017, 08, 16, 10, 08, 00), getCharactersNotificationsContacts.First().SendDate);
            Assert.Equal(1.5, getCharactersNotificationsContacts.First().StandingLevel);
        }

        [Fact]
        public void GetCharactersPortrait_successfully_returns_a_charactersPortraits()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;

            string getCharactersPortraitJson = "{\"px64x64\": \"https://imageserver.eveonline.com/Character/95465499_64.jpg\",\"px128x128\": \"https://imageserver.eveonline.com/Character/95465499_128.jpg\",\"px256x256\": \"https://imageserver.eveonline.com/Character/95465499_256.jpg\",\"px512x512\": \"https://imageserver.eveonline.com/Character/95465499_512.jpg\"}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersPortraitJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            V2CharactersPortrait getCharactersPortrait = internalLatestCharacter.GetCharactersPortrait(characterId);

            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_64.jpg", getCharactersPortrait.Px64X64);
            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_128.jpg", getCharactersPortrait.Px128X128);
            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_256.jpg", getCharactersPortrait.Px256X256);
            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_512.jpg", getCharactersPortrait.Px512X512);
        }

        [Fact]
        public async Task GetCharactersPortraitAsync_successfully_returns_a_charactersPortraits()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;

            string getCharactersPortraitJson = "{\"px64x64\": \"https://imageserver.eveonline.com/Character/95465499_64.jpg\",\"px128x128\": \"https://imageserver.eveonline.com/Character/95465499_128.jpg\",\"px256x256\": \"https://imageserver.eveonline.com/Character/95465499_256.jpg\",\"px512x512\": \"https://imageserver.eveonline.com/Character/95465499_512.jpg\"}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getCharactersPortraitJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            V2CharactersPortrait getCharactersPortrait = await internalLatestCharacter.GetCharactersPortraitAsync(characterId);

            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_64.jpg", getCharactersPortrait.Px64X64);
            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_128.jpg", getCharactersPortrait.Px128X128);
            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_256.jpg", getCharactersPortrait.Px256X256);
            Assert.Equal("https://imageserver.eveonline.com/Character/95465499_512.jpg", getCharactersPortrait.Px512X512);
        }

        [Fact]
        public void GetCharactersRoles_successfully_returns_a_characterRoles()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_corporation_roles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersRolesJson = "{\"roles\": [\"Director\",\"Station_Manager\"]}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersRolesJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            V2CharacterRoles getCharactersRoles = internalLatestCharacter.GetCharactersRoles(inputToken, characterId);

            Assert.Equal(2, getCharactersRoles.Roles.Count);
            Assert.Equal(CharacterRoles.Director, getCharactersRoles.Roles[0]);
            Assert.Equal(CharacterRoles.Station_Manager, getCharactersRoles.Roles[1]);
            Assert.Equal(0, getCharactersRoles.RolesAtHq.Count);
            Assert.Equal(0, getCharactersRoles.RolesAtBase.Count);
            Assert.Equal(0, getCharactersRoles.RolesAtOther.Count);
        }

        [Fact]
        public async Task GetCharactersRolesAsync_successfully_returns_a_characterRoles()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_corporation_roles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersRolesJson = "{\"roles\": [\"Director\",\"Station_Manager\"]}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getCharactersRolesJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            V2CharacterRoles getCharactersRoles = await internalLatestCharacter.GetCharactersRolesAsync(inputToken, characterId);

            Assert.Equal(2, getCharactersRoles.Roles.Count);
            Assert.Equal(CharacterRoles.Director, getCharactersRoles.Roles[0]);
            Assert.Equal(CharacterRoles.Station_Manager, getCharactersRoles.Roles[1]);
            Assert.Equal(0, getCharactersRoles.RolesAtHq.Count);
            Assert.Equal(0, getCharactersRoles.RolesAtBase.Count);
            Assert.Equal(0, getCharactersRoles.RolesAtOther.Count);
        }

        [Fact]
        public void GetCharactersStandings_successfully_returns_a_list_of_charactersStandings()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_standings_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersStandingsJson = "[{\"from_id\": 3009841,\"from_type\": \"agent\",\"standing\": 0.1},{\"from_id\": 1000061,\"from_type\": \"npc_corp\",\"standing\": 0},{\"from_id\": 500003,\"from_type\": \"faction\",\"standing\": -1}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersStandingsJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V2CharactersStandings> getCharactersStandings = internalLatestCharacter.GetCharactersStandings(inputToken, characterId);

            Assert.Equal(3, getCharactersStandings.Count);
            Assert.Equal(3009841, getCharactersStandings.First().FromId);
            Assert.Equal(StandingFromType.agent, getCharactersStandings.First().FromType);
            Assert.Equal(0.1f, getCharactersStandings.First().Standing);
            Assert.Equal(StandingFromType.npc_corp, getCharactersStandings[1].FromType);
            Assert.Equal(StandingFromType.faction, getCharactersStandings[2].FromType);
        }

        [Fact]
        public async Task GetCharactersStandingsAsync_successfully_returns_a_list_of_charactersStandings()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_standings_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersStandingsJson = "[{\"from_id\": 3009841,\"from_type\": \"agent\",\"standing\": 0.1},{\"from_id\": 1000061,\"from_type\": \"npc_corp\",\"standing\": 0},{\"from_id\": 500003,\"from_type\": \"faction\",\"standing\": -1}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getCharactersStandingsJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V2CharactersStandings> getCharactersStandings = await internalLatestCharacter.GetCharactersStandingsAsync(inputToken, characterId);

            Assert.Equal(3, getCharactersStandings.Count);
            Assert.Equal(3009841, getCharactersStandings.First().FromId);
            Assert.Equal(StandingFromType.agent, getCharactersStandings.First().FromType);
            Assert.Equal(0.1f, getCharactersStandings.First().Standing);
            Assert.Equal(StandingFromType.npc_corp, getCharactersStandings[1].FromType);
            Assert.Equal(StandingFromType.faction, getCharactersStandings[2].FromType);
        }

        [Fact]
        public void GetCharactersStats_successfully_returns_a_list_of_charactersStats()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characterstats_read_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersStatsJson = "[{\"year\": 2014,\"character\": {\"days_of_activity\": 365,\"minutes\": 1000000,\"sessions_started\": 500},\"combat\": {\"kills_low_sec\": 42}},{\"year\": 2015,\"character\": {\"days_of_activity\": 365,\"minutes\": 1000000, \"sessions_started\": 500},\"combat\": {\"kills_null_sec\": 1337}}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersStatsJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V2CharactersStats> getCharactersStats = internalLatestCharacter.GetCharactersStats(inputToken, characterId);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characterstats_read_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersStatsJson = "[{\"year\": 2014,\"character\": {\"days_of_activity\": 365,\"minutes\": 1000000,\"sessions_started\": 500},\"combat\": {\"kills_low_sec\": 42}},{\"year\": 2015,\"character\": {\"days_of_activity\": 365,\"minutes\": 1000000, \"sessions_started\": 500},\"combat\": {\"kills_null_sec\": 1337}}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getCharactersStatsJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V2CharactersStats> getCharactersStats = await internalLatestCharacter.GetCharactersStatsAsync(inputToken, characterId);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersTitlesJson = "[{\"title_id\": 1,\"name\": \"Awesome Title\"}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersTitlesJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V1CharacterTitles> getCharactersTitles = internalLatestCharacter.GetCharactersTitles(inputToken, characterId);

            Assert.Equal(1, getCharactersTitles.Count);
            Assert.Equal(1, getCharactersTitles.First().TitleId);
            Assert.Equal("Awesome Title", getCharactersTitles.First().Name);
        }

        [Fact]
        public async Task GetCharactersTitlesAsync_successfully_returns_a_list_of_charactersTitles()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            Scopes scopes = Scopes.esi_characters_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ScopesFlags = scopes };
            string getCharactersTitlesJson = "[{\"title_id\": 1,\"name\": \"Awesome Title\"}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getCharactersTitlesJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V1CharacterTitles> getCharactersTitles = await internalLatestCharacter.GetCharactersTitlesAsync(inputToken, characterId);

            Assert.Equal(1, getCharactersTitles.Count);
            Assert.Equal(1, getCharactersTitles.First().TitleId);
            Assert.Equal("Awesome Title", getCharactersTitles.First().Name);
        }

        [Fact]
        public void GetCharactersAffiliation_successfully_returns_a_list_of_charactersAffiliation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            IList<int> characterIds = new List<int>(23);

            string getCharactersAffiliationJson = "[{\"character_id\": 95538921,\"corporation_id\": 109299958,\"alliance_id\": 434243723}]";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersAffiliationJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V1CharacterAffiliations> getCharactersAffiliation = internalLatestCharacter.GetCharactersAffiliation(characterIds);

            Assert.Equal(1, getCharactersAffiliation.Count);
            Assert.Equal(95538921, getCharactersAffiliation.First().CharacterId);
            Assert.Equal(109299958, getCharactersAffiliation.First().CorporationId);
            Assert.Equal(434243723, getCharactersAffiliation.First().AllianceId);
        }

        [Fact]
        public async Task GetCharactersAffiliationAsync_successfully_returns_a_list_of_charactersAffiliation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            IList<int> characterIds = new List<int>(23);

            string getCharactersAffiliationJson = "[{\"character_id\": 95538921,\"corporation_id\": 109299958,\"alliance_id\": 434243723}]";

            mockedWebClient.Setup(x => x.PostAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getCharactersAffiliationJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V1CharacterAffiliations> getCharactersAffiliation = await internalLatestCharacter.GetCharactersAffiliationAsync(characterIds);

            Assert.Equal(1, getCharactersAffiliation.Count);
            Assert.Equal(95538921, getCharactersAffiliation.First().CharacterId);
            Assert.Equal(109299958, getCharactersAffiliation.First().CorporationId);
            Assert.Equal(434243723, getCharactersAffiliation.First().AllianceId);
        }

        [Fact]
        public void GetCharactersNames_successfully_returns_a_list_of_charactersNames()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            IList<int> characterIds = new List<int> { 23, 34 };

            string getCharactersNamesJson = "[{\"character_id\": 95465499,\"character_name\": \"CCP Bartender\"}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getCharactersNamesJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V1CharactersNames> getCharactersNames = internalLatestCharacter.GetCharactersNames(characterIds);

            Assert.Equal(1, getCharactersNames.Count);
            Assert.Equal(95465499, getCharactersNames.First().CharacterId);
            Assert.Equal("CCP Bartender", getCharactersNames.First().CharacterName);
        }

        [Fact]
        public async Task GetCharactersNamesAsync_successfully_returns_a_list_of_charactersNames()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            IList<int> characterIds = new List<int>(23);

            string getCharactersNamesJson = "[{\"character_id\": 95465499,\"character_name\": \"CCP Bartender\"}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getCharactersNamesJson);

            InternalLatestCharacter internalLatestCharacter = new InternalLatestCharacter(mockedWebClient.Object, string.Empty);

            IList<V1CharactersNames> getCharactersNames = await internalLatestCharacter.GetCharactersNamesAsync(characterIds);

            Assert.Equal(1, getCharactersNames.Count);
            Assert.Equal(95465499, getCharactersNames.First().CharacterId);
            Assert.Equal("CCP Bartender", getCharactersNames.First().CharacterName);
        }
    }
}
