using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class PlanetaryInteractionIntegrationTests
    {
        [Fact]
        public void CharactersPlanets_successfully_returns_a_listV1PlanetaryInteractionCharactersPlanets()
        {
            int characterId = 88823;
            PlanetScopes scopes = PlanetScopes.esi_planets_manage_planets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, PlanetScopesFlags = scopes };

            LatestPlanetaryInteractionEndpoints internalLatestPlanetaryInteraction = new LatestPlanetaryInteractionEndpoints(string.Empty, true);

            IList<V1PlanetaryInteractionCharactersPlanets> returnModel = internalLatestPlanetaryInteraction.CharactersPlanets(inputToken);

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(new DateTime(2016, 11, 28, 16, 42, 51), returnModel[0].LastUpdate);
            Assert.Equal(1, returnModel[1].NumPins);
            Assert.Equal(90000001, returnModel[0].OwnerId);
            Assert.Equal(40023697, returnModel[1].PlanetId);
            Assert.Equal(V1PlanetaryInteractionPlanetType.Plasma, returnModel[0].PlanetType);
            Assert.Equal(30000379, returnModel[1].SolarSystemId);
            Assert.Equal(0, returnModel[0].UpgradeLevel);
        }

        [Fact]
        public async Task CharactersPlanetsAsync_successfully_returns_a_listV1PlanetaryInteractionCharactersPlanets()
        {
            int characterId = 88823;
            PlanetScopes scopes = PlanetScopes.esi_planets_manage_planets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, PlanetScopesFlags = scopes };

            LatestPlanetaryInteractionEndpoints internalLatestPlanetaryInteraction = new LatestPlanetaryInteractionEndpoints(string.Empty, true);

            IList<V1PlanetaryInteractionCharactersPlanets> returnModel = await internalLatestPlanetaryInteraction.CharactersPlanetsAsync(inputToken);

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(new DateTime(2016, 11, 28, 16, 42, 51), returnModel[0].LastUpdate);
            Assert.Equal(1, returnModel[1].NumPins);
            Assert.Equal(90000001, returnModel[0].OwnerId);
            Assert.Equal(40023697, returnModel[1].PlanetId);
            Assert.Equal(V1PlanetaryInteractionPlanetType.Plasma, returnModel[0].PlanetType);
            Assert.Equal(30000379, returnModel[1].SolarSystemId);
            Assert.Equal(0, returnModel[0].UpgradeLevel);
        }

        [Fact]
        public void CharacterPlanet_successfully_returns_a_V3PlanetaryInteractionCharactersPlanet()
        {
            int characterId = 88823;
            PlanetScopes scopes = PlanetScopes.esi_planets_manage_planets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, PlanetScopesFlags = scopes };

            LatestPlanetaryInteractionEndpoints internalLatestPlanetaryInteraction = new LatestPlanetaryInteractionEndpoints(string.Empty, true);

            V3PlanetaryInteractionCharactersPlanet returnModel = internalLatestPlanetaryInteraction.CharacterPlanet(inputToken, 9222);

            Assert.Equal(1000000017022, returnModel.Links[0].DestinationPinId);
            Assert.Equal(0, returnModel.Links[0].LinkLevel);
            Assert.Equal(1000000017021, returnModel.Links[0].SourcePinId);
            Assert.Equal(1.5508784497f, returnModel.Pins[0].Latitude);
            Assert.Equal(0.7171459333f, returnModel.Pins[0].Longitude);
            Assert.Equal(1000000017021, returnModel.Pins[0].PinId);
            Assert.Equal(2254, returnModel.Pins[0].TypeId);
            Assert.Equal(1.5336063994f, returnModel.Pins[1].Latitude);
            Assert.Equal(0.7097755844f, returnModel.Pins[1].Longitude);
            Assert.Equal(1000000017022, returnModel.Pins[1].PinId);
            Assert.Equal(2256, returnModel.Pins[1].TypeId);
            Assert.Equal(2393, returnModel.Routes[0].ContentTypeId);
            Assert.Equal(1000000017030, returnModel.Routes[0].DestinationPinId);
            Assert.Equal(20, returnModel.Routes[0].Quantity);
            Assert.Equal(4, returnModel.Routes[0].RouteId);
            Assert.Equal(1000000017029, returnModel.Routes[0].SourcePinId);
        }

        [Fact]
        public async Task CharacterPlanetAsync_successfully_returns_a_V3PlanetaryInteractionCharactersPlanet()
        {
            int characterId = 88823;
            PlanetScopes scopes = PlanetScopes.esi_planets_manage_planets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, PlanetScopesFlags = scopes };

            LatestPlanetaryInteractionEndpoints internalLatestPlanetaryInteraction = new LatestPlanetaryInteractionEndpoints(string.Empty, true);

            V3PlanetaryInteractionCharactersPlanet returnModel = await internalLatestPlanetaryInteraction.CharacterPlanetAsync(inputToken, 9222);

            Assert.Equal(1000000017022, returnModel.Links[0].DestinationPinId);
            Assert.Equal(0, returnModel.Links[0].LinkLevel);
            Assert.Equal(1000000017021, returnModel.Links[0].SourcePinId);
            Assert.Equal(1.5508784497f, returnModel.Pins[0].Latitude);
            Assert.Equal(0.7171459333f, returnModel.Pins[0].Longitude);
            Assert.Equal(1000000017021, returnModel.Pins[0].PinId);
            Assert.Equal(2254, returnModel.Pins[0].TypeId);
            Assert.Equal(1.5336063994f, returnModel.Pins[1].Latitude);
            Assert.Equal(0.7097755844f, returnModel.Pins[1].Longitude);
            Assert.Equal(1000000017022, returnModel.Pins[1].PinId);
            Assert.Equal(2256, returnModel.Pins[1].TypeId);
            Assert.Equal(2393, returnModel.Routes[0].ContentTypeId);
            Assert.Equal(1000000017030, returnModel.Routes[0].DestinationPinId);
            Assert.Equal(20, returnModel.Routes[0].Quantity);
            Assert.Equal(4, returnModel.Routes[0].RouteId);
            Assert.Equal(1000000017029, returnModel.Routes[0].SourcePinId);
        }

        [Fact]
        public void CorporationsCustomsOffices_successfully_returns_a_pagedModelV1PlanetaryInteractionCorporationCustomsOffice()
        {
            int characterId = 88823;
            PlanetScopes scopes = PlanetScopes.esi_planets_read_customs_offices_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, PlanetScopesFlags = scopes };

            LatestPlanetaryInteractionEndpoints internalLatestPlanetaryInteraction = new LatestPlanetaryInteractionEndpoints(string.Empty, true);

            PagedModel<V1PlanetaryInteractionCorporationCustomsOffice> returnModel = internalLatestPlanetaryInteraction.CorporationsCustomsOffices(inputToken, 2888, 1);

            Assert.Equal(1, returnModel.CurrentPage);
            Assert.Equal(1, returnModel.Model.Count);
            Assert.Equal(0.1f, returnModel.Model[0].AllianceTaxRate);
            Assert.True(returnModel.Model[0].AllowAccessWithStandings);
            Assert.False(returnModel.Model[0].AllowAllianceAccess);
            Assert.Equal(0.02f, returnModel.Model[0].CorporationTaxRate);
            Assert.Equal(0.05f, returnModel.Model[0].ExcellentStandingTaxRate);
            Assert.Equal(0.2f, returnModel.Model[0].GoodStandingTaxRate);
            Assert.Equal(0.5f, returnModel.Model[0].NeutralStandingTaxRate);
            Assert.Equal(1000000014530, returnModel.Model[0].OfficeId);
            Assert.Equal(1, returnModel.Model[0].ReinforceExitEnd);
            Assert.Equal(23, returnModel.Model[0].ReinforceExitStart);
            Assert.Equal(23, returnModel.Model[0].ReinforceExitStart);
            Assert.Equal(30003657, returnModel.Model[0].SystemId);
        }

        [Fact]
        public async Task CorporationsCustomsOfficesAsync_successfully_returns_a_pagedModelV1PlanetaryInteractionCorporationCustomsOffice()
        {
            int characterId = 88823;
            PlanetScopes scopes = PlanetScopes.esi_planets_read_customs_offices_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, PlanetScopesFlags = scopes };

            LatestPlanetaryInteractionEndpoints internalLatestPlanetaryInteraction = new LatestPlanetaryInteractionEndpoints(string.Empty, true);

            PagedModel<V1PlanetaryInteractionCorporationCustomsOffice> returnModel = await internalLatestPlanetaryInteraction.CorporationsCustomsOfficesAsync(inputToken, 2888, 1);

            Assert.Equal(1, returnModel.CurrentPage);
            Assert.Equal(1, returnModel.Model.Count);
            Assert.Equal(0.1f, returnModel.Model[0].AllianceTaxRate);
            Assert.True(returnModel.Model[0].AllowAccessWithStandings);
            Assert.False(returnModel.Model[0].AllowAllianceAccess);
            Assert.Equal(0.02f, returnModel.Model[0].CorporationTaxRate);
            Assert.Equal(0.05f, returnModel.Model[0].ExcellentStandingTaxRate);
            Assert.Equal(0.2f, returnModel.Model[0].GoodStandingTaxRate);
            Assert.Equal(0.5f, returnModel.Model[0].NeutralStandingTaxRate);
            Assert.Equal(1000000014530, returnModel.Model[0].OfficeId);
            Assert.Equal(1, returnModel.Model[0].ReinforceExitEnd);
            Assert.Equal(23, returnModel.Model[0].ReinforceExitStart);
            Assert.Equal(23, returnModel.Model[0].ReinforceExitStart);
            Assert.Equal(30003657, returnModel.Model[0].SystemId);
        }

        [Fact]
        public void Schematic_successfully_returns_a_V1PlanetaryInteractionSchematic()
        {
            LatestPlanetaryInteractionEndpoints internalLatestPlanetaryInteraction = new LatestPlanetaryInteractionEndpoints(string.Empty, true);

            V1PlanetaryInteractionSchematic returnModel = internalLatestPlanetaryInteraction.Schematic(3333);

            Assert.Equal(1800, returnModel.CycleTime);
            Assert.Equal("Bacteria", returnModel.SchematicName);
        }

        [Fact]
        public async Task SchematicAsync_successfully_returns_a_V1PlanetaryInteractionSchematic()
        {
            LatestPlanetaryInteractionEndpoints internalLatestPlanetaryInteraction = new LatestPlanetaryInteractionEndpoints(string.Empty, true);

            V1PlanetaryInteractionSchematic returnModel = await internalLatestPlanetaryInteraction.SchematicAsync(3333);

            Assert.Equal(1800, returnModel.CycleTime);
            Assert.Equal("Bacteria", returnModel.SchematicName);
        }
    }
}
