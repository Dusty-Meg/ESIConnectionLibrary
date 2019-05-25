using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V6WalletCharacterJournal
    {
        public double? Amount { get; set; }
        public double? Balance { get; set; }
        public long? ContextId { get; set; }
        public V6WalletCharacterJournalContextIdType? ContextIdType { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int? FirstPartyId { get; set; }
        public long Id { get; set; }
        public string Reason { get; set; }
        public V6WalletCharacterJournalRefType RefType { get; set; }
        public int? SecondPartyId { get; set; }
        public double? Tax { get; set; }
        public int? TaxReceiverId { get; set; }
    }
}