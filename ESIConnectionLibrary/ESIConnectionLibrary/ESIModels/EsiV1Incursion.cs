using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1Incursion
    {
        [JsonProperty(PropertyName = "constellation_id")]
        public int ConstellationId { get; set; }

        [JsonProperty(PropertyName = "faction_Id")]
        public int FactionId { get; set; }

        [JsonProperty(PropertyName = "has_boss")]
        public bool HasBoss { get; set; }

        [JsonProperty(PropertyName = "infested_solar_systems")]
        public IList<int> InfestedSolarSystems { get; set; }

        [JsonProperty(PropertyName = "influence")]
        public float Influence { get; set; }

        [JsonProperty(PropertyName = "staging_solar_system_id")]
        public int StagingSolarSystemId { get; set; }

        [JsonProperty(PropertyName = "state")]
        public EsiV1IncursionState State { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}