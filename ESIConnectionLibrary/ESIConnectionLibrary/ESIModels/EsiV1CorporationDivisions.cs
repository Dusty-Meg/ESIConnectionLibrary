using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1CorporationDivisions
    {
        [JsonProperty(PropertyName = "hangar")]
        public IList<EsiV1CorporationDivisionsHangar> Hangar { get; set; }

        [JsonProperty(PropertyName = "wallet")]
        public IList<EsiV1CorporationDivisionsWallet> Wallet { get; set; }
    }
}