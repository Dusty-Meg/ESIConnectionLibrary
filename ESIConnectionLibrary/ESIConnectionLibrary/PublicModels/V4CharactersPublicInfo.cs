using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V5CharactersPublicInfo
    {
        public string Name { get; set; }
        
        public string Title { get; set; }

        public string Description { get; set; }

        public int CorporationId { get; set; }

        public int? AllianceId { get; set; }

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }

        public int RaceId { get; set; }

        public int BloodlineId { get; set; }

        public float? SecurityStatus { get; set; }

        public int? FactionId { get; set; }
    }
}
