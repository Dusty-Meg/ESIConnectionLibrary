using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1IndustryCorporationObserver
    {
        [JsonProperty(PropertyName = "character_id")]
        public int CharacterId { get; set; }

        [JsonProperty(PropertyName = "last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public long Quantity { get; set; }

        [JsonProperty(PropertyName = "recorded_corporation_id")]
        public int RecordedCorporationId { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }
    }
}