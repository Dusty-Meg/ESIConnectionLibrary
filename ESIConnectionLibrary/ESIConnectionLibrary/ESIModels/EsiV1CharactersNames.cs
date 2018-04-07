using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1CharactersNames
    {
        [JsonProperty(PropertyName = "character_id")]
        public long CharacterId { get; set; }

        [JsonProperty(PropertyName = "character_name")]
        public string CharacterName { get; set; }
    }
}
