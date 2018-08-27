using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestMarketEndpoints
    {
        IList<V2MarketCharactersOrders> CharacterOrders(SsoToken token);
        Task<IList<V2MarketCharactersOrders>> CharacterOrdersAsync(SsoToken token);
        PagedModel<V1MarketCharacterHistoricOrders> CharacterOrdersHistoric(SsoToken token, int page);
        Task<PagedModel<V1MarketCharacterHistoricOrders>> CharacterOrdersHistoricAsync(SsoToken token, int page);
        PagedModel<V3MarketCorporationOrders> CorporationOrders(SsoToken token, int corporationId, int page);
        Task<PagedModel<V3MarketCorporationOrders>> CorporationOrdersAsync(SsoToken token, int corporationId, int page);
        PagedModel<V3MarketCorporationOrdersHistoric> CorporationOrdersHistoric(SsoToken token, int corporationId, int page);
        Task<PagedModel<V3MarketCorporationOrdersHistoric>> CorporationOrdersHistoricAsync(SsoToken token, int corporationId, int page);
        V1MarketGroupInformation Group(int marketGroupId);
        Task<V1MarketGroupInformation> GroupAsync(int marketGroupId);
        IList<int> Groups();
        Task<IList<int>> GroupsAsync();
        IList<V1MarketHistory> History(int regionId, int typeId);
        Task<IList<V1MarketHistory>> HistoryAsync(int regionId, int typeId);
        PagedModel<V1MarketOrders> Orders(int regionId, OrderType orderType, int page, int? typeId);
        Task<PagedModel<V1MarketOrders>> OrdersAsync(int regionId, OrderType orderType, int page, int? typeId);
        IList<V1MarketPrice> Prices();
        Task<IList<V1MarketPrice>> PricesAsync();
        PagedModel<V1MarketStructure> Structure(SsoToken token, long structureId, int page);
        Task<PagedModel<V1MarketStructure>> StructureAsync(SsoToken token, long structureId, int page);
        PagedModel<int> Types(int regionId, int page);
        Task<PagedModel<int>> TypesAsync(int regionId, int page);
    }
}