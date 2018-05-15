using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V3PlanetaryInteractionCharactersPlanetRoutes
    {
        public int ContentTypeId { get; set; }
        public long DestinationPinId { get; set; }
        public float Quantity { get; set; }
        public long RouteId { get; set; }
        public long SourcePinId { get; set; }
        public IList<long> Waypoints { get; set; }
    }
}