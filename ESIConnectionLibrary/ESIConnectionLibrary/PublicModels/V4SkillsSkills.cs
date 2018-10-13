using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V4SkillsSkills
    {
        public IList<V4SkillsSkillsSkill> Skills { get; set; }
        public long? TotalSp { get; set; }
        public int? UnallocatedSp { get; set; }
    }
}
