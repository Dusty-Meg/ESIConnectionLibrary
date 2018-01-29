using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1CharacterIndustryJob
    {
        public int ActivityId { get; set; }
        public long BlueprintId { get; set; }
        public int BlueprintLocationId { get; set; }
        public int BlueprintTypeId { get; set; }
        public int? CompletedCharacterId { get; set; }
        public int? CompletedDate { get; set; }
        public int? Cost { get; set; }
        public int Duration { get; set; }
        public DateTime EndDate { get; set; }
        public int FacilityId { get; set; }
        public int InstallerId { get; set; }
        public int JobId { get; set; }
        public int? LicensedRuns { get; set; }
        public int OutputLocationId { get; set; }
        public DateTime? PauseDate { get; set; }
        public double? Probability { get; set; }
        public int? ProductTypeId { get; set; }
        public int Runs { get; set; }
        public DateTime StartDate { get; set; }
        public int StationId { get; set; }
        public V1IndustryJobStatus Status { get; set; }
        public int? SuccessfulRuns { get; set; }
    }
}
