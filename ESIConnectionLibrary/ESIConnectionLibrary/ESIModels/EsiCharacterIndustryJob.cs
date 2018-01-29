using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiCharacterIndustryJob
    {
        [JsonProperty(PropertyName = "activity_id")]
        public int ActivityId { get; set; }

        [JsonProperty(PropertyName = "blueprint_id")]
        public long BlueprintId { get; set; }

        [JsonProperty(PropertyName = "blueprint_location_id")]
        public int BlueprintLocationId { get; set; }

        [JsonProperty(PropertyName = "blueprint_type_id")]
        public int BlueprintTypeId { get; set; }

        [JsonProperty(PropertyName = "completed_character_id")]
        public int? CompletedCharacterId { get; set; }

        [JsonProperty(PropertyName = "completed_date")]
        public int? CompletedDate { get; set; }

        [JsonProperty(PropertyName = "cost")]
        public int? Cost { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "end_date")]
        public DateTime EndDate { get; set; }

        [JsonProperty(PropertyName = "facility_id")]
        public int FacilityId { get; set; }

        [JsonProperty(PropertyName = "installer_id")]
        public int InstallerId { get; set; }

        [JsonProperty(PropertyName = "job_id")]
        public int JobId { get; set; }

        [JsonProperty(PropertyName = "licensed_runs")]
        public int? LicensedRuns { get; set; }

        [JsonProperty(PropertyName = "output_location_id")]
        public int OutputLocationId { get; set; }

        [JsonProperty(PropertyName = "pause_date")]
        public DateTime? PauseDate { get; set; }

        [JsonProperty(PropertyName = "probability")]
        public double? Probability { get; set; }

        [JsonProperty(PropertyName = "product_type_id")]
        public int? ProductTypeId { get; set; }

        [JsonProperty(PropertyName = "runs")]
        public int Runs { get; set; }

        [JsonProperty(PropertyName = "start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty(PropertyName = "station_id")]
        public int StationId { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "successful_runs")]
        public int? SuccessfulRuns { get; set; }
    }


}
