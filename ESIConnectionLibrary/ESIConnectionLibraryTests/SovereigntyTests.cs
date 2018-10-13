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
    public class SovereigntyTests
    {
        [Fact]
        public void Campaigns_successfully_returns_a_list_of_Campaigns()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"attackers_score\": 0.4,\r\n    \"campaign_id\": 32833,\r\n    \"constellation_id\": 20000125,\r\n    \"defender_id\": 1695357456,\r\n    \"defender_score\": 0.6,\r\n    \"event_type\": \"station_defense\",\r\n    \"solar_system_id\": 30000856,\r\n    \"start_time\": \"2016-10-29T14:34:40Z\",\r\n    \"structure_id\": 61001096\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestSovereignty internalLatestSovereignty = new InternalLatestSovereignty(mockedWebClient.Object, string.Empty);

            IList<V1SovereigntyCampaigns> response = internalLatestSovereignty.Campaigns();

            Assert.Equal(1, response.Count);
            Assert.Equal(0.4f, response.First().AttackersScore);
            Assert.Equal(20000125, response.First().ConstellationId);
            Assert.Equal(1695357456, response.First().DefenderId);
            Assert.Equal(0.6f, response.First().DefenderScore);
            Assert.Equal(V1SovereigntyCampaignsEventType.StationDefense, response.First().EventType);
            Assert.Equal(30000856, response.First().SolarSystemId);
            Assert.Equal(new DateTime(2016,10,29,14,34,40), response.First().StartTime);
            Assert.Equal(61001096, response.First().StructureId);
        }

        [Fact]
        public async Task CampaignsAsync_successfully_returns_a_list_of_Campaigns()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"attackers_score\": 0.4,\r\n    \"campaign_id\": 32833,\r\n    \"constellation_id\": 20000125,\r\n    \"defender_id\": 1695357456,\r\n    \"defender_score\": 0.6,\r\n    \"event_type\": \"station_defense\",\r\n    \"solar_system_id\": 30000856,\r\n    \"start_time\": \"2016-10-29T14:34:40Z\",\r\n    \"structure_id\": 61001096\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestSovereignty internalLatestSovereignty = new InternalLatestSovereignty(mockedWebClient.Object, string.Empty);

            IList<V1SovereigntyCampaigns> response = await internalLatestSovereignty.CampaignsAsync();

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
        public void Map_successfully_returns_a_list_of_Map()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"faction_id\": 500001,\r\n    \"system_id\": 30045334\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestSovereignty internalLatestSovereignty = new InternalLatestSovereignty(mockedWebClient.Object, string.Empty);

            IList<V1SovereigntyMap> response = internalLatestSovereignty.Map();

            Assert.Equal(1, response.Count);
            Assert.Equal(500001, response.First().FactionId);
            Assert.Equal(30045334, response.First().SystemId);
        }

        [Fact]
        public async Task MapAsync_successfully_returns_a_list_of_Map()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"faction_id\": 500001,\r\n    \"system_id\": 30045334\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestSovereignty internalLatestSovereignty = new InternalLatestSovereignty(mockedWebClient.Object, string.Empty);

            IList<V1SovereigntyMap> response = await internalLatestSovereignty.MapAsync();

            Assert.Equal(1, response.Count);
            Assert.Equal(500001, response.First().FactionId);
            Assert.Equal(30045334, response.First().SystemId);
        }

        [Fact]
        public void Structures_successfully_returns_a_list_of_Structures()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"alliance_id\": 498125261,\r\n    \"solar_system_id\": 30000570,\r\n    \"structure_id\": 1018253388776,\r\n    \"structure_type_id\": 32226,\r\n    \"vulnerability_occupancy_level\": 2,\r\n    \"vulnerable_end_time\": \"2016-10-29T05:30:00Z\",\r\n    \"vulnerable_start_time\": \"2016-10-28T20:30:00Z\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestSovereignty internalLatestSovereignty = new InternalLatestSovereignty(mockedWebClient.Object, string.Empty);

            IList<V1SovereigntyStructures> response = internalLatestSovereignty.Structures();

            Assert.Equal(1, response.Count);
            Assert.Equal(498125261, response.First().AllianceId);
            Assert.Equal(30000570, response.First().SolarSystemId);
            Assert.Equal(1018253388776, response.First().StructureId);
            Assert.Equal(32226, response.First().StructureTypeId);
            Assert.Equal(2, response.First().VulnerabilityOccupancyLevel);
            Assert.Equal(new DateTime(2016,10,29,5,30,0), response.First().VulnerableEndTime);
            Assert.Equal(new DateTime(2016, 10, 28, 20, 30, 0), response.First().VulnerableStartTime);
        }

        [Fact]
        public async Task StructuresAsync_successfully_returns_a_list_of_Structures()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"alliance_id\": 498125261,\r\n    \"solar_system_id\": 30000570,\r\n    \"structure_id\": 1018253388776,\r\n    \"structure_type_id\": 32226,\r\n    \"vulnerability_occupancy_level\": 2,\r\n    \"vulnerable_end_time\": \"2016-10-29T05:30:00Z\",\r\n    \"vulnerable_start_time\": \"2016-10-28T20:30:00Z\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestSovereignty internalLatestSovereignty = new InternalLatestSovereignty(mockedWebClient.Object, string.Empty);

            IList<V1SovereigntyStructures> response = await internalLatestSovereignty.StructuresAsync();

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
