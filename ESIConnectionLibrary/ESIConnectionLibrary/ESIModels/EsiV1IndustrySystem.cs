using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1IndustrySystem
    {
        [JsonProperty(PropertyName = "cost_indices")]
        public IList<EsiV1IndustrySystemCostIndices> CostIndices { get; set; }

        [JsonProperty(PropertyName = "solar_system_id")]
        public int SolarSystemId { get; set; }
    }
}