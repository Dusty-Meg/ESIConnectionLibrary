using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1CharactersAssetsNames
    {
        [JsonProperty(PropertyName = "item_id")]
        public long ItemId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}