using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1InsuranceInsuranceLevels
    {
        [JsonProperty(PropertyName = "cost")]
        public float Cost { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "payout")]
        public float Payout { get; set; }
    }
}