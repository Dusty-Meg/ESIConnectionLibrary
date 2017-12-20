namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiSkills
    {
        public EsiSkillsSkill[] skills { get; set; }
        public long? total_sp { get; set; }
        public int? unallocated_sp { get; set; }
    }
}
