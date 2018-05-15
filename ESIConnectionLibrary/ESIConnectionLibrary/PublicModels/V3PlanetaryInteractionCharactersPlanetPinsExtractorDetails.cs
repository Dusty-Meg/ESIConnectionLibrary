using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V3PlanetaryInteractionCharactersPlanetPinsExtractorDetails
    {
        public int? CycleTime { get; set; }
        public float? HeadRadius { get; set; }
        public IList<V3PlanetaryInteractionCharactersPlanetPinsExtractorDetailsHeads> Heads { get; set; }
        public int? ProductTypeId { get; set; }
        public int? QtyPerCycle { get; set; }
    }
}