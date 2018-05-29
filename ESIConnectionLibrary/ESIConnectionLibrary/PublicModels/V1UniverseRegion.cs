using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1UniverseRegion
    {
        public IList<int> Constellations { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
    }
}