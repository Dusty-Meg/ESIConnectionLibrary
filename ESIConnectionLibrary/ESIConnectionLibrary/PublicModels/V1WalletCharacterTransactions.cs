using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1WalletCharacterTransactions
    {
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public bool IsBuy { get; set; }
        public bool IsPersonal { get; set; }
        public long JournalRefId { get; set; }
        public long LocationId { get; set; }
        public int Quantity { get; set; }
        public long TransactionId { get; set; }
        public int TypeId { get; set; }
        public double UnitPrice { get; set; }
    }
}