using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1IndustrySystemCostIndices
    {
        [JsonProperty(PropertyName = "activity")]
        public EsiV1IndustrySystemCostIndicesActivity Activity { get; set; }

        [JsonProperty(PropertyName = "cost_index")]
        public float CostIndex { get; set; }
    }
}