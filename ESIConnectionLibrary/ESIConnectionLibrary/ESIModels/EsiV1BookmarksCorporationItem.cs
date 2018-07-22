using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1BookmarksCorporationItem
    {
        [JsonProperty(PropertyName = "item_id")]
        public long ItemId { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }
    }
}