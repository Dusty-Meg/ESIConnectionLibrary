using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2MailCreateLabel
    {
        [JsonProperty(PropertyName = "color")]
        public EsiMailLabelColor? Color { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}