﻿using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharactersNotifications
    {
        [JsonProperty(PropertyName = "notification_id")]
        public long NotificationId { get; set; }

        [JsonProperty(PropertyName = "sender_id")]
        public int SenderId { get; set; }

        [JsonProperty(PropertyName = "sender_type")]
        public EsiSenderType SenderType { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty(PropertyName = "is_read")]
        public bool? IsRead { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "type")]
        public EsiNotificationType Type { get; set; }
    }
}
