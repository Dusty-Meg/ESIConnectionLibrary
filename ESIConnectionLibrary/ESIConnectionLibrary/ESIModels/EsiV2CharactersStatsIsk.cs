using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharactersStatsIsk
    {
        [JsonProperty(PropertyName = "in")]
        public long? In { get; set; }

        [JsonProperty(PropertyName = "out")]
        public long? Out { get; set; }
    }
}