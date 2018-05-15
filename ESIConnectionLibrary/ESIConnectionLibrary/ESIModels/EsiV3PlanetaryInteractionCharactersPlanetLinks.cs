using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3PlanetaryInteractionCharactersPlanetLinks
    {
        [JsonProperty(PropertyName = "destination_pin_id")]
        public long DestinationPinId { get; set; }

        [JsonProperty(PropertyName = "link_level")]
        public int LinkLevel { get; set; }

        [JsonProperty(PropertyName = "source_pin_id")]
        public long SourcePinId { get; set; }
    }
}