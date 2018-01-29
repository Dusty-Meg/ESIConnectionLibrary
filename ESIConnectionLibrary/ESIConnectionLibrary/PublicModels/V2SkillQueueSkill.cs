using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V2SkillQueueSkill
    {
        public DateTime FinishDate { get; set; }
        public int FinishedLevel { get; set; }
        public int? LevelEndSp { get; set; }
        public int? LevelStartSp { get; set; }
        public int QueuePosition { get; set; }
        public int SkillId { get; set; }
        public DateTime? StartDate { get; set; }
        public string TrainingStartSp { get; set; }
    }
}
