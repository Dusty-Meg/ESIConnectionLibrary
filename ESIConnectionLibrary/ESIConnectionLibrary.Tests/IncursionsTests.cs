using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibrary.Tests
{
    public class IncursionsTests
    {
        [Fact]
        public void Character_successfully_returns_a_FleetCharacter()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"constellation_id\": 20000607,\r\n    \"faction_id\": 500019,\r\n    \"has_boss\": true,\r\n    \"infested_solar_systems\": [\r\n      30004148,\r\n      30004149,\r\n      30004150,\r\n      30004151,\r\n      30004152,\r\n      30004153,\r\n      30004154\r\n    ],\r\n    \"influence\": 0.9,\r\n    \"staging_solar_system_id\": 30004154,\r\n    \"state\": \"mobilizing\",\r\n    \"type\": \"Incursion\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestIncursions internalLatestIncursions = new InternalLatestIncursions(mockedWebClient.Object, string.Empty);

            IList<V1Incursion> model = internalLatestIncursions.Incursions();

            Assert.Single(model);
            Assert.Equal(20000607, model[0].ConstellationId);
            Assert.Equal(500019, model[0].FactionId);
            Assert.True(model[0].HasBoss);
            
            Assert.Equal(7, model[0].InfestedSolarSystems.Count);
            Assert.Equal(30004148, model[0].InfestedSolarSystems[0]);
            Assert.Equal(30004149, model[0].InfestedSolarSystems[1]);
            Assert.Equal(30004150, model[0].InfestedSolarSystems[2]);
            Assert.Equal(30004151, model[0].InfestedSolarSystems[3]);
            Assert.Equal(30004152, model[0].InfestedSolarSystems[4]);
            Assert.Equal(30004153, model[0].InfestedSolarSystems[5]);
            Assert.Equal(30004154, model[0].InfestedSolarSystems[6]);

            Assert.Equal(0.9f, model[0].Influence);
            Assert.Equal(30004154, model[0].StagingSolarSystemId);
            Assert.Equal(V1IncursionState.Mobilizing, model[0].State);
            Assert.Equal("Incursion", model[0].Type);
        }


        [Fact]
        public async Task CharacterAsync_successfully_returns_a_FleetCharacter()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"constellation_id\": 20000607,\r\n    \"faction_id\": 500019,\r\n    \"has_boss\": true,\r\n    \"infested_solar_systems\": [\r\n      30004148,\r\n      30004149,\r\n      30004150,\r\n      30004151,\r\n      30004152,\r\n      30004153,\r\n      30004154\r\n    ],\r\n    \"influence\": 0.9,\r\n    \"staging_solar_system_id\": 30004154,\r\n    \"state\": \"mobilizing\",\r\n    \"type\": \"Incursion\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestIncursions internalLatestIncursions = new InternalLatestIncursions(mockedWebClient.Object, string.Empty);

            IList<V1Incursion> model = await internalLatestIncursions.IncursionsAsync();

            Assert.Single(model);
            Assert.Equal(20000607, model[0].ConstellationId);
            Assert.Equal(500019, model[0].FactionId);
            Assert.True(model[0].HasBoss);

            Assert.Equal(7, model[0].InfestedSolarSystems.Count);
            Assert.Equal(30004148, model[0].InfestedSolarSystems[0]);
            Assert.Equal(30004149, model[0].InfestedSolarSystems[1]);
            Assert.Equal(30004150, model[0].InfestedSolarSystems[2]);
            Assert.Equal(30004151, model[0].InfestedSolarSystems[3]);
            Assert.Equal(30004152, model[0].InfestedSolarSystems[4]);
            Assert.Equal(30004153, model[0].InfestedSolarSystems[5]);
            Assert.Equal(30004154, model[0].InfestedSolarSystems[6]);

            Assert.Equal(0.9f, model[0].Influence);
            Assert.Equal(30004154, model[0].StagingSolarSystemId);
            Assert.Equal(V1IncursionState.Mobilizing, model[0].State);
            Assert.Equal("Incursion", model[0].Type);
        }
    }
}
