using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharactersNotificationsContacts
    {
        [JsonProperty(PropertyName = "notification_id")]
        public float NotificationId { get; set; }

        [JsonProperty(PropertyName = "send_date")]
        public DateTime SendDate { get; set; }

        [JsonProperty(PropertyName = "standing_level")]
        public float StandingLevel { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "sender_character_id")]
        public int SenderCharacterId { get; set; }
    }
}
