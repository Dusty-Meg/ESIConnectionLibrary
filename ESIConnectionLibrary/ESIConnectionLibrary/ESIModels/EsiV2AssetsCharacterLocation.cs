﻿using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2AssetsCharacterLocation
    {
        [JsonProperty(PropertyName = "item_id")]
        public long ItemId { get; set; }

        [JsonProperty(PropertyName = "position")]
        public EsiPosition Position { get; set; }
    }
}