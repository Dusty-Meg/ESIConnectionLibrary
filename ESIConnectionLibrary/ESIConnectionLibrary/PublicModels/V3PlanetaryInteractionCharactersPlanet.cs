using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V3PlanetaryInteractionCharactersPlanet
    {
        public IList<V3PlanetaryInteractionCharactersPlanetLinks> Links { get; set; }
        public IList<V3PlanetaryInteractionCharactersPlanetPins> Pins { get; set; }
        public IList<V3PlanetaryInteractionCharactersPlanetRoutes> Routes { get; set; }
    }
}