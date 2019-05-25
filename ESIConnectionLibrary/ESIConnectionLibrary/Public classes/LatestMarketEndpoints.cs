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

        public LatestMarketEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestMarket = new InternalLatestMarket(null, userAgent, testing);
        }

        public IList<V2MarketCharactersOrders> CharacterOrders(SsoToken token)
        {
            return _internalLatestMarket.CharacterOrders(token);
        }

        public async Task<IList<V2MarketCharactersOrders>> CharacterOrdersAsync(SsoToken token)
        {
            return await _internalLatestMarket.CharacterOrdersAsync(token);
        }

        public PagedModel<V1MarketCharacterHistoricOrders> CharacterOrdersHistoric(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestMarket.CharacterOrdersHistoric(token, page);
        }

        public async Task<PagedModel<V1MarketCharacterHistoricOrders>> CharacterOrdersHistoricAsync(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestMarket.CharacterOrdersHistoricAsync(token, page);
        }

        public PagedModel<V3MarketCorporationOrders> CorporationOrders(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestMarket.CorporationOrders(token, corporationId, page);
        }

        public async Task<PagedModel<V3MarketCorporationOrders>> CorporationOrdersAsync(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestMarket.CorporationOrdersAsync(token, corporationId, page);
        }

        public PagedModel<V3MarketCorporationOrdersHistoric> CorporationOrdersHistoric(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestMarket.CorporationOrdersHistoric(token, corporationId, page);
        }

        public async Task<PagedModel<V3MarketCorporationOrdersHistoric>> CorporationOrdersHistoricAsync(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestMarket.CorporationOrdersHistoricAsync(token, corporationId, page);
        }

        public V1MarketGroupInformation Group(int marketGroupId)
        {
            return _internalLatestMarket.Group(marketGroupId);
        }

        public async Task<V1MarketGroupInformation> GroupAsync(int marketGroupId)
        {
            return await _internalLatestMarket.GroupAsync(marketGroupId);
        }

        public IList<int> Groups()
        {
            return _internalLatestMarket.Groups();
        }

        public async Task<IList<int>> GroupsAsync()
        {
            return await _internalLatestMarket.GroupsAsync();
        }

        public IList<V1MarketHistory> History(int regionId, int typeId)
        {
            return _internalLatestMarket.History(regionId, typeId);
        }

        public async Task<IList<V1MarketHistory>> HistoryAsync(int regionId, int typeId)
        {
            return await _internalLatestMarket.HistoryAsync(regionId, typeId);
        }

        public PagedModel<V1MarketOrders> Orders(int regionId, OrderType orderType, int page, int? typeId)
        {
            return _internalLatestMarket.Orders(regionId, orderType, page, typeId);
        }

        public async Task<PagedModel<V1MarketOrders>> OrdersAsync(int regionId, OrderType orderType, int page, int? typeId)
        {
            return await _internalLatestMarket.OrdersAsync(regionId, orderType, page, typeId);
        }

        public IList<V1MarketPrice> Prices()
        {
            return _internalLatestMarket.Prices();
        }

        public async Task<IList<V1MarketPrice>> PricesAsync()
        {
            return await _internalLatestMarket.PricesAsync();
        }

        public PagedModel<V1MarketStructure> Structure(SsoToken token, long structureId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestMarket.Structure(token, structureId, page);
        }

        public async Task<PagedModel<V1MarketStructure>> StructureAsync(SsoToken token, long structureId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestMarket.StructureAsync(token, structureId, page);
        }

        public PagedModel<int> Types(int regionId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestMarket.Types(regionId, page);
        }

        public async Task<PagedModel<int>> TypesAsync(int regionId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestMarket.TypesAsync(regionId, page);
        }
    }
}
