using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1SovereigntyCampaignsParticipants
    {
        [JsonProperty(PropertyName = "alliance_id")]
        public int AllianceId { get; set; }

        [JsonProperty(PropertyName = "score")]
        public float Score { get; set; }
    }
}