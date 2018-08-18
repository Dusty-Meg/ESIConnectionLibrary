using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FwFactionLeaderboardVictoryPointsActiveTotal
    {
        [JsonProperty(PropertyName = "amount")]
        public int? Amount { get; set; }

        [JsonProperty(PropertyName = "faction_id")]
        public int? FactionId { get; set; }
    }
}