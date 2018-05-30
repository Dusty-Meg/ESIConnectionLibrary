using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1UniverseMoon
    {
        [JsonProperty(PropertyName = "moon_id")]
        public int MoonId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "position")]
        public EsiPosition Position { get; set; }

        [JsonProperty(PropertyName = "system_id")]
        public int SystemId { get; set; }
    }
}