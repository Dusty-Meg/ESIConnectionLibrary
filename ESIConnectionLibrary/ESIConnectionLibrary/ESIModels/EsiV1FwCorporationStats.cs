using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FwCorporationStats
    {
        [JsonProperty(PropertyName = "enlisted_on")]
        public DateTime? EnlistedOn { get; set; }

        [JsonProperty(PropertyName = "faction_id")]
        public int? FactionId { get; set; }

        [JsonProperty(PropertyName = "kills")]
        public EsiV1FwCorporationKills Kills { get; set; }

        [JsonProperty(PropertyName = "pilots")]
        public int Pilots { get; set; }

        [JsonProperty(PropertyName = "victory_points")]
        public EsiV1FwCorporationVictoryPoints VictoryPoints { get; set; }
    }
}