using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2UniverseFactions
    {
        [JsonProperty(PropertyName = "corporation_id")]
        public int? CorporationId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "faction_id")]
        public int FactionId { get; set; }

        [JsonProperty(PropertyName = "is_unique")]
        public bool IsUnique { get; set; }

        [JsonProperty(PropertyName = "militia_corporation_id")]
        public int? MilitiaCorporationId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "size_factor")]
        public float SizeFactor { get; set; }

        [JsonProperty(PropertyName = "solar_system_id")]
        public int? SolarSystemId { get; set; }

        [JsonProperty(PropertyName = "station_count")]
        public int StationCount { get; set; }

        [JsonProperty(PropertyName = "station_system_count")]
        public int StationSystemCount { get; set; }
    }
}