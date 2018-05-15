using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3PlanetaryInteractionCharactersPlanetRoutes
    {
        [JsonProperty(PropertyName = "content_type_id")]
        public int ContentTypeId { get; set; }

        [JsonProperty(PropertyName = "destination_pin_id")]
        public long DestinationPinId { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public float Quantity { get; set; }

        [JsonProperty(PropertyName = "route_id")]
        public long RouteId { get; set; }

        [JsonProperty(PropertyName = "source_pin_id")]
        public long SourcePinId { get; set; }

        [JsonProperty(PropertyName = "waypoints")]
        public IList<long> Waypoints { get; set; }
    }
}