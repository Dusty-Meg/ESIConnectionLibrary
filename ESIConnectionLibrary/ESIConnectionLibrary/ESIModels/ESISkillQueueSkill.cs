using System;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiSkillQueueSkill
    {
        public DateTime finish_date { get; set; }
        public int finished_level { get; set; }
        public int? level_end_sp { get; set; }
        public int? level_start_sp { get; set; }
        public int queue_position { get; set; }
        public int skill_id { get; set; }
        public DateTime? start_date { get; set; }
        public string training_start_sp { get; set; }
    }
}