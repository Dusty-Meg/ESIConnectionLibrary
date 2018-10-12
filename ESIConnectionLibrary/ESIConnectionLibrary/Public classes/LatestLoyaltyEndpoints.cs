using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestLoyaltyEndpoints : ILatestLoyaltyEndpoints
    {
        private readonly IInternalLatestLoyalty _internalLatestLoyalty;

        public LatestLoyaltyEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestLoyalty = new InternalLatestLoyalty(null, userAgent, testing);
        }

        public IList<V1LoyaltyPoint> Points(SsoToken token)
        {
            return _internalLatestLoyalty.Points(token);
        }

        public async Task<IList<V1LoyaltyPoint>> PointsAsync(SsoToken token)
        {
            return await _internalLatestLoyalty.PointsAsync(token);
        }

        public IList<V1LoyaltyOffer> Offers(int corporationId)
        {
            return _internalLatestLoyalty.Offers(corporationId);
        }

        public async Task<IList<V1LoyaltyOffer>> OffersAsync(int corporationId)
        {
            return await _internalLatestLoyalty.OffersAsync(corporationId);
        }
    }
}
