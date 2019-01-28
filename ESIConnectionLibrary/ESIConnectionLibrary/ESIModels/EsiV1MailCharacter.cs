using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1MailCharacter
    {
        [JsonProperty(PropertyName = "from")]
        public int? From { get; set; }

        [JsonProperty(PropertyName = "is_read")]
        public bool? IsRead { get; set; }

        [JsonProperty(PropertyName = "labels")]
        public IList<int> Labels { get; set; }

        [JsonProperty(PropertyName = "mail_id")]
        public int? MailId { get; set; }

        [JsonProperty(PropertyName = "recipients")]
        public IList<EsiMailRecipients> Recipients { get; set; }

        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime? Timestamp { get; set; }
    }
}
