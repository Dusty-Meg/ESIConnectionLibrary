﻿using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1ContractsPublic
    {
        [JsonProperty(PropertyName = "buyout")]
        public double? Buyout { get; set; }

        [JsonProperty(PropertyName = "collateral")]
        public double? Collateral { get; set; }

        [JsonProperty(PropertyName = "contract_id")]
        public int ContractId { get; set; }

        [JsonProperty(PropertyName = "date_expired")]
        public DateTime DateExpired { get; set; }

        [JsonProperty(PropertyName = "date_issued")]
        public DateTime DateIssued { get; set; }

        [JsonProperty(PropertyName = "days_to_complete")]
        public int? DaysToComplete { get; set; }

        [JsonProperty(PropertyName = "end_location_id")]
        public long? EndLocationId { get; set; }

        [JsonProperty(PropertyName = "for_corporation")]
        public bool? ForCorporation { get; set; }

        [JsonProperty(PropertyName = "issuer_corporation_id")]
        public int IssuerCorporationId { get; set; }

        [JsonProperty(PropertyName = "issuer_id")]
        public int IssuerId { get; set; }

        [JsonProperty(PropertyName = "price")]
        public double? Price { get; set; }

        [JsonProperty(PropertyName = "reward")]
        public double? Reward { get; set; }

        [JsonProperty(PropertyName = "start_location_id")]
        public long? StartLocationId { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "type")]
        public EsiV1ContractsPublicType Type { get; set; }

        [JsonProperty(PropertyName = "volume")]
        public double? Volume { get; set; }
    }
}
