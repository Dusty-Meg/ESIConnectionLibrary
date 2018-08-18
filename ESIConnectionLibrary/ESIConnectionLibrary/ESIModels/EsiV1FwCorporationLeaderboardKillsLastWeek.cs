using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FwCorporationLeaderboardKillsLastWeek
    {
        [JsonProperty(PropertyName = "amount")]
        public int? Amount { get; set; }

        [JsonProperty(PropertyName = "corporation_id")]
        public int? CorporationId { get; set; }
    }
}