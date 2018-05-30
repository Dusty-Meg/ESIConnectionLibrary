using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1UniverseRaces
    {
        [JsonProperty(PropertyName = "alliance_id")]
        public int AllianceId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "race_id")]
        public int RaceId { get; set; }
    }
}