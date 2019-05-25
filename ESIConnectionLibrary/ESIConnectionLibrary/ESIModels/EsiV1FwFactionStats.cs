using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FwFactionStats
    {
        [JsonProperty(PropertyName = "faction_id")]
        public int FactionId { get; set; }

        [JsonProperty(PropertyName = "kills")]
        public EsiV1FwFactionStatsKills Kills { get; set; }

        [JsonProperty(PropertyName = "pilots")]
        public int Pilots { get; set; }

        [JsonProperty(PropertyName = "systems_controlled")]
        public int SystemsControlled { get; set; }

        [JsonProperty(PropertyName = "victory_points")]
        public EsiV1FwFactionStatsVictoryPoints VictoryPoints { get; set; }
    }
}
