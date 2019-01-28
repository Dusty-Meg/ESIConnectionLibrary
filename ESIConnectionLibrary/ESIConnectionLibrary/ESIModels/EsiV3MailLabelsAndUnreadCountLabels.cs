using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3MailLabelsAndUnreadCountLabels
    {
        [JsonProperty(PropertyName = "color")]
        public EsiMailLabelColor? Color { get; set; }

        [JsonProperty(PropertyName = "label_id")]
        public int? LabelId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "unread_count")]
        public int? UnreadCount { get; set; }
    }
}