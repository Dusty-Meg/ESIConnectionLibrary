using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class InsuranceShipPrices
    {
        public IList<InsuranceShipPriceLevels> Levels { get; set; }
        public int TypeId { get; set; }
    }
}
