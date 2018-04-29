using System.Collections.Generic;
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

        public IList<V2MarketCharactersOrders> GetCharactersMarketOrders(SsoToken token, int characterId)
        {
            return _internalLatestMarket.GetCharactersMarketOrders(token, characterId);
        }

        public async Task<IList<V2MarketCharactersOrders>> GetCharactersMarketOrdersAsync(SsoToken token, int characterId)
        {
            return await _internalLatestMarket.GetCharactersMarketOrdersAsync(token, characterId);
        }

        public PagedModel<V1MarketCharacterHistoricOrders> GetCharactersMarketHistoricOrders(SsoToken token, int characterId, int page)
        {
            return _internalLatestMarket.GetCharactersMarketHistoricOrders(token, characterId, page);
        }

        public async Task<PagedModel<V1MarketCharacterHistoricOrders>> GetCharactersMarketHistoricOrdersAsync(SsoToken token, int characterId, int page)
        {
            return await _internalLatestMarket.GetCharactersMarketHistoricOrdersAsync(token, characterId, page);
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
