using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestLoyalty
    {
        IList<V1LoyaltyOffer> Offers(int corporationId);
        Task<IList<V1LoyaltyOffer>> OffersAsync(int corporationId);
        IList<V1LoyaltyPoint> Points(SsoToken token);
        Task<IList<V1LoyaltyPoint>> PointsAsync(SsoToken token);
    }
}