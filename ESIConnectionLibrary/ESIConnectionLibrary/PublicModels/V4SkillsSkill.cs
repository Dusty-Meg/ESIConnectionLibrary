using ESIConnectionLibrary.ESIModels;

namespace ESIConnectionLibrary.PublicModels
{
    public class V4SkillsSkill
    {
        public long? SkillId { get; set; }
        public int? SkillpointsInSkill { get; set; }
        public int? TrainedSkillLevel { get; set; }
        public int? ActiveSkillLevel { get; set; }
    }
}