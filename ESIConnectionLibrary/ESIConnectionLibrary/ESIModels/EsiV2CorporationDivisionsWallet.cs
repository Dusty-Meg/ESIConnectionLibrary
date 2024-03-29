﻿using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CorporationDivisionsWallet
    {
        [JsonProperty(PropertyName = "division")]
        public int Division { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}