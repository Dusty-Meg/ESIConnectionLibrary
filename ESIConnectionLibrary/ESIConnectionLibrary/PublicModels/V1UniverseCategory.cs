using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1UniverseCategory
    {
        public int CategoryId { get; set; }
        public IList<int> Groups { get; set; }
        public string Name { get; set; }
        public bool Published { get; set; }
    }
}