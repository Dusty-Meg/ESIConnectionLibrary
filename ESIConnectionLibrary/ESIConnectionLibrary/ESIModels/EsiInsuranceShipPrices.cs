using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiInsuranceShipPrices
    {
        [JsonProperty(PropertyName = "levels")]
        public IList<EsiInsuranceShipPriceLevels> Levels { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }
    }
}
