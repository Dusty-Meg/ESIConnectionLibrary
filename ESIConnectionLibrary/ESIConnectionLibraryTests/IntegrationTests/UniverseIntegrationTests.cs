using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class UniverseIntegrationTests
    {
        [Fact]
        public void Ancestries_successfully_returns_a_list_of_Ancestries()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> returnModel = internalLatestUniverse.Categories();

            Assert.Equal(3, returnModel.Count);
            Assert.Equal(1, returnModel[0]);
            Assert.Equal(2, returnModel[1]);
            Assert.Equal(3, returnModel[2]);
        }

        [Fact]
        public async Task CategoriesAsync_successfully_returns_a_list_of_ints()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> returnModel = await internalLatestUniverse.CategoriesAsync();

            Assert.Equal(3, returnModel.Count);
            Assert.Equal(1, returnModel[0]);
            Assert.Equal(2, returnModel[1]);
            Assert.Equal(3, returnModel[2]);
        }

        [Fact]
        public void Category_successfully_returns_a_category()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> returnModel = internalLatestUniverse.Constellations();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(20000001, returnModel[0]);
            Assert.Equal(20000002, returnModel[1]);
        }

        [Fact]
        public async Task ConstellationsAsync_successfully_returns_a_list_of_ints()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> returnModel = await internalLatestUniverse.ConstellationsAsync();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(20000001, returnModel[0]);
            Assert.Equal(20000002, returnModel[1]);
        }

        [Fact]
        public void Constellation_successfully_returns_a_constellation()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> returnModel = internalLatestUniverse.Graphics();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(10, returnModel[0]);
            Assert.Equal(4106, returnModel[1]);
        }

        [Fact]
        public async Task GraphicsAsync_successfully_returns_a_list_of_ints()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> returnModel = await internalLatestUniverse.GraphicsAsync();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(10, returnModel[0]);
            Assert.Equal(4106, returnModel[1]);
        }

        [Fact]
        public void Graphic_successfully_returns_a_graphic()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            V1UniverseGraphic returnModel = internalLatestUniverse.Graphic(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal("res:/dx9/model/worldobject/planet/moon.red", returnModel.GraphicFile);
            Assert.Equal(10, returnModel.GraphicId);
        }

        [Fact]
        public async Task GraphicAsync_successfully_returns_a_graphic()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            V1UniverseGraphic returnModel = await internalLatestUniverse.GraphicAsync(int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal("res:/dx9/model/worldobject/planet/moon.red", returnModel.GraphicFile);
            Assert.Equal(10, returnModel.GraphicId);
        }

        [Fact]
        public void Groups_successfully_returns_a_PagedModel_of_ints()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            PagedModel<int> returnModel = internalLatestUniverse.Groups(1);

            Assert.Equal(1, returnModel.CurrentPage);
            Assert.Equal(3, returnModel.Model.Count);
            Assert.Equal(1, returnModel.Model[0]);
            Assert.Equal(2, returnModel.Model[1]);
            Assert.Equal(3, returnModel.Model[2]);
        }

        [Fact]
        public async Task GroupsAsync_successfully_returns_a_PagedModel_of_ints()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            PagedModel<int> response = await internalLatestUniverse.GroupsAsync(1);

            Assert.Equal(1, response.CurrentPage);
            Assert.Equal(3, response.Model.Count);
            Assert.Equal(1, response.Model[0]);
            Assert.Equal(2, response.Model[1]);
            Assert.Equal(3, response.Model[2]);
        }

        [Fact]
        public void Group_successfully_returns_a_group()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<V1UniverseRaces> returnModel = internalLatestUniverse.Races();

            Assert.Equal(1, returnModel.Count);
            Assert.Equal(500001, returnModel[0].AllianceId);
            Assert.Equal("Founded on the tenets of patriotism and hard work...", returnModel[0].Description);
            Assert.Equal("Caldari", returnModel[0].Name);
            Assert.Equal(1, returnModel[0].RaceId);
        }

        [Fact]
        public async Task RacesAsync_successfully_returns_a_list_of_Races()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> returnModel = internalLatestUniverse.Regions();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(11000001, returnModel[0]);
            Assert.Equal(11000002, returnModel[1]);
        }

        [Fact]
        public async Task RegionsAsync_successfully_returns_a_list_of_ints()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> returnModel = await internalLatestUniverse.RegionsAsync();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(11000001, returnModel[0]);
            Assert.Equal(11000002, returnModel[1]);
        }

        [Fact]
        public void Region_successfully_returns_a_region()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<long> returnModel = internalLatestUniverse.Structures();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(1020988381992, returnModel[0]);
            Assert.Equal(1020988381991, returnModel[1]);
        }

        [Fact]
        public async Task StructuresAsync_successfully_returns_a_list_of_longs()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<long> returnModel = await internalLatestUniverse.StructuresAsync();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(1020988381992, returnModel[0]);
            Assert.Equal(1020988381991, returnModel[1]);
        }

        [Fact]
        public void Structure_successfully_returns_a_structure()
        {
            UniverseScopes scopes = UniverseScopes.esi_universe_read_structures_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 33434, CharacterName = "sbla", UniverseScopesFlags = scopes };

            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            V2UniverseStructure returnModel = internalLatestUniverse.Structure(inputToken, int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal("V-3YG7 VI - The Capital", returnModel.Name);
            Assert.Equal(30000142, returnModel.SolarSystemId);
        }

        [Fact]
        public async Task StructureAsync_successfully_returns_a_structure()
        {
            UniverseScopes scopes = UniverseScopes.esi_universe_read_structures_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 33434, CharacterName = "sbla", UniverseScopesFlags = scopes };

            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            V2UniverseStructure returnModel = await internalLatestUniverse.StructureAsync(inputToken, int.MinValue);

            Assert.NotNull(returnModel);
            Assert.Equal("V-3YG7 VI - The Capital", returnModel.Name);
            Assert.Equal(30000142, returnModel.SolarSystemId);
        }

        [Fact]
        public void SystemJumps_successfully_returns_a_list_of_SystemJumps()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<V1UniverseSystemJumps> returnModel = internalLatestUniverse.SystemJumps();

            Assert.Equal(1, returnModel.Count);
            Assert.Equal(42, returnModel[0].ShipJumps);
            Assert.Equal(30002410, returnModel[0].SystemId);
        }

        [Fact]
        public async Task SystemJumpsAsync_successfully_returns_a_list_of_SystemJumps()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<V1UniverseSystemJumps> returnModel = await internalLatestUniverse.SystemJumpsAsync();

            Assert.Equal(1, returnModel.Count);
            Assert.Equal(42, returnModel[0].ShipJumps);
            Assert.Equal(30002410, returnModel[0].SystemId);
        }

        [Fact]
        public void SystemKills_successfully_returns_a_list_of_SystemKills()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> returnModel = internalLatestUniverse.Systems();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(30000001, returnModel[0]);
            Assert.Equal(30000002, returnModel[1]);
        }

        [Fact]
        public async Task SystemsAsync_successfully_returns_a_list_of_ints()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> returnModel = await internalLatestUniverse.SystemsAsync();

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(30000001, returnModel[0]);
            Assert.Equal(30000002, returnModel[1]);
        }

        [Fact]
        public void System_successfully_returns_a_system()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            PagedModel<int> returnModel = internalLatestUniverse.Types(1);

            Assert.Equal(1, returnModel.CurrentPage);
            Assert.Equal(3, returnModel.Model.Count);
            Assert.Equal(1, returnModel.Model[0]);
            Assert.Equal(2, returnModel.Model[1]);
            Assert.Equal(3, returnModel.Model[2]);
        }

        [Fact]
        public async Task TypesAsync_successfully_returns_a_PagedModel_of_ints()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            PagedModel<int> returnModel = await internalLatestUniverse.TypesAsync(1);

            Assert.Equal(1, returnModel.CurrentPage);
            Assert.Equal(3, returnModel.Model.Count);
            Assert.Equal(1, returnModel.Model[0]);
            Assert.Equal(2, returnModel.Model[1]);
            Assert.Equal(3, returnModel.Model[2]);
        }

        [Fact]
        public void Type_successfully_returns_a_item_type()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
