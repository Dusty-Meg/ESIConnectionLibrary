using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
