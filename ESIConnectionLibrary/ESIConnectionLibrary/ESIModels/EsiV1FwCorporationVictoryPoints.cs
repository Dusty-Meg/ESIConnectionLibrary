using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FwCorporationVictoryPoints
    {
        [JsonProperty(PropertyName = "last_week")]
        public int LastWeek { get; set; }

        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }

        [JsonProperty(PropertyName = "yesterday")]
        public int Yesterday { get; set; }
    }
}