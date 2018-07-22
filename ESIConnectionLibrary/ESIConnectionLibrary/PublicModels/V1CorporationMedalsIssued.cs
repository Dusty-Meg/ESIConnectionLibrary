using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1CorporationMedalsIssued
    {
        public int CharacterId { get; set; }
        public DateTime IssuedAt { get; set; }
        public int IssuerId { get; set; }
        public int MedalId { get; set; }
        public string Reason { get; set; }
        public V1CorporationMedalsIssuedStatus Status { get; set; }
    }
}