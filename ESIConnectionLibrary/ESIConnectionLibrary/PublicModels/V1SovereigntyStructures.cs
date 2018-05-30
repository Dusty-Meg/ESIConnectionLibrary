using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1SovereigntyStructures
    {
        public int AllianceId { get; set; }
        public int SolarSystemId { get; set; }
        public long StructureId { get; set; }
        public int StructureTypeId { get; set; }
        public float? VulnerabilityOccupancyLevel { get; set; }
        public DateTime? VulnerableEndTime { get; set; }
        public DateTime? VulnerableStartTime { get; set; }
    }
}