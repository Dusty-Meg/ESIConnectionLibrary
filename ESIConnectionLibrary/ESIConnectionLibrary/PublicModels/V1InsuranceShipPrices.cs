using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1InsuranceShipPrices
    {
        public IList<V1InsuranceShipPriceLevels> Levels { get; set; }
        public int TypeId { get; set; }
    }
}
