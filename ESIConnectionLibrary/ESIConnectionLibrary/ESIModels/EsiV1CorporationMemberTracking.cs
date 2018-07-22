using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1CorporationMemberTracking
    {
        [JsonProperty(PropertyName = "base_id")]
        public int? BaseId { get; set; }

        [JsonProperty(PropertyName = "character_id")]
        public int CharacterId { get; set; }

        [JsonProperty(PropertyName = "location_id")]
        public long? LocationId { get; set; }

        [JsonProperty(PropertyName = "logoff_date")]
        public DateTime? LogoffDate { get; set; }

        [JsonProperty(PropertyName = "logon_date")]
        public DateTime? LogonDate { get; set; }

        [JsonProperty(PropertyName = "ship_type_id")]
        public int? ShipTypeId { get; set; }

        [JsonProperty(PropertyName = "start_date")]
        public DateTime? StartDate { get; set; }
    }
}