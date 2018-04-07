using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharactersPortrait
    {
        [JsonProperty(PropertyName = "px64x64")]
        public string Px64X64 { get; set; }

        [JsonProperty(PropertyName = "px128x128")]
        public string Px128X128 { get; set; }

        [JsonProperty(PropertyName = "px256x256")]
        public string Px256X256 { get; set; }

        [JsonProperty(PropertyName = "px512x512")]
        public string Px512X512 { get; set; }
    }
}
