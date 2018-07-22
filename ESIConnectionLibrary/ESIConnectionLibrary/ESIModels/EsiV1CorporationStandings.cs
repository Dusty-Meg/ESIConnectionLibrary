using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1CorporationStandings
    {
        [JsonProperty(PropertyName = "from_id")]
        public int FromId { get; set; }

        [JsonProperty(PropertyName = "from_type")]
        public EsiV1CorporationStandingsFromType FromType { get; set; }

        [JsonProperty(PropertyName = "standing")]
        public float Standing { get; set; }
    }
}