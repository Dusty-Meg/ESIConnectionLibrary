using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Exceptions;
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

        public IList<V2MarketCharactersOrders> GetCharactersMarketOrders(SsoToken token)
        {
            return _internalLatestMarket.GetCharactersMarketOrders(token);
        }

        public async Task<IList<V2MarketCharactersOrders>> GetCharactersMarketOrdersAsync(SsoToken token)
        {
            return await _internalLatestMarket.GetCharactersMarketOrdersAsync(token);
        }

        public PagedModel<V1MarketCharacterHistoricOrders> GetCharactersMarketHistoricOrders(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return _internalLatestMarket.GetCharactersMarketHistoricOrders(token, page);
        }

        public async Task<PagedModel<V1MarketCharacterHistoricOrders>> GetCharactersMarketHistoricOrdersAsync(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return await _internalLatestMarket.GetCharactersMarketHistoricOrdersAsync(token, page);
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
