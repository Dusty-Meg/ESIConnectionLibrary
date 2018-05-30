using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1SovereigntyCampaigns
    {
        public float? AttackersScore { get; set; }
        public int CampaignId { get; set; }
        public int ConstellationId { get; set; }
        public int? DefenderId { get; set; }
        public float? DefenderScore { get; set; }
        public V1SovereigntyCampaignsEventType EventType { get; set; }
        public V1SovereigntyCampaignsParticipants Participants { get; set; }
        public int SolarSystemId { get; set; }
        public DateTime StartTime { get; set; }
        public long StructureId { get; set; }
    }
}