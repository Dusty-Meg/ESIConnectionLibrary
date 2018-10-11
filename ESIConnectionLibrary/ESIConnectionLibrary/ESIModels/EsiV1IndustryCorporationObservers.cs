using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1IndustryCorporationObservers
    {
        [JsonProperty(PropertyName = "last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty(PropertyName = "observer_id")]
        public long ObserverId { get; set; }

        [JsonProperty(PropertyName = "observer_type")]
        public EsiV1IndustryCorporationObserversType ObserverType { get; set; }
    }
}