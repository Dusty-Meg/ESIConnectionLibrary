using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class IncursionsIntegrationTests
    {
        [Fact]
        public void Character_successfully_returns_a_FleetCharacter()
        {
            LatestIncursionsEndpoints internalLatestIncursions = new LatestIncursionsEndpoints(string.Empty, true);

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
            LatestIncursionsEndpoints internalLatestIncursions = new LatestIncursionsEndpoints(string.Empty, true);

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
