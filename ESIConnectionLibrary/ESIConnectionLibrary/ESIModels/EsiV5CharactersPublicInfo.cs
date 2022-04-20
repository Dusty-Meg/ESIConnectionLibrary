using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV5CharactersPublicInfo
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "corporation_id")]
        public int CorporationId { get; set; }

        [JsonProperty(PropertyName = "alliance_id")]
        public int? AllianceId { get; set; }

        [JsonProperty(PropertyName = "birthday")]
        public DateTime Birthday { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public EsiGender Gender { get; set; }

        [JsonProperty(PropertyName = "race_id")]
        public int RaceId { get; set; }

        [JsonProperty(PropertyName = "bloodline_id")]
        public int BloodlineId { get; set; }

        [JsonProperty(PropertyName = "security_status")]
        public float? SecurityStatus { get; set; }

        [JsonProperty(PropertyName = "faction_id")]
        public int? FactionId { get; set; }
    }
}
