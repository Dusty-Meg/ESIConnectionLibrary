using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V5CorporationPublicInfo
    {
        public int? AllianceId { get; set; }
        public int CeoId { get; set; }
        public int CreatorId { get; set; }
        public DateTime? DateFounded { get; set; }
        public string Description { get; set; }
        public int? FactionId { get; set; }
        public int? HomeStationId { get; set; }
        public int MemberCount { get; set; }
        public string Name { get; set; }
        public long? Shares { get; set; }
        public float TaxRate { get; set; }
        public string Ticker { get; set; }
        public string Url { get; set; }
        public bool? WarEligible { get; set; }
    }
}