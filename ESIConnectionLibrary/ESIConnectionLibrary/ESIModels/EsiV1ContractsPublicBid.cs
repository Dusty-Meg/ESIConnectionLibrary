using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1ContractsPublicBid
    {
        [JsonProperty(PropertyName = "amount")]
        public float Amount { get; set; }

        [JsonProperty(PropertyName = "bid_id")]
        public int BidId { get; set; }

        [JsonProperty(PropertyName = "bidder_id")]
        public int BidderId { get; set; }

        [JsonProperty(PropertyName = "date_bid")]
        public DateTime DateBid { get; set; }
    }
}