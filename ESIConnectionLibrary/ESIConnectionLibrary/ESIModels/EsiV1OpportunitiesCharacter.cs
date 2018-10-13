using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1OpportunitiesCharacter
    {
        [JsonProperty(PropertyName = "completed_at")]
        public DateTime CompletedAt { get; set; }

        [JsonProperty(PropertyName = "task_id")]
        public int TaskId { get; set; }
    }
}