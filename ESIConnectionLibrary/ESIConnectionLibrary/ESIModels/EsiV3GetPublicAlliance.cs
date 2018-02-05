using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3GetPublicAlliance
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "creator_id")]
        public int CreatorId { get; set; }

        [JsonProperty(PropertyName = "creator_corporation_id")]
        public int CreatorCorporationId { get; set; }

        [JsonProperty(PropertyName = "ticket")]
        public string Ticket { get; set; }

        [JsonProperty(PropertyName = "executor_corporation_id")]
        public int? ExecutorCorporationId { get; set; }

        [JsonProperty(PropertyName = "date_founded")]
        public DateTime DateFounded { get; set; }

        [JsonProperty(PropertyName = "faction_id")]
        public int? FactionId { get; set; }
    }
}
