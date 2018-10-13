using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1OpportunitiesTask
    {
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "notification")]
        public string Notification { get; set; }

        [JsonProperty(PropertyName = "task_id")]
        public int TaskId { get; set; }
    }
}