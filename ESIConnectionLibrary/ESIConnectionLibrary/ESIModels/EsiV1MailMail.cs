using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1MailMail
    {
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "from")]
        public int? From { get; set; }

        [JsonProperty(PropertyName = "labels")]
        public IList<int> Labels { get; set; }

        [JsonProperty(PropertyName = "read")]
        public bool? Read { get; set; }

        [JsonProperty(PropertyName = "recipients")]
        public IList<EsiMailRecipients> Recipients { get; set; }

        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime? Timestamp { get; set; }
    }
}
