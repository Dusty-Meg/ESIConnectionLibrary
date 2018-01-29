using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1GetSingleKillmailAttacker
    {
        [JsonProperty(PropertyName = "alliance_id")]
        public int? AllianceId { get; set; }

        [JsonProperty(PropertyName = "character_id")]
        public int? CharacterId { get; set; }

        [JsonProperty(PropertyName = "corporation_id")]
        public int? CorporationId { get; set; }

        [JsonProperty(PropertyName = "damage_done")]
        public int DamageDone { get; set; }

        [JsonProperty(PropertyName = "faction_id")]
        public int? FactionId { get; set; }

        [JsonProperty(PropertyName = "final_blow")]
        public bool FinalBlow { get; set; }

        [JsonProperty(PropertyName = "security_status")]
        public float SecurityStatus { get; set; }

        [JsonProperty(PropertyName = "ship_type_id")]
        public int? ShipTypeId { get; set; }

        [JsonProperty(PropertyName = "weapon_type_id")]
        public int? WeaponTypeId { get; set; }
    }
}