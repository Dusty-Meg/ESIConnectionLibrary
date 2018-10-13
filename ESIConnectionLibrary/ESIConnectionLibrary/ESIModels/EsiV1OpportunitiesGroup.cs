using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1OpportunitiesGroup
    {
        [JsonProperty(PropertyName = "connected_groups")]
        public IList<int> ConnectedGroups { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "group_id")]
        public int GroupId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "notification")]
        public string Notification { get; set; }

        [JsonProperty(PropertyName = "required_tasks")]
        public IList<int> RequiredTasks { get; set; }
    }
}