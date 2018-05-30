using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2UniverseSystemKills
    {
        [JsonProperty(PropertyName = "npc_kills")]
        public int NpcKills { get; set; }

        [JsonProperty(PropertyName = "pod_kills")]
        public int PodKills { get; set; }

        [JsonProperty(PropertyName = "ship_kills")]
        public int ShipKills { get; set; }

        [JsonProperty(PropertyName = "system_id")]
        public int SystemId { get; set; }
    }
}