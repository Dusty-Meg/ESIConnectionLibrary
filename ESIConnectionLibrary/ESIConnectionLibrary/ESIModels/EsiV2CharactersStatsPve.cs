using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharactersStatsPve
    {
        [JsonProperty(PropertyName = "dungeons_completed_agent")]
        public long? DungeonsCompletedAgent { get; set; }

        [JsonProperty(PropertyName = "dungeons_completed_distribution")]
        public long? DungeonsCompletedDistribution { get; set; }

        [JsonProperty(PropertyName = "missions_succeeded")]
        public long? MissionsSucceeded { get; set; }

        [JsonProperty(PropertyName = "missions_succeeded_epic_arc")]
        public long? MissionsSucceededEpicArc { get; set; }
    }
}