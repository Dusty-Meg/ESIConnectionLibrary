using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FwCharacterLeaderboardKillsActiveTotal
    {
        [JsonProperty(PropertyName = "amount")]
        public int? Amount { get; set; }

        [JsonProperty(PropertyName = "character_id")]
        public int? CharacterId { get; set; }
    }
}