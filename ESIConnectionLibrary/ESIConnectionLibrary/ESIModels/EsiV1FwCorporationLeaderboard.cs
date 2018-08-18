using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FwCorporationLeaderboard
    {
        [JsonProperty(PropertyName = "kills")]
        public EsiV1FwCorporationLeaderboardKills Kills { get; set; }

        [JsonProperty(PropertyName = "victory_points")]
        public EsiV1FwCorporationLeaderboardVictoryPoints VictoryPoints { get; set; }
    }
}