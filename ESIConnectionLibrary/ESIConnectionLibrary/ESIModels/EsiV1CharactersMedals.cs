using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1CharactersMedals
    {
        [JsonProperty(PropertyName = "medal_id")]
        public int MedalId { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "corporation_id")]
        public int CorporationId { get; set; }

        [JsonProperty(PropertyName = "issuer_id")]
        public int IssuerId { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        [JsonProperty(PropertyName = "status")]
        public EsiMedalsStatus Status { get; set; }

        [JsonProperty(PropertyName = "graphics")]
        public IList<EsiV1CharactersMedalsGraphics> Graphics { get; set; }
    }
}
