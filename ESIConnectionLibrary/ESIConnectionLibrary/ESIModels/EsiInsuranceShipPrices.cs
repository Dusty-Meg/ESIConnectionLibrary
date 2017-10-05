using System.Collections.Generic;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiInsuranceShipPrices
    {
        public IList<EsiInsuranceShipPriceLevels> levels { get; set; }
        public int type_id { get; set; }
    }
}
