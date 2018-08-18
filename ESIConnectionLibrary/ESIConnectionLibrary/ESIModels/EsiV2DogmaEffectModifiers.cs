using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2DogmaEffectModifiers
    {
        [JsonProperty(PropertyName = "domain")]
        public string Domain { get; set; }

        [JsonProperty(PropertyName = "effect_id")]
        public int? EffectId { get; set; }

        [JsonProperty(PropertyName = "func")]
        public string Func { get; set; }

        [JsonProperty(PropertyName = "modified_attribute_id")]
        public int? ModifiedAttributeId { get; set; }

        [JsonProperty(PropertyName = "modifying_attribute_id")]
        public int? ModifyingAttributeId { get; set; }

        [JsonProperty(PropertyName = "operator")]
        public int? Operator { get; set; }
    }
}