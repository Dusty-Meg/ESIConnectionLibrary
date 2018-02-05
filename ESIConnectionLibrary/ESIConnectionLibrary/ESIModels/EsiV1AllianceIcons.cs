using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1AllianceIcons
    {
        [JsonProperty(PropertyName = "px64x64")]
        public string Px64X64 { get; set; }

        [JsonProperty(PropertyName = "px128x128")]
        public string Px128X128 { get; set; }
    }
}