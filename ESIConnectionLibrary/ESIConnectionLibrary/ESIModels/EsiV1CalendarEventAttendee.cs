using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1CalendarEventAttendee
    {
        [JsonProperty(PropertyName = "character_id")]
        public int? CharacterId { get; set; }

        [JsonProperty(PropertyName = "event_response")]
        public EsiV1CalendarEventAttendeeResponses? EventResponse { get; set; }
    }
}