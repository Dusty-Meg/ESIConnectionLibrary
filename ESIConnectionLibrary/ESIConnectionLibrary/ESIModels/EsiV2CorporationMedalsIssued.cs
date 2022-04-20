using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CorporationMedalsIssued
    {
        [JsonProperty(PropertyName = "character_id")]
        public int CharacterId { get; set; }

        [JsonProperty(PropertyName = "issued_at")]
        public DateTime IssuedAt { get; set; }

        [JsonProperty(PropertyName = "issuer_id")]
        public int IssuerId { get; set; }

        [JsonProperty(PropertyName = "medal_id")]
        public int MedalId { get; set; }

        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        [JsonProperty(PropertyName = "status")]
        public EsiV2CorporationMedalsIssuedStatus Status { get; set; }
    }
}