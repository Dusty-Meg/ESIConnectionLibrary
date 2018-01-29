using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiSkillsSkill
    {
        [JsonProperty(PropertyName = "skill_id")]
        public int? SkillId { get; set; }

        [JsonProperty(PropertyName = "skillpoints_in_skill")]
        public long? SkillpointsInSkill { get; set; }

        [JsonProperty(PropertyName = "trained_skill_level")]
        public int? TrainedSkillLevel { get; set; }

        [JsonProperty(PropertyName = "active_skill_level")]
        public int? ActiveSkillLevel { get; set; }
    }
}