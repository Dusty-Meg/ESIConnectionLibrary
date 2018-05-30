using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1UniverseCategory
    {
        [JsonProperty(PropertyName = "category_id")]
        public int CategoryId { get; set; }

        [JsonProperty(PropertyName = "groups")]
        public IList<int> Groups { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "published")]
        public bool Published { get; set; }
    }
}