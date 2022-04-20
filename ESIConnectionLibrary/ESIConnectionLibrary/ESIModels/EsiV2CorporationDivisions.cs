using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CorporationDivisions
    {
        [JsonProperty(PropertyName = "hangar")]
        public IList<EsiV2CorporationDivisionsHangar> Hangar { get; set; }

        [JsonProperty(PropertyName = "wallet")]
        public IList<EsiV2CorporationDivisionsWallet> Wallet { get; set; }
    }
}