using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1CorporationDivisions
    {
        public IList<V1CorporationDivisionsHangar> Hangar { get; set; }
        public IList<V1CorporationDivisionsWallet> Wallet { get; set; }
    }
}