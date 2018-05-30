using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1UniverseGroup
    {
        public int CategoryId { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public bool Published { get; set; }
        public IList<int> Types { get; set; }
    }
}