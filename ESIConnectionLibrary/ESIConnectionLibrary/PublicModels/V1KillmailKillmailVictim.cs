using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1KillmailKillmailVictim
    {
        public int? AllianceId { get; set; }
        public int? CharacterId { get; set; }
        public int? CorporationId { get; set; }
        public int DamageTaken { get; set; }
        public int? FactionId { get; set; }
        public IList<V1KillmailKillmailVictimItem> Items { get; set; }
        public V1KillmailKillmailVictimPosition Position { get; set; }
        public int ShipTypeId { get; set; }
    }
}