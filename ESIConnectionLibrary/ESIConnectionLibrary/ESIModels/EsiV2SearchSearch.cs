using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2SearchSearch
    {
        [JsonProperty(PropertyName = "agent")]
        public IList<int> Agent { get; set; }

        [JsonProperty(PropertyName = "alliance")]
        public IList<int> Alliance { get; set; }

        [JsonProperty(PropertyName = "character")]
        public IList<int> Character { get; set; }

        [JsonProperty(PropertyName = "constellation")]
        public IList<int> Constellation { get; set; }

        [JsonProperty(PropertyName = "corporation")]
        public IList<int> Corporation { get; set; }

        [JsonProperty(PropertyName = "faction")]
        public IList<int> Faction { get; set; }

        [JsonProperty(PropertyName = "inventory_type")]
        public IList<int> InventoryType { get; set; }

        [JsonProperty(PropertyName = "region")]
        public IList<int> Region { get; set; }

        [JsonProperty(PropertyName = "solar_system")]
        public IList<int> SolarSystem { get; set; }

        [JsonProperty(PropertyName = "station")]
        public IList<int> Station { get; set; }
    }
}