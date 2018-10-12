using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1LocationShip
    {
        [JsonProperty(PropertyName = "ship_item_id")]
        public long ShipItemId { get; set; }

        [JsonProperty(PropertyName = "ship_name")]
        public string ShipName { get; set; }

        [JsonProperty(PropertyName = "ship_type_id")]
        public int ShipTypeId { get; set; }
    }
}