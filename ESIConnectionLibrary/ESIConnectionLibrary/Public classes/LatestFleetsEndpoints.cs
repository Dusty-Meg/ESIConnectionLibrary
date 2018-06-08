using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestFleetsEndpoints : ILatestFleetsEndpoints
    {
        private readonly IInternalLatestFleets _internalLatestFleets;

        public LatestFleetsEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestFleets = new InternalLatestFleets(null, userAgent, testing);
        }

        public V1GetFleet GetFleet(SsoToken token, long fleetId)
        {
            return _internalLatestFleets.GetFleet(token, fleetId);
        }

        public async Task<V1GetFleet> GetFleetAsync(SsoToken token, long fleetId)
        {
            return await _internalLatestFleets.GetFleetAsync(token, fleetId);
        }
    }
}
