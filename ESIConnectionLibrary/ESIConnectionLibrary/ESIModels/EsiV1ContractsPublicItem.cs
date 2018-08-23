using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1ContractsPublicItem
    {
        [JsonProperty(PropertyName = "is_blueprint_copy")]
        public bool? IsBlueprintCopy { get; set; }

        [JsonProperty(PropertyName = "is_included")]
        public bool IsIncluded { get; set; }

        [JsonProperty(PropertyName = "item_id")]
        public long? ItemId { get; set; }

        [JsonProperty(PropertyName = "material_efficiency")]
        public int? MaterialEfficiency { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "record_id")]
        public long RecordId { get; set; }

        [JsonProperty(PropertyName = "runs")]
        public int? Runs { get; set; }

        [JsonProperty(PropertyName = "time_efficiency")]
        public int? TimeEfficiency { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }
    }
}