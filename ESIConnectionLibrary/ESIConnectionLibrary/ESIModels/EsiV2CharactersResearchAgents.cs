using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharactersResearchAgents
    {
        [JsonProperty(PropertyName = "agent_id")]
        public int AgentId { get; set; }

        [JsonProperty(PropertyName = "skill_type_id")]
        public int SkillTypeId { get; set; }

        [JsonProperty(PropertyName = "started_at")]
        public DateTime StartedAt { get; set; }

        [JsonProperty(PropertyName = "points_per_day")]
        public float PointsPerDay { get; set; }

        [JsonProperty(PropertyName = "remainder_points")]
        public float RemainderPoints { get; set; }
    }
}
