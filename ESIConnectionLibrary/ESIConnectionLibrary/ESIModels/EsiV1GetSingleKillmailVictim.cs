using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1GetSingleKillmailVictim
    {
        [JsonProperty(PropertyName = "alliance_id")]
        public int? AllianceId { get; set; }

        [JsonProperty(PropertyName = "character_id")]
        public int? CharacterId { get; set; }

        [JsonProperty(PropertyName = "corporation_id")]
        public int? CorporationId { get; set; }

        [JsonProperty(PropertyName = "damage_taken")]
        public int DamageTaken { get; set; }

        [JsonProperty(PropertyName = "faction_id")]
        public int? FactionId { get; set; }

        [JsonProperty(PropertyName = "items")]
        public IList<EsiV1GetSingleKillmailItem> Items { get; set; }

        [JsonProperty(PropertyName = "position")]
        public EsiV1GetSingleKillmailPosition Position { get; set; }

        [JsonProperty(PropertyName = "ship_type_id")]
        public int ShipTypeId { get; set; }
    }
}