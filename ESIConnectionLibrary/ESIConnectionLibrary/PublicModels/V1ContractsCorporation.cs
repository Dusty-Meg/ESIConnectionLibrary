using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1ContractsCorporation
    {
        public int AcceptorId { get; set; }
        public int AssigneeId { get; set; }
        public V1ContractsCorporationAvailability Availability { get; set; }
        public double? Buyout { get; set; }
        public double? Collateral { get; set; }
        public int ContractId { get; set; }
        public DateTime? DateAccepted { get; set; }
        public DateTime? DateCompleted { get; set; }
        public DateTime DateExpired { get; set; }
        public DateTime DateIssued { get; set; }
        public int? DaysToComplete { get; set; }
        public long? EndLocationId { get; set; }
        public bool ForCorporation { get; set; }
        public int IssuerCorporationId { get; set; }
        public int IssuerId { get; set; }
        public double? Price { get; set; }
        public double? Reward { get; set; }
        public long? StartLocationId { get; set; }
        public V1ContractsCorporationStatus Status { get; set; }
        public string Title { get; set; }
        public V1ContractsCorporationType Type { get; set; }
        public double? Volume { get; set; }
    }
}