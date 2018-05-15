using System;
using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V3PlanetaryInteractionCharactersPlanetPins
    {
        public IList<V3PlanetaryInteractionCharactersPlanetPinsContent> Contents { get; set; }
        public DateTime ExpiryTime { get; set; }
        public IList<V3PlanetaryInteractionCharactersPlanetPinsExtractorDetails> ExtractorDetails { get; set; }
        public IList<V3PlanetaryInteractionCharactersPlanetPinsExtractorDetailsFactoryDetails> FactoryDetails { get; set; }
        public DateTime? InstallTime { get; set; }
        public DateTime? LastCycleStart { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public long PinId { get; set; }
        public int? SchematicId { get; set; }
        public int TypeId { get; set; }
    }
}