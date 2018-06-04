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

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2});

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

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2});

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

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

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

            string json = "[{\"category\": \"character\",\"id\": 95465499,\"name\": \"CCP Bartender\"},{\"category\": \"solar_system\",\"id\": 30000142,\"name\": \"Jita\"}]";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V2UniverseNames> response = internalLatestUniverse.GetNames(new List<int>());

            Assert.Equal(2, response.Count);
            Assert.Equal(V2UniverseNamesCategory.character, response[0].Category);
            Assert.Equal(95465499, response[0].Id);
            Assert.Equal("CCP Bartender", response[0].Name);
            Assert.Equal(V2UniverseNamesCategory.solar_system, response[1].Category);
            Assert.Equal(30000142, response[1].Id);
            Assert.Equal("Jita", response[1].Name);
        }

        [Fact]
        public async Task GetNames_successfully_returns_a_list_of_NamesAsync()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[{\"category\": \"character\",\"id\": 95465499,\"name\": \"CCP Bartender\"},{\"category\": \"solar_system\",\"id\": 30000142,\"name\": \"Jita\"}]";

            mockedWebClient.Setup(x => x.PostAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(json);

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V2UniverseNames> response = await internalLatestUniverse.GetNamesAsync(new List<int>());

            Assert.Equal(2, response.Count);
            Assert.Equal(V2UniverseNamesCategory.character, response[0].Category);
            Assert.Equal(95465499, response[0].Id);
            Assert.Equal("CCP Bartender", response[0].Name);
            Assert.Equal(V2UniverseNamesCategory.solar_system, response[1].Category);
            Assert.Equal(30000142, response[1].Id);
            Assert.Equal("Jita", response[1].Name);
        }

        [Fact]
        public void GetPlanet_successfully_returns_a_planet()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"name\": \"Akpivem III\",\r\n  \"planet_id\": 40000046,\r\n  \"position\": {\r\n    \"x\": -189226344497,\r\n    \"y\": 9901605317,\r\n    \"z\": -254852632979\r\n  },\r\n  \"system_id\": 30000003,\r\n  \"type_id\": 13\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

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

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

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
        public void GetRaces_successfully_returns_a_list_of_Races()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"alliance_id\": 500001,\r\n    \"description\": \"Founded on the tenets of patriotism and hard work...\",\r\n    \"name\": \"Caldari\",\r\n    \"race_id\": 1\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V1UniverseRaces> response = internalLatestUniverse.GetRaces();

            Assert.Equal(1, response.Count);
            Assert.Equal(500001, response[0].AllianceId);
            Assert.Equal("Founded on the tenets of patriotism and hard work...", response[0].Description);
            Assert.Equal("Caldari", response[0].Name);
            Assert.Equal(1, response[0].RaceId);
        }

        [Fact]
        public async Task GetRacesAsync_successfully_returns_a_list_of_Races()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"alliance_id\": 500001,\r\n    \"description\": \"Founded on the tenets of patriotism and hard work...\",\r\n    \"name\": \"Caldari\",\r\n    \"race_id\": 1\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V1UniverseRaces> response = await internalLatestUniverse.GetRacesAsync();

            Assert.Equal(1, response.Count);
            Assert.Equal(500001, response[0].AllianceId);
            Assert.Equal("Founded on the tenets of patriotism and hard work...", response[0].Description);
            Assert.Equal("Caldari", response[0].Name);
            Assert.Equal(1, response[0].RaceId);
        }

        [Fact]
        public void GetRegions_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  11000001,\r\n  11000002\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> response = internalLatestUniverse.GetRegions();

            Assert.Equal(2, response.Count);
            Assert.Equal(11000001, response[0]);
            Assert.Equal(11000002, response[1]);
        }

        [Fact]
        public async Task GetRegionsAsync_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  11000001,\r\n  11000002\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> response = await internalLatestUniverse.GetRegionsAsync();

            Assert.Equal(2, response.Count);
            Assert.Equal(11000001, response[0]);
            Assert.Equal(11000002, response[1]);
        }

        [Fact]
        public void GetRegion_successfully_returns_a_region()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"constellations\": [\r\n    20000302,\r\n    20000303\r\n  ],\r\n  \"description\": \"It has long been an established fact of civilization...\",\r\n  \"name\": \"Metropolis\",\r\n  \"region_id\": 10000042\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseRegion response = internalLatestUniverse.GetRegion(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal(2, response.Constellations.Count);
            Assert.Equal(20000302, response.Constellations[0]);
            Assert.Equal(20000303, response.Constellations[1]);
            Assert.Equal("It has long been an established fact of civilization...", response.Description);
            Assert.Equal("Metropolis", response.Name);
            Assert.Equal(10000042, response.RegionId);
        }

        [Fact]
        public async Task GetRegionAsync_successfully_returns_a_region()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"constellations\": [\r\n    20000302,\r\n    20000303\r\n  ],\r\n  \"description\": \"It has long been an established fact of civilization...\",\r\n  \"name\": \"Metropolis\",\r\n  \"region_id\": 10000042\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseRegion response = await internalLatestUniverse.GetRegionAsync(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal(2, response.Constellations.Count);
            Assert.Equal(20000302, response.Constellations[0]);
            Assert.Equal(20000303, response.Constellations[1]);
            Assert.Equal("It has long been an established fact of civilization...", response.Description);
            Assert.Equal("Metropolis", response.Name);
            Assert.Equal(10000042, response.RegionId);
        }

        [Fact]
        public void GetStargate_successfully_returns_a_stargate()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"destination\": {\r\n    \"stargate_id\": 50000056,\r\n    \"system_id\": 30000001\r\n  },\r\n  \"name\": \"Stargate (Tanoo)\",\r\n  \"position\": {\r\n    \"x\": -101092761600,\r\n    \"y\": 5279539200,\r\n    \"z\": 1550503403520\r\n  },\r\n  \"stargate_id\": 50000342,\r\n  \"system_id\": 30000003,\r\n  \"type_id\": 29624\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseStargate response = internalLatestUniverse.GetStargate(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal(50000056, response.Destination.StargateId);
            Assert.Equal(30000001, response.Destination.SystemId);
            Assert.Equal("Stargate (Tanoo)", response.Name);
            Assert.Equal(-101092761600, response.Position.X);
            Assert.Equal(5279539200, response.Position.Y);
            Assert.Equal(1550503403520, response.Position.Z);
            Assert.Equal(50000342, response.StargateId);
            Assert.Equal(30000003, response.SystemId);
            Assert.Equal(29624, response.TypeId);
        }

        [Fact]
        public async Task GetStargateAsync_successfully_returns_a_stargate()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"destination\": {\r\n    \"stargate_id\": 50000056,\r\n    \"system_id\": 30000001\r\n  },\r\n  \"name\": \"Stargate (Tanoo)\",\r\n  \"position\": {\r\n    \"x\": -101092761600,\r\n    \"y\": 5279539200,\r\n    \"z\": 1550503403520\r\n  },\r\n  \"stargate_id\": 50000342,\r\n  \"system_id\": 30000003,\r\n  \"type_id\": 29624\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseStargate response = await internalLatestUniverse.GetStargateAsync(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal(50000056, response.Destination.StargateId);
            Assert.Equal(30000001, response.Destination.SystemId);
            Assert.Equal("Stargate (Tanoo)", response.Name);
            Assert.Equal(-101092761600, response.Position.X);
            Assert.Equal(5279539200, response.Position.Y);
            Assert.Equal(1550503403520, response.Position.Z);
            Assert.Equal(50000342, response.StargateId);
            Assert.Equal(30000003, response.SystemId);
            Assert.Equal(29624, response.TypeId);
        }

        [Fact]
        public void GetStar_successfully_returns_a_star()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"age\": 9398686722,\r\n  \"luminosity\": 0.0661500022,\r\n  \"name\": \"BKG-Q2 - Star\",\r\n  \"radius\": 346600000,\r\n  \"solar_system_id\": 30004333,\r\n  \"spectral_class\": \"K2 V\",\r\n  \"temperature\": 3953,\r\n  \"type_id\": 45033\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseStar response = internalLatestUniverse.GetStar(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal(9398686722, response.Age);
            Assert.Equal(0.0661500022f, response.Luminosity);
            Assert.Equal("BKG-Q2 - Star", response.Name);
            Assert.Equal(346600000, response.Radius);
            Assert.Equal(30004333, response.SolarSystemId);
            Assert.Equal(V1UniverseStarSpectralClass.K2V, response.SpectralClass);
            Assert.Equal(3953, response.Temperature);
            Assert.Equal(45033, response.TypeId);
        }

        [Fact]
        public async Task GetStarAsync_successfully_returns_a_star()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"age\": 9398686722,\r\n  \"luminosity\": 0.0661500022,\r\n  \"name\": \"BKG-Q2 - Star\",\r\n  \"radius\": 346600000,\r\n  \"solar_system_id\": 30004333,\r\n  \"spectral_class\": \"K2 V\",\r\n  \"temperature\": 3953,\r\n  \"type_id\": 45033\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseStar response = await internalLatestUniverse.GetStarAsync(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal(9398686722, response.Age);
            Assert.Equal(0.0661500022f, response.Luminosity);
            Assert.Equal("BKG-Q2 - Star", response.Name);
            Assert.Equal(346600000, response.Radius);
            Assert.Equal(30004333, response.SolarSystemId);
            Assert.Equal(V1UniverseStarSpectralClass.K2V, response.SpectralClass);
            Assert.Equal(3953, response.Temperature);
            Assert.Equal(45033, response.TypeId);
        }

        [Fact]
        public void GetStation_successfully_returns_a_station()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"max_dockable_ship_volume\": 50000000,\r\n  \"name\": \"Jakanerva III - Moon 15 - Prompt Delivery Storage\",\r\n  \"office_rental_cost\": 10000,\r\n  \"owner\": 1000003,\r\n  \"position\": {\r\n    \"x\": 165632286720,\r\n    \"y\": 2771804160,\r\n    \"z\": -2455331266560\r\n  },\r\n  \"race_id\": 1,\r\n  \"reprocessing_efficiency\": 0.5,\r\n  \"reprocessing_stations_take\": 0.05,\r\n  \"services\": [\r\n    \"courier-missions\",\r\n    \"reprocessing-plant\",\r\n    \"market\",\r\n    \"repair-facilities\",\r\n    \"fitting\",\r\n    \"news\",\r\n    \"storage\",\r\n    \"insurance\",\r\n    \"docking\",\r\n    \"office-rental\",\r\n    \"loyalty-point-store\",\r\n    \"navy-offices\"\r\n  ],\r\n  \"station_id\": 60000277,\r\n  \"system_id\": 30000148,\r\n  \"type_id\": 1531\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V2UniverseStation response = internalLatestUniverse.GetStation(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal(50000000, response.MaxDockableShipVolume);
            Assert.Equal("Jakanerva III - Moon 15 - Prompt Delivery Storage", response.Name);
            Assert.Equal(10000, response.OfficeRentalCost);
            Assert.Equal(1000003, response.Owner);
            Assert.Equal(165632286720, response.Position.X);
            Assert.Equal(2771804160, response.Position.Y);
            Assert.Equal(-2455331266560, response.Position.Z);
            Assert.Equal(1, response.RaceId);
            Assert.Equal(0.5f, response.ReprocessingEfficiency);
            Assert.Equal(0.05f, response.ReprocessingStationsTake);
            Assert.Equal(12, response.Services.Count);
            Assert.Contains(V2UniverseStationServices.courierMissions, response.Services);
            Assert.Contains(V2UniverseStationServices.reprocessingPlant, response.Services);
            Assert.Contains(V2UniverseStationServices.market, response.Services);
            Assert.Contains(V2UniverseStationServices.repairFacilities, response.Services);
            Assert.Contains(V2UniverseStationServices.fitting, response.Services);
            Assert.Contains(V2UniverseStationServices.news, response.Services);
            Assert.Contains(V2UniverseStationServices.storage, response.Services);
            Assert.Contains(V2UniverseStationServices.insurance, response.Services);
            Assert.Contains(V2UniverseStationServices.docking, response.Services);
            Assert.Contains(V2UniverseStationServices.officeRental, response.Services);
            Assert.Contains(V2UniverseStationServices.loyaltyPointStore, response.Services);
            Assert.Contains(V2UniverseStationServices.navyOffices, response.Services);
            Assert.Equal(60000277, response.StationId);
            Assert.Equal(30000148, response.SystemId);
            Assert.Equal(1531, response.TypeId);
        }

        [Fact]
        public async Task GetStationAsync_successfully_returns_a_station()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"max_dockable_ship_volume\": 50000000,\r\n  \"name\": \"Jakanerva III - Moon 15 - Prompt Delivery Storage\",\r\n  \"office_rental_cost\": 10000,\r\n  \"owner\": 1000003,\r\n  \"position\": {\r\n    \"x\": 165632286720,\r\n    \"y\": 2771804160,\r\n    \"z\": -2455331266560\r\n  },\r\n  \"race_id\": 1,\r\n  \"reprocessing_efficiency\": 0.5,\r\n  \"reprocessing_stations_take\": 0.05,\r\n  \"services\": [\r\n    \"courier-missions\",\r\n    \"reprocessing-plant\",\r\n    \"market\",\r\n    \"repair-facilities\",\r\n    \"fitting\",\r\n    \"news\",\r\n    \"storage\",\r\n    \"insurance\",\r\n    \"docking\",\r\n    \"office-rental\",\r\n    \"loyalty-point-store\",\r\n    \"navy-offices\"\r\n  ],\r\n  \"station_id\": 60000277,\r\n  \"system_id\": 30000148,\r\n  \"type_id\": 1531\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V2UniverseStation response = await internalLatestUniverse.GetStationAsync(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal(50000000, response.MaxDockableShipVolume);
            Assert.Equal("Jakanerva III - Moon 15 - Prompt Delivery Storage", response.Name);
            Assert.Equal(10000, response.OfficeRentalCost);
            Assert.Equal(1000003, response.Owner);
            Assert.Equal(165632286720, response.Position.X);
            Assert.Equal(2771804160, response.Position.Y);
            Assert.Equal(-2455331266560, response.Position.Z);
            Assert.Equal(1, response.RaceId);
            Assert.Equal(0.5f, response.ReprocessingEfficiency);
            Assert.Equal(0.05f, response.ReprocessingStationsTake);
            Assert.Equal(12, response.Services.Count);
            Assert.Contains(V2UniverseStationServices.courierMissions, response.Services);
            Assert.Contains(V2UniverseStationServices.reprocessingPlant, response.Services);
            Assert.Contains(V2UniverseStationServices.market, response.Services);
            Assert.Contains(V2UniverseStationServices.repairFacilities, response.Services);
            Assert.Contains(V2UniverseStationServices.fitting, response.Services);
            Assert.Contains(V2UniverseStationServices.news, response.Services);
            Assert.Contains(V2UniverseStationServices.storage, response.Services);
            Assert.Contains(V2UniverseStationServices.insurance, response.Services);
            Assert.Contains(V2UniverseStationServices.docking, response.Services);
            Assert.Contains(V2UniverseStationServices.officeRental, response.Services);
            Assert.Contains(V2UniverseStationServices.loyaltyPointStore, response.Services);
            Assert.Contains(V2UniverseStationServices.navyOffices, response.Services);
            Assert.Equal(60000277, response.StationId);
            Assert.Equal(30000148, response.SystemId);
            Assert.Equal(1531, response.TypeId);
        }

        [Fact]
        public void GetStructures_successfully_returns_a_list_of_longs()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1020988381992,\r\n  1020988381991\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<long> response = internalLatestUniverse.GetStructures();

            Assert.Equal(2, response.Count);
            Assert.Equal(1020988381992, response[0]);
            Assert.Equal(1020988381991, response[1]);
        }

        [Fact]
        public async Task GetStructuresAsync_successfully_returns_a_list_of_longs()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1020988381992,\r\n  1020988381991\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<long> response = await internalLatestUniverse.GetStructuresAsync();

            Assert.Equal(2, response.Count);
            Assert.Equal(1020988381992, response[0]);
            Assert.Equal(1020988381991, response[1]);
        }

        [Fact]
        public void GetStructure_successfully_returns_a_structure()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            UniverseScopes scopes = UniverseScopes.esi_universe_read_structures_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 33434, CharacterName = "sbla", UniverseScopesFlags = scopes };
            string json = "{\r\n  \"name\": \"V-3YG7 VI - The Capital\",\r\n  \"solar_system_id\": 30000142\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseStructure response = internalLatestUniverse.GetStructure(inputToken, int.MinValue);

            Assert.NotNull(response);
            Assert.Equal("V-3YG7 VI - The Capital", response.Name);
            Assert.Equal(30000142, response.SolarSystemId);
        }

        [Fact]
        public async Task GetStructureAsync_successfully_returns_a_structure()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            UniverseScopes scopes = UniverseScopes.esi_universe_read_structures_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 33434, CharacterName = "sbla", UniverseScopesFlags = scopes };
            string json = "{\r\n  \"name\": \"V-3YG7 VI - The Capital\",\r\n  \"solar_system_id\": 30000142\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseStructure response = await internalLatestUniverse.GetStructureAsync(inputToken, int.MinValue);

            Assert.NotNull(response);
            Assert.Equal("V-3YG7 VI - The Capital", response.Name);
            Assert.Equal(30000142, response.SolarSystemId);
        }

        [Fact]
        public void GetSystemJumps_successfully_returns_a_list_of_SystemJumps()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"ship_jumps\": 42,\r\n    \"system_id\": 30002410\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V1UniverseSystemJumps> response = internalLatestUniverse.GetSystemJumps();

            Assert.Equal(1, response.Count);
            Assert.Equal(42, response[0].ShipJumps);
            Assert.Equal(30002410, response[0].SystemId);
        }

        [Fact]
        public async Task GetSystemJumpsAsync_successfully_returns_a_list_of_SystemJumps()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"ship_jumps\": 42,\r\n    \"system_id\": 30002410\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V1UniverseSystemJumps> response = await internalLatestUniverse.GetSystemJumpsAsync();

            Assert.Equal(1, response.Count);
            Assert.Equal(42, response[0].ShipJumps);
            Assert.Equal(30002410, response[0].SystemId);
        }

        [Fact]
        public void GetSystemKills_successfully_returns_a_list_of_SystemKills()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"npc_kills\": 0,\r\n    \"pod_kills\": 24,\r\n    \"ship_kills\": 42,\r\n    \"system_id\": 30002410\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V2UniverseSystemKills> response = internalLatestUniverse.GetSystemKills();

            Assert.Equal(1, response.Count);
            Assert.Equal(0, response[0].NpcKills);
            Assert.Equal(24, response[0].PodKills);
            Assert.Equal(42, response[0].ShipKills);
            Assert.Equal(30002410, response[0].SystemId);
        }

        [Fact]
        public async Task GetSystemKillsAsync_successfully_returns_a_list_of_SystemKills()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"npc_kills\": 0,\r\n    \"pod_kills\": 24,\r\n    \"ship_kills\": 42,\r\n    \"system_id\": 30002410\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V2UniverseSystemKills> response = await internalLatestUniverse.GetSystemKillsAsync();

            Assert.Equal(1, response.Count);
            Assert.Equal(0, response[0].NpcKills);
            Assert.Equal(24, response[0].PodKills);
            Assert.Equal(42, response[0].ShipKills);
            Assert.Equal(30002410, response[0].SystemId);
        }

        [Fact]
        public void GetSystems_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  30000001,\r\n  30000002\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> response = internalLatestUniverse.GetSystems();

            Assert.Equal(2, response.Count);
            Assert.Equal(30000001, response[0]);
            Assert.Equal(30000002, response[1]);
        }

        [Fact]
        public async Task GetSystemsAsync_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  30000001,\r\n  30000002\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> response = await internalLatestUniverse.GetSystemsAsync();

            Assert.Equal(2, response.Count);
            Assert.Equal(30000001, response[0]);
            Assert.Equal(30000002, response[1]);
        }

        [Fact]
        public void GetSystem_successfully_returns_a_system()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"constellation_id\": 20000001,\r\n  \"name\": \"Akpivem\",\r\n  \"planets\": [\r\n    {\r\n      \"moons\": [\r\n        40000042\r\n      ],\r\n      \"planet_id\": 40000041\r\n    },\r\n    {\r\n      \"planet_id\": 40000043\r\n    }\r\n  ],\r\n  \"position\": {\r\n    \"x\": -91174141133075340,\r\n    \"y\": 43938227486247170,\r\n    \"z\": -56482824383339900\r\n  },\r\n  \"security_class\": \"B\",\r\n  \"security_status\": 0.8462923765,\r\n  \"star_id\": 40000040,\r\n  \"stargates\": [\r\n    50000342\r\n  ],\r\n  \"system_id\": 30000003\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V3UniverseSystem response = internalLatestUniverse.GetSystem(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal(20000001, response.ConstellationId);
            Assert.Equal("Akpivem", response.Name);
            Assert.Equal(2, response.Planets.Count);
            Assert.Equal(1, response.Planets[0].Moons.Count);
            Assert.Equal(40000042, response.Planets[0].Moons[0]);
            Assert.Equal(40000041, response.Planets[0].PlanetId);
            Assert.Equal(40000043, response.Planets[1].PlanetId);
            Assert.Equal(-91174141133075340, response.Position.X);
            Assert.Equal(43938227486247170, response.Position.Y);
            Assert.Equal(-56482824383339900, response.Position.Z);
            Assert.Equal("B", response.SecurityClass);
            Assert.Equal(0.8462923765f, response.SecurityStatus);
            Assert.Equal(40000040, response.StarId);
            Assert.Equal(1, response.Stargates.Count);
            Assert.Equal(50000342, response.Stargates[0]);
            Assert.Equal(30000003, response.SystemId);
        }

        [Fact]
        public async Task GetSystemAsync_successfully_returns_a_system()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"constellation_id\": 20000001,\r\n  \"name\": \"Akpivem\",\r\n  \"planets\": [\r\n    {\r\n      \"moons\": [\r\n        40000042\r\n      ],\r\n      \"planet_id\": 40000041\r\n    },\r\n    {\r\n      \"planet_id\": 40000043\r\n    }\r\n  ],\r\n  \"position\": {\r\n    \"x\": -91174141133075340,\r\n    \"y\": 43938227486247170,\r\n    \"z\": -56482824383339900\r\n  },\r\n  \"security_class\": \"B\",\r\n  \"security_status\": 0.8462923765,\r\n  \"star_id\": 40000040,\r\n  \"stargates\": [\r\n    50000342\r\n  ],\r\n  \"system_id\": 30000003\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V3UniverseSystem response = await internalLatestUniverse.GetSystemAsync(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal(20000001, response.ConstellationId);
            Assert.Equal("Akpivem", response.Name);
            Assert.Equal(2, response.Planets.Count);
            Assert.Equal(1, response.Planets[0].Moons.Count);
            Assert.Equal(40000042, response.Planets[0].Moons[0]);
            Assert.Equal(40000041, response.Planets[0].PlanetId);
            Assert.Equal(40000043, response.Planets[1].PlanetId);
            Assert.Equal(-91174141133075340, response.Position.X);
            Assert.Equal(43938227486247170, response.Position.Y);
            Assert.Equal(-56482824383339900, response.Position.Z);
            Assert.Equal("B", response.SecurityClass);
            Assert.Equal(0.8462923765f, response.SecurityStatus);
            Assert.Equal(40000040, response.StarId);
            Assert.Equal(1, response.Stargates.Count);
            Assert.Equal(50000342, response.Stargates[0]);
            Assert.Equal(30000003, response.SystemId);
        }

        [Fact]
        public void GetTypes_successfully_returns_a_PagedModel_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1,\r\n  2,\r\n  3\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2});

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            PagedModel<int> response = internalLatestUniverse.GetTypes(1);

            Assert.Equal(2, response.MaxPages);
            Assert.Equal(1, response.CurrentPage);
            Assert.Equal(3, response.Model.Count);
            Assert.Equal(1, response.Model[0]);
            Assert.Equal(2, response.Model[1]);
            Assert.Equal(3, response.Model[2]);
        }

        [Fact]
        public async Task GetTypesAsync_successfully_returns_a_PagedModel_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1,\r\n  2,\r\n  3\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2});

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            PagedModel<int> response = await internalLatestUniverse.GetTypesAsync(1);

            Assert.Equal(2, response.MaxPages);
            Assert.Equal(1, response.CurrentPage);
            Assert.Equal(3, response.Model.Count);
            Assert.Equal(1, response.Model[0]);
            Assert.Equal(2, response.Model[1]);
            Assert.Equal(3, response.Model[2]);
        }

        [Fact]
        public void GetType_successfully_returns_a_item_type()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\"description\": \"The Rifter is a...\",\"group_id\": 25,\"name\": \"Rifter\",\"published\": true,\"type_id\": 587}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V3UniverseType response = internalLatestUniverse.GetType(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal("The Rifter is a...", response.Description);
            Assert.Equal(25, response.GroupId);
            Assert.Equal("Rifter", response.Name);
            Assert.True(response.Published);
            Assert.Equal(587, response.TypeId);
        }

        [Fact]
        public async Task GetType_successfully_returns_a_item_typeAsync()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\"description\": \"The Rifter is a...\",\"group_id\": 25,\"name\": \"Rifter\",\"published\": true,\"type_id\": 587}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V3UniverseType response = await internalLatestUniverse.GetTypeAsync(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal("The Rifter is a...", response.Description);
            Assert.Equal(25, response.GroupId);
            Assert.Equal("Rifter", response.Name);
            Assert.True(response.Published);
            Assert.Equal(587, response.TypeId);
        }
    }
}
