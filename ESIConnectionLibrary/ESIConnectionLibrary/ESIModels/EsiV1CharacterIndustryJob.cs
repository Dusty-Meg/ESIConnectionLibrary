using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1CharacterIndustryJob
    {
        [JsonProperty(PropertyName = "activity_id")]
        public int ActivityId { get; set; }

        [JsonProperty(PropertyName = "blueprint_id")]
        public long BlueprintId { get; set; }

        [JsonProperty(PropertyName = "blueprint_location_id")]
        public long BlueprintLocationId { get; set; }

        [JsonProperty(PropertyName = "blueprint_type_id")]
        public int BlueprintTypeId { get; set; }

        [JsonProperty(PropertyName = "completed_character_id")]
        public int? CompletedCharacterId { get; set; }

        [JsonProperty(PropertyName = "completed_date")]
        public DateTime? CompletedDate { get; set; }

        [JsonProperty(PropertyName = "cost")]
        public double? Cost { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "end_date")]
        public DateTime EndDate { get; set; }

        [JsonProperty(PropertyName = "facility_id")]
        public long FacilityId { get; set; }

        [JsonProperty(PropertyName = "installer_id")]
        public int InstallerId { get; set; }

        [JsonProperty(PropertyName = "job_id")]
        public int JobId { get; set; }

        [JsonProperty(PropertyName = "licensed_runs")]
        public int? LicensedRuns { get; set; }

        [JsonProperty(PropertyName = "output_location_id")]
        public long OutputLocationId { get; set; }

        [JsonProperty(PropertyName = "pause_date")]
        public DateTime? PauseDate { get; set; }

        [JsonProperty(PropertyName = "probability")]
        public float? Probability { get; set; }

        [JsonProperty(PropertyName = "product_type_id")]
        public int? ProductTypeId { get; set; }

        [JsonProperty(PropertyName = "runs")]
        public int Runs { get; set; }

        [JsonProperty(PropertyName = "start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty(PropertyName = "station_id")]
        public long StationId { get; set; }

        [JsonProperty(PropertyName = "status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EsiV1CharacterIndustryJobsStatus Status { get; set; }

        [JsonProperty(PropertyName = "successful_runs")]
        public int? SuccessfulRuns { get; set; }
    }


}
