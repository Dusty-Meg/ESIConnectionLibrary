using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V2CorporationAllianceHistory
    {
        public int? AllianceId { get; set; }
        public bool? IsDeleted { get; set; }
        public int RecordId { get; set; }
        public DateTime StartDate { get; set; }
    }
}