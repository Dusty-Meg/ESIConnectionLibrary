using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV4WalletCorporationJournal
    {
        [JsonProperty(PropertyName = "amount")]
        public double? Amount { get; set; }

        [JsonProperty(PropertyName = "balance")]
        public double? Balance { get; set; }

        [JsonProperty(PropertyName = "context_id")]
        public long? ContextId { get; set; }

        [JsonProperty(PropertyName = "context_id_type")]
        public EsiWalletContextIdType? ContextIdType { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "first_party_id")]
        public int? FirstPartyId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        [JsonProperty(PropertyName = "ref_type")]
        public EsiWalletRefType RefType { get; set; }

        [JsonProperty(PropertyName = "second_party_id")]
        public int? SecondPartyId { get; set; }

        [JsonProperty(PropertyName = "tax")]
        public double? Tax { get; set; }

        [JsonProperty(PropertyName = "tax_receiver_id")]
        public int? TaxReceiverId { get; set; }
    }
}