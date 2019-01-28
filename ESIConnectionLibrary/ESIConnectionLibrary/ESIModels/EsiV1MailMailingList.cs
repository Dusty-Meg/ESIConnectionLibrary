using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1MailMailingList
    {
        [JsonProperty(PropertyName = "mailing_list_id")]
        public int MailingListId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}