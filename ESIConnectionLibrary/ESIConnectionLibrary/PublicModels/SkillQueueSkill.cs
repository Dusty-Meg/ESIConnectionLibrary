using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class SkillQueueSkill
    {
        public DateTime FinishDate { get; set; }
        public int FinishedLevel { get; set; }
        public int QueuePosition { get; set; }
        public int SkillId { get; set; }
        public DateTime StartDate { get; set; }
    }

    public class SkillQueue
    {
        public SkillQueueSkill[] Skills { get; set; }
    }
}
