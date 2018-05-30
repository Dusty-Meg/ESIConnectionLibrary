using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1UniverseGroup
    {
        [JsonProperty(PropertyName = "category_id")]
        public int CategoryId { get; set; }

        [JsonProperty(PropertyName = "group_id")]
        public int GroupId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "published")]
        public bool Published { get; set; }

        [JsonProperty(PropertyName = "types")]
        public IList<int> Types { get; set; }
    }
}