using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1WalletCharacterTransactions
    {
        [JsonProperty(PropertyName = "client_id")]
        public int ClientId { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "is_buy")]
        public bool IsBuy { get; set; }

        [JsonProperty(PropertyName = "is_personal")]
        public bool IsPersonal { get; set; }

        [JsonProperty(PropertyName = "journal_ref_id")]
        public long JournalRefId { get; set; }

        [JsonProperty(PropertyName = "location_id")]
        public long LocationId { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "transaction_id")]
        public long TransactionId { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }

        [JsonProperty(PropertyName = "unit_price")]
        public double UnitPrice { get; set; }
    }
}