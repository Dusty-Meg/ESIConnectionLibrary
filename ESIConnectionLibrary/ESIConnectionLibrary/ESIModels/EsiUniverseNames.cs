using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiUniverseNames
    {
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
