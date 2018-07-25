using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1ContractsCharacterItems
    {
        [JsonProperty(PropertyName = "is_included")]
        public bool IsIncluded { get; set; }

        [JsonProperty(PropertyName = "is_singleton")]
        public bool IsSingleton { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "raw_quantity")]
        public int? RawQuantity { get; set; }

        [JsonProperty(PropertyName = "record_id")]
        public long RecordId { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }
    }
}