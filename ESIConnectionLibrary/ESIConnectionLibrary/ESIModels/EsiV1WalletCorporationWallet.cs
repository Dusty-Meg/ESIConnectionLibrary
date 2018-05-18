using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1WalletCorporationWallet
    {
        [JsonProperty(PropertyName = "balance")]
        public double Balance { get; set; }

        [JsonProperty(PropertyName = "division")]
        public int Division { get; set; }
    }
}
