using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestUniverse
    {
        IList<V1UniverseAncestries> GetAncestries();
        Task<IList<V1UniverseAncestries>> GetAncestriesAsync();
        V1UniverseAsteroidBelt GetAsteroidBelt(int asteroidBelId);
        Task<V1UniverseAsteroidBelt> GetAsteroidBeltAsync(int asteroidBelId);
        IList<V1UniverseBloodlines> GetBloodlines();
        Task<IList<V1UniverseBloodlines>> GetBloodlinesAsync();
        IList<int> GetCategories();
        Task<IList<int>> GetCategoriesAsync();
        V1UniverseCategory GetCategory(int categoryId);
        Task<V1UniverseCategory> GetCategoryAsync(int categoryId);
        V1UniverseConstellation GetConstellation(int constellationId);
        Task<V1UniverseConstellation> GetConstellationAsync(int constellationId);
        IList<int> GetConstellations();
        Task<IList<int>> GetConstellationsAsync();
        IList<V2UniverseFactions> GetFactions();
        Task<IList<V2UniverseFactions>> GetFactionsAsync();
        V1UniverseGraphic GetGraphic(int graphicId);
        Task<V1UniverseGraphic> GetGraphicAsync(int graphicId);
        IList<int> GetGraphics();
        Task<IList<int>> GetGraphicsAsync();
        V1UniverseGroup GetGroup(int groupId);
        Task<V1UniverseGroup> GetGroupAsync(int groupId);
        PagedModel<int> GetGroups(int page);
        Task<PagedModel<int>> GetGroupsAsync(int page);
        V1UniverseNamesToIds GetIds(IList<string> names);
        Task<V1UniverseNamesToIds> GetIdsAsync(IList<string> names);
        V1UniverseMoon GetMoon(int moonId);
        Task<V1UniverseMoon> GetMoonAsync(int moonId);
        IList<V2UniverseNames> GetNames(IList<int> ids);
        Task<IList<V2UniverseNames>> GetNamesAsync(IList<int> ids);
        V1UniversePlanet GetPlanet(int planetId);
        Task<V1UniversePlanet> GetPlanetAsync(int planetId);
        IList<V1UniverseRaces> GetRaces();
        Task<IList<V1UniverseRaces>> GetRacesAsync();
        V1UniverseRegion GetRegion(int regionId);
        Task<V1UniverseRegion> GetRegionAsync(int planetId);
        IList<int> GetRegions();
        Task<IList<int>> GetRegionsAsync();
        V1UniverseStar GetStar(int starId);
        Task<V1UniverseStar> GetStarAsync(int starId);
        V1UniverseStargate GetStargate(int stargateId);
        Task<V1UniverseStargate> GetStargateAsync(int stargateId);
        V2UniverseStation GetStation(int stationId);
        Task<V2UniverseStation> GetStationAsync(int stationId);
        V2UniverseStructure GetStructure(SsoToken token, long structureId);
        Task<V2UniverseStructure> GetStructureAsync(SsoToken token, long structureId);
        IList<long> GetStructures();
        Task<IList<long>> GetStructuresAsync();
        V4UniverseSystem GetSystem(int systemId);
        Task<V4UniverseSystem> GetSystemAsync(int systemId);
        IList<V1UniverseSystemJumps> GetSystemJumps();
        Task<IList<V1UniverseSystemJumps>> GetSystemJumpsAsync();
        IList<V2UniverseSystemKills> GetSystemKills();
        Task<IList<V2UniverseSystemKills>> GetSystemKillsAsync();
        IList<int> GetSystems();
        Task<IList<int>> GetSystemsAsync();
        V3UniverseType GetType(int typeId);
        Task<V3UniverseType> GetTypeAsync(int typeId);
        PagedModel<int> GetTypes(int page);
        Task<PagedModel<int>> GetTypesAsync(int page);
    }
}