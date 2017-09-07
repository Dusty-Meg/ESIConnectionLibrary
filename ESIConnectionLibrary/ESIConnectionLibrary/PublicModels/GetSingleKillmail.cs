using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESIConnectionLibrary.PublicModels
{
    public class GetSingleKillmail
    {
        public IList<GetSingleKillmailAttacker> Attackers { get; set; }
        public int KillmailId { get; set; }
        public DateTime KillmailTime { get; set; }
        public int? MoonId { get; set; }
        public int SolarSystemId { get; set; }
        public GetSingleKillmailVictim Victim { get; set; }
        public int? WarId { get; set; }
    }

    public class GetSingleKillmailVictim
    {
        public int? AllianceId { get; set; }
        public int? CharacterId { get; set; }
        public int? CorporationId { get; set; }
        public int DamageTaken { get; set; }
        public int? FactionId { get; set; }
        public IList<GetSingleKillmailItem> Items { get; set; }
        public GetSingleKillmailPosition Position { get; set; }
        public int ShipTypeId { get; set; }
    }

    public class GetSingleKillmailPosition
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }

    public class GetSingleKillmailItem
    {
        public int Flag { get; set; }
        public int ItemTypeId { get; set; }
        public IList<GetSingleKillmailItem> Items { get; set; }
        public int? QuantityDestroyed { get; set; }
        public int? QuantityDropped { get; set; }
        public int Singleton { get; set; }
    }

    public class GetSingleKillmailAttacker
    {
        public int? AllianceId { get; set; }
        public int? CharacterId { get; set; }
        public int? CorporationId { get; set; }
        public int DamageDone { get; set; }
        public int? FactionId { get; set; }
        public bool FinalBlow { get; set; }
        public float SecurityStatus { get; set; }
        public int? ShipTypeId { get; set; }
        public int? WeaponTypeId { get; set; }
    }
}
