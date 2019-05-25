using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Exceptions;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestUniverseEndpoints : ILatestUniverseEndpoints
    {
        private readonly IInternalLatestUniverse _internalLatestUniverse;

        public LatestUniverseEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestUniverse = new InternalLatestUniverse(null, userAgent, testing);
        }

        public IList<V1UniverseAncestries> Ancestries()
        {
            return _internalLatestUniverse.Ancestries();
        }

        public async Task<IList<V1UniverseAncestries>> AncestriesAsync()
        {
            return await _internalLatestUniverse.AncestriesAsync();
        }

        public V1UniverseAsteroidBelt AsteroidBelt(int asteroidBelId)
        {
            return _internalLatestUniverse.AsteroidBelt(asteroidBelId);
        }

        public async Task<V1UniverseAsteroidBelt> AsteroidBeltAsync(int asteroidBelId)
        {
            return await _internalLatestUniverse.AsteroidBeltAsync(asteroidBelId);
        }

        public IList<V1UniverseBloodlines> Bloodlines()
        {
            return _internalLatestUniverse.Bloodlines();
        }

        public async Task<IList<V1UniverseBloodlines>> BloodlinesAsync()
        {
            return await _internalLatestUniverse.BloodlinesAsync();
        }

        public IList<int> Categories()
        {
            return _internalLatestUniverse.Categories();
        }

        public async Task<IList<int>> CategoriesAsync()
        {
            return await _internalLatestUniverse.CategoriesAsync();
        }

        public V1UniverseCategory Category(int categoryId)
        {
            return _internalLatestUniverse.Category(categoryId);
        }

        public async Task<V1UniverseCategory> CategoryAsync(int categoryId)
        {
            return await _internalLatestUniverse.CategoryAsync(categoryId);
        }

        public IList<int> Constellations()
        {
            return _internalLatestUniverse.Constellations();
        }

        public async Task<IList<int>> ConstellationsAsync()
        {
            return await _internalLatestUniverse.ConstellationsAsync();
        }

        public V1UniverseConstellation Constellation(int constellationId)
        {
            return _internalLatestUniverse.Constellation(constellationId);
        }

        public async Task<V1UniverseConstellation> ConstellationAsync(int constellationId)
        {
            return await _internalLatestUniverse.ConstellationAsync(constellationId);
        }

        public IList<V2UniverseFactions> Factions()
        {
            return _internalLatestUniverse.Factions();
        }

        public async Task<IList<V2UniverseFactions>> FactionsAsync()
        {
            return await _internalLatestUniverse.FactionsAsync();
        }

        public IList<int> Graphics()
        {
            return _internalLatestUniverse.Graphics();
        }

        public async Task<IList<int>> GraphicsAsync()
        {
            return await _internalLatestUniverse.GraphicsAsync();
        }

        public V1UniverseGraphic Graphic(int graphicId)
        {
            return _internalLatestUniverse.Graphic(graphicId);
        }

        public async Task<V1UniverseGraphic> GraphicAsync(int graphicId)
        {
            return await _internalLatestUniverse.GraphicAsync(graphicId);
        }

        public V1UniverseGroup Group(int groupId)
        {
            return _internalLatestUniverse.Group(groupId);
        }

        public async Task<V1UniverseGroup> GroupAsync(int groupId)
        {
            return await _internalLatestUniverse.GroupAsync(groupId);
        }

        public PagedModel<int> Groups(int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestUniverse.Groups(page);
        }

        public async Task<PagedModel<int>> GroupsAsync(int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestUniverse.GroupsAsync(page);
        }

        public V1UniverseNamesToIds Ids(IList<string> names)
        {
            return _internalLatestUniverse.Ids(names);
        }

        public async Task<V1UniverseNamesToIds> IdsAsync(IList<string> names)
        {
            return await _internalLatestUniverse.IdsAsync(names);
        }

        public V1UniverseMoon Moon(int moonId)
        {
            return _internalLatestUniverse.Moon(moonId);
        }

        public async Task<V1UniverseMoon> MoonAsync(int moonId)
        {
            return await _internalLatestUniverse.MoonAsync(moonId);
        }

        public IList<V2UniverseNames> Names(IList<int> ids)
        {
            return _internalLatestUniverse.Names(ids);
        }

        public async Task<IList<V2UniverseNames>> NamesAsync(IList<int> ids)
        {
            return await _internalLatestUniverse.NamesAsync(ids);
        }

        public V1UniversePlanet Planet(int planetId)
        {
            return _internalLatestUniverse.Planet(planetId);
        }

        public async Task<V1UniversePlanet> PlanetAsync(int planetId)
        {
            return await _internalLatestUniverse.PlanetAsync(planetId);
        }

        public IList<V1UniverseRaces> Races()
        {
            return _internalLatestUniverse.Races();
        }

        public async Task<IList<V1UniverseRaces>> RacesAsync()
        {
            return await _internalLatestUniverse.RacesAsync();
        }

        public IList<int> Regions()
        {
            return _internalLatestUniverse.Regions();
        }

        public async Task<IList<int>> RegionsAsync()
        {
            return await _internalLatestUniverse.RegionsAsync();
        }

        public V1UniverseRegion Region(int regionId)
        {
            return _internalLatestUniverse.Region(regionId);
        }

        public async Task<V1UniverseRegion> RegionAsync(int planetId)
        {
            return await _internalLatestUniverse.RegionAsync(planetId);
        }

        public V1UniverseStargate Stargate(int stargateId)
        {
            return _internalLatestUniverse.Stargate(stargateId);
        }

        public async Task<V1UniverseStargate> StargateAsync(int stargateId)
        {
            return await _internalLatestUniverse.StargateAsync(stargateId);
        }

        public V1UniverseStar Star(int starId)
        {
            return _internalLatestUniverse.Star(starId);
        }

        public async Task<V1UniverseStar> StarAsync(int starId)
        {
            return await _internalLatestUniverse.StarAsync(starId);
        }

        public V2UniverseStation Station(int stationId)
        {
            return _internalLatestUniverse.Station(stationId);
        }

        public async Task<V2UniverseStation> StationAsync(int stationId)
        {
            return await _internalLatestUniverse.StationAsync(stationId);
        }

        public IList<long> Structures()
        {
            return _internalLatestUniverse.Structures();
        }

        public async Task<IList<long>> StructuresAsync()
        {
            return await _internalLatestUniverse.StructuresAsync();
        }

        public V2UniverseStructure Structure(SsoToken token, long structureId)
        {
            return _internalLatestUniverse.Structure(token, structureId);
        }

        public async Task<V2UniverseStructure> StructureAsync(SsoToken token, long structureId)
        {
            return await _internalLatestUniverse.StructureAsync(token, structureId);
        }

        public IList<V1UniverseSystemJumps> SystemJumps()
        {
            return _internalLatestUniverse.SystemJumps();
        }

        public async Task<IList<V1UniverseSystemJumps>> SystemJumpsAsync()
        {
            return await _internalLatestUniverse.SystemJumpsAsync();
        }

        public IList<V2UniverseSystemKills> SystemKills()
        {
            return _internalLatestUniverse.SystemKills();
        }

        public async Task<IList<V2UniverseSystemKills>> SystemKillsAsync()
        {
            return await _internalLatestUniverse.SystemKillsAsync();
        }

        public IList<int> Systems()
        {
            return _internalLatestUniverse.Systems();
        }

        public async Task<IList<int>> SystemsAsync()
        {
            return await _internalLatestUniverse.SystemsAsync();
        }

        public V4UniverseSystem System(int systemId)
        {
            return _internalLatestUniverse.System(systemId);
        }

        public async Task<V4UniverseSystem> SystemAsync(int systemId)
        {
            return await _internalLatestUniverse.SystemAsync(systemId);
        }

        public PagedModel<int> Types(int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestUniverse.Types(page);
        }

        public async Task<PagedModel<int>> TypesAsync(int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestUniverse.TypesAsync(page);
        }

        public V3UniverseType Type(int typeId)
        {
            return _internalLatestUniverse.Type(typeId);
        }

        public async Task<V3UniverseType> TypeAsync(int typeId)
        {
            return await _internalLatestUniverse.TypeAsync(typeId);
        }
    }
}
