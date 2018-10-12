using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestUniverse
    {
        IList<V1UniverseAncestries> Ancestries();
        Task<IList<V1UniverseAncestries>> AncestriesAsync();
        V1UniverseAsteroidBelt AsteroidBelt(int asteroidBelId);
        Task<V1UniverseAsteroidBelt> AsteroidBeltAsync(int asteroidBelId);
        IList<V1UniverseBloodlines> Bloodlines();
        Task<IList<V1UniverseBloodlines>> BloodlinesAsync();
        IList<int> Categories();
        Task<IList<int>> CategoriesAsync();
        V1UniverseCategory Category(int categoryId);
        Task<V1UniverseCategory> CategoryAsync(int categoryId);
        V1UniverseConstellation Constellation(int constellationId);
        Task<V1UniverseConstellation> ConstellationAsync(int constellationId);
        IList<int> Constellations();
        Task<IList<int>> ConstellationsAsync();
        IList<V2UniverseFactions> Factions();
        Task<IList<V2UniverseFactions>> FactionsAsync();
        V1UniverseGraphic Graphic(int graphicId);
        Task<V1UniverseGraphic> GraphicAsync(int graphicId);
        IList<int> Graphics();
        Task<IList<int>> GraphicsAsync();
        V1UniverseGroup Group(int groupId);
        Task<V1UniverseGroup> GroupAsync(int groupId);
        PagedModel<int> Groups(int page);
        Task<PagedModel<int>> GroupsAsync(int page);
        V1UniverseNamesToIds Ids(IList<string> names);
        Task<V1UniverseNamesToIds> IdsAsync(IList<string> names);
        V1UniverseMoon Moon(int moonId);
        Task<V1UniverseMoon> MoonAsync(int moonId);
        IList<V2UniverseNames> Names(IList<int> ids);
        Task<IList<V2UniverseNames>> NamesAsync(IList<int> ids);
        V1UniversePlanet Planet(int planetId);
        Task<V1UniversePlanet> PlanetAsync(int planetId);
        IList<V1UniverseRaces> Races();
        Task<IList<V1UniverseRaces>> RacesAsync();
        V1UniverseRegion Region(int regionId);
        Task<V1UniverseRegion> RegionAsync(int planetId);
        IList<int> Regions();
        Task<IList<int>> RegionsAsync();
        V1UniverseStar Star(int starId);
        Task<V1UniverseStar> StarAsync(int starId);
        V1UniverseStargate Stargate(int stargateId);
        Task<V1UniverseStargate> StargateAsync(int stargateId);
        V2UniverseStation Station(int stationId);
        Task<V2UniverseStation> StationAsync(int stationId);
        V2UniverseStructure Structure(SsoToken token, long structureId);
        Task<V2UniverseStructure> StructureAsync(SsoToken token, long structureId);
        IList<long> Structures();
        Task<IList<long>> StructuresAsync();
        V4UniverseSystem System(int systemId);
        Task<V4UniverseSystem> SystemAsync(int systemId);
        IList<V1UniverseSystemJumps> SystemJumps();
        Task<IList<V1UniverseSystemJumps>> SystemJumpsAsync();
        IList<V2UniverseSystemKills> SystemKills();
        Task<IList<V2UniverseSystemKills>> SystemKillsAsync();
        IList<int> Systems();
        Task<IList<int>> SystemsAsync();
        V3UniverseType Type(int typeId);
        Task<V3UniverseType> TypeAsync(int typeId);
        PagedModel<int> Types(int page);
        Task<PagedModel<int>> TypesAsync(int page);
    }
}