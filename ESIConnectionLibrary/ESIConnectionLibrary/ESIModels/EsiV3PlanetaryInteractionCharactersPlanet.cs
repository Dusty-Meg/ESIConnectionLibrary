using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3PlanetaryInteractionCharactersPlanet
    {
        [JsonProperty(PropertyName = "links")]
        public IList<EsiV3PlanetaryInteractionCharactersPlanetLinks> Links { get; set; }

        [JsonProperty(PropertyName = "pins")]
        public IList<EsiV3PlanetaryInteractionCharactersPlanetPins> Pins { get; set; }

        [JsonProperty(PropertyName = "routes")]
        public IList<EsiV3PlanetaryInteractionCharactersPlanetRoutes> Routes { get; set; }
    }
}