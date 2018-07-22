using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1CorporationMemberTracking
    {
        public int? BaseId { get; set; }
        public int CharacterId { get; set; }
        public long? LocationId { get; set; }
        public DateTime? LogoffDate { get; set; }
        public DateTime? LogonDate { get; set; }
        public int? ShipTypeId { get; set; }
        public DateTime? StartDate { get; set; }
    }
}