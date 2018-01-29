using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV4Skills
    {
        [JsonProperty(PropertyName = "skills")]
        public EsiV4SkillsSkill[] Skills { get; set; }

        [JsonProperty(PropertyName = "total_sp")]
        public long? TotalSp { get; set; }

        [JsonProperty(PropertyName = "unallocated_sp")]
        public int? UnallocatedSp { get; set; }
    }
}
