﻿using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1IndustryCharacter
    {
        public int ActivityId { get; set; }
        public long BlueprintId { get; set; }
        public long BlueprintLocationId { get; set; }
        public int BlueprintTypeId { get; set; }
        public int? CompletedCharacterId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public double? Cost { get; set; }
        public int Duration { get; set; }
        public DateTime EndDate { get; set; }
        public long FacilityId { get; set; }
        public int InstallerId { get; set; }
        public int JobId { get; set; }
        public int? LicensedRuns { get; set; }
        public long OutputLocationId { get; set; }
        public DateTime? PauseDate { get; set; }
        public float? Probability { get; set; }
        public int? ProductTypeId { get; set; }
        public int Runs { get; set; }
        public DateTime StartDate { get; set; }
        public long StationId { get; set; }
        public V1IndustryCharacterStatus Status { get; set; }
        public int? SuccessfulRuns { get; set; }
    }
}
