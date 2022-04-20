using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V2CorporationDivisions
    {
        public IList<V2CorporationDivisionsHangar> Hangar { get; set; }
        public IList<V2CorporationDivisionsWallet> Wallet { get; set; }
    }
}