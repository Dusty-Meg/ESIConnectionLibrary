using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1SovereigntyCampaigns
    {
        [JsonProperty(PropertyName = "attackers_score")]
        public float? AttackersScore { get; set; }

        [JsonProperty(PropertyName = "campaign_id")]
        public int CampaignId { get; set; }

        [JsonProperty(PropertyName = "constellation_id")]
        public int ConstellationId { get; set; }

        [JsonProperty(PropertyName = "defender_id")]
        public int? DefenderId { get; set; }

        [JsonProperty(PropertyName = "defender_score")]
        public float? DefenderScore { get; set; }

        [JsonProperty(PropertyName = "event_type")]
        public EsiV1SovereigntyCampaignsEventType EventType { get; set; }

        [JsonProperty(PropertyName = "participants")]
        public EsiV1SovereigntyCampaignsParticipants Participants { get; set; }

        [JsonProperty(PropertyName = "solar_system_id")]
        public int SolarSystemId { get; set; }

        [JsonProperty(PropertyName = "start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty(PropertyName = "structure_id")]
        public long StructureId { get; set; }
    }
}
