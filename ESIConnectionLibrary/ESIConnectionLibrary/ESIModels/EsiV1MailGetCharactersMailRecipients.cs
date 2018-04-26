using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1MailGetCharactersMailRecipients
    {
        [JsonProperty(PropertyName = "recipient_id")]
        public int RecipientId { get; set; }

        [JsonProperty(PropertyName = "recipient_type")]
        public EsiMailRecipientType MailRecipientType { get; set; }
    }
}