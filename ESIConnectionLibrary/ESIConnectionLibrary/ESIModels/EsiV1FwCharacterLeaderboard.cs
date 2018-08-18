using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FwCharacterLeaderboard
    {
        [JsonProperty(PropertyName = "kills")]
        public EsiV1FwCharacterLeaderboardKills Kills { get; set; }

        [JsonProperty(PropertyName = "victory_points")]
        public EsiV1FwCharacterLeaderboardVictoryPoints VictoryPoints { get; set; }
    }
}