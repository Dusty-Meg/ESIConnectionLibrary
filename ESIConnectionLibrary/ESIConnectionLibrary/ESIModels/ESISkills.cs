using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiSkills
    {
        [JsonProperty(PropertyName = "skills")]
        public EsiSkillsSkill[] Skills { get; set; }

        [JsonProperty(PropertyName = "total_sp")]
        public long? TotalSp { get; set; }

        [JsonProperty(PropertyName = "unallocated_sp")]
        public int? UnallocatedSp { get; set; }
    }
}
