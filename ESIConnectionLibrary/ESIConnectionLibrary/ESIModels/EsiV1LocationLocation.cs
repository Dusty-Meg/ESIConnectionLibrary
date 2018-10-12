using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1LocationLocation
    {
        [JsonProperty(PropertyName = "solar_system_id")]
        public int SolarSystemId { get; set; }

        [JsonProperty(PropertyName = "station_id")]
        public int? StationId { get; set; }

        [JsonProperty(PropertyName = "structure_id")]
        public long? StructureId { get; set; }
    }
}
