using System;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibrary.Tests
{
    public class LocationTests
    {
        [Fact]
        public void Location_Successfully_returns_a_V1LocationLocation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;
            LocationScopes scopes = LocationScopes.esi_location_read_location_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, LocationScopesFlags = scopes };

            string json = "{\r\n  \"solar_system_id\": 30002505,\r\n  \"structure_id\": 1000000016989\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestLocation internalLatestLocation = new InternalLatestLocation(mockedWebClient.Object, string.Empty);

            V1LocationLocation returnModel = internalLatestLocation.Location(inputToken);

            Assert.Equal(30002505, returnModel.SolarSystemId);
            Assert.Equal(1000000016989, returnModel.StructureId);
        }

        [Fact]
        public async Task LocationAsync_Successfully_returns_a_V1LocationLocation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;
            LocationScopes scopes = LocationScopes.esi_location_read_location_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, LocationScopesFlags = scopes };

            string json = "{\r\n  \"solar_system_id\": 30002505,\r\n  \"structure_id\": 1000000016989\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestLocation internalLatestLocation = new InternalLatestLocation(mockedWebClient.Object, string.Empty);

            V1LocationLocation returnModel = await internalLatestLocation.LocationAsync(inputToken);

            Assert.Equal(30002505, returnModel.SolarSystemId);
            Assert.Equal(1000000016989, returnModel.StructureId);
        }

        [Fact]
        public void Online_Successfully_returns_a_V2LocationOnline()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;
            LocationScopes scopes = LocationScopes.esi_location_read_online_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, LocationScopesFlags = scopes };

            string json = "{\r\n  \"last_login\": \"2017-01-02T03:04:05Z\",\r\n  \"last_logout\": \"2017-01-02T04:05:06Z\",\r\n  \"logins\": 9001,\r\n  \"online\": true\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestLocation internalLatestLocation = new InternalLatestLocation(mockedWebClient.Object, string.Empty);

            V2LocationOnline returnModel = internalLatestLocation.Online(inputToken);

            Assert.Equal(new DateTime(2017,01,02,03,04,05), returnModel.LastLogin);
            Assert.Equal(new DateTime(2017, 01, 02, 04, 05, 06), returnModel.LastLogout);
            Assert.Equal(9001, returnModel.Logins);
            Assert.True(returnModel.Online);
        }

        [Fact]
        public async Task OnlineAsync_Successfully_returns_a_V2LocationOnline()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;
            LocationScopes scopes = LocationScopes.esi_location_read_online_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, LocationScopesFlags = scopes };

            string json = "{\r\n  \"last_login\": \"2017-01-02T03:04:05Z\",\r\n  \"last_logout\": \"2017-01-02T04:05:06Z\",\r\n  \"logins\": 9001,\r\n  \"online\": true\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestLocation internalLatestLocation = new InternalLatestLocation(mockedWebClient.Object, string.Empty);

            V2LocationOnline returnModel = await internalLatestLocation.OnlineAsync(inputToken);

            Assert.Equal(new DateTime(2017, 01, 02, 03, 04, 05), returnModel.LastLogin);
            Assert.Equal(new DateTime(2017, 01, 02, 04, 05, 06), returnModel.LastLogout);
            Assert.Equal(9001, returnModel.Logins);
            Assert.True(returnModel.Online);
        }

        [Fact]
        public void Ship_Successfully_returns_a_V1LocationShip()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;
            LocationScopes scopes = LocationScopes.esi_location_read_ship_type_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, LocationScopesFlags = scopes };

            string json = "{\r\n  \"ship_item_id\": 1000000016991,\r\n  \"ship_name\": \"SPACESHIPS!!!\",\r\n  \"ship_type_id\": 1233\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestLocation internalLatestLocation = new InternalLatestLocation(mockedWebClient.Object, string.Empty);

            V1LocationShip returnModel = internalLatestLocation.Ship(inputToken);

            Assert.Equal(1000000016991, returnModel.ShipItemId);
            Assert.Equal("SPACESHIPS!!!", returnModel.ShipName);
            Assert.Equal(1233, returnModel.ShipTypeId);
        }

        [Fact]
        public async Task ShipAsync_Successfully_returns_a_V1LocationShip()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 8976562;
            LocationScopes scopes = LocationScopes.esi_location_read_ship_type_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, LocationScopesFlags = scopes };

            string json = "{\r\n  \"ship_item_id\": 1000000016991,\r\n  \"ship_name\": \"SPACESHIPS!!!\",\r\n  \"ship_type_id\": 1233\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestLocation internalLatestLocation = new InternalLatestLocation(mockedWebClient.Object, string.Empty);

            V1LocationShip returnModel = await internalLatestLocation.ShipAsync(inputToken);

            Assert.Equal(1000000016991, returnModel.ShipItemId);
            Assert.Equal("SPACESHIPS!!!", returnModel.ShipName);
            Assert.Equal(1233, returnModel.ShipTypeId);
        }
    }
}
