using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CorporationStarbases
    {
        [JsonProperty(PropertyName = "moon_id")]
        public int? MoonId { get; set; }

        [JsonProperty(PropertyName = "onlined_since")]
        public DateTime? OnlinedSince { get; set; }

        [JsonProperty(PropertyName = "reinforced_until")]
        public DateTime? ReinforcedUntil { get; set; }

        [JsonProperty(PropertyName = "starbase_id")]
        public long StarbaseId { get; set; }

        [JsonProperty(PropertyName = "state")]
        public EsiV2CorporationStarbasesState? State { get; set; }

        [JsonProperty(PropertyName = "system_id")]
        public int SystemId { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }

        [JsonProperty(PropertyName = "unanchor_at")]
        public DateTime? UnanchorAt { get; set; }
    }
}