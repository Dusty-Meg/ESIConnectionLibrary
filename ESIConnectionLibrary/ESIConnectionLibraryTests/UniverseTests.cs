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
    public class UniverseTests
    {
        [Fact]
        public void GetAncestries_successfully_returns_a_list_of_Ancestries()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"bloodline_id\": 1,\r\n    \"description\": \"Acutely aware of the small population...\",\r\n    \"id\": 12,\r\n    \"name\": \"Tube Child\",\r\n    \"short_description\": \"Manufactured citizens of the State.\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V1UniverseAncestries> response = internalLatestUniverse.GetAncestries();

            Assert.Equal(1, response.Count);
            Assert.Equal(1, response.First().BloodlineId);
            Assert.Equal("Acutely aware of the small population...", response.First().Description);
            Assert.Equal(12, response.First().Id);
            Assert.Equal("Tube Child", response.First().Name);
            Assert.Equal("Manufactured citizens of the State.", response.First().ShortDescription);
        }

        [Fact]
        public async Task GetAncestriesAsync_successfully_returns_a_list_of_Ancestries()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"bloodline_id\": 1,\r\n    \"description\": \"Acutely aware of the small population...\",\r\n    \"id\": 12,\r\n    \"name\": \"Tube Child\",\r\n    \"short_description\": \"Manufactured citizens of the State.\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V1UniverseAncestries> response = await internalLatestUniverse.GetAncestriesAsync();

            Assert.Equal(1, response.Count);
            Assert.Equal(1, response.First().BloodlineId);
            Assert.Equal("Acutely aware of the small population...", response.First().Description);
            Assert.Equal(12, response.First().Id);
            Assert.Equal("Tube Child", response.First().Name);
            Assert.Equal("Manufactured citizens of the State.", response.First().ShortDescription);
        }

        [Fact]
        public void GetAsteroidBelt_successfully_returns_a_asteroid_belt()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"name\": \"Tanoo I - Asteroid Belt 1\",\r\n  \"position\": {\r\n    \"x\": 161967513600,\r\n    \"y\": 21288837120,\r\n    \"z\": -73505464320\r\n  },\r\n  \"system_id\": 30000001\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseAsteroidBelt response = internalLatestUniverse.GetAsteroidBelt(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal("Tanoo I - Asteroid Belt 1", response.Name);
            Assert.Equal(161967513600, response.Position.X);
            Assert.Equal(21288837120, response.Position.Y);
            Assert.Equal(-73505464320, response.Position.Z);
            Assert.Equal(30000001, response.SystemId);
        }

        [Fact]
        public async Task GetAsteroidBeltAsync_successfully_returns_a_asteroid_belt()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"name\": \"Tanoo I - Asteroid Belt 1\",\r\n  \"position\": {\r\n    \"x\": 161967513600,\r\n    \"y\": 21288837120,\r\n    \"z\": -73505464320\r\n  },\r\n  \"system_id\": 30000001\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseAsteroidBelt response = await internalLatestUniverse.GetAsteroidBeltAsync(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal("Tanoo I - Asteroid Belt 1", response.Name);
            Assert.Equal(161967513600, response.Position.X);
            Assert.Equal(21288837120, response.Position.Y);
            Assert.Equal(-73505464320, response.Position.Z);
            Assert.Equal(30000001, response.SystemId);
        }

        [Fact]
        public void GetBloodlines_successfully_returns_a_list_of_Bloodlines()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"bloodline_id\": 1,\r\n    \"charisma\": 6,\r\n    \"corporation_id\": 1000006,\r\n    \"description\": \"The Deteis are regarded as ...\",\r\n    \"intelligence\": 7,\r\n    \"memory\": 7,\r\n    \"name\": \"Deteis\",\r\n    \"perception\": 5,\r\n    \"race_id\": 1,\r\n    \"ship_type_id\": 601,\r\n    \"willpower\": 5\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V1UniverseBloodlines> response = internalLatestUniverse.GetBloodlines();

            Assert.Equal(1, response.Count);
            Assert.Equal(1, response.First().BloodlineId);
            Assert.Equal(6, response.First().Charisma);
            Assert.Equal(1000006, response.First().CorporationId);
            Assert.Equal("The Deteis are regarded as ...", response.First().Description);
            Assert.Equal(7, response.First().Intelligence);
            Assert.Equal(7, response.First().Memory);
            Assert.Equal("Deteis", response.First().Name);
            Assert.Equal(5, response.First().Perception);
            Assert.Equal(1, response.First().RaceId);
            Assert.Equal(601, response.First().ShipTypeId);
            Assert.Equal(5, response.First().Willpower);
        }

        [Fact]
        public async Task GetBloodlinesAsync_successfully_returns_a_list_of_Bloodlines()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"bloodline_id\": 1,\r\n    \"charisma\": 6,\r\n    \"corporation_id\": 1000006,\r\n    \"description\": \"The Deteis are regarded as ...\",\r\n    \"intelligence\": 7,\r\n    \"memory\": 7,\r\n    \"name\": \"Deteis\",\r\n    \"perception\": 5,\r\n    \"race_id\": 1,\r\n    \"ship_type_id\": 601,\r\n    \"willpower\": 5\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V1UniverseBloodlines> response = await internalLatestUniverse.GetBloodlinesAsync();

            Assert.Equal(1, response.Count);
            Assert.Equal(1, response.First().BloodlineId);
            Assert.Equal(6, response.First().Charisma);
            Assert.Equal(1000006, response.First().CorporationId);
            Assert.Equal("The Deteis are regarded as ...", response.First().Description);
            Assert.Equal(7, response.First().Intelligence);
            Assert.Equal(7, response.First().Memory);
            Assert.Equal("Deteis", response.First().Name);
            Assert.Equal(5, response.First().Perception);
            Assert.Equal(1, response.First().RaceId);
            Assert.Equal(601, response.First().ShipTypeId);
            Assert.Equal(5, response.First().Willpower);
        }

        [Fact]
        public void GetCategories_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1,\r\n  2,\r\n  3\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> response = internalLatestUniverse.GetCategories();

            Assert.Equal(3, response.Count);
            Assert.Equal(1, response[0]);
            Assert.Equal(2, response[1]);
            Assert.Equal(3, response[2]);
        }

        [Fact]
        public async Task GetCategoriesAsync_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1,\r\n  2,\r\n  3\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> response = await internalLatestUniverse.GetCategoriesAsync();

            Assert.Equal(3, response.Count);
            Assert.Equal(1, response[0]);
            Assert.Equal(2, response[1]);
            Assert.Equal(3, response[2]);
        }

        [Fact]
        public void GetCategory_successfully_returns_a_category()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"category_id\": 6,\r\n  \"groups\": [\r\n    25,\r\n    26,\r\n    27\r\n  ],\r\n  \"name\": \"Ship\",\r\n  \"published\": true\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseCategory response = internalLatestUniverse.GetCategory(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal(6, response.CategoryId);
            Assert.Equal(3, response.Groups.Count);
            Assert.Equal(25, response.Groups[0]);
            Assert.Equal(26, response.Groups[1]);
            Assert.Equal(27, response.Groups[2]);
            Assert.Equal("Ship", response.Name);
            Assert.True(response.Published);
        }

        [Fact]
        public async Task GetCategoryAsync_successfully_returns_a_category()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"category_id\": 6,\r\n  \"groups\": [\r\n    25,\r\n    26,\r\n    27\r\n  ],\r\n  \"name\": \"Ship\",\r\n  \"published\": true\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseCategory response = await internalLatestUniverse.GetCategoryAsync(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal(6, response.CategoryId);
            Assert.Equal(3, response.Groups.Count);
            Assert.Equal(25, response.Groups[0]);
            Assert.Equal(26, response.Groups[1]);
            Assert.Equal(27, response.Groups[2]);
            Assert.Equal("Ship", response.Name);
            Assert.True(response.Published);
        }

        [Fact]
        public void GetConstellations_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  20000001,\r\n  20000002\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> response = internalLatestUniverse.GetConstellations();

            Assert.Equal(2, response.Count);
            Assert.Equal(20000001, response[0]);
            Assert.Equal(20000002, response[1]);
        }

        [Fact]
        public async Task GetConstellationsAsync_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  20000001,\r\n  20000002\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> response = await internalLatestUniverse.GetConstellationsAsync();

            Assert.Equal(2, response.Count);
            Assert.Equal(20000001, response[0]);
            Assert.Equal(20000002, response[1]);
        }

        [Fact]
        public void GetConstellation_successfully_returns_a_constellation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"constellation_id\": 20000009,\r\n  \"name\": \"Mekashtad\",\r\n  \"position\": {\r\n    \"x\": 67796138757472320,\r\n    \"y\": -70591121348560960,\r\n    \"z\": -59587016159270070\r\n  },\r\n  \"region_id\": 10000001,\r\n  \"systems\": [\r\n    20000302,\r\n    20000303\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseConstellation response = internalLatestUniverse.GetConstellation(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal(20000009, response.ConstellationId);
            Assert.Equal("Mekashtad", response.Name);
            Assert.Equal(67796138757472320, response.Position.X);
            Assert.Equal(-70591121348560960, response.Position.Y);
            Assert.Equal(-59587016159270070, response.Position.Z);
            Assert.Equal(10000001, response.RegionId);
            Assert.Equal(2, response.Systems.Count);
            Assert.Equal(20000302, response.Systems[0]);
            Assert.Equal(20000303, response.Systems[1]);
        }

        [Fact]
        public async Task GetConstellationAsync_successfully_returns_a_constellation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"constellation_id\": 20000009,\r\n  \"name\": \"Mekashtad\",\r\n  \"position\": {\r\n    \"x\": 67796138757472320,\r\n    \"y\": -70591121348560960,\r\n    \"z\": -59587016159270070\r\n  },\r\n  \"region_id\": 10000001,\r\n  \"systems\": [\r\n    20000302,\r\n    20000303\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseConstellation response = await internalLatestUniverse.GetConstellationAsync(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal(20000009, response.ConstellationId);
            Assert.Equal("Mekashtad", response.Name);
            Assert.Equal(67796138757472320, response.Position.X);
            Assert.Equal(-70591121348560960, response.Position.Y);
            Assert.Equal(-59587016159270070, response.Position.Z);
            Assert.Equal(10000001, response.RegionId);
            Assert.Equal(2, response.Systems.Count);
            Assert.Equal(20000302, response.Systems[0]);
            Assert.Equal(20000303, response.Systems[1]);
        }

        [Fact]
        public void GetFactions_successfully_returns_a_list_of_Factions()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"corporation_id\": 456,\r\n    \"description\": \"blah blah\",\r\n    \"faction_id\": 1,\r\n    \"is_unique\": true,\r\n    \"name\": \"Faction\",\r\n    \"size_factor\": 1,\r\n    \"solar_system_id\": 123,\r\n    \"station_count\": 1000,\r\n    \"station_system_count\": 100\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V2UniverseFactions> response = internalLatestUniverse.GetFactions();

            Assert.Equal(1, response.Count);
            Assert.Equal(456, response.First().CorporationId);
            Assert.Equal("blah blah", response.First().Description);
            Assert.Equal(1, response.First().FactionId);
            Assert.True(response.First().IsUnique);
            Assert.Equal("Faction", response.First().Name);
            Assert.Equal(1, response.First().SizeFactor);
            Assert.Equal(123, response.First().SolarSystemId);
            Assert.Equal(1000, response.First().StationCount);
            Assert.Equal(100, response.First().StationSystemCount);
        }

        [Fact]
        public async Task GetFactionsAsync_successfully_returns_a_list_of_Factions()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"corporation_id\": 456,\r\n    \"description\": \"blah blah\",\r\n    \"faction_id\": 1,\r\n    \"is_unique\": true,\r\n    \"name\": \"Faction\",\r\n    \"size_factor\": 1,\r\n    \"solar_system_id\": 123,\r\n    \"station_count\": 1000,\r\n    \"station_system_count\": 100\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V2UniverseFactions> response = await internalLatestUniverse.GetFactionsAsync();

            Assert.Equal(1, response.Count);
            Assert.Equal(456, response.First().CorporationId);
            Assert.Equal("blah blah", response.First().Description);
            Assert.Equal(1, response.First().FactionId);
            Assert.True(response.First().IsUnique);
            Assert.Equal("Faction", response.First().Name);
            Assert.Equal(1, response.First().SizeFactor);
            Assert.Equal(123, response.First().SolarSystemId);
            Assert.Equal(1000, response.First().StationCount);
            Assert.Equal(100, response.First().StationSystemCount);
        }

        [Fact]
        public void GetGraphics_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  10,\r\n  4106\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> response = internalLatestUniverse.GetGraphics();

            Assert.Equal(2, response.Count);
            Assert.Equal(10, response[0]);
            Assert.Equal(4106, response[1]);
        }

        [Fact]
        public async Task GetGraphicsAsync_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  10,\r\n  4106\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> response = await internalLatestUniverse.GetGraphicsAsync();

            Assert.Equal(2, response.Count);
            Assert.Equal(10, response[0]);
            Assert.Equal(4106, response[1]);
        }

        [Fact]
        public void GetGraphic_successfully_returns_a_graphic()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"graphic_file\": \"res:/dx9/model/worldobject/planet/moon.red\",\r\n  \"graphic_id\": 10\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseGraphic response = internalLatestUniverse.GetGraphic(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal("res:/dx9/model/worldobject/planet/moon.red", response.GraphicFile);
            Assert.Equal(10, response.GraphicId);
        }

        [Fact]
        public async Task GetGraphicAsync_successfully_returns_a_graphic()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"graphic_file\": \"res:/dx9/model/worldobject/planet/moon.red\",\r\n  \"graphic_id\": 10\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseGraphic response = await internalLatestUniverse.GetGraphicAsync(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal("res:/dx9/model/worldobject/planet/moon.red", response.GraphicFile);
            Assert.Equal(10, response.GraphicId);
        }

        [Fact]
        public void GetGroups_successfully_returns_a_PagedModel_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1,\r\n  2,\r\n  3\r\n]";

            PagedJson pagedJson = new PagedJson { Response = json, MaxPages = 2 };

            mockedWebClient.Setup(x => x.GetPaged(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(pagedJson);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            PagedModel<int> response = internalLatestUniverse.GetGroups(1);

            Assert.Equal(2, response.MaxPages);
            Assert.Equal(1, response.CurrentPage);
            Assert.Equal(3, response.Model.Count);
            Assert.Equal(1, response.Model[0]);
            Assert.Equal(2, response.Model[1]);
            Assert.Equal(3, response.Model[2]);
        }

        [Fact]
        public async Task GetGroupsAsync_successfully_returns_a_PagedModel_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1,\r\n  2,\r\n  3\r\n]";

            PagedJson pagedJson = new PagedJson { Response = json, MaxPages = 2 };

            mockedWebClient.Setup(x => x.GetPagedAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(pagedJson);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            PagedModel<int> response = await internalLatestUniverse.GetGroupsAsync(1);

            Assert.Equal(2, response.MaxPages);
            Assert.Equal(1, response.CurrentPage);
            Assert.Equal(3, response.Model.Count);
            Assert.Equal(1, response.Model[0]);
            Assert.Equal(2, response.Model[1]);
            Assert.Equal(3, response.Model[2]);
        }

        [Fact]
        public void GetGroup_successfully_returns_a_group()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"category_id\": 6,\r\n  \"group_id\": 25,\r\n  \"name\": \"Frigate\",\r\n  \"published\": true,\r\n  \"types\": [\r\n    587,\r\n    586,\r\n    585\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseGroup response = internalLatestUniverse.GetGroup(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal(6, response.CategoryId);
            Assert.Equal(25, response.GroupId);
            Assert.Equal("Frigate", response.Name);
            Assert.True(response.Published);
            Assert.Equal(3, response.Types.Count);
            Assert.Equal(587, response.Types[0]);
            Assert.Equal(586, response.Types[1]);
            Assert.Equal(585, response.Types[2]);
        }

        [Fact]
        public async Task GetGroupAsync_successfully_returns_a_group()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"category_id\": 6,\r\n  \"group_id\": 25,\r\n  \"name\": \"Frigate\",\r\n  \"published\": true,\r\n  \"types\": [\r\n    587,\r\n    586,\r\n    585\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseGroup response = await internalLatestUniverse.GetGroupAsync(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal(6, response.CategoryId);
            Assert.Equal(25, response.GroupId);
            Assert.Equal("Frigate", response.Name);
            Assert.True(response.Published);
            Assert.Equal(3, response.Types.Count);
            Assert.Equal(587, response.Types[0]);
            Assert.Equal(586, response.Types[1]);
            Assert.Equal(585, response.Types[2]);
        }

        [Fact]
        public void GetIds_successfully_returns_a_list_of_strings()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"characters\": [\r\n    {\r\n      \"id\": 95465499,\r\n      \"name\": \"CCP Bartender\"\r\n    },\r\n    {\r\n      \"id\": 2112625428,\r\n      \"name\": \"CCP Zoetrope\"\r\n    }\r\n  ],\r\n  \"systems\": [\r\n    {\r\n      \"id\": 30000142,\r\n      \"name\": \"Jita\"\r\n    }\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseNamesToIds response = internalLatestUniverse.GetIds(new List<string>());

            Assert.Equal(2, response.Characters.Count);
            Assert.Equal(95465499, response.Characters[0].Id);
            Assert.Equal("CCP Bartender", response.Characters[0].Name);
            Assert.Equal(2112625428, response.Characters[1].Id);
            Assert.Equal("CCP Zoetrope", response.Characters[1].Name);
            Assert.Equal(1, response.Systems.Count);
            Assert.Equal(30000142, response.Systems[0].Id);
            Assert.Equal("Jita", response.Systems[0].Name);
        }

        [Fact]
        public async Task GetIdsAsync_successfully_returns_a_list_of_strings()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"characters\": [\r\n    {\r\n      \"id\": 95465499,\r\n      \"name\": \"CCP Bartender\"\r\n    },\r\n    {\r\n      \"id\": 2112625428,\r\n      \"name\": \"CCP Zoetrope\"\r\n    }\r\n  ],\r\n  \"systems\": [\r\n    {\r\n      \"id\": 30000142,\r\n      \"name\": \"Jita\"\r\n    }\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.PostAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseNamesToIds response = await internalLatestUniverse.GetIdsAsync(new List<string>());

            Assert.Equal(2, response.Characters.Count);
            Assert.Equal(95465499, response.Characters[0].Id);
            Assert.Equal("CCP Bartender", response.Characters[0].Name);
            Assert.Equal(2112625428, response.Characters[1].Id);
            Assert.Equal("CCP Zoetrope", response.Characters[1].Name);
            Assert.Equal(1, response.Systems.Count);
            Assert.Equal(30000142, response.Systems[0].Id);
            Assert.Equal("Jita", response.Systems[0].Name);
        }

        [Fact]
        public void GetMoon_successfully_returns_a_moon()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"moon_id\": 40000042,\r\n  \"name\": \"Akpivem I - Moon 1\",\r\n  \"position\": {\r\n    \"x\": 58605102008,\r\n    \"y\": -3066616285,\r\n    \"z\": -55193617920\r\n  },\r\n  \"system_id\": 30000003\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseMoon response = internalLatestUniverse.GetMoon(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal(40000042, response.MoonId);
            Assert.Equal("Akpivem I - Moon 1", response.Name);
            Assert.Equal(58605102008, response.Position.X);
            Assert.Equal(-3066616285, response.Position.Y);
            Assert.Equal(-55193617920, response.Position.Z);
            Assert.Equal(30000003, response.SystemId);
        }

        [Fact]
        public async Task GetMoonAsync_successfully_returns_a_moon()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"moon_id\": 40000042,\r\n  \"name\": \"Akpivem I - Moon 1\",\r\n  \"position\": {\r\n    \"x\": 58605102008,\r\n    \"y\": -3066616285,\r\n    \"z\": -55193617920\r\n  },\r\n  \"system_id\": 30000003\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseMoon response = await internalLatestUniverse.GetMoonAsync(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal(40000042, response.MoonId);
            Assert.Equal("Akpivem I - Moon 1", response.Name);
            Assert.Equal(58605102008, response.Position.X);
            Assert.Equal(-3066616285, response.Position.Y);
            Assert.Equal(-55193617920, response.Position.Z);
            Assert.Equal(30000003, response.SystemId);
        }

        [Fact]
        public void GetNames_successfully_returns_a_list_of_Names()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string universeNamesJson = "[{\"category\": \"character\",\"id\": 95465499,\"name\": \"CCP Bartender\"},{\"category\": \"solar_system\",\"id\": 30000142,\"name\": \"Jita\"}]";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(universeNamesJson);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V2UniverseNames> universeNames = internalLatestUniverse.GetNames(new List<int>());

            Assert.Equal(2, universeNames.Count);
            Assert.Equal(V2UniverseNamesCategory.character, universeNames[0].Category);
            Assert.Equal(95465499, universeNames[0].Id);
            Assert.Equal("CCP Bartender", universeNames[0].Name);
            Assert.Equal(V2UniverseNamesCategory.solar_system, universeNames[1].Category);
            Assert.Equal(30000142, universeNames[1].Id);
            Assert.Equal("Jita", universeNames[1].Name);
        }

        [Fact]
        public async Task GetNames_successfully_returns_a_list_of_NamesAsync()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string universeNamesJson = "[{\"category\": \"character\",\"id\": 95465499,\"name\": \"CCP Bartender\"},{\"category\": \"solar_system\",\"id\": 30000142,\"name\": \"Jita\"}]";

            mockedWebClient.Setup(x => x.PostAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(universeNamesJson);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V2UniverseNames> universeNames = await internalLatestUniverse.GetNamesAsync(new List<int>());

            Assert.Equal(2, universeNames.Count);
            Assert.Equal(V2UniverseNamesCategory.character, universeNames[0].Category);
            Assert.Equal(95465499, universeNames[0].Id);
            Assert.Equal("CCP Bartender", universeNames[0].Name);
            Assert.Equal(V2UniverseNamesCategory.solar_system, universeNames[1].Category);
            Assert.Equal(30000142, universeNames[1].Id);
            Assert.Equal("Jita", universeNames[1].Name);
        }

        [Fact]
        public void GetPlanet_successfully_returns_a_planet()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"name\": \"Akpivem III\",\r\n  \"planet_id\": 40000046,\r\n  \"position\": {\r\n    \"x\": -189226344497,\r\n    \"y\": 9901605317,\r\n    \"z\": -254852632979\r\n  },\r\n  \"system_id\": 30000003,\r\n  \"type_id\": 13\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniversePlanet response = internalLatestUniverse.GetPlanet(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal("Akpivem III", response.Name);
            Assert.Equal(40000046, response.PlanetId);
            Assert.Equal(-189226344497, response.Position.X);
            Assert.Equal(9901605317, response.Position.Y);
            Assert.Equal(-254852632979, response.Position.Z);
            Assert.Equal(30000003, response.SystemId);
            Assert.Equal(13, response.TypeId);
        }

        [Fact]
        public async Task GetPlanetAsync_successfully_returns_a_planet()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"name\": \"Akpivem III\",\r\n  \"planet_id\": 40000046,\r\n  \"position\": {\r\n    \"x\": -189226344497,\r\n    \"y\": 9901605317,\r\n    \"z\": -254852632979\r\n  },\r\n  \"system_id\": 30000003,\r\n  \"type_id\": 13\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniversePlanet response = await internalLatestUniverse.GetPlanetAsync(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal("Akpivem III", response.Name);
            Assert.Equal(40000046, response.PlanetId);
            Assert.Equal(-189226344497, response.Position.X);
            Assert.Equal(9901605317, response.Position.Y);
            Assert.Equal(-254852632979, response.Position.Z);
            Assert.Equal(30000003, response.SystemId);
            Assert.Equal(13, response.TypeId);
        }












        [Fact]
        public void GetType_successfully_returns_a_item_type()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string universeTypeJson = "{\"description\": \"The Rifter is a...\",\"group_id\": 25,\"name\": \"Rifter\",\"published\": true,\"type_id\": 587}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(universeTypeJson);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V3UniverseType v3UniverseType = internalLatestUniverse.GetType(int.MinValue);

            Assert.NotNull(v3UniverseType);
            Assert.Equal("The Rifter is a...", v3UniverseType.Description);
            Assert.Equal("Rifter", v3UniverseType.Name);
        }

        [Fact]
        public async Task GetType_successfully_returns_a_item_typeAsync()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string universeTypeJson = "{\"description\": \"The Rifter is a...\",\"group_id\": 25,\"name\": \"Rifter\",\"published\": true,\"type_id\": 587}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(universeTypeJson);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V3UniverseType v3UniverseType = await internalLatestUniverse.GetTypeAsync(int.MinValue);

            Assert.NotNull(v3UniverseType);
            Assert.Equal("The Rifter is a...", v3UniverseType.Description);
            Assert.Equal("Rifter", v3UniverseType.Name);
        }
    }
}
