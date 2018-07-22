using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3CalendarEvent
    {
        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "event_id")]
        public int EventId { get; set; }

        [JsonProperty(PropertyName = "importance")]
        public int Importance { get; set; }

        [JsonProperty(PropertyName = "owner_id")]
        public int OwnerId { get; set; }

        [JsonProperty(PropertyName = "owner_name")]
        public string OwnerName { get; set; }

        [JsonProperty(PropertyName = "owner_type")]
        public EsiV3CalendarEventOwnerType OwnerType { get; set; }

        [JsonProperty(PropertyName = "response")]
        public string Response { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}