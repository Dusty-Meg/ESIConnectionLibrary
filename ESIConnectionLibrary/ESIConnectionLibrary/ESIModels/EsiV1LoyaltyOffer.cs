using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1LoyaltyOffer
    {
        [JsonProperty(PropertyName = "ak_cost")]
        public int? AkCost { get; set; }

        [JsonProperty(PropertyName = "isk_cost")]
        public long IskCost { get; set; }

        [JsonProperty(PropertyName = "lp_cost")]
        public int LpCost { get; set; }

        [JsonProperty(PropertyName = "offer_id")]
        public int OfferId { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "required_items")]
        public IList<EsiV1LoyaltyOfferRequiredItem> RequiredItems { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }
    }
}