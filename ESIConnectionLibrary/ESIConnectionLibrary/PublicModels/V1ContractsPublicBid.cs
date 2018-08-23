using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1ContractsPublicBid
    {
        public float amount { get; set; }
        public int bid_id { get; set; }
        public int bidder_id { get; set; }
        public DateTime date_bid { get; set; }
    }
}