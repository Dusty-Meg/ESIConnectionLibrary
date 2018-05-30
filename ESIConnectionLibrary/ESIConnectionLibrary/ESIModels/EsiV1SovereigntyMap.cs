using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1SovereigntyMap
    {
        [JsonProperty(PropertyName = "alliance_id")]
        public int? AllianceId { get; set; }

        [JsonProperty(PropertyName = "corporation_id")]
        public int? CorporationId { get; set; }

        [JsonProperty(PropertyName = "faction_id")]
        public int? FactionId { get; set; }

        [JsonProperty(PropertyName = "system_id")]
        public int SystemId { get; set; }
    }
}