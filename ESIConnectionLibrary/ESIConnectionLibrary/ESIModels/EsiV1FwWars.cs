using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    public class EsiV1FwWars
    {
        [JsonProperty(PropertyName = "against_id")]
        public int AgainstId { get; set; }

        [JsonProperty(PropertyName = "faction_id")]
        public int FactionId { get; set; }
    }
}