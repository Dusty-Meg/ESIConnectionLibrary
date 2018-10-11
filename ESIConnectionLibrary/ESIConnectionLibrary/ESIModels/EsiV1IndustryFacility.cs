using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1IndustryFacility
    {
        [JsonProperty(PropertyName = "facility_id")]
        public long FacilityId { get; set; }

        [JsonProperty(PropertyName = "owner_id")]
        public int OwnerId { get; set; }

        [JsonProperty(PropertyName = "region_id")]
        public int RegionId { get; set; }

        [JsonProperty(PropertyName = "solar_system_id")]
        public int SolarSystemId { get; set; }

        [JsonProperty(PropertyName = "tax")]
        public float? Tax { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }
    }
}