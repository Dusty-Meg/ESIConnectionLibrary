using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1MarketHistory
    {
        [JsonProperty(PropertyName = "average")]
        public double Average { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "highest")]
        public double Highest { get; set; }

        [JsonProperty(PropertyName = "lowest")]
        public double Lowest { get; set; }

        [JsonProperty(PropertyName = "order_count")]
        public long OrderCount { get; set; }

        [JsonProperty(PropertyName = "volume")]
        public long Volume { get; set; }
    }
}