using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1ContactCharacterLabel
    {
        [JsonProperty(PropertyName = "label_id")]
        public long LabelId { get; set; }

        [JsonProperty(PropertyName = "label_name")]
        public string LabelName { get; set; }
    }
}