using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1DogmaDynamicItemEffect
    {
        [JsonProperty(PropertyName = "effect_id")]
        public int EffectId { get; set; }

        [JsonProperty(PropertyName = "is_default")]
        public bool IsDefault { get; set; }
    }
}