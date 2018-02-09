using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestFleets
    {
        V1GetFleet GetFleet(SsoToken token, long fleetId);
        Task<V1GetFleet> GetFleetAsync(SsoToken token, long fleetId);
    }
}