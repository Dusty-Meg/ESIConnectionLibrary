using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class FleetsTests
    {
        [Fact]
        public void Character_successfully_returns_a_FleetCharacter()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            FleetScopes scopes = FleetScopes.esi_fleets_read_fleet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, FleetScopesFlags = scopes };
            string json = "{\r\n  \"fleet_id\": 1234567890,\r\n  \"role\": \"fleet_commander\",\r\n  \"squad_id\": -1,\r\n  \"wing_id\": -1\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestFleets internalLatestFleets = new InternalLatestFleets(mockedWebClient.Object, string.Empty);

            V1FleetCharacter model = internalLatestFleets.Character(inputToken);

            Assert.Equal(1234567890, model.FleetId);
            Assert.Equal(FleetRole.FleetCommander, model.Role);
            Assert.Equal(-1, model.SquadId);
            Assert.Equal(-1, model.WingId);
        }

        [Fact]
        public async Task CharacterAsync_successfully_returns_a_FleetCharacter()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            FleetScopes scopes = FleetScopes.esi_fleets_read_fleet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, FleetScopesFlags = scopes };
            string json = "{\r\n  \"fleet_id\": 1234567890,\r\n  \"role\": \"fleet_commander\",\r\n  \"squad_id\": -1,\r\n  \"wing_id\": -1\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestFleets internalLatestFleets = new InternalLatestFleets(mockedWebClient.Object, string.Empty);

            V1FleetCharacter model = await internalLatestFleets.CharacterAsync(inputToken);

            Assert.Equal(1234567890, model.FleetId);
            Assert.Equal(FleetRole.FleetCommander, model.Role);
            Assert.Equal(-1, model.SquadId);
            Assert.Equal(-1, model.WingId);
        }

        [Fact]
        public void Fleet_successfully_returns_a_Fleet()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            FleetScopes scopes = FleetScopes.esi_fleets_read_fleet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, FleetScopesFlags = scopes };
            string json = "{\"is_free_move\": false,\"is_registered\": false,\"is_voice_enabled\": false,\"motd\": \"This is an <b>awesome</b> fleet!\"}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestFleets internalLatestFleets = new InternalLatestFleets(mockedWebClient.Object, string.Empty);

            V1Fleet model = internalLatestFleets.Fleet(inputToken, long.MinValue);

            Assert.False(model.IsFreeMove);
            Assert.False(model.IsRegistered);
            Assert.False(model.IsVoiceEnabled);
        }

        [Fact]
        public async Task FleetAsync_successfully_returns_a_Fleet()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            FleetScopes scopes = FleetScopes.esi_fleets_read_fleet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, FleetScopesFlags = scopes };
            string json = "{\"is_free_move\": false,\"is_registered\": false,\"is_voice_enabled\": false,\"motd\": \"This is an <b>awesome</b> fleet!\"}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestFleets internalLatestFleets = new InternalLatestFleets(mockedWebClient.Object, string.Empty);

            V1Fleet model = await internalLatestFleets.FleetAsync(inputToken, long.MinValue);

            Assert.False(model.IsFreeMove);
            Assert.False(model.IsRegistered);
            Assert.False(model.IsVoiceEnabled);
        }

        [Fact]
        public void Members_successfully_returns_a_list_id_fleetMember()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            FleetScopes scopes = FleetScopes.esi_fleets_read_fleet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, FleetScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"character_id\": 93265215,\r\n    \"join_time\": \"2016-04-29T12:34:56Z\",\r\n    \"role\": \"squad_commander\",\r\n    \"role_name\": \"Squad Commander (Boss)\",\r\n    \"ship_type_id\": 33328,\r\n    \"solar_system_id\": 30003729,\r\n    \"squad_id\": 3129411261968,\r\n    \"station_id\": 61000180,\r\n    \"takes_fleet_warp\": true,\r\n    \"wing_id\": 2073711261968\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestFleets internalLatestFleets = new InternalLatestFleets(mockedWebClient.Object, string.Empty);

            IList<V1FleetMember> model = internalLatestFleets.Members(inputToken, long.MinValue);

            Assert.Single(model);
            Assert.Equal(93265215, model[0].CharacterId);
            Assert.Equal(new DateTime(2016, 04, 29, 12, 34, 56), model[0].JoinTime);
            Assert.Equal(FleetRole.SquadCommander, model[0].Role);
            Assert.Equal("Squad Commander (Boss)", model[0].RoleName);
            Assert.Equal(33328, model[0].ShipTypeId);
            Assert.Equal(30003729, model[0].SolarSystemId);
            Assert.Equal(3129411261968, model[0].SquadId);
            Assert.Equal(61000180, model[0].StationId);
            Assert.True(model[0].TakesFleetWarp);
            Assert.Equal(2073711261968, model[0].WingId);
        }

        [Fact]
        public async Task MembersAsync_successfully_returns_a_list_id_fleetMember()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            FleetScopes scopes = FleetScopes.esi_fleets_read_fleet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, FleetScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"character_id\": 93265215,\r\n    \"join_time\": \"2016-04-29T12:34:56Z\",\r\n    \"role\": \"squad_commander\",\r\n    \"role_name\": \"Squad Commander (Boss)\",\r\n    \"ship_type_id\": 33328,\r\n    \"solar_system_id\": 30003729,\r\n    \"squad_id\": 3129411261968,\r\n    \"station_id\": 61000180,\r\n    \"takes_fleet_warp\": true,\r\n    \"wing_id\": 2073711261968\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestFleets internalLatestFleets = new InternalLatestFleets(mockedWebClient.Object, string.Empty);

            IList<V1FleetMember> model = await internalLatestFleets.MembersAsync(inputToken, long.MinValue);

            Assert.Single(model);
            Assert.Equal(93265215, model[0].CharacterId);
            Assert.Equal(new DateTime(2016, 04, 29, 12, 34, 56), model[0].JoinTime);
            Assert.Equal(FleetRole.SquadCommander, model[0].Role);
            Assert.Equal("Squad Commander (Boss)", model[0].RoleName);
            Assert.Equal(33328, model[0].ShipTypeId);
            Assert.Equal(30003729, model[0].SolarSystemId);
            Assert.Equal(3129411261968, model[0].SquadId);
            Assert.Equal(61000180, model[0].StationId);
            Assert.True(model[0].TakesFleetWarp);
            Assert.Equal(2073711261968, model[0].WingId);
        }

        [Fact]
        public void Wings_successfully_returns_a_list_id_fleetWing()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            FleetScopes scopes = FleetScopes.esi_fleets_read_fleet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, FleetScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"id\": 2073711261968,\r\n    \"name\": \"Wing 1\",\r\n    \"squads\": [\r\n      {\r\n        \"id\": 3129411261968,\r\n        \"name\": \"Squad 1\"\r\n      }\r\n    ]\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestFleets internalLatestFleets = new InternalLatestFleets(mockedWebClient.Object, string.Empty);

            IList<V1FleetWing> model = internalLatestFleets.Wings(inputToken, long.MinValue);

            Assert.Single(model);
            Assert.Equal(2073711261968, model[0].Id);
            Assert.Equal("Wing 1", model[0].Name);

            Assert.Single(model[0].Squads);

            Assert.Equal(3129411261968, model[0].Squads[0].Id);
            Assert.Equal("Squad 1", model[0].Squads[0].Name);
        }

        [Fact]
        public async Task WingsAsync_successfully_returns_a_list_id_fleetWing()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            FleetScopes scopes = FleetScopes.esi_fleets_read_fleet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, FleetScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"id\": 2073711261968,\r\n    \"name\": \"Wing 1\",\r\n    \"squads\": [\r\n      {\r\n        \"id\": 3129411261968,\r\n        \"name\": \"Squad 1\"\r\n      }\r\n    ]\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestFleets internalLatestFleets = new InternalLatestFleets(mockedWebClient.Object, string.Empty);

            IList<V1FleetWing> model = await internalLatestFleets.WingsAsync(inputToken, long.MinValue);

            Assert.Single(model);
            Assert.Equal(2073711261968, model[0].Id);
            Assert.Equal("Wing 1", model[0].Name);

            Assert.Single(model[0].Squads);

            Assert.Equal(3129411261968, model[0].Squads[0].Id);
            Assert.Equal("Squad 1", model[0].Squads[0].Name);
        }
    }
}
