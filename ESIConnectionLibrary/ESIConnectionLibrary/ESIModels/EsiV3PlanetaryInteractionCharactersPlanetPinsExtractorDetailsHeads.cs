using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3PlanetaryInteractionCharactersPlanetPinsExtractorDetailsHeads
    {
        [JsonProperty(PropertyName = "head_id")]
        public int HeadId { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public float Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public float Longitude { get; set; }
    }
}