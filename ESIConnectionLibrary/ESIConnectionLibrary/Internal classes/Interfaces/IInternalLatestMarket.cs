using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestMarket
    {
        V1MarketGroupInformation GetMarketGroupInformation(int marketGroupId);
        Task<V1MarketGroupInformation> GetMarketGroupInformationAsync(int marketGroupId);
    }
}