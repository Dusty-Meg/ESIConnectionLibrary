using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1UniverseBloodlines
    {
        [JsonProperty(PropertyName = "bloodline_id")]
        public int BloodlineId { get; set; }

        [JsonProperty(PropertyName = "charisma")]
        public int Charisma { get; set; }

        [JsonProperty(PropertyName = "corporation_id")]
        public int CorporationId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "intelligence")]
        public int Intelligence { get; set; }

        [JsonProperty(PropertyName = "memory")]
        public int Memory { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "perception")]
        public int Perception { get; set; }

        [JsonProperty(PropertyName = "race_id")]
        public int RaceId { get; set; }

        [JsonProperty(PropertyName = "ship_type_id")]
        public int ShipTypeId { get; set; }

        [JsonProperty(PropertyName = "willpower")]
        public int Willpower { get; set; }
    }
}