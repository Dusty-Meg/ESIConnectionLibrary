using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3UniverseTypeDogmaAttribute
    {
        [JsonProperty(PropertyName = "attribute_id")]
        public long AttributeId { get; set; }

        [JsonProperty(PropertyName = "value")]
        public long Value { get; set; }
    }
}