using System;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiSkillQueueSkill
    {
        public DateTime finish_date { get; set; }
        public int finished_level { get; set; }
        public int queue_position { get; set; }
        public int skill_id { get; set; }
        public DateTime start_date { get; set; }
    }
}