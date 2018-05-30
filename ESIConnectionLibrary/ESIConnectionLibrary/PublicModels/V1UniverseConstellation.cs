using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1UniverseConstellation
    {
        public int ConstellationId { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
        public int RegionId { get; set; }
        public IList<int> Systems { get; set; }
    }
}