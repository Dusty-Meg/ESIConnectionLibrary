using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1CharactersCorporationHistory
    {
        [JsonProperty(PropertyName = "start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty(PropertyName = "corporation_id")]
        public int CorporationId { get; set; }

        [JsonProperty(PropertyName = "is_deleted")]
        public bool? IsDeleted { get; set; }

        [JsonProperty(PropertyName = "record_id")]
        public int RecordId { get; set; }
    }
}
