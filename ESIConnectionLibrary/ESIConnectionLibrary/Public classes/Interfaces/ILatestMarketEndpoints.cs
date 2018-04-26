using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestMarketEndpoints
    {
        V1MarketGroupInformation GetMarketGroupInformation(int marketGroupId);
        Task<V1MarketGroupInformation> GetMarketGroupInformationAsync(int marketGroupId);
    }
}