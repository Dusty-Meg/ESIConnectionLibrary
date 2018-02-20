using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiPosition
    {
        [JsonProperty(PropertyName = "x")]
        public double X { get; set; }

        [JsonProperty(PropertyName = "y")]
        public double Y { get; set; }

        [JsonProperty(PropertyName = "z")]
        public double Z { get; set; }
    }
}