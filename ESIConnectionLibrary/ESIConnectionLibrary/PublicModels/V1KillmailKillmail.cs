using System;
using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1KillmailKillmail
    {
        public IList<V1KillmailKillmailAttacker> Attackers { get; set; }
        public int KillmailId { get; set; }
        public DateTime KillmailTime { get; set; }
        public int? MoonId { get; set; }
        public int SolarSystemId { get; set; }
        public V1KillmailKillmailVictim Victim { get; set; }
        public int? WarId { get; set; }
    }
}
