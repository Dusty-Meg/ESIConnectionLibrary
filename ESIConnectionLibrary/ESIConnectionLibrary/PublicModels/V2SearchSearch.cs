using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V2SearchSearch
    {
        public IList<int> Agent { get; set; }
        public IList<int> Alliance { get; set; }
        public IList<int> Character { get; set; }
        public IList<int> Constellation { get; set; }
        public IList<int> Corporation { get; set; }
        public IList<int> Faction { get; set; }
        public IList<int> InventoryType { get; set; }
        public IList<int> Region { get; set; }
        public IList<int> SolarSystem { get; set; }
        public IList<int> Station { get; set; }
    }
}