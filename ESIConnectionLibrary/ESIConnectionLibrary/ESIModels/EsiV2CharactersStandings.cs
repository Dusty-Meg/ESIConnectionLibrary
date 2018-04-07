using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharactersStandings
    {
        [JsonProperty(PropertyName = "from_id")]
        public int FromId { get; set; }

        [JsonProperty(PropertyName = "from_type")]
        public EsiStandingFromType FromType { get; set; }

        [JsonProperty(PropertyName = "standing")]
        public float Standing { get; set; }
    }
}
