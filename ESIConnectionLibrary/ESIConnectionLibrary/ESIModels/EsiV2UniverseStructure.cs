using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2UniverseStructure
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "owner_id")]
        public int OwnerId { get; set; }

        [JsonProperty(PropertyName = "position")]
        public EsiPosition Position { get; set; }

        [JsonProperty(PropertyName = "solar_system_id")]
        public int SolarSystemId { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int? TypeId { get; set; }
    }
}