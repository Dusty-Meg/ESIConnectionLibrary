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

        public IList<V1UniverseAncestries> GetAncestries()
        {
            return _internalLatestUniverse.GetAncestries();
        }

        public async Task<IList<V1UniverseAncestries>> GetAncestriesAsync()
        {
            return await _internalLatestUniverse.GetAncestriesAsync();
        }

        public V1UniverseAsteroidBelt GetAsteroidBelt(int asteroidBelId)
        {
            return _internalLatestUniverse.GetAsteroidBelt(asteroidBelId);
        }

        public async Task<V1UniverseAsteroidBelt> GetAsteroidBeltAsync(int asteroidBelId)
        {
            return await _internalLatestUniverse.GetAsteroidBeltAsync(asteroidBelId);
        }

        public IList<V1UniverseBloodlines> GetBloodlines()
        {
            return _internalLatestUniverse.GetBloodlines();
        }

        public async Task<IList<V1UniverseBloodlines>> GetBloodlinesAsync()
        {
            return await _internalLatestUniverse.GetBloodlinesAsync();
        }

        public IList<int> GetCategories()
        {
            return _internalLatestUniverse.GetCategories();
        }

        public async Task<IList<int>> GetCategoriesAsync()
        {
            return await _internalLatestUniverse.GetCategoriesAsync();
        }

        public V1UniverseCategory GetCategory(int categoryId)
        {
            return _internalLatestUniverse.GetCategory(categoryId);
        }

        public async Task<V1UniverseCategory> GetCategoryAsync(int categoryId)
        {
            return await _internalLatestUniverse.GetCategoryAsync(categoryId);
        }

        public IList<int> GetConstellations()
        {
            return _internalLatestUniverse.GetConstellations();
        }

        public async Task<IList<int>> GetConstellationsAsync()
        {
            return await _internalLatestUniverse.GetConstellationsAsync();
        }

        public V1UniverseConstellation GetConstellation(int constellationId)
        {
            return _internalLatestUniverse.GetConstellation(constellationId);
        }

        public async Task<V1UniverseConstellation> GetConstellationAsync(int constellationId)
        {
            return await _internalLatestUniverse.GetConstellationAsync(constellationId);
        }

        public IList<V2UniverseFactions> GetFactions()
        {
            return _internalLatestUniverse.GetFactions();
        }

        public async Task<IList<V2UniverseFactions>> GetFactionsAsync()
        {
            return await _internalLatestUniverse.GetFactionsAsync();
        }

        public IList<int> GetGraphics()
        {
            return _internalLatestUniverse.GetGraphics();
        }

        public async Task<IList<int>> GetGraphicsAsync()
        {
            return await _internalLatestUniverse.GetGraphicsAsync();
        }

        public V1UniverseGraphic GetGraphic(int graphicId)
        {
            return _internalLatestUniverse.GetGraphic(graphicId);
        }

        public async Task<V1UniverseGraphic> GetGraphicAsync(int graphicId)
        {
            return await _internalLatestUniverse.GetGraphicAsync(graphicId);
        }

        public V1UniverseGroup GetGroup(int groupId)
        {
            return _internalLatestUniverse.GetGroup(groupId);
        }

        public async Task<V1UniverseGroup> GetGroupAsync(int groupId)
        {
            return await _internalLatestUniverse.GetGroupAsync(groupId);
        }

        public PagedModel<int> GetGroups(int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return _internalLatestUniverse.GetGroups(page);
        }

        public async Task<PagedModel<int>> GetGroupsAsync(int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return await _internalLatestUniverse.GetGroupsAsync(page);
        }

        public V1UniverseNamesToIds GetIds(IList<string> names)
        {
            return _internalLatestUniverse.GetIds(names);
        }

        public async Task<V1UniverseNamesToIds> GetIdsAsync(IList<string> names)
        {
            return await _internalLatestUniverse.GetIdsAsync(names);
        }

        public V1UniverseMoon GetMoon(int moonId)
        {
            return _internalLatestUniverse.GetMoon(moonId);
        }

        public async Task<V1UniverseMoon> GetMoonAsync(int moonId)
        {
            return await _internalLatestUniverse.GetMoonAsync(moonId);
        }

        public IList<V2UniverseNames> GetNames(IList<int> ids)
        {
            return _internalLatestUniverse.GetNames(ids);
        }

        public async Task<IList<V2UniverseNames>> GetNamesAsync(IList<int> ids)
        {
            return await _internalLatestUniverse.GetNamesAsync(ids);
        }

        public V1UniversePlanet GetPlanet(int planetId)
        {
            return _internalLatestUniverse.GetPlanet(planetId);
        }

        public async Task<V1UniversePlanet> GetPlanetAsync(int planetId)
        {
            return await _internalLatestUniverse.GetPlanetAsync(planetId);
        }

        public IList<V1UniverseRaces> GetRaces()
        {
            return _internalLatestUniverse.GetRaces();
        }

        public async Task<IList<V1UniverseRaces>> GetRacesAsync()
        {
            return await _internalLatestUniverse.GetRacesAsync();
        }

        public IList<int> GetRegions()
        {
            return _internalLatestUniverse.GetRegions();
        }

        public async Task<IList<int>> GetRegionsAsync()
        {
            return await _internalLatestUniverse.GetRegionsAsync();
        }

        public V1UniverseRegion GetRegion(int regionId)
        {
            return _internalLatestUniverse.GetRegion(regionId);
        }

        public async Task<V1UniverseRegion> GetRegionAsync(int planetId)
        {
            return await _internalLatestUniverse.GetRegionAsync(planetId);
        }

        public V1UniverseStargate GetStargate(int stargateId)
        {
            return _internalLatestUniverse.GetStargate(stargateId);
        }

        public async Task<V1UniverseStargate> GetStargateAsync(int stargateId)
        {
            return await _internalLatestUniverse.GetStargateAsync(stargateId);
        }

        public V1UniverseStar GetStar(int starId)
        {
            return _internalLatestUniverse.GetStar(starId);
        }

        public async Task<V1UniverseStar> GetStarAsync(int starId)
        {
            return await _internalLatestUniverse.GetStarAsync(starId);
        }

        public V2UniverseStation GetStation(int stationId)
        {
            return _internalLatestUniverse.GetStation(stationId);
        }

        public async Task<V2UniverseStation> GetStationAsync(int stationId)
        {
            return await _internalLatestUniverse.GetStationAsync(stationId);
        }

        public IList<long> GetStructures()
        {
            return _internalLatestUniverse.GetStructures();
        }

        public async Task<IList<long>> GetStructuresAsync()
        {
            return await _internalLatestUniverse.GetStructuresAsync();
        }

        public V1UniverseStructure GetStructure(SsoToken token, long structureId)
        {
            return _internalLatestUniverse.GetStructure(token, structureId);
        }

        public async Task<V1UniverseStructure> GetStructureAsync(SsoToken token, long structureId)
        {
            return await _internalLatestUniverse.GetStructureAsync(token, structureId);
        }

        public IList<V1UniverseSystemJumps> GetSystemJumps()
        {
            return _internalLatestUniverse.GetSystemJumps();
        }

        public async Task<IList<V1UniverseSystemJumps>> GetSystemJumpsAsync()
        {
            return await _internalLatestUniverse.GetSystemJumpsAsync();
        }

        public IList<V2UniverseSystemKills> GetSystemKills()
        {
            return _internalLatestUniverse.GetSystemKills();
        }

        public async Task<IList<V2UniverseSystemKills>> GetSystemKillsAsync()
        {
            return await _internalLatestUniverse.GetSystemKillsAsync();
        }

        public IList<int> GetSystems()
        {
            return _internalLatestUniverse.GetSystems();
        }

        public async Task<IList<int>> GetSystemsAsync()
        {
            return await _internalLatestUniverse.GetSystemsAsync();
        }

        public V3UniverseSystem GetSystem(int systemId)
        {
            return _internalLatestUniverse.GetSystem(systemId);
        }

        public async Task<V3UniverseSystem> GetSystemAsync(int systemId)
        {
            return await _internalLatestUniverse.GetSystemAsync(systemId);
        }

        public PagedModel<int> GetTypes(int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return _internalLatestUniverse.GetTypes(page);
        }

        public async Task<PagedModel<int>> GetTypesAsync(int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return await _internalLatestUniverse.GetTypesAsync(page);
        }

        public V3UniverseType GetType(int typeId)
        {
            return _internalLatestUniverse.GetType(typeId);
        }

        public async Task<V3UniverseType> GetTypeAsync(int typeId)
        {
            return await _internalLatestUniverse.GetTypeAsync(typeId);
        }
    }
}
