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
        public void Ancestries_successfully_returns_a_list_of_Ancestries()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"bloodline_id\": 1,\r\n    \"description\": \"Acutely aware of the small population...\",\r\n    \"id\": 12,\r\n    \"name\": \"Tube Child\",\r\n    \"short_description\": \"Manufactured citizens of the State.\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V1UniverseAncestries> returnModel = internalLatestUniverse.Ancestries();

            Assert.Equal(1, returnModel.Count);
            Assert.Equal(1, returnModel.First().BloodlineId);
            Assert.Equal("Acutely aware of the small population...", returnModel.First().Description);
            Assert.Equal(12, returnModel.First().Id);
            Assert.Equal("Tube Child", returnModel.First().Name);
            Assert.Equal("Manufactured citizens of the State.", returnModel.First().ShortDescription);
        }

        [Fact]
        public async Task AncestriesAsync_successfully_returns_a_list_of_Ancestries()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"bloodline_id\": 1,\r\n    \"description\": \"Acutely aware of the small population...\",\r\n    \"id\": 12,\r\n    \"name\": \"Tube Child\",\r\n    \"short_description\": \"Manufactured citizens of the State.\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V1UniverseAncestries> returnModel = await internalLatestUniverse.AncestriesAsync();

            Assert.Equal(1, returnModel.Count);
            Assert.Equal(1, returnModel.First().BloodlineId);
            Assert.Equal("Acutely aware of the small population...", returnModel.First().Description);
            Assert.Equal(12, returnModel.First().Id);
            Assert.Equal("Tube Child", returnModel.First().Name);
            Assert.Equal("Manufactured citizens of the State.", returnModel.First().ShortDescription);
        }

        [Fact]
        public void AsteroidBelt_successfully_returns_a_asteroid_belt()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"name\": \"Tanoo I - Asteroid Belt 1\",\r\n  \"position\": {\r\n    \"x\": 161967513600,\r\n    \"y\": 21288837120,\r\n    \"z\": -73505464320\r\n  },\r\n  \"system_id\": 30000001\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseAsteroidBelt returnModel = internalLatestUniverse.AsteroidBelt(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal("Tanoo I - Asteroid Belt 1", returnModel.Name);
            Assert.Equal(161967513600, returnModel.Position.X);
            Assert.Equal(21288837120, returnModel.Position.Y);
            Assert.Equal(-73505464320, returnModel.Position.Z);
            Assert.Equal(30000001, returnModel.SystemId);
        }

        [Fact]
        public async Task AsteroidBeltAsync_successfully_returns_a_asteroid_belt()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"name\": \"Tanoo I - Asteroid Belt 1\",\r\n  \"position\": {\r\n    \"x\": 161967513600,\r\n    \"y\": 21288837120,\r\n    \"z\": -73505464320\r\n  },\r\n  \"system_id\": 30000001\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseAsteroidBelt returnModel = await internalLatestUniverse.AsteroidBeltAsync(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal("Tanoo I - Asteroid Belt 1", returnModel.Name);
            Assert.Equal(161967513600, returnModel.Position.X);
            Assert.Equal(21288837120, returnModel.Position.Y);
            Assert.Equal(-73505464320, returnModel.Position.Z);
            Assert.Equal(30000001, returnModel.SystemId);
        }

        [Fact]
        public void Bloodlines_successfully_returns_a_list_of_Bloodlines()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"bloodline_id\": 1,\r\n    \"charisma\": 6,\r\n    \"corporation_id\": 1000006,\r\n    \"description\": \"The Deteis are regarded as ...\",\r\n    \"intelligence\": 7,\r\n    \"memory\": 7,\r\n    \"name\": \"Deteis\",\r\n    \"perception\": 5,\r\n    \"race_id\": 1,\r\n    \"ship_type_id\": 601,\r\n    \"willpower\": 5\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V1UniverseBloodlines> returnModel = internalLatestUniverse.Bloodlines();

            Assert.Equal(1, returnModel.Count);
            Assert.Equal(1, returnModel.First().BloodlineId);
            Assert.Equal(6, returnModel.First().Charisma);
            Assert.Equal(1000006, returnModel.First().CorporationId);
            Assert.Equal("The Deteis are regarded as ...", returnModel.First().Description);
            Assert.Equal(7, returnModel.First().Intelligence);
            Assert.Equal(7, returnModel.First().Memory);
            Assert.Equal("Deteis", returnModel.First().Name);
            Assert.Equal(5, returnModel.First().Perception);
            Assert.Equal(1, returnModel.First().RaceId);
            Assert.Equal(601, returnModel.First().ShipTypeId);
            Assert.Equal(5, returnModel.First().Willpower);
        }

        [Fact]
        public async Task BloodlinesAsync_successfully_returns_a_list_of_Bloodlines()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"bloodline_id\": 1,\r\n    \"charisma\": 6,\r\n    \"corporation_id\": 1000006,\r\n    \"description\": \"The Deteis are regarded as ...\",\r\n    \"intelligence\": 7,\r\n    \"memory\": 7,\r\n    \"name\": \"Deteis\",\r\n    \"perception\": 5,\r\n    \"race_id\": 1,\r\n    \"ship_type_id\": 601,\r\n    \"willpower\": 5\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V1UniverseBloodlines> returnModel = await internalLatestUniverse.BloodlinesAsync();

            Assert.Equal(1, returnModel.Count);
            Assert.Equal(1, returnModel.First().BloodlineId);
            Assert.Equal(6, returnModel.First().Charisma);
            Assert.Equal(1000006, returnModel.First().CorporationId);
            Assert.Equal("The Deteis are regarded as ...", returnModel.First().Description);
            Assert.Equal(7, returnModel.First().Intelligence);
            Assert.Equal(7, returnModel.First().Memory);
            Assert.Equal("Deteis", returnModel.First().Name);
            Assert.Equal(5, returnModel.First().Perception);
            Assert.Equal(1, returnModel.First().RaceId);
            Assert.Equal(601, returnModel.First().ShipTypeId);
            Assert.Equal(5, returnModel.First().Willpower);
        }

        [Fact]
        public void Categories_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1,\r\n  2,\r\n  3\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> returnModel = internalLatestUniverse.Categories();

            Assert.Equal(3, returnModel.Count);
            Assert.Equal(1, returnModel[0]);
            Assert.Equal(2, returnModel[1]);
            Assert.Equal(3, returnModel[2]);
        }

        [Fact]
        public async Task CategoriesAsync_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1,\r\n  2,\r\n  3\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> returnModel = await internalLatestUniverse.CategoriesAsync();

            Assert.Equal(3, returnModel.Count);
            Assert.Equal(1, returnModel[0]);
            Assert.Equal(2, returnModel[1]);
            Assert.Equal(3, returnModel[2]);
        }

        [Fact]
        public void Category_successfully_returns_a_category()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"category_id\": 6,\r\n  \"groups\": [\r\n    25,\r\n    26,\r\n    27\r\n  ],\r\n  \"name\": \"Ship\",\r\n  \"published\": true\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseCategory returnModel = internalLatestUniverse.Category(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal(6, returnModel.CategoryId);
            Assert.Equal(3, returnModel.Groups.Count);
            Assert.Equal(25, returnModel.Groups[0]);
            Assert.Equal(26, returnModel.Groups[1]);
            Assert.Equal(27, returnModel.Groups[2]);
            Assert.Equal("Ship", returnModel.Name);
            Assert.True(returnModel.Published);
        }

        [Fact]
        public async Task CategoryAsync_successfully_returns_a_category()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"category_id\": 6,\r\n  \"groups\": [\r\n    25,\r\n    26,\r\n    27\r\n  ],\r\n  \"name\": \"Ship\",\r\n  \"published\": true\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseCategory returnModel = await internalLatestUniverse.CategoryAsync(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal(6, returnModel.CategoryId);
            Assert.Equal(3, returnModel.Groups.Count);
            Assert.Equal(25, returnModel.Groups[0]);
            Assert.Equal(26, returnModel.Groups[1]);
            Assert.Equal(27, returnModel.Groups[2]);
            Assert.Equal("Ship", returnModel.Name);
            Assert.True(returnModel.Published);
        }

        [Fact]
        public void Constellations_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  20000001,\r\n  20000002\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> returnModel = internalLatestUniverse.Constellations();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(20000001, returnModel[0]);
            Assert.Equal(20000002, returnModel[1]);
        }

        [Fact]
        public async Task ConstellationsAsync_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  20000001,\r\n  20000002\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> returnModel = await internalLatestUniverse.ConstellationsAsync();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(20000001, returnModel[0]);
            Assert.Equal(20000002, returnModel[1]);
        }

        [Fact]
        public void Constellation_successfully_returns_a_constellation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"constellation_id\": 20000009,\r\n  \"name\": \"Mekashtad\",\r\n  \"position\": {\r\n    \"x\": 67796138757472320,\r\n    \"y\": -70591121348560960,\r\n    \"z\": -59587016159270070\r\n  },\r\n  \"region_id\": 10000001,\r\n  \"systems\": [\r\n    20000302,\r\n    20000303\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseConstellation returnModel = internalLatestUniverse.Constellation(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal(20000009, returnModel.ConstellationId);
            Assert.Equal("Mekashtad", returnModel.Name);
            Assert.Equal(67796138757472320, returnModel.Position.X);
            Assert.Equal(-70591121348560960, returnModel.Position.Y);
            Assert.Equal(-59587016159270070, returnModel.Position.Z);
            Assert.Equal(10000001, returnModel.RegionId);
            Assert.Equal(2, returnModel.Systems.Count);
            Assert.Equal(20000302, returnModel.Systems[0]);
            Assert.Equal(20000303, returnModel.Systems[1]);
        }

        [Fact]
        public async Task ConstellationAsync_successfully_returns_a_constellation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"constellation_id\": 20000009,\r\n  \"name\": \"Mekashtad\",\r\n  \"position\": {\r\n    \"x\": 67796138757472320,\r\n    \"y\": -70591121348560960,\r\n    \"z\": -59587016159270070\r\n  },\r\n  \"region_id\": 10000001,\r\n  \"systems\": [\r\n    20000302,\r\n    20000303\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseConstellation returnModel = await internalLatestUniverse.ConstellationAsync(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal(20000009, returnModel.ConstellationId);
            Assert.Equal("Mekashtad", returnModel.Name);
            Assert.Equal(67796138757472320, returnModel.Position.X);
            Assert.Equal(-70591121348560960, returnModel.Position.Y);
            Assert.Equal(-59587016159270070, returnModel.Position.Z);
            Assert.Equal(10000001, returnModel.RegionId);
            Assert.Equal(2, returnModel.Systems.Count);
            Assert.Equal(20000302, returnModel.Systems[0]);
            Assert.Equal(20000303, returnModel.Systems[1]);
        }

        [Fact]
        public void Factions_successfully_returns_a_list_of_Factions()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"corporation_id\": 456,\r\n    \"description\": \"blah blah\",\r\n    \"faction_id\": 1,\r\n    \"is_unique\": true,\r\n    \"name\": \"Faction\",\r\n    \"size_factor\": 1,\r\n    \"solar_system_id\": 123,\r\n    \"station_count\": 1000,\r\n    \"station_system_count\": 100\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V2UniverseFactions> returnModel = internalLatestUniverse.Factions();

            Assert.Equal(1, returnModel.Count);
            Assert.Equal(456, returnModel.First().CorporationId);
            Assert.Equal("blah blah", returnModel.First().Description);
            Assert.Equal(1, returnModel.First().FactionId);
            Assert.True(returnModel.First().IsUnique);
            Assert.Equal("Faction", returnModel.First().Name);
            Assert.Equal(1, returnModel.First().SizeFactor);
            Assert.Equal(123, returnModel.First().SolarSystemId);
            Assert.Equal(1000, returnModel.First().StationCount);
            Assert.Equal(100, returnModel.First().StationSystemCount);
        }

        [Fact]
        public async Task FactionsAsync_successfully_returns_a_list_of_Factions()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"corporation_id\": 456,\r\n    \"description\": \"blah blah\",\r\n    \"faction_id\": 1,\r\n    \"is_unique\": true,\r\n    \"name\": \"Faction\",\r\n    \"size_factor\": 1,\r\n    \"solar_system_id\": 123,\r\n    \"station_count\": 1000,\r\n    \"station_system_count\": 100\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V2UniverseFactions> returnModel = await internalLatestUniverse.FactionsAsync();

            Assert.Equal(1, returnModel.Count);
            Assert.Equal(456, returnModel.First().CorporationId);
            Assert.Equal("blah blah", returnModel.First().Description);
            Assert.Equal(1, returnModel.First().FactionId);
            Assert.True(returnModel.First().IsUnique);
            Assert.Equal("Faction", returnModel.First().Name);
            Assert.Equal(1, returnModel.First().SizeFactor);
            Assert.Equal(123, returnModel.First().SolarSystemId);
            Assert.Equal(1000, returnModel.First().StationCount);
            Assert.Equal(100, returnModel.First().StationSystemCount);
        }

        [Fact]
        public void Graphics_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  10,\r\n  4106\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> returnModel = internalLatestUniverse.Graphics();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(10, returnModel[0]);
            Assert.Equal(4106, returnModel[1]);
        }

        [Fact]
        public async Task GraphicsAsync_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  10,\r\n  4106\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> returnModel = await internalLatestUniverse.GraphicsAsync();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(10, returnModel[0]);
            Assert.Equal(4106, returnModel[1]);
        }

        [Fact]
        public void Graphic_successfully_returns_a_graphic()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"graphic_file\": \"res:/dx9/model/worldobject/planet/moon.red\",\r\n  \"graphic_id\": 10\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseGraphic returnModel = internalLatestUniverse.Graphic(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal("res:/dx9/model/worldobject/planet/moon.red", returnModel.GraphicFile);
            Assert.Equal(10, returnModel.GraphicId);
        }

        [Fact]
        public async Task GraphicAsync_successfully_returns_a_graphic()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"graphic_file\": \"res:/dx9/model/worldobject/planet/moon.red\",\r\n  \"graphic_id\": 10\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseGraphic returnModel = await internalLatestUniverse.GraphicAsync(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal("res:/dx9/model/worldobject/planet/moon.red", returnModel.GraphicFile);
            Assert.Equal(10, returnModel.GraphicId);
        }

        [Fact]
        public void Groups_successfully_returns_a_PagedModel_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1,\r\n  2,\r\n  3\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2});

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            PagedModel<int> returnModel = internalLatestUniverse.Groups(1);

            Assert.Equal(2, returnModel.MaxPages);
            Assert.Equal(1, returnModel.CurrentPage);
            Assert.Equal(3, returnModel.Model.Count);
            Assert.Equal(1, returnModel.Model[0]);
            Assert.Equal(2, returnModel.Model[1]);
            Assert.Equal(3, returnModel.Model[2]);
        }

        [Fact]
        public async Task GroupsAsync_successfully_returns_a_PagedModel_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1,\r\n  2,\r\n  3\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2});

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            PagedModel<int> returnModel = await internalLatestUniverse.GroupsAsync(1);

            Assert.Equal(2, returnModel.MaxPages);
            Assert.Equal(1, returnModel.CurrentPage);
            Assert.Equal(3, returnModel.Model.Count);
            Assert.Equal(1, returnModel.Model[0]);
            Assert.Equal(2, returnModel.Model[1]);
            Assert.Equal(3, returnModel.Model[2]);
        }

        [Fact]
        public void Group_successfully_returns_a_group()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"category_id\": 6,\r\n  \"group_id\": 25,\r\n  \"name\": \"Frigate\",\r\n  \"published\": true,\r\n  \"types\": [\r\n    587,\r\n    586,\r\n    585\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseGroup returnModel = internalLatestUniverse.Group(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal(6, returnModel.CategoryId);
            Assert.Equal(25, returnModel.GroupId);
            Assert.Equal("Frigate", returnModel.Name);
            Assert.True(returnModel.Published);
            Assert.Equal(3, returnModel.Types.Count);
            Assert.Equal(587, returnModel.Types[0]);
            Assert.Equal(586, returnModel.Types[1]);
            Assert.Equal(585, returnModel.Types[2]);
        }

        [Fact]
        public async Task GroupAsync_successfully_returns_a_group()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"category_id\": 6,\r\n  \"group_id\": 25,\r\n  \"name\": \"Frigate\",\r\n  \"published\": true,\r\n  \"types\": [\r\n    587,\r\n    586,\r\n    585\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseGroup returnModel = await internalLatestUniverse.GroupAsync(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal(6, returnModel.CategoryId);
            Assert.Equal(25, returnModel.GroupId);
            Assert.Equal("Frigate", returnModel.Name);
            Assert.True(returnModel.Published);
            Assert.Equal(3, returnModel.Types.Count);
            Assert.Equal(587, returnModel.Types[0]);
            Assert.Equal(586, returnModel.Types[1]);
            Assert.Equal(585, returnModel.Types[2]);
        }

        [Fact]
        public void Ids_successfully_returns_a_list_of_strings()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"characters\": [\r\n    {\r\n      \"id\": 95465499,\r\n      \"name\": \"CCP Bartender\"\r\n    },\r\n    {\r\n      \"id\": 2112625428,\r\n      \"name\": \"CCP Zoetrope\"\r\n    }\r\n  ],\r\n  \"systems\": [\r\n    {\r\n      \"id\": 30000142,\r\n      \"name\": \"Jita\"\r\n    }\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseNamesToIds returnModel = internalLatestUniverse.Ids(new List<string>());

            Assert.Equal(2, returnModel.Characters.Count);
            Assert.Equal(95465499, returnModel.Characters[0].Id);
            Assert.Equal("CCP Bartender", returnModel.Characters[0].Name);
            Assert.Equal(2112625428, returnModel.Characters[1].Id);
            Assert.Equal("CCP Zoetrope", returnModel.Characters[1].Name);
            Assert.Equal(1, returnModel.Systems.Count);
            Assert.Equal(30000142, returnModel.Systems[0].Id);
            Assert.Equal("Jita", returnModel.Systems[0].Name);
        }

        [Fact]
        public async Task IdsAsync_successfully_returns_a_list_of_strings()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"characters\": [\r\n    {\r\n      \"id\": 95465499,\r\n      \"name\": \"CCP Bartender\"\r\n    },\r\n    {\r\n      \"id\": 2112625428,\r\n      \"name\": \"CCP Zoetrope\"\r\n    }\r\n  ],\r\n  \"systems\": [\r\n    {\r\n      \"id\": 30000142,\r\n      \"name\": \"Jita\"\r\n    }\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.PostAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseNamesToIds returnModel = await internalLatestUniverse.IdsAsync(new List<string>());

            Assert.Equal(2, returnModel.Characters.Count);
            Assert.Equal(95465499, returnModel.Characters[0].Id);
            Assert.Equal("CCP Bartender", returnModel.Characters[0].Name);
            Assert.Equal(2112625428, returnModel.Characters[1].Id);
            Assert.Equal("CCP Zoetrope", returnModel.Characters[1].Name);
            Assert.Equal(1, returnModel.Systems.Count);
            Assert.Equal(30000142, returnModel.Systems[0].Id);
            Assert.Equal("Jita", returnModel.Systems[0].Name);
        }

        [Fact]
        public void Moon_successfully_returns_a_moon()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"moon_id\": 40000042,\r\n  \"name\": \"Akpivem I - Moon 1\",\r\n  \"position\": {\r\n    \"x\": 58605102008,\r\n    \"y\": -3066616285,\r\n    \"z\": -55193617920\r\n  },\r\n  \"system_id\": 30000003\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseMoon returnModel = internalLatestUniverse.Moon(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal(40000042, returnModel.MoonId);
            Assert.Equal("Akpivem I - Moon 1", returnModel.Name);
            Assert.Equal(58605102008, returnModel.Position.X);
            Assert.Equal(-3066616285, returnModel.Position.Y);
            Assert.Equal(-55193617920, returnModel.Position.Z);
            Assert.Equal(30000003, returnModel.SystemId);
        }

        [Fact]
        public async Task MoonAsync_successfully_returns_a_moon()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"moon_id\": 40000042,\r\n  \"name\": \"Akpivem I - Moon 1\",\r\n  \"position\": {\r\n    \"x\": 58605102008,\r\n    \"y\": -3066616285,\r\n    \"z\": -55193617920\r\n  },\r\n  \"system_id\": 30000003\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseMoon returnModel = await internalLatestUniverse.MoonAsync(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal(40000042, returnModel.MoonId);
            Assert.Equal("Akpivem I - Moon 1", returnModel.Name);
            Assert.Equal(58605102008, returnModel.Position.X);
            Assert.Equal(-3066616285, returnModel.Position.Y);
            Assert.Equal(-55193617920, returnModel.Position.Z);
            Assert.Equal(30000003, returnModel.SystemId);
        }

        [Fact]
        public void Names_successfully_returns_a_list_of_Names()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[{\"category\": \"character\",\"id\": 95465499,\"name\": \"CCP Bartender\"},{\"category\": \"solar_system\",\"id\": 30000142,\"name\": \"Jita\"}]";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V2UniverseNames> returnModel = internalLatestUniverse.Names(new List<int>());

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(V2UniverseNamesCategory.Character, returnModel[0].Category);
            Assert.Equal(95465499, returnModel[0].Id);
            Assert.Equal("CCP Bartender", returnModel[0].Name);
            Assert.Equal(V2UniverseNamesCategory.SolarSystem, returnModel[1].Category);
            Assert.Equal(30000142, returnModel[1].Id);
            Assert.Equal("Jita", returnModel[1].Name);
        }

        [Fact]
        public async Task Names_successfully_returns_a_list_of_NamesAsync()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[{\"category\": \"character\",\"id\": 95465499,\"name\": \"CCP Bartender\"},{\"category\": \"solar_system\",\"id\": 30000142,\"name\": \"Jita\"}]";

            mockedWebClient.Setup(x => x.PostAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V2UniverseNames> returnModel = await internalLatestUniverse.NamesAsync(new List<int>());

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(V2UniverseNamesCategory.Character, returnModel[0].Category);
            Assert.Equal(95465499, returnModel[0].Id);
            Assert.Equal("CCP Bartender", returnModel[0].Name);
            Assert.Equal(V2UniverseNamesCategory.SolarSystem, returnModel[1].Category);
            Assert.Equal(30000142, returnModel[1].Id);
            Assert.Equal("Jita", returnModel[1].Name);
        }

        [Fact]
        public void Planet_successfully_returns_a_planet()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"name\": \"Akpivem III\",\r\n  \"planet_id\": 40000046,\r\n  \"position\": {\r\n    \"x\": -189226344497,\r\n    \"y\": 9901605317,\r\n    \"z\": -254852632979\r\n  },\r\n  \"system_id\": 30000003,\r\n  \"type_id\": 13\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniversePlanet returnModel = internalLatestUniverse.Planet(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal("Akpivem III", returnModel.Name);
            Assert.Equal(40000046, returnModel.PlanetId);
            Assert.Equal(-189226344497, returnModel.Position.X);
            Assert.Equal(9901605317, returnModel.Position.Y);
            Assert.Equal(-254852632979, returnModel.Position.Z);
            Assert.Equal(30000003, returnModel.SystemId);
            Assert.Equal(13, returnModel.TypeId);
        }

        [Fact]
        public async Task PlanetAsync_successfully_returns_a_planet()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"name\": \"Akpivem III\",\r\n  \"planet_id\": 40000046,\r\n  \"position\": {\r\n    \"x\": -189226344497,\r\n    \"y\": 9901605317,\r\n    \"z\": -254852632979\r\n  },\r\n  \"system_id\": 30000003,\r\n  \"type_id\": 13\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniversePlanet returnModel = await internalLatestUniverse.PlanetAsync(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal("Akpivem III", returnModel.Name);
            Assert.Equal(40000046, returnModel.PlanetId);
            Assert.Equal(-189226344497, returnModel.Position.X);
            Assert.Equal(9901605317, returnModel.Position.Y);
            Assert.Equal(-254852632979, returnModel.Position.Z);
            Assert.Equal(30000003, returnModel.SystemId);
            Assert.Equal(13, returnModel.TypeId);
        }

        [Fact]
        public void Races_successfully_returns_a_list_of_Races()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"alliance_id\": 500001,\r\n    \"description\": \"Founded on the tenets of patriotism and hard work...\",\r\n    \"name\": \"Caldari\",\r\n    \"race_id\": 1\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V1UniverseRaces> returnModel = internalLatestUniverse.Races();

            Assert.Equal(1, returnModel.Count);
            Assert.Equal(500001, returnModel[0].AllianceId);
            Assert.Equal("Founded on the tenets of patriotism and hard work...", returnModel[0].Description);
            Assert.Equal("Caldari", returnModel[0].Name);
            Assert.Equal(1, returnModel[0].RaceId);
        }

        [Fact]
        public async Task GetRacesAsync_successfully_returns_a_list_of_Races()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"alliance_id\": 500001,\r\n    \"description\": \"Founded on the tenets of patriotism and hard work...\",\r\n    \"name\": \"Caldari\",\r\n    \"race_id\": 1\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V1UniverseRaces> returnModel = await internalLatestUniverse.RacesAsync();

            Assert.Equal(1, returnModel.Count);
            Assert.Equal(500001, returnModel[0].AllianceId);
            Assert.Equal("Founded on the tenets of patriotism and hard work...", returnModel[0].Description);
            Assert.Equal("Caldari", returnModel[0].Name);
            Assert.Equal(1, returnModel[0].RaceId);
        }

        [Fact]
        public void Regions_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  11000001,\r\n  11000002\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> returnModel = internalLatestUniverse.Regions();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(11000001, returnModel[0]);
            Assert.Equal(11000002, returnModel[1]);
        }

        [Fact]
        public async Task RegionsAsync_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  11000001,\r\n  11000002\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> returnModel = await internalLatestUniverse.RegionsAsync();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(11000001, returnModel[0]);
            Assert.Equal(11000002, returnModel[1]);
        }

        [Fact]
        public void Region_successfully_returns_a_region()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"constellations\": [\r\n    20000302,\r\n    20000303\r\n  ],\r\n  \"description\": \"It has long been an established fact of civilization...\",\r\n  \"name\": \"Metropolis\",\r\n  \"region_id\": 10000042\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseRegion returnModel = internalLatestUniverse.Region(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal(2, returnModel.Constellations.Count);
            Assert.Equal(20000302, returnModel.Constellations[0]);
            Assert.Equal(20000303, returnModel.Constellations[1]);
            Assert.Equal("It has long been an established fact of civilization...", returnModel.Description);
            Assert.Equal("Metropolis", returnModel.Name);
            Assert.Equal(10000042, returnModel.RegionId);
        }

        [Fact]
        public async Task RegionAsync_successfully_returns_a_region()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"constellations\": [\r\n    20000302,\r\n    20000303\r\n  ],\r\n  \"description\": \"It has long been an established fact of civilization...\",\r\n  \"name\": \"Metropolis\",\r\n  \"region_id\": 10000042\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseRegion returnModel = await internalLatestUniverse.RegionAsync(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal(2, returnModel.Constellations.Count);
            Assert.Equal(20000302, returnModel.Constellations[0]);
            Assert.Equal(20000303, returnModel.Constellations[1]);
            Assert.Equal("It has long been an established fact of civilization...", returnModel.Description);
            Assert.Equal("Metropolis", returnModel.Name);
            Assert.Equal(10000042, returnModel.RegionId);
        }

        [Fact]
        public void Stargate_successfully_returns_a_stargate()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"destination\": {\r\n    \"stargate_id\": 50000056,\r\n    \"system_id\": 30000001\r\n  },\r\n  \"name\": \"Stargate (Tanoo)\",\r\n  \"position\": {\r\n    \"x\": -101092761600,\r\n    \"y\": 5279539200,\r\n    \"z\": 1550503403520\r\n  },\r\n  \"stargate_id\": 50000342,\r\n  \"system_id\": 30000003,\r\n  \"type_id\": 29624\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseStargate returnModel = internalLatestUniverse.Stargate(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal(50000056, returnModel.Destination.StargateId);
            Assert.Equal(30000001, returnModel.Destination.SystemId);
            Assert.Equal("Stargate (Tanoo)", returnModel.Name);
            Assert.Equal(-101092761600, returnModel.Position.X);
            Assert.Equal(5279539200, returnModel.Position.Y);
            Assert.Equal(1550503403520, returnModel.Position.Z);
            Assert.Equal(50000342, returnModel.StargateId);
            Assert.Equal(30000003, returnModel.SystemId);
            Assert.Equal(29624, returnModel.TypeId);
        }

        [Fact]
        public async Task StargateAsync_successfully_returns_a_stargate()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"destination\": {\r\n    \"stargate_id\": 50000056,\r\n    \"system_id\": 30000001\r\n  },\r\n  \"name\": \"Stargate (Tanoo)\",\r\n  \"position\": {\r\n    \"x\": -101092761600,\r\n    \"y\": 5279539200,\r\n    \"z\": 1550503403520\r\n  },\r\n  \"stargate_id\": 50000342,\r\n  \"system_id\": 30000003,\r\n  \"type_id\": 29624\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseStargate returnModel = await internalLatestUniverse.StargateAsync(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal(50000056, returnModel.Destination.StargateId);
            Assert.Equal(30000001, returnModel.Destination.SystemId);
            Assert.Equal("Stargate (Tanoo)", returnModel.Name);
            Assert.Equal(-101092761600, returnModel.Position.X);
            Assert.Equal(5279539200, returnModel.Position.Y);
            Assert.Equal(1550503403520, returnModel.Position.Z);
            Assert.Equal(50000342, returnModel.StargateId);
            Assert.Equal(30000003, returnModel.SystemId);
            Assert.Equal(29624, returnModel.TypeId);
        }

        [Fact]
        public void Star_successfully_returns_a_star()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"age\": 9398686722,\r\n  \"luminosity\": 0.0661500022,\r\n  \"name\": \"BKG-Q2 - Star\",\r\n  \"radius\": 346600000,\r\n  \"solar_system_id\": 30004333,\r\n  \"spectral_class\": \"K2 V\",\r\n  \"temperature\": 3953,\r\n  \"type_id\": 45033\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseStar returnModel = internalLatestUniverse.Star(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal(9398686722, returnModel.Age);
            Assert.Equal(0.0661500022f, returnModel.Luminosity);
            Assert.Equal("BKG-Q2 - Star", returnModel.Name);
            Assert.Equal(346600000, returnModel.Radius);
            Assert.Equal(30004333, returnModel.SolarSystemId);
            Assert.Equal(V1UniverseStarSpectralClass.K2V, returnModel.SpectralClass);
            Assert.Equal(3953, returnModel.Temperature);
            Assert.Equal(45033, returnModel.TypeId);
        }

        [Fact]
        public async Task StarAsync_successfully_returns_a_star()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"age\": 9398686722,\r\n  \"luminosity\": 0.0661500022,\r\n  \"name\": \"BKG-Q2 - Star\",\r\n  \"radius\": 346600000,\r\n  \"solar_system_id\": 30004333,\r\n  \"spectral_class\": \"K2 V\",\r\n  \"temperature\": 3953,\r\n  \"type_id\": 45033\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V1UniverseStar returnModel = await internalLatestUniverse.StarAsync(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal(9398686722, returnModel.Age);
            Assert.Equal(0.0661500022f, returnModel.Luminosity);
            Assert.Equal("BKG-Q2 - Star", returnModel.Name);
            Assert.Equal(346600000, returnModel.Radius);
            Assert.Equal(30004333, returnModel.SolarSystemId);
            Assert.Equal(V1UniverseStarSpectralClass.K2V, returnModel.SpectralClass);
            Assert.Equal(3953, returnModel.Temperature);
            Assert.Equal(45033, returnModel.TypeId);
        }

        [Fact]
        public void Station_successfully_returns_a_station()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"max_dockable_ship_volume\": 50000000,\r\n  \"name\": \"Jakanerva III - Moon 15 - Prompt Delivery Storage\",\r\n  \"office_rental_cost\": 10000,\r\n  \"owner\": 1000003,\r\n  \"position\": {\r\n    \"x\": 165632286720,\r\n    \"y\": 2771804160,\r\n    \"z\": -2455331266560\r\n  },\r\n  \"race_id\": 1,\r\n  \"reprocessing_efficiency\": 0.5,\r\n  \"reprocessing_stations_take\": 0.05,\r\n  \"services\": [\r\n    \"courier-missions\",\r\n    \"reprocessing-plant\",\r\n    \"market\",\r\n    \"repair-facilities\",\r\n    \"fitting\",\r\n    \"news\",\r\n    \"storage\",\r\n    \"insurance\",\r\n    \"docking\",\r\n    \"office-rental\",\r\n    \"loyalty-point-store\",\r\n    \"navy-offices\"\r\n  ],\r\n  \"station_id\": 60000277,\r\n  \"system_id\": 30000148,\r\n  \"type_id\": 1531\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V2UniverseStation returnModel = internalLatestUniverse.Station(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal(50000000, returnModel.MaxDockableShipVolume);
            Assert.Equal("Jakanerva III - Moon 15 - Prompt Delivery Storage", returnModel.Name);
            Assert.Equal(10000, returnModel.OfficeRentalCost);
            Assert.Equal(1000003, returnModel.Owner);
            Assert.Equal(165632286720, returnModel.Position.X);
            Assert.Equal(2771804160, returnModel.Position.Y);
            Assert.Equal(-2455331266560, returnModel.Position.Z);
            Assert.Equal(1, returnModel.RaceId);
            Assert.Equal(0.5f, returnModel.ReprocessingEfficiency);
            Assert.Equal(0.05f, returnModel.ReprocessingStationsTake);
            Assert.Equal(12, returnModel.Services.Count);
            Assert.Contains(V2UniverseStationServices.CourierMissions, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.ReprocessingPlant, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.Market, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.RepairFacilities, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.Fitting, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.News, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.Storage, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.Insurance, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.Docking, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.OfficeRental, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.LoyaltyPointStore, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.NavyOffices, returnModel.Services);
            Assert.Equal(60000277, returnModel.StationId);
            Assert.Equal(30000148, returnModel.SystemId);
            Assert.Equal(1531, returnModel.TypeId);
        }

        [Fact]
        public async Task StationAsync_successfully_returns_a_station()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"max_dockable_ship_volume\": 50000000,\r\n  \"name\": \"Jakanerva III - Moon 15 - Prompt Delivery Storage\",\r\n  \"office_rental_cost\": 10000,\r\n  \"owner\": 1000003,\r\n  \"position\": {\r\n    \"x\": 165632286720,\r\n    \"y\": 2771804160,\r\n    \"z\": -2455331266560\r\n  },\r\n  \"race_id\": 1,\r\n  \"reprocessing_efficiency\": 0.5,\r\n  \"reprocessing_stations_take\": 0.05,\r\n  \"services\": [\r\n    \"courier-missions\",\r\n    \"reprocessing-plant\",\r\n    \"market\",\r\n    \"repair-facilities\",\r\n    \"fitting\",\r\n    \"news\",\r\n    \"storage\",\r\n    \"insurance\",\r\n    \"docking\",\r\n    \"office-rental\",\r\n    \"loyalty-point-store\",\r\n    \"navy-offices\"\r\n  ],\r\n  \"station_id\": 60000277,\r\n  \"system_id\": 30000148,\r\n  \"type_id\": 1531\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V2UniverseStation returnModel = await internalLatestUniverse.StationAsync(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal(50000000, returnModel.MaxDockableShipVolume);
            Assert.Equal("Jakanerva III - Moon 15 - Prompt Delivery Storage", returnModel.Name);
            Assert.Equal(10000, returnModel.OfficeRentalCost);
            Assert.Equal(1000003, returnModel.Owner);
            Assert.Equal(165632286720, returnModel.Position.X);
            Assert.Equal(2771804160, returnModel.Position.Y);
            Assert.Equal(-2455331266560, returnModel.Position.Z);
            Assert.Equal(1, returnModel.RaceId);
            Assert.Equal(0.5f, returnModel.ReprocessingEfficiency);
            Assert.Equal(0.05f, returnModel.ReprocessingStationsTake);
            Assert.Equal(12, returnModel.Services.Count);
            Assert.Contains(V2UniverseStationServices.CourierMissions, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.ReprocessingPlant, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.Market, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.RepairFacilities, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.Fitting, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.News, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.Storage, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.Insurance, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.Docking, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.OfficeRental, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.LoyaltyPointStore, returnModel.Services);
            Assert.Contains(V2UniverseStationServices.NavyOffices, returnModel.Services);
            Assert.Equal(60000277, returnModel.StationId);
            Assert.Equal(30000148, returnModel.SystemId);
            Assert.Equal(1531, returnModel.TypeId);
        }

        [Fact]
        public void Structures_successfully_returns_a_list_of_longs()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1020988381992,\r\n  1020988381991\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<long> returnModel = internalLatestUniverse.Structures();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(1020988381992, returnModel[0]);
            Assert.Equal(1020988381991, returnModel[1]);
        }

        [Fact]
        public async Task StructuresAsync_successfully_returns_a_list_of_longs()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1020988381992,\r\n  1020988381991\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<long> returnModel = await internalLatestUniverse.StructuresAsync();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(1020988381992, returnModel[0]);
            Assert.Equal(1020988381991, returnModel[1]);
        }

        [Fact]
        public void Structure_successfully_returns_a_structure()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            UniverseScopes scopes = UniverseScopes.esi_universe_read_structures_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 33434, CharacterName = "sbla", UniverseScopesFlags = scopes };
            string json = "{\r\n  \"name\": \"V-3YG7 VI - The Capital\",\r\n  \"solar_system_id\": 30000142\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V2UniverseStructure returnModel = internalLatestUniverse.Structure(inputToken, int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal("V-3YG7 VI - The Capital", returnModel.Name);
            Assert.Equal(30000142, returnModel.SolarSystemId);
        }

        [Fact]
        public async Task StructureAsync_successfully_returns_a_structure()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            UniverseScopes scopes = UniverseScopes.esi_universe_read_structures_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 33434, CharacterName = "sbla", UniverseScopesFlags = scopes };
            string json = "{\r\n  \"name\": \"V-3YG7 VI - The Capital\",\r\n  \"solar_system_id\": 30000142\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V2UniverseStructure returnModel = await internalLatestUniverse.StructureAsync(inputToken, int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal("V-3YG7 VI - The Capital", returnModel.Name);
            Assert.Equal(30000142, returnModel.SolarSystemId);
        }

        [Fact]
        public void SystemJumps_successfully_returns_a_list_of_SystemJumps()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"ship_jumps\": 42,\r\n    \"system_id\": 30002410\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V1UniverseSystemJumps> returnModel = internalLatestUniverse.SystemJumps();

            Assert.Equal(1, returnModel.Count);
            Assert.Equal(42, returnModel[0].ShipJumps);
            Assert.Equal(30002410, returnModel[0].SystemId);
        }

        [Fact]
        public async Task SystemJumpsAsync_successfully_returns_a_list_of_SystemJumps()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"ship_jumps\": 42,\r\n    \"system_id\": 30002410\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V1UniverseSystemJumps> returnModel = await internalLatestUniverse.SystemJumpsAsync();

            Assert.Equal(1, returnModel.Count);
            Assert.Equal(42, returnModel[0].ShipJumps);
            Assert.Equal(30002410, returnModel[0].SystemId);
        }

        [Fact]
        public void SystemKills_successfully_returns_a_list_of_SystemKills()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"npc_kills\": 0,\r\n    \"pod_kills\": 24,\r\n    \"ship_kills\": 42,\r\n    \"system_id\": 30002410\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V2UniverseSystemKills> returnModel = internalLatestUniverse.SystemKills();

            Assert.Equal(1, returnModel.Count);
            Assert.Equal(0, returnModel[0].NpcKills);
            Assert.Equal(24, returnModel[0].PodKills);
            Assert.Equal(42, returnModel[0].ShipKills);
            Assert.Equal(30002410, returnModel[0].SystemId);
        }

        [Fact]
        public async Task SystemKillsAsync_successfully_returns_a_list_of_SystemKills()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"npc_kills\": 0,\r\n    \"pod_kills\": 24,\r\n    \"ship_kills\": 42,\r\n    \"system_id\": 30002410\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<V2UniverseSystemKills> returnModel = await internalLatestUniverse.SystemKillsAsync();

            Assert.Equal(1, returnModel.Count);
            Assert.Equal(0, returnModel[0].NpcKills);
            Assert.Equal(24, returnModel[0].PodKills);
            Assert.Equal(42, returnModel[0].ShipKills);
            Assert.Equal(30002410, returnModel[0].SystemId);
        }

        [Fact]
        public void Systems_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  30000001,\r\n  30000002\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> returnModel = internalLatestUniverse.Systems();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(30000001, returnModel[0]);
            Assert.Equal(30000002, returnModel[1]);
        }

        [Fact]
        public async Task SystemsAsync_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  30000001,\r\n  30000002\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            IList<int> returnModel = await internalLatestUniverse.SystemsAsync();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(30000001, returnModel[0]);
            Assert.Equal(30000002, returnModel[1]);
        }

        [Fact]
        public void System_successfully_returns_a_system()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"constellation_id\": 20000001,\r\n  \"name\": \"Akpivem\",\r\n  \"planets\": [\r\n    {\r\n      \"moons\": [\r\n        40000042\r\n      ],\r\n      \"planet_id\": 40000041\r\n    },\r\n    {\r\n      \"planet_id\": 40000043\r\n    }\r\n  ],\r\n  \"position\": {\r\n    \"x\": -91174141133075340,\r\n    \"y\": 43938227486247170,\r\n    \"z\": -56482824383339900\r\n  },\r\n  \"security_class\": \"B\",\r\n  \"security_status\": 0.8462923765,\r\n  \"star_id\": 40000040,\r\n  \"stargates\": [\r\n    50000342\r\n  ],\r\n  \"system_id\": 30000003\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V4UniverseSystem returnModel = internalLatestUniverse.System(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal(20000001, returnModel.ConstellationId);
            Assert.Equal("Akpivem", returnModel.Name);
            Assert.Equal(2, returnModel.Planets.Count);
            Assert.Equal(1, returnModel.Planets[0].Moons.Count);
            Assert.Equal(40000042, returnModel.Planets[0].Moons[0]);
            Assert.Equal(40000041, returnModel.Planets[0].PlanetId);
            Assert.Equal(40000043, returnModel.Planets[1].PlanetId);
            Assert.Equal(-91174141133075340, returnModel.Position.X);
            Assert.Equal(43938227486247170, returnModel.Position.Y);
            Assert.Equal(-56482824383339900, returnModel.Position.Z);
            Assert.Equal("B", returnModel.SecurityClass);
            Assert.Equal(0.8462923765f, returnModel.SecurityStatus);
            Assert.Equal(40000040, returnModel.StarId);
            Assert.Equal(1, returnModel.Stargates.Count);
            Assert.Equal(50000342, returnModel.Stargates[0]);
            Assert.Equal(30000003, returnModel.SystemId);
        }

        [Fact]
        public async Task SystemAsync_successfully_returns_a_system()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"constellation_id\": 20000001,\r\n  \"name\": \"Akpivem\",\r\n  \"planets\": [\r\n    {\r\n      \"moons\": [\r\n        40000042\r\n      ],\r\n      \"planet_id\": 40000041\r\n    },\r\n    {\r\n      \"planet_id\": 40000043\r\n    }\r\n  ],\r\n  \"position\": {\r\n    \"x\": -91174141133075340,\r\n    \"y\": 43938227486247170,\r\n    \"z\": -56482824383339900\r\n  },\r\n  \"security_class\": \"B\",\r\n  \"security_status\": 0.8462923765,\r\n  \"star_id\": 40000040,\r\n  \"stargates\": [\r\n    50000342\r\n  ],\r\n  \"system_id\": 30000003\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V4UniverseSystem returnModel = await internalLatestUniverse.SystemAsync(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal(20000001, returnModel.ConstellationId);
            Assert.Equal("Akpivem", returnModel.Name);
            Assert.Equal(2, returnModel.Planets.Count);
            Assert.Equal(1, returnModel.Planets[0].Moons.Count);
            Assert.Equal(40000042, returnModel.Planets[0].Moons[0]);
            Assert.Equal(40000041, returnModel.Planets[0].PlanetId);
            Assert.Equal(40000043, returnModel.Planets[1].PlanetId);
            Assert.Equal(-91174141133075340, returnModel.Position.X);
            Assert.Equal(43938227486247170, returnModel.Position.Y);
            Assert.Equal(-56482824383339900, returnModel.Position.Z);
            Assert.Equal("B", returnModel.SecurityClass);
            Assert.Equal(0.8462923765f, returnModel.SecurityStatus);
            Assert.Equal(40000040, returnModel.StarId);
            Assert.Equal(1, returnModel.Stargates.Count);
            Assert.Equal(50000342, returnModel.Stargates[0]);
            Assert.Equal(30000003, returnModel.SystemId);
        }

        [Fact]
        public void Types_successfully_returns_a_PagedModel_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1,\r\n  2,\r\n  3\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2});

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            PagedModel<int> returnModel = internalLatestUniverse.Types(1);

            Assert.Equal(2, returnModel.MaxPages);
            Assert.Equal(1, returnModel.CurrentPage);
            Assert.Equal(3, returnModel.Model.Count);
            Assert.Equal(1, returnModel.Model[0]);
            Assert.Equal(2, returnModel.Model[1]);
            Assert.Equal(3, returnModel.Model[2]);
        }

        [Fact]
        public async Task TypesAsync_successfully_returns_a_PagedModel_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1,\r\n  2,\r\n  3\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2});

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            PagedModel<int> returnModel = await internalLatestUniverse.TypesAsync(1);

            Assert.Equal(2, returnModel.MaxPages);
            Assert.Equal(1, returnModel.CurrentPage);
            Assert.Equal(3, returnModel.Model.Count);
            Assert.Equal(1, returnModel.Model[0]);
            Assert.Equal(2, returnModel.Model[1]);
            Assert.Equal(3, returnModel.Model[2]);
        }

        [Fact]
        public void Type_successfully_returns_a_item_type()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\"description\": \"The Rifter is a...\",\"group_id\": 25,\"name\": \"Rifter\",\"published\": true,\"type_id\": 587}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V3UniverseType returnModel = internalLatestUniverse.Type(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal("The Rifter is a...", returnModel.Description);
            Assert.Equal(25, returnModel.GroupId);
            Assert.Equal("Rifter", returnModel.Name);
            Assert.True(returnModel.Published);
            Assert.Equal(587, returnModel.TypeId);
        }

        [Fact]
        public async Task Type_successfully_returns_a_item_typeAsync()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\"description\": \"The Rifter is a...\",\"group_id\": 25,\"name\": \"Rifter\",\"published\": true,\"type_id\": 587}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestUniverse internalLatestUniverse = new InternalLatestUniverse(mockedWebClient.Object, string.Empty);

            V3UniverseType returnModel = await internalLatestUniverse.TypeAsync(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal("The Rifter is a...", returnModel.Description);
            Assert.Equal(25, returnModel.GroupId);
            Assert.Equal("Rifter", returnModel.Name);
            Assert.True(returnModel.Published);
            Assert.Equal(587, returnModel.TypeId);
        }
    }
}
