﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiKillmail
    {
        [JsonProperty(PropertyName = "attackers")]
        public IList<EsiGetSingleKillmailAttacker> Attackers { get; set; }

        [JsonProperty(PropertyName = "killmail_id")]
        public int KillmailId { get; set; }

        [JsonProperty(PropertyName = "killmail_time")]
        public DateTime KillmailTime { get; set; }

        [JsonProperty(PropertyName = "moon_id")]
        public int? MoonId { get; set; }

        [JsonProperty(PropertyName = "solar_system_id")]
        public int SolarSystemId { get; set; }

        [JsonProperty(PropertyName = "victim")]
        public EsiGetSingleKillmailVictim Victim { get; set; }

        [JsonProperty(PropertyName = "war_id")]
        public int? WarId { get; set; }
    }
}
