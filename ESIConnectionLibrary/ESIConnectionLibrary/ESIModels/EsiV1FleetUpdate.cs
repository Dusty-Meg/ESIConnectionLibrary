using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FleetUpdate
    {
        [JsonProperty(PropertyName = "is_free_move")]
        public bool? IsFreeMove { get; set; }

        [JsonProperty(PropertyName = "motd")]
        public string Motd { get; set; }
    }
}