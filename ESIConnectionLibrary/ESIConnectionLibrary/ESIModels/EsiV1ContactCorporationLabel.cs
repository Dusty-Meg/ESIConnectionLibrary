using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1ContactCorporationLabel
    {
        [JsonProperty(PropertyName = "label_id")]
        public long LabelId { get; set; }

        [JsonProperty(PropertyName = "label_name")]
        public string LabelName { get; set; }
    }
}