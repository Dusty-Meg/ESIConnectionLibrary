using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestFleetsEndpoints
    {
        V1GetFleet GetFleet(SsoToken token, long fleetId);
        Task<V1GetFleet> GetFleetAsync(SsoToken token, long fleetId);
    }
}