using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1CharacterTitles
    {
        [JsonProperty(PropertyName = "title_id")]
        public int? TitleId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
