using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV4SkillsSkills
    {
        [JsonProperty(PropertyName = "skills")]
        public IList<EsiV4SkillsSkillsSkill> Skills { get; set; }

        [JsonProperty(PropertyName = "total_sp")]
        public long? TotalSp { get; set; }

        [JsonProperty(PropertyName = "unallocated_sp")]
        public int? UnallocatedSp { get; set; }
    }
}
