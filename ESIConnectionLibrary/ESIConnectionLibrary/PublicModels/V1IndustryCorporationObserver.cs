using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1IndustryCorporationObserver
    {
        public int CharacterId { get; set; }
        public DateTime LastUpdated { get; set; }
        public long Quantity { get; set; }
        public int RecordedCorporationId { get; set; }
        public int TypeId { get; set; }
    }
}