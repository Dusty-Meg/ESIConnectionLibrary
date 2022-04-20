using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3CorporationAllianceHistory
    {
        [JsonProperty(PropertyName = "alliance_id")]
        public int? AllianceId { get; set; }

        [JsonProperty(PropertyName = "is_deleted")]
        public bool? IsDeleted { get; set; }

        [JsonProperty(PropertyName = "record_id")]
        public int RecordId { get; set; }

        [JsonProperty(PropertyName = "start_date")]
        public DateTime StartDate { get; set; }
    }
}