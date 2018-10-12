using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1LoyaltyPoint
    {
        [JsonProperty(PropertyName = "corporation_id")]
        public int CorporationId { get; set; }

        [JsonProperty(PropertyName = "loyalty_points")]
        public int LoyaltyPoints { get; set; }
    }
}