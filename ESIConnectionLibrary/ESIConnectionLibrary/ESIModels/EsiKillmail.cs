using System;
using System.Collections.Generic;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiKillmail
    {
        public IList<EsiGetSingleKillmailAttacker> attackers { get; set; }
        public int killmail_id { get; set; }
        public DateTime killmail_time { get; set; }
        public int? moon_id { get; set; }
        public int solar_system_id { get; set; }
        public EsiGetSingleKillmailVictim victim { get; set; }
        public int? war_id { get; set; }
    }

    internal class EsiGetSingleKillmailVictim
    {
        public int? alliance_id { get; set; }
        public int? character_id { get; set; }
        public int? corporation_id { get; set; }
        public int damage_taken { get; set; }
        public int? faction_id { get; set; }
        public IList<EsiGetSingleKillmailItem> items { get; set; }
        public EsiGetSingleKillmailPosition position { get; set; }
        public int ship_type_id { get; set; }
    }

    internal class EsiGetSingleKillmailPosition
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    internal class EsiGetSingleKillmailItem
    {
        public int flag { get; set; }
        public int item_type_id { get; set; }
        public IList<EsiGetSingleKillmailItem> items { get; set; }
        public int? quantity_destroyed { get; set; }
        public int? quantity_dropped { get; set; }
        public int singleton { get; set; }
    }

    internal class EsiGetSingleKillmailAttacker
    {
        public int? alliance_id { get; set; }
        public int? character_id { get; set; }
        public int? corporation_id { get; set; }
        public int damage_done { get; set; }
        public int? faction_id { get; set; }
        public bool final_blow { get; set; }
        public float security_status { get; set; }
        public int? ship_type_id { get; set; }
        public int? weapon_type_id { get; set; }
    }
}
