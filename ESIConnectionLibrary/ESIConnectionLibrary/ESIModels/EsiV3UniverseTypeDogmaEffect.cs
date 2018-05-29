using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3UniverseTypeDogmaEffect
    {
        [JsonProperty(PropertyName = "effect_id")]
        public long EffectId { get; set; }

        [JsonProperty(PropertyName = "is_default")]
        public bool IsDefault { get; set; }
    }
}