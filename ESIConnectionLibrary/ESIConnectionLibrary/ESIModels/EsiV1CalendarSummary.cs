using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1CalendarSummary
    {
        [JsonProperty(PropertyName = "event_date")]
        public DateTime? EventDate { get; set; }

        [JsonProperty(PropertyName = "event_id")]
        public int? EventId { get; set; }

        [JsonProperty(PropertyName = "event_response")]
        public EsiV1CalendarSummaryEventResponses? EventResponse { get; set; }

        [JsonProperty(PropertyName = "importance")]
        public int? Importance { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}
