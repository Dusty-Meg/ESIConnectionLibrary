using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV5CorporationPublicInfo
    {
        [JsonProperty(PropertyName = "alliance_id")]
        public int? AllianceId { get; set; }

        [JsonProperty(PropertyName = "ceo_id")]
        public int CeoId { get; set; }

        [JsonProperty(PropertyName = "creator_id")]
        public int CreatorId { get; set; }

        [JsonProperty(PropertyName = "date_founded")]
        public DateTime? DateFounded { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "faction_id")]
        public int? FactionId { get; set; }

        [JsonProperty(PropertyName = "home_station_id")]
        public int? HomeStationId { get; set; }

        [JsonProperty(PropertyName = "member_count")]
        public int MemberCount { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "shares")]
        public long? Shares { get; set; }

        [JsonProperty(PropertyName = "tax_rate")]
        public float TaxRate { get; set; }

        [JsonProperty(PropertyName = "ticker")]
        public string Ticker { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "war_eligible")]
        public bool? WarEligible { get; set; }
    }
}
