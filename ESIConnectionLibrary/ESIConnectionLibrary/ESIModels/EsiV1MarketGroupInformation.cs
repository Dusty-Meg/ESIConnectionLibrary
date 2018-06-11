using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1MarketGroupInformation
    {
        [JsonProperty(PropertyName = "market_group_id")]
        public int MarketGroupId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "types")]
        public IList<int> Types { get; set; }

        [JsonProperty(PropertyName = "parent_group_id")]
        public int? ParentGroupId { get; set; }
    }
}
