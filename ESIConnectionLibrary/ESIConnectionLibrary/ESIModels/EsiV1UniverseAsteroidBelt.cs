using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1UniverseAsteroidBelt
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "position")]
        public EsiPosition Position { get; set; }

        [JsonProperty(PropertyName = "system_id")]
        public int SystemId { get; set; }
    }
}