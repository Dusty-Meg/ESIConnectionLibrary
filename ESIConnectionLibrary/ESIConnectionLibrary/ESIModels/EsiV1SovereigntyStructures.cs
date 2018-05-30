using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1SovereigntyStructures
    {
        [JsonProperty(PropertyName = "alliance_id")]
        public int AllianceId { get; set; }

        [JsonProperty(PropertyName = "solar_system_id")]
        public int SolarSystemId { get; set; }

        [JsonProperty(PropertyName = "structure_id")]
        public long StructureId { get; set; }

        [JsonProperty(PropertyName = "structure_type_id")]
        public int StructureTypeId { get; set; }

        [JsonProperty(PropertyName = "vulnerability_occupancy_level")]
        public float? VulnerabilityOccupancyLevel { get; set; }

        [JsonProperty(PropertyName = "vulnerable_end_time")]
        public DateTime? VulnerableEndTime { get; set; }

        [JsonProperty(PropertyName = "vulnerable_start_time")]
        public DateTime? VulnerableStartTime { get; set; }
    }
}