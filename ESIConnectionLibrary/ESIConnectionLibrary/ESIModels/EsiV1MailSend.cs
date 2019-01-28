using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1MailSend
    {
        [JsonProperty(PropertyName = "approved_cost")]
        public long? ApprovedCost { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "recipients")]
        public IList<EsiMailRecipients> Recipients { get; set; }

        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }
    }
}