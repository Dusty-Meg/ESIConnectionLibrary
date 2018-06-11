using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class SovereigntyIntegrationTests
    {
        [Fact]
        public void GetCampaigns_successfully_returns_a_list_of_Campaigns()
        {
            LatestSovereigntyEndpoints internalLatestSovereignty = new LatestSovereigntyEndpoints(string.Empty, true);

            IList<V1SovereigntyCampaigns> response = internalLatestSovereignty.GetCampaigns();

            Assert.Equal(1, response.Count);
            Assert.Equal(0.4f, response.First().AttackersScore);
            Assert.Equal(20000125, response.First().ConstellationId);
            Assert.Equal(1695357456, response.First().DefenderId);
            Assert.Equal(0.6f, response.First().DefenderScore);
            Assert.Equal(V1SovereigntyCampaignsEventType.StationDefense, response.First().EventType);
            Assert.Equal(30000856, response.First().SolarSystemId);
            Assert.Equal(new DateTime(2016, 10, 29, 14, 34, 40), response.First().StartTime);
            Assert.Equal(61001096, response.First().StructureId);
        }

        [Fact]
        public async Task GetCampaignsAsync_successfully_returns_a_list_of_Campaigns()
        {
            LatestSovereigntyEndpoints internalLatestSovereignty = new LatestSovereigntyEndpoints(string.Empty, true);

            IList<V1SovereigntyCampaigns> response = await internalLatestSovereignty.GetCampaignsAsync();

            Assert.Equal(1, response.Count);
            Assert.Equal(0.4f, response.First().AttackersScore);
            Assert.Equal(20000125, response.First().ConstellationId);
            Assert.Equal(1695357456, response.First().DefenderId);
            Assert.Equal(0.6f, response.First().DefenderScore);
            Assert.Equal(V1SovereigntyCampaignsEventType.StationDefense, response.First().EventType);
            Assert.Equal(30000856, response.First().SolarSystemId);
            Assert.Equal(new DateTime(2016, 10, 29, 14, 34, 40), response.First().StartTime);
            Assert.Equal(61001096, response.First().StructureId);
        }

        [Fact]
        public void GetMap_successfully_returns_a_list_of_Map()
        {
            LatestSovereigntyEndpoints internalLatestSovereignty = new LatestSovereigntyEndpoints(string.Empty, true);

            IList<V1SovereigntyMap> response = internalLatestSovereignty.GetMap();

            Assert.Equal(1, response.Count);
            Assert.Equal(500001, response.First().FactionId);
            Assert.Equal(30045334, response.First().SystemId);
        }

        [Fact]
        public async Task GetMapAsync_successfully_returns_a_list_of_Map()
        {
            LatestSovereigntyEndpoints internalLatestSovereignty = new LatestSovereigntyEndpoints(string.Empty, true);

            IList<V1SovereigntyMap> response = await internalLatestSovereignty.GetMapAsync();

            Assert.Equal(1, response.Count);
            Assert.Equal(500001, response.First().FactionId);
            Assert.Equal(30045334, response.First().SystemId);
        }

        [Fact]
        public void GetStructures_successfully_returns_a_list_of_Structures()
        {
            LatestSovereigntyEndpoints internalLatestSovereignty = new LatestSovereigntyEndpoints(string.Empty, true);

            IList<V1SovereigntyStructures> response = internalLatestSovereignty.GetStructures();

            Assert.Equal(1, response.Count);
            Assert.Equal(498125261, response.First().AllianceId);
            Assert.Equal(30000570, response.First().SolarSystemId);
            Assert.Equal(1018253388776, response.First().StructureId);
            Assert.Equal(32226, response.First().StructureTypeId);
            Assert.Equal(2, response.First().VulnerabilityOccupancyLevel);
            Assert.Equal(new DateTime(2016, 10, 29, 5, 30, 0), response.First().VulnerableEndTime);
            Assert.Equal(new DateTime(2016, 10, 28, 20, 30, 0), response.First().VulnerableStartTime);
        }

        [Fact]
        public async Task GetStructuresAsync_successfully_returns_a_list_of_Structures()
        {
            LatestSovereigntyEndpoints internalLatestSovereignty = new LatestSovereigntyEndpoints(string.Empty, true);

            IList<V1SovereigntyStructures> response = await internalLatestSovereignty.GetStructuresAsync();

            Assert.Equal(1, response.Count);
            Assert.Equal(498125261, response.First().AllianceId);
            Assert.Equal(30000570, response.First().SolarSystemId);
            Assert.Equal(1018253388776, response.First().StructureId);
            Assert.Equal(32226, response.First().StructureTypeId);
            Assert.Equal(2, response.First().VulnerabilityOccupancyLevel);
            Assert.Equal(new DateTime(2016, 10, 29, 5, 30, 0), response.First().VulnerableEndTime);
            Assert.Equal(new DateTime(2016, 10, 28, 20, 30, 0), response.First().VulnerableStartTime);
        }
    }
}
