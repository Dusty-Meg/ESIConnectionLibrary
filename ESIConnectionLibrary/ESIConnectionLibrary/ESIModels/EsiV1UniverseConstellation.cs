using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1UniverseConstellation
    {
        [JsonProperty(PropertyName = "constellation_id")]
        public int ConstellationId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "position")]
        public EsiPosition Position { get; set; }

        [JsonProperty(PropertyName = "region_id")]
        public int RegionId { get; set; }

        [JsonProperty(PropertyName = "systems")]
        public IList<int> Systems { get; set; }
    }
}