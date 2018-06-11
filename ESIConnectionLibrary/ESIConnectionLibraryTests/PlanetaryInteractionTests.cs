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
    public class PlanetaryInteractionTests
    {
        [Fact]
        public void GetCharactersPlanets_successfully_returns_a_listV1PlanetaryInteractionCharactersPlanets()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            PlanetScopes scopes = PlanetScopes.esi_planets_manage_planets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, PlanetScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"last_update\": \"2016-11-28T16:42:51Z\",\r\n    \"num_pins\": 1,\r\n    \"owner_id\": 90000001,\r\n    \"planet_id\": 40023691,\r\n    \"planet_type\": \"plasma\",\r\n    \"solar_system_id\": 30000379,\r\n    \"upgrade_level\": 0\r\n  },\r\n  {\r\n    \"last_update\": \"2016-11-28T16:41:54Z\",\r\n    \"num_pins\": 1,\r\n    \"owner_id\": 90000001,\r\n    \"planet_id\": 40023697,\r\n    \"planet_type\": \"barren\",\r\n    \"solar_system_id\": 30000379,\r\n    \"upgrade_level\": 0\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestPlanetaryInteraction internalLatestPlanetaryInteraction = new InternalLatestPlanetaryInteraction(mockedWebClient.Object, string.Empty);

            IList<V1PlanetaryInteractionCharactersPlanets> getPlanets = internalLatestPlanetaryInteraction.GetCharactersPlanets(inputToken);

            Assert.Equal(2, getPlanets.Count);
            Assert.Equal(new DateTime(2016, 11, 28, 16, 42, 51), getPlanets[0].LastUpdate);
            Assert.Equal(1, getPlanets[1].NumPins);
            Assert.Equal(90000001, getPlanets[0].OwnerId);
            Assert.Equal(40023697, getPlanets[1].PlanetId);
            Assert.Equal(V1PlanetaryInteractionPlanetType.Plasma, getPlanets[0].PlanetType);
            Assert.Equal(30000379, getPlanets[1].SolarSystemId);
            Assert.Equal(0, getPlanets[0].UpgradeLevel);
        }

        [Fact]
        public async Task GetCharactersPlanetsAsync_successfully_returns_a_listV1PlanetaryInteractionCharactersPlanets()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            PlanetScopes scopes = PlanetScopes.esi_planets_manage_planets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, PlanetScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"last_update\": \"2016-11-28T16:42:51Z\",\r\n    \"num_pins\": 1,\r\n    \"owner_id\": 90000001,\r\n    \"planet_id\": 40023691,\r\n    \"planet_type\": \"plasma\",\r\n    \"solar_system_id\": 30000379,\r\n    \"upgrade_level\": 0\r\n  },\r\n  {\r\n    \"last_update\": \"2016-11-28T16:41:54Z\",\r\n    \"num_pins\": 1,\r\n    \"owner_id\": 90000001,\r\n    \"planet_id\": 40023697,\r\n    \"planet_type\": \"barren\",\r\n    \"solar_system_id\": 30000379,\r\n    \"upgrade_level\": 0\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestPlanetaryInteraction internalLatestPlanetaryInteraction = new InternalLatestPlanetaryInteraction(mockedWebClient.Object, string.Empty);

            IList<V1PlanetaryInteractionCharactersPlanets> getPlanets = await internalLatestPlanetaryInteraction.GetCharactersPlanetsAsync(inputToken);

            Assert.Equal(2, getPlanets.Count);
            Assert.Equal(new DateTime(2016, 11, 28, 16, 42, 51), getPlanets[0].LastUpdate);
            Assert.Equal(1, getPlanets[1].NumPins);
            Assert.Equal(90000001, getPlanets[0].OwnerId);
            Assert.Equal(40023697, getPlanets[1].PlanetId);
            Assert.Equal(V1PlanetaryInteractionPlanetType.Plasma, getPlanets[0].PlanetType);
            Assert.Equal(30000379, getPlanets[1].SolarSystemId);
            Assert.Equal(0, getPlanets[0].UpgradeLevel);
        }

        [Fact]
        public void GetCharacterPlanet_successfully_returns_a_V3PlanetaryInteractionCharactersPlanet()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            PlanetScopes scopes = PlanetScopes.esi_planets_manage_planets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, PlanetScopesFlags = scopes };
            string json = "{\r\n  \"links\": [\r\n    {\r\n      \"destination_pin_id\": 1000000017022,\r\n      \"link_level\": 0,\r\n      \"source_pin_id\": 1000000017021\r\n    }\r\n  ],\r\n  \"pins\": [\r\n    {\r\n      \"latitude\": 1.5508784497,\r\n      \"longitude\": 0.7171459333,\r\n      \"pin_id\": 1000000017021,\r\n      \"type_id\": 2254\r\n    },\r\n    {\r\n      \"latitude\": 1.5336063994,\r\n      \"longitude\": 0.7097755844,\r\n      \"pin_id\": 1000000017022,\r\n      \"type_id\": 2256\r\n    }\r\n  ],\r\n  \"routes\": [\r\n    {\r\n      \"content_type_id\": 2393,\r\n      \"destination_pin_id\": 1000000017030,\r\n      \"quantity\": 20,\r\n      \"route_id\": 4,\r\n      \"source_pin_id\": 1000000017029\r\n    }\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestPlanetaryInteraction internalLatestPlanetaryInteraction = new InternalLatestPlanetaryInteraction(mockedWebClient.Object, string.Empty);

            V3PlanetaryInteractionCharactersPlanet getPlanet = internalLatestPlanetaryInteraction.GetCharacterPlanet(inputToken, 9222);

            Assert.Equal(1000000017022, getPlanet.Links[0].DestinationPinId);
            Assert.Equal(0, getPlanet.Links[0].LinkLevel);
            Assert.Equal(1000000017021, getPlanet.Links[0].SourcePinId);
            Assert.Equal(1.5508784497f, getPlanet.Pins[0].Latitude);
            Assert.Equal(0.7171459333f, getPlanet.Pins[0].Longitude);
            Assert.Equal(1000000017021, getPlanet.Pins[0].PinId);
            Assert.Equal(2254, getPlanet.Pins[0].TypeId);
            Assert.Equal(1.5336063994f, getPlanet.Pins[1].Latitude);
            Assert.Equal(0.7097755844f, getPlanet.Pins[1].Longitude);
            Assert.Equal(1000000017022, getPlanet.Pins[1].PinId);
            Assert.Equal(2256, getPlanet.Pins[1].TypeId);
            Assert.Equal(2393, getPlanet.Routes[0].ContentTypeId);
            Assert.Equal(1000000017030, getPlanet.Routes[0].DestinationPinId);
            Assert.Equal(20, getPlanet.Routes[0].Quantity);
            Assert.Equal(4, getPlanet.Routes[0].RouteId);
            Assert.Equal(1000000017029, getPlanet.Routes[0].SourcePinId);
        }

        [Fact]
        public async Task GetCharacterPlanetAsync_successfully_returns_a_V3PlanetaryInteractionCharactersPlanet()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            PlanetScopes scopes = PlanetScopes.esi_planets_manage_planets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, PlanetScopesFlags = scopes };
            string json = "{\r\n  \"links\": [\r\n    {\r\n      \"destination_pin_id\": 1000000017022,\r\n      \"link_level\": 0,\r\n      \"source_pin_id\": 1000000017021\r\n    }\r\n  ],\r\n  \"pins\": [\r\n    {\r\n      \"latitude\": 1.5508784497,\r\n      \"longitude\": 0.7171459333,\r\n      \"pin_id\": 1000000017021,\r\n      \"type_id\": 2254\r\n    },\r\n    {\r\n      \"latitude\": 1.5336063994,\r\n      \"longitude\": 0.7097755844,\r\n      \"pin_id\": 1000000017022,\r\n      \"type_id\": 2256\r\n    }\r\n  ],\r\n  \"routes\": [\r\n    {\r\n      \"content_type_id\": 2393,\r\n      \"destination_pin_id\": 1000000017030,\r\n      \"quantity\": 20,\r\n      \"route_id\": 4,\r\n      \"source_pin_id\": 1000000017029\r\n    }\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestPlanetaryInteraction internalLatestPlanetaryInteraction = new InternalLatestPlanetaryInteraction(mockedWebClient.Object, string.Empty);

            V3PlanetaryInteractionCharactersPlanet getPlanet = await internalLatestPlanetaryInteraction.GetCharacterPlanetAsync(inputToken, 9222);

            Assert.Equal(1000000017022, getPlanet.Links[0].DestinationPinId);
            Assert.Equal(0, getPlanet.Links[0].LinkLevel);
            Assert.Equal(1000000017021, getPlanet.Links[0].SourcePinId);
            Assert.Equal(1.5508784497f, getPlanet.Pins[0].Latitude);
            Assert.Equal(0.7171459333f, getPlanet.Pins[0].Longitude);
            Assert.Equal(1000000017021, getPlanet.Pins[0].PinId);
            Assert.Equal(2254, getPlanet.Pins[0].TypeId);
            Assert.Equal(1.5336063994f, getPlanet.Pins[1].Latitude);
            Assert.Equal(0.7097755844f, getPlanet.Pins[1].Longitude);
            Assert.Equal(1000000017022, getPlanet.Pins[1].PinId);
            Assert.Equal(2256, getPlanet.Pins[1].TypeId);
            Assert.Equal(2393, getPlanet.Routes[0].ContentTypeId);
            Assert.Equal(1000000017030, getPlanet.Routes[0].DestinationPinId);
            Assert.Equal(20, getPlanet.Routes[0].Quantity);
            Assert.Equal(4, getPlanet.Routes[0].RouteId);
            Assert.Equal(1000000017029, getPlanet.Routes[0].SourcePinId);
        }

        [Fact]
        public void GetCorporationsCustomsOffices_successfully_returns_a_pagedModelV1PlanetaryInteractionCorporationCustomsOffice()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            PlanetScopes scopes = PlanetScopes.esi_planets_read_customs_offices_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, PlanetScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"alliance_tax_rate\": 0.1,\r\n    \"allow_access_with_standings\": true,\r\n    \"allow_alliance_access\": false,\r\n    \"corporation_tax_rate\": 0.02,\r\n    \"excellent_standing_tax_rate\": 0.05,\r\n    \"good_standing_tax_rate\": 0.2,\r\n    \"neutral_standing_tax_rate\": 0.5,\r\n    \"office_id\": 1000000014530,\r\n    \"reinforce_exit_end\": 1,\r\n    \"reinforce_exit_start\": 23,\r\n    \"standing_level\": \"neutral\",\r\n    \"system_id\": 30003657\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestPlanetaryInteraction internalLatestPlanetaryInteraction = new InternalLatestPlanetaryInteraction(mockedWebClient.Object, string.Empty);

            PagedModel<V1PlanetaryInteractionCorporationCustomsOffice> getCustomsOffices = internalLatestPlanetaryInteraction.GetCorporationsCustomsOffices(inputToken, 2888, 1);

            Assert.Equal(2, getCustomsOffices.MaxPages);
            Assert.Equal(1, getCustomsOffices.CurrentPage);
            Assert.Equal(1, getCustomsOffices.Model.Count);
            Assert.Equal(0.1f, getCustomsOffices.Model[0].AllianceTaxRate);
            Assert.True(getCustomsOffices.Model[0].AllowAccessWithStandings);
            Assert.False(getCustomsOffices.Model[0].AllowAllianceAccess);
            Assert.Equal(0.02f, getCustomsOffices.Model[0].CorporationTaxRate);
            Assert.Equal(0.05f, getCustomsOffices.Model[0].ExcellentStandingTaxRate);
            Assert.Equal(0.2f, getCustomsOffices.Model[0].GoodStandingTaxRate);
            Assert.Equal(0.5f, getCustomsOffices.Model[0].NeutralStandingTaxRate);
            Assert.Equal(1000000014530, getCustomsOffices.Model[0].OfficeId);
            Assert.Equal(1, getCustomsOffices.Model[0].ReinforceExitEnd);
            Assert.Equal(23, getCustomsOffices.Model[0].ReinforceExitStart);
            Assert.Equal(23, getCustomsOffices.Model[0].ReinforceExitStart);
            Assert.Equal(30003657, getCustomsOffices.Model[0].SystemId);
        }

        [Fact]
        public async Task GetCorporationsCustomsOfficesAsync_successfully_returns_a_pagedModelV1PlanetaryInteractionCorporationCustomsOffice()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            PlanetScopes scopes = PlanetScopes.esi_planets_read_customs_offices_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, PlanetScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"alliance_tax_rate\": 0.1,\r\n    \"allow_access_with_standings\": true,\r\n    \"allow_alliance_access\": false,\r\n    \"corporation_tax_rate\": 0.02,\r\n    \"excellent_standing_tax_rate\": 0.05,\r\n    \"good_standing_tax_rate\": 0.2,\r\n    \"neutral_standing_tax_rate\": 0.5,\r\n    \"office_id\": 1000000014530,\r\n    \"reinforce_exit_end\": 1,\r\n    \"reinforce_exit_start\": 23,\r\n    \"standing_level\": \"neutral\",\r\n    \"system_id\": 30003657\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestPlanetaryInteraction internalLatestPlanetaryInteraction = new InternalLatestPlanetaryInteraction(mockedWebClient.Object, string.Empty);

            PagedModel<V1PlanetaryInteractionCorporationCustomsOffice> getCustomsOffices = await internalLatestPlanetaryInteraction.GetCorporationsCustomsOfficesAsync(inputToken, 2888, 1);

            Assert.Equal(2, getCustomsOffices.MaxPages);
            Assert.Equal(1, getCustomsOffices.CurrentPage);
            Assert.Equal(1, getCustomsOffices.Model.Count);
            Assert.Equal(0.1f, getCustomsOffices.Model[0].AllianceTaxRate);
            Assert.True(getCustomsOffices.Model[0].AllowAccessWithStandings);
            Assert.False(getCustomsOffices.Model[0].AllowAllianceAccess);
            Assert.Equal(0.02f, getCustomsOffices.Model[0].CorporationTaxRate);
            Assert.Equal(0.05f, getCustomsOffices.Model[0].ExcellentStandingTaxRate);
            Assert.Equal(0.2f, getCustomsOffices.Model[0].GoodStandingTaxRate);
            Assert.Equal(0.5f, getCustomsOffices.Model[0].NeutralStandingTaxRate);
            Assert.Equal(1000000014530, getCustomsOffices.Model[0].OfficeId);
            Assert.Equal(1, getCustomsOffices.Model[0].ReinforceExitEnd);
            Assert.Equal(23, getCustomsOffices.Model[0].ReinforceExitStart);
            Assert.Equal(23, getCustomsOffices.Model[0].ReinforceExitStart);
            Assert.Equal(30003657, getCustomsOffices.Model[0].SystemId);
        }

        [Fact]
        public void GetSchematic_successfully_returns_a_V1PlanetaryInteractionSchematic()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"cycle_time\": 1800,\r\n  \"schematic_name\": \"Bacteria\"\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestPlanetaryInteraction internalLatestPlanetaryInteraction = new InternalLatestPlanetaryInteraction(mockedWebClient.Object, string.Empty);

            V1PlanetaryInteractionSchematic getSchematic = internalLatestPlanetaryInteraction.GetSchematic(3333);

            Assert.Equal(1800, getSchematic.CycleTime);
            Assert.Equal("Bacteria", getSchematic.SchematicName);
        }

        [Fact]
        public async Task GetSchematicAsync_successfully_returns_a_V1PlanetaryInteractionSchematic()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"cycle_time\": 1800,\r\n  \"schematic_name\": \"Bacteria\"\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestPlanetaryInteraction internalLatestPlanetaryInteraction = new InternalLatestPlanetaryInteraction(mockedWebClient.Object, string.Empty);

            V1PlanetaryInteractionSchematic getSchematic = await internalLatestPlanetaryInteraction.GetSchematicAsync(3333);

            Assert.Equal(1800, getSchematic.CycleTime);
            Assert.Equal("Bacteria", getSchematic.SchematicName);
        }
    }
}
