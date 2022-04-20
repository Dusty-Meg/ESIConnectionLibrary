using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharactersMedalsGraphics
    {
        [JsonProperty(PropertyName = "part")]
        public int Part { get; set; }

        [JsonProperty(PropertyName = "layer")]
        public int Layer { get; set; }

        [JsonProperty(PropertyName = "graphic")]
        public string Graphic { get; set; }

        [JsonProperty(PropertyName = "color")]
        public int? Color { get; set; }
    }
}