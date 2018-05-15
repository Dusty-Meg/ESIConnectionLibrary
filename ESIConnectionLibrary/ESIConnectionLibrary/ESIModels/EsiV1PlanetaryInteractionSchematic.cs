using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1PlanetaryInteractionSchematic
    {
        [JsonProperty(PropertyName = "cycle_time")]
        public int CycleTime { get; set; }

        [JsonProperty(PropertyName = "schematic_name")]
        public string SchematicName { get; set; }
    }
}