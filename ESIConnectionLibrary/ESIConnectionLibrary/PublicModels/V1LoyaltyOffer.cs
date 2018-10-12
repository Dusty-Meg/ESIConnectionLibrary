using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1LoyaltyOffer
    {
        public int? AkCost { get; set; }
        public long IskCost { get; set; }
        public int LpCost { get; set; }
        public int OfferId { get; set; }
        public int Quantity { get; set; }
        public IList<V1LoyaltyOfferRequiredItem> RequiredItems { get; set; }
        public int TypeId { get; set; }
    }
}