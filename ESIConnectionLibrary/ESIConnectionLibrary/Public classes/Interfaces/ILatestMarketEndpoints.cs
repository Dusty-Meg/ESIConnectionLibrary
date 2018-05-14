using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestMarketEndpoints
    {
        V1MarketGroupInformation GetMarketGroupInformation(int marketGroupId);
        Task<V1MarketGroupInformation> GetMarketGroupInformationAsync(int marketGroupId);
        PagedModel<V1MarketCharacterHistoricOrders> GetCharactersMarketHistoricOrders(SsoToken token, int page);
        Task<PagedModel<V1MarketCharacterHistoricOrders>> GetCharactersMarketHistoricOrdersAsync(SsoToken token, int page);
        IList<V2MarketCharactersOrders> GetCharactersMarketOrders(SsoToken token);
        Task<IList<V2MarketCharactersOrders>> GetCharactersMarketOrdersAsync(SsoToken token);
    }
}