using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1InsuranceShipPrices
    {
        [JsonProperty(PropertyName = "levels")]
        public IList<EsiV1InsuranceShipPriceLevels> Levels { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }
    }
}
