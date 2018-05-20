using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1UiSendMail
    {
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "recipients")]
        public IList<int> Recipients { get; set; }

        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

        [JsonProperty(PropertyName = "to_corp_or_alliance_id")]
        public int? ToCorpOrAllianceId { get; set; }

        [JsonProperty(PropertyName = "to_mailing_list_id")]
        public int? ToMailingListId { get; set; }
    }
}
