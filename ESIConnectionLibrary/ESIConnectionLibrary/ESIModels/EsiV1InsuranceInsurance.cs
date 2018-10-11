using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1InsuranceInsurance
    {
        [JsonProperty(PropertyName = "levels")]
        public IList<EsiV1InsuranceInsuranceLevels> Levels { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }
    }
}
