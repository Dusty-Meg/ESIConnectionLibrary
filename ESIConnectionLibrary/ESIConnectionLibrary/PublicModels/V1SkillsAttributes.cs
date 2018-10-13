using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1SkillsAttributes
    {
        public string AccruedRemapCooldownDate { get; set; }
        public int? BonusRemaps { get; set; }
        public int Charisma { get; set; }
        public int Intelligence { get; set; }
        public DateTime? LastRemapDate { get; set; }
        public int Memory { get; set; }
        public int Perception { get; set; }
        public int Willpower { get; set; }
    }
}
