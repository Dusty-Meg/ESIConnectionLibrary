using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1UniverseNamesToIds
    {
        public IList<V1UniverseIds> Agents { get; set; }
        public IList<V1UniverseIds> Alliances { get; set; }
        public IList<V1UniverseIds> Characters { get; set; }
        public IList<V1UniverseIds> Constellations { get; set; }
        public IList<V1UniverseIds> Corporations { get; set; }
        public IList<V1UniverseIds> Factions { get; set; }
        public IList<V1UniverseIds> InventoryTypes { get; set; }
        public IList<V1UniverseIds> Region { get; set; }
        public IList<V1UniverseIds> Stations { get; set; }
        public IList<V1UniverseIds> Systems { get; set; }
    }
}