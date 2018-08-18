using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FwFactionLeaderboard
    {
        [JsonProperty(PropertyName = "kills")]
        public EsiV1FwFactionLeaderboardKills Kills { get; set; }

        [JsonProperty(PropertyName = "victory_points")]
        public EsiV1FwFactionLeaderboardVictoryPoints VictoryPoints { get; set; }
    }
}