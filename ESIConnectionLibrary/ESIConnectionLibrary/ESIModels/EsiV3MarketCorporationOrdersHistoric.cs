﻿using System;
using ESIConnectionLibrary.Internal_classes;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3MarketCorporationOrdersHistoric
    {
        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "escrow")]
        public double? Escrow { get; set; }

        [JsonProperty(PropertyName = "is_buy_order")]
        public bool? IsBuyOrder { get; set; }

        [JsonProperty(PropertyName = "issued")]
        public DateTime Issued { get; set; }

        [JsonProperty(PropertyName = "issued_by")]
        public int IssuedBy { get; set; }

        [JsonProperty(PropertyName = "location_id")]
        public long LocationId { get; set; }

        [JsonProperty(PropertyName = "min_volume")]
        public int? MinVolume { get; set; }

        [JsonProperty(PropertyName = "order_id")]
        public long OrderId { get; set; }

        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }

        [JsonProperty(PropertyName = "range")]
        [JsonConverter(typeof(MarketOrderRangeTypeConverter))]
        public EsiMarketRange Range { get; set; }

        [JsonProperty(PropertyName = "region_id")]
        public int RegionId { get; set; }

        [JsonProperty(PropertyName = "state")]
        public EsiMarketState State { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }

        [JsonProperty(PropertyName = "volume_remain")]
        public int VolumeRemain { get; set; }

        [JsonProperty(PropertyName = "volume_total")]
        public int VolumeTotal { get; set; }

        [JsonProperty(PropertyName = "wallet_division")]
        public int WalletDivision { get; set; }
    }
}