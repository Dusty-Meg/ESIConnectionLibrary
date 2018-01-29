﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiGetSingleKillmailItem
    {
        [JsonProperty(PropertyName = "flag")]
        public int Flag { get; set; }

        [JsonProperty(PropertyName = "item_type_id")]
        public int ItemTypeId { get; set; }

        [JsonProperty(PropertyName = "items")]
        public IList<EsiGetSingleKillmailItem> Items { get; set; }

        [JsonProperty(PropertyName = "quantity_destroyed")]
        public int? QuantityDestroyed { get; set; }

        [JsonProperty(PropertyName = "quantity_dropped")]
        public int? QuantityDropped { get; set; }

        [JsonProperty(PropertyName = "singleton")]
        public int Singleton { get; set; }
    }
}