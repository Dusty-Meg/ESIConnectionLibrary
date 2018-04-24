using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestMarketEndpoints : ILatestMarketEndpoints
    {
        private readonly IInternalLatestMarket _internalLatestMarket;

        public LatestMarketEndpoints(string userAgent)
        {
            _internalLatestMarket = new InternalLatestMarket(null, userAgent);
        }

        public V1MarketGroupInformation GetMarketGroupInformation(int marketGroupId)
        {
            return _internalLatestMarket.GetMarketGroupInformation(marketGroupId);
        }

        public async Task<V1MarketGroupInformation> GetMarketGroupInformationAsync(int marketGroupId)
        {
            return await _internalLatestMarket.GetMarketGroupInformationAsync(marketGroupId);
        }
    }
}
