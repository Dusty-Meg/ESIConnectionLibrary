using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1UniverseNamesToIds
    {
        [JsonProperty(PropertyName = "agents")]
        public IList<EsiV1UniverseIds> Agents { get; set; }

        [JsonProperty(PropertyName = "alliances")]
        public IList<EsiV1UniverseIds> Alliances { get; set; }

        [JsonProperty(PropertyName = "characters")]
        public IList<EsiV1UniverseIds> Characters { get; set; }

        [JsonProperty(PropertyName = "constellations")]
        public IList<EsiV1UniverseIds> Constellations { get; set; }

        [JsonProperty(PropertyName = "corporations")]
        public IList<EsiV1UniverseIds> Corporations { get; set; }

        [JsonProperty(PropertyName = "factions")]
        public IList<EsiV1UniverseIds> Factions { get; set; }

        [JsonProperty(PropertyName = "inventory_types")]
        public IList<EsiV1UniverseIds> InventoryTypes { get; set; }

        [JsonProperty(PropertyName = "region")]
        public IList<EsiV1UniverseIds> Region { get; set; }

        [JsonProperty(PropertyName = "stations")]
        public IList<EsiV1UniverseIds> Stations { get; set; }

        [JsonProperty(PropertyName = "systems")]
        public IList<EsiV1UniverseIds> Systems { get; set; }
    }
}