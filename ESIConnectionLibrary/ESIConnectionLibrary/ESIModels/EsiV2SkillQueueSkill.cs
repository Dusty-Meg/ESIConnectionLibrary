using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2SkillQueueSkill
    {
        [JsonProperty(PropertyName = "finish_date")]
        public DateTime FinishDate { get; set; }

        [JsonProperty(PropertyName = "finished_level")]
        public int FinishedLevel { get; set; }

        [JsonProperty(PropertyName = "level_end_sp")]
        public int? LevelEndSp { get; set; }

        [JsonProperty(PropertyName = "level_start_sp")]
        public int? LevelStartSp { get; set; }

        [JsonProperty(PropertyName = "queue_position")]
        public int QueuePosition { get; set; }

        [JsonProperty(PropertyName = "skill_id")]
        public int SkillId { get; set; }

        [JsonProperty(PropertyName = "start_date")]
        public DateTime? StartDate { get; set; }

        [JsonProperty(PropertyName = "training_start_sp")]
        public string TrainingStartSp { get; set; }
    }
}