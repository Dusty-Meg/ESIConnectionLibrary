using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1IndustryCharacterMining
    {
        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public long Quantity { get; set; }

        [JsonProperty(PropertyName = "solar_system_id")]
        public int SolarSystemId { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }
    }
}