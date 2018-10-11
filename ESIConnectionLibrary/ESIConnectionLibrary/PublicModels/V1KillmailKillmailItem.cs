using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1KillmailKillmailItem
    {
        public int Flag { get; set; }
        public int ItemTypeId { get; set; }
        public IList<V1KillmailKillmailItem> Items { get; set; }
        public int? QuantityDestroyed { get; set; }
        public int? QuantityDropped { get; set; }
        public int Singleton { get; set; }
        public InvFlags ItemFlag => (InvFlags)Flag;
    }
}