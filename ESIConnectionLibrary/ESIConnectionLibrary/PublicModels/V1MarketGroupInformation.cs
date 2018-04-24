using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1MarketGroupInformation
    {
        public int MarketGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<int> Types { get; set; }
        public int? ParentGroupId { get; set; }
    }
}