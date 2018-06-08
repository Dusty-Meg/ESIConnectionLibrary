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
        public void GetAncestries_successfully_returns_a_list_of_Ancestries()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> response = internalLatestUniverse.GetCategories();

            Assert.Equal(3, response.Count);
            Assert.Equal(1, response[0]);
            Assert.Equal(2, response[1]);
            Assert.Equal(3, response[2]);
        }

        [Fact]
        public async Task GetCategoriesAsync_successfully_returns_a_list_of_ints()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> response = await internalLatestUniverse.GetCategoriesAsync();

            Assert.Equal(3, response.Count);
            Assert.Equal(1, response[0]);
            Assert.Equal(2, response[1]);
            Assert.Equal(3, response[2]);
        }

        [Fact]
        public void GetCategory_successfully_returns_a_category()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> response = internalLatestUniverse.GetConstellations();

            Assert.Equal(2, response.Count);
            Assert.Equal(20000001, response[0]);
            Assert.Equal(20000002, response[1]);
        }

        [Fact]
        public async Task GetConstellationsAsync_successfully_returns_a_list_of_ints()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> response = await internalLatestUniverse.GetConstellationsAsync();

            Assert.Equal(2, response.Count);
            Assert.Equal(20000001, response[0]);
            Assert.Equal(20000002, response[1]);
        }

        [Fact]
        public void GetConstellation_successfully_returns_a_constellation()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> response = internalLatestUniverse.GetGraphics();

            Assert.Equal(2, response.Count);
            Assert.Equal(10, response[0]);
            Assert.Equal(4106, response[1]);
        }

        [Fact]
        public async Task GetGraphicsAsync_successfully_returns_a_list_of_ints()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> response = await internalLatestUniverse.GetGraphicsAsync();

            Assert.Equal(2, response.Count);
            Assert.Equal(10, response[0]);
            Assert.Equal(4106, response[1]);
        }

        [Fact]
        public void GetGraphic_successfully_returns_a_graphic()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            V1UniverseGraphic response = internalLatestUniverse.GetGraphic(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal("res:/dx9/model/worldobject/planet/moon.red", response.GraphicFile);
            Assert.Equal(10, response.GraphicId);
        }

        [Fact]
        public async Task GetGraphicAsync_successfully_returns_a_graphic()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            V1UniverseGraphic response = await internalLatestUniverse.GetGraphicAsync(int.MinValue);

            Assert.NotNull(response);
            Assert.Equal("res:/dx9/model/worldobject/planet/moon.red", response.GraphicFile);
            Assert.Equal(10, response.GraphicId);
        }

        [Fact]
        public void GetGroups_successfully_returns_a_PagedModel_of_ints()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            PagedModel<int> response = internalLatestUniverse.GetGroups(1);

            Assert.Equal(1, response.CurrentPage);
            Assert.Equal(3, response.Model.Count);
            Assert.Equal(1, response.Model[0]);
            Assert.Equal(2, response.Model[1]);
            Assert.Equal(3, response.Model[2]);
        }

        [Fact]
        public async Task GetGroupsAsync_successfully_returns_a_PagedModel_of_ints()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            PagedModel<int> response = await internalLatestUniverse.GetGroupsAsync(1);

            Assert.Equal(1, response.CurrentPage);
            Assert.Equal(3, response.Model.Count);
            Assert.Equal(1, response.Model[0]);
            Assert.Equal(2, response.Model[1]);
            Assert.Equal(3, response.Model[2]);
        }

        [Fact]
        public void GetGroup_successfully_returns_a_group()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> response = internalLatestUniverse.GetRegions();

            Assert.Equal(2, response.Count);
            Assert.Equal(11000001, response[0]);
            Assert.Equal(11000002, response[1]);
        }

        [Fact]
        public async Task GetRegionsAsync_successfully_returns_a_list_of_ints()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> response = await internalLatestUniverse.GetRegionsAsync();

            Assert.Equal(2, response.Count);
            Assert.Equal(11000001, response[0]);
            Assert.Equal(11000002, response[1]);
        }

        [Fact]
        public void GetRegion_successfully_returns_a_region()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<long> response = internalLatestUniverse.GetStructures();

            Assert.Equal(2, response.Count);
            Assert.Equal(1020988381992, response[0]);
            Assert.Equal(1020988381991, response[1]);
        }

        [Fact]
        public async Task GetStructuresAsync_successfully_returns_a_list_of_longs()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<long> response = await internalLatestUniverse.GetStructuresAsync();

            Assert.Equal(2, response.Count);
            Assert.Equal(1020988381992, response[0]);
            Assert.Equal(1020988381991, response[1]);
        }

        [Fact]
        public void GetStructure_successfully_returns_a_structure()
        {
            UniverseScopes scopes = UniverseScopes.esi_universe_read_structures_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 33434, CharacterName = "sbla", UniverseScopesFlags = scopes };

            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            V1UniverseStructure response = internalLatestUniverse.GetStructure(inputToken, int.MinValue);

            Assert.NotNull(response);
            Assert.Equal("V-3YG7 VI - The Capital", response.Name);
            Assert.Equal(30000142, response.SolarSystemId);
        }

        [Fact]
        public async Task GetStructureAsync_successfully_returns_a_structure()
        {
            UniverseScopes scopes = UniverseScopes.esi_universe_read_structures_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = 33434, CharacterName = "sbla", UniverseScopesFlags = scopes };

            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            V1UniverseStructure response = await internalLatestUniverse.GetStructureAsync(inputToken, int.MinValue);

            Assert.NotNull(response);
            Assert.Equal("V-3YG7 VI - The Capital", response.Name);
            Assert.Equal(30000142, response.SolarSystemId);
        }

        [Fact]
        public void GetSystemJumps_successfully_returns_a_list_of_SystemJumps()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<V1UniverseSystemJumps> response = internalLatestUniverse.GetSystemJumps();

            Assert.Equal(1, response.Count);
            Assert.Equal(42, response[0].ShipJumps);
            Assert.Equal(30002410, response[0].SystemId);
        }

        [Fact]
        public async Task GetSystemJumpsAsync_successfully_returns_a_list_of_SystemJumps()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<V1UniverseSystemJumps> response = await internalLatestUniverse.GetSystemJumpsAsync();

            Assert.Equal(1, response.Count);
            Assert.Equal(42, response[0].ShipJumps);
            Assert.Equal(30002410, response[0].SystemId);
        }

        [Fact]
        public void GetSystemKills_successfully_returns_a_list_of_SystemKills()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> response = internalLatestUniverse.GetSystems();

            Assert.Equal(2, response.Count);
            Assert.Equal(30000001, response[0]);
            Assert.Equal(30000002, response[1]);
        }

        [Fact]
        public async Task GetSystemsAsync_successfully_returns_a_list_of_ints()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            IList<int> response = await internalLatestUniverse.GetSystemsAsync();

            Assert.Equal(2, response.Count);
            Assert.Equal(30000001, response[0]);
            Assert.Equal(30000002, response[1]);
        }

        [Fact]
        public void GetSystem_successfully_returns_a_system()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            PagedModel<int> response = internalLatestUniverse.GetTypes(1);

            Assert.Equal(1, response.CurrentPage);
            Assert.Equal(3, response.Model.Count);
            Assert.Equal(1, response.Model[0]);
            Assert.Equal(2, response.Model[1]);
            Assert.Equal(3, response.Model[2]);
        }

        [Fact]
        public async Task GetTypesAsync_successfully_returns_a_PagedModel_of_ints()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

            PagedModel<int> response = await internalLatestUniverse.GetTypesAsync(1);

            Assert.Equal(1, response.CurrentPage);
            Assert.Equal(3, response.Model.Count);
            Assert.Equal(1, response.Model[0]);
            Assert.Equal(2, response.Model[1]);
            Assert.Equal(3, response.Model[2]);
        }

        [Fact]
        public void GetType_successfully_returns_a_item_type()
        {
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
            LatestUniverseEndpoints internalLatestUniverse = new LatestUniverseEndpoints(string.Empty, true);

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
