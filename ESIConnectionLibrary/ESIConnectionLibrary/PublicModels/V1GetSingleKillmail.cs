using System;
using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1GetSingleKillmail
    {
        public IList<V1GetSingleKillmailAttacker> Attackers { get; set; }
        public int KillmailId { get; set; }
        public DateTime KillmailTime { get; set; }
        public int? MoonId { get; set; }
        public int SolarSystemId { get; set; }
        public V1GetSingleKillmailVictim Victim { get; set; }
        public int? WarId { get; set; }
    }
}
