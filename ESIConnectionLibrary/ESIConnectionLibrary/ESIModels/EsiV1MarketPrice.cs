using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1MarketPrice
    {
        [JsonProperty(PropertyName = "adjusted_price")]
        public double? AdjustedPrice { get; set; }

        [JsonProperty(PropertyName = "average_price")]
        public double? AveragePrice { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }
    }
}