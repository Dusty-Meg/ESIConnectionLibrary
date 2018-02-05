using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V3GetPublicAlliance
    {
        public string Name { get; set; }
        public int CreatorId { get; set; }
        public int CreatorCorporationId { get; set; }
        public string Ticket { get; set; }
        public int? ExecutorCorporationId { get; set; }
        public DateTime DateFounded { get; set; }
        public int? FactionId { get; set; }
    }
}