﻿using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1ContractsPublicBid
    {
        public float Amount { get; set; }
        public int BidId { get; set; }
        public int BidderId { get; set; }
        public DateTime DateBid { get; set; }
    }
}