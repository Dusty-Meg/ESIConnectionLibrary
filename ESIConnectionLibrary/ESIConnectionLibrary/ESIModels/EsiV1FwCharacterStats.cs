using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FwCharacterStats
    {
        [JsonProperty(PropertyName = "current_rank")]
        public int? CurrentRank { get; set; }

        [JsonProperty(PropertyName = "enlisted_on")]
        public DateTime? EnlistedOn { get; set; }

        [JsonProperty(PropertyName = "faction_id")]
        public int? FactionId { get; set; }

        [JsonProperty(PropertyName = "highest_rank")]
        public int? HighestRank { get; set; }

        [JsonProperty(PropertyName = "kills")]
        public EsiV1FwCharacterStatsKills Kills { get; set; }

        [JsonProperty(PropertyName = "victory_points")]
        public EsiV1FwCharacterStatsVictoryPoints VictoryPoints { get; set; }
    }
}