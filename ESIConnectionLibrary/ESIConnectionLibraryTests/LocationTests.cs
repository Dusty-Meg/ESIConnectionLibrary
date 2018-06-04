using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class LocationTests
    {
        [Fact]
        public void GetCharacterLocation_Successfully_returns_a_V1LocationCharacterLocation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;
            LocationScopes scopes = LocationScopes.esi_location_read_location_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, LocationScopesFlags = scopes };

            string json = "{\r\n  \"solar_system_id\": 30002505,\r\n  \"structure_id\": 1000000016989\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestLocation internalLatestLocation = new InternalLatestLocation(mockedWebClient.Object, string.Empty);

            V1LocationCharacterLocation v1LocationCharacterLocation = internalLatestLocation.GetCharacterLocation(inputToken);

            Assert.Equal(30002505, v1LocationCharacterLocation.SolarSystemId);
            Assert.Equal(1000000016989, v1LocationCharacterLocation.StructureId);
        }

        [Fact]
        public async Task GetCharacterLocationAsync_Successfully_returns_a_V1LocationCharacterLocation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;
            LocationScopes scopes = LocationScopes.esi_location_read_location_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, LocationScopesFlags = scopes };

            string json = "{\r\n  \"solar_system_id\": 30002505,\r\n  \"structure_id\": 1000000016989\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestLocation internalLatestLocation = new InternalLatestLocation(mockedWebClient.Object, string.Empty);

            V1LocationCharacterLocation v1LocationCharacterLocation = await internalLatestLocation.GetCharacterLocationAsync(inputToken);

            Assert.Equal(30002505, v1LocationCharacterLocation.SolarSystemId);
            Assert.Equal(1000000016989, v1LocationCharacterLocation.StructureId);
        }

        [Fact]
        public void GetCharacterOnlineStatus_Successfully_returns_a_V2LocationCharacterOnline()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;
            LocationScopes scopes = LocationScopes.esi_location_read_online_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, LocationScopesFlags = scopes };

            string json = "{\r\n  \"last_login\": \"2017-01-02T03:04:05Z\",\r\n  \"last_logout\": \"2017-01-02T04:05:06Z\",\r\n  \"logins\": 9001,\r\n  \"online\": true\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestLocation internalLatestLocation = new InternalLatestLocation(mockedWebClient.Object, string.Empty);

            V2LocationCharacterOnline v2LocationCharacterOnline = internalLatestLocation.GetCharacterOnlineStatus(inputToken);

            Assert.Equal(new DateTime(2017,01,02,03,04,05), v2LocationCharacterOnline.LastLogin);
            Assert.Equal(new DateTime(2017, 01, 02, 04, 05, 06), v2LocationCharacterOnline.LastLogout);
            Assert.Equal(9001, v2LocationCharacterOnline.Logins);
            Assert.True(v2LocationCharacterOnline.Online);
        }

        [Fact]
        public async Task GetCharacterOnlineStatusAsync_Successfully_returns_a_V2LocationCharacterOnline()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;
            LocationScopes scopes = LocationScopes.esi_location_read_online_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, LocationScopesFlags = scopes };

            string json = "{\r\n  \"last_login\": \"2017-01-02T03:04:05Z\",\r\n  \"last_logout\": \"2017-01-02T04:05:06Z\",\r\n  \"logins\": 9001,\r\n  \"online\": true\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestLocation internalLatestLocation = new InternalLatestLocation(mockedWebClient.Object, string.Empty);

            V2LocationCharacterOnline v2LocationCharacterOnline = await internalLatestLocation.GetCharacterOnlineStatusAsync(inputToken);

            Assert.Equal(new DateTime(2017, 01, 02, 03, 04, 05), v2LocationCharacterOnline.LastLogin);
            Assert.Equal(new DateTime(2017, 01, 02, 04, 05, 06), v2LocationCharacterOnline.LastLogout);
            Assert.Equal(9001, v2LocationCharacterOnline.Logins);
            Assert.True(v2LocationCharacterOnline.Online);
        }

        [Fact]
        public void GetCharacterShip_Successfully_returns_a_V1LocationCharacterShip()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;
            LocationScopes scopes = LocationScopes.esi_location_read_ship_type_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, LocationScopesFlags = scopes };

            string json = "{\r\n  \"ship_item_id\": 1000000016991,\r\n  \"ship_name\": \"SPACESHIPS!!!\",\r\n  \"ship_type_id\": 1233\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestLocation internalLatestLocation = new InternalLatestLocation(mockedWebClient.Object, string.Empty);

            V1LocationCharacterShip v1LocationCharacterShip = internalLatestLocation.GetCharacterShip(inputToken);

            Assert.Equal(1000000016991, v1LocationCharacterShip.ShipItemId);
            Assert.Equal("SPACESHIPS!!!", v1LocationCharacterShip.ShipName);
            Assert.Equal(1233, v1LocationCharacterShip.ShipTypeId);
        }

        [Fact]
        public async Task GetCharacterShipAsync_Successfully_returns_a_V1LocationCharacterShip()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;
            LocationScopes scopes = LocationScopes.esi_location_read_ship_type_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, LocationScopesFlags = scopes };

            string json = "{\r\n  \"ship_item_id\": 1000000016991,\r\n  \"ship_name\": \"SPACESHIPS!!!\",\r\n  \"ship_type_id\": 1233\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestLocation internalLatestLocation = new InternalLatestLocation(mockedWebClient.Object, string.Empty);

            V1LocationCharacterShip v1LocationCharacterShip = await internalLatestLocation.GetCharacterShipAsync(inputToken);

            Assert.Equal(1000000016991, v1LocationCharacterShip.ShipItemId);
            Assert.Equal("SPACESHIPS!!!", v1LocationCharacterShip.ShipName);
            Assert.Equal(1233, v1LocationCharacterShip.ShipTypeId);
        }
    }
}
