using System;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibrary.Tests.IntegrationTests
{
    public class LocationIntegrationTests
    {
        [Fact]
        public void Location_Successfully_returns_a_V1LocationLocation()
        {
            int characterId = 8976562;
            LocationScopes scopes = LocationScopes.esi_location_read_location_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, LocationScopesFlags = scopes };

            LatestLocationEndpoints internalLatestLocation = new LatestLocationEndpoints(string.Empty, true);

            V1LocationLocation returnModel = internalLatestLocation.Location(inputToken);

            Assert.Equal(30002505, returnModel.SolarSystemId);
            Assert.Equal(1000000016989, returnModel.StructureId);
        }

        [Fact]
        public async Task LocationAsync_Successfully_returns_a_V1LocationLocation()
        {
            int characterId = 8976562;
            LocationScopes scopes = LocationScopes.esi_location_read_location_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, LocationScopesFlags = scopes };

            LatestLocationEndpoints internalLatestLocation = new LatestLocationEndpoints(string.Empty, true);

            V1LocationLocation returnModel = await internalLatestLocation.LocationAsync(inputToken);

            Assert.Equal(30002505, returnModel.SolarSystemId);
            Assert.Equal(1000000016989, returnModel.StructureId);
        }

        [Fact]
        public void Online_Successfully_returns_a_V2LocationOnline()
        {
            int characterId = 8976562;
            LocationScopes scopes = LocationScopes.esi_location_read_online_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, LocationScopesFlags = scopes };

            LatestLocationEndpoints internalLatestLocation = new LatestLocationEndpoints(string.Empty, true);

            V2LocationOnline returnModel = internalLatestLocation.Online(inputToken);

            Assert.Equal(new DateTime(2017, 01, 02, 03, 04, 05), returnModel.LastLogin);
            Assert.Equal(new DateTime(2017, 01, 02, 04, 05, 06), returnModel.LastLogout);
            Assert.Equal(9001, returnModel.Logins);
            Assert.True(returnModel.Online);
        }

        [Fact]
        public async Task OnlineAsync_Successfully_returns_a_V2LocationOnline()
        {
            int characterId = 8976562;
            LocationScopes scopes = LocationScopes.esi_location_read_online_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, LocationScopesFlags = scopes };

            LatestLocationEndpoints internalLatestLocation = new LatestLocationEndpoints(string.Empty, true);

            V2LocationOnline returnModel = await internalLatestLocation.OnlineAsync(inputToken);

            Assert.Equal(new DateTime(2017, 01, 02, 03, 04, 05), returnModel.LastLogin);
            Assert.Equal(new DateTime(2017, 01, 02, 04, 05, 06), returnModel.LastLogout);
            Assert.Equal(9001, returnModel.Logins);
            Assert.True(returnModel.Online);
        }

        [Fact]
        public void Ship_Successfully_returns_a_V1LocationShip()
        {
            int characterId = 8976562;
            LocationScopes scopes = LocationScopes.esi_location_read_ship_type_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, LocationScopesFlags = scopes };

            LatestLocationEndpoints internalLatestLocation = new LatestLocationEndpoints(string.Empty, true);

            V1LocationShip returnModel = internalLatestLocation.Ship(inputToken);

            Assert.Equal(1000000016991, returnModel.ShipItemId);
            Assert.Equal("SPACESHIPS!!!", returnModel.ShipName);
            Assert.Equal(1233, returnModel.ShipTypeId);
        }

        [Fact]
        public async Task ShipAsync_Successfully_returns_a_V1LocationShip()
        {
            int characterId = 8976562;
            LocationScopes scopes = LocationScopes.esi_location_read_ship_type_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, LocationScopesFlags = scopes };

            LatestLocationEndpoints internalLatestLocation = new LatestLocationEndpoints(string.Empty, true);

            V1LocationShip returnModel = await internalLatestLocation.ShipAsync(inputToken);

            Assert.Equal(1000000016991, returnModel.ShipItemId);
            Assert.Equal("SPACESHIPS!!!", returnModel.ShipName);
            Assert.Equal(1233, returnModel.ShipTypeId);
        }
    }
}
