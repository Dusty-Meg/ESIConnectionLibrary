using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3MailLabelsAndUnreadCount
    {
        [JsonProperty(PropertyName = "labels")]
        public IList<EsiV3MailLabelsAndUnreadCountLabels> Labels { get; set; }

        [JsonProperty(PropertyName = "total_unread_count")]
        public int? TotalUnreadCount { get; set; }
    }
}