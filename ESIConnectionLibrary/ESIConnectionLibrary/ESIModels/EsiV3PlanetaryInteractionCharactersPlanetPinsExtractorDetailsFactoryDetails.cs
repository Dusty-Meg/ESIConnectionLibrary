using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3PlanetaryInteractionCharactersPlanetPinsExtractorDetailsFactoryDetails
    {
        [JsonProperty(PropertyName = "schematic_id")]
        public int SchematicId { get; set; }
    }
}