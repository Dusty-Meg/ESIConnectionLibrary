using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1UniverseSystemJumps
    {
        [JsonProperty(PropertyName = "ship_jumps")]
        public int ShipJumps { get; set; }

        [JsonProperty(PropertyName = "system_id")]
        public int SystemId { get; set; }
    }
}