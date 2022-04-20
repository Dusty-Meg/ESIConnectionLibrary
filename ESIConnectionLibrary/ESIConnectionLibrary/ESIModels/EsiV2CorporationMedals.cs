using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CorporationMedals
    {
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "creator_id")]
        public int CreatorId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "medal_id")]
        public int MedalId { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}