using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1DogmaDynamicItemAttribute
    {
        [JsonProperty(PropertyName = "attribute_id")]
        public int AttributeId { get; set; }

        [JsonProperty(PropertyName = "value")]
        public float Value { get; set; }
    }
}