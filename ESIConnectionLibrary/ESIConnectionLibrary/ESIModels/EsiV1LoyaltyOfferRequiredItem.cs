using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1LoyaltyOfferRequiredItem
    {
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }
    }
}