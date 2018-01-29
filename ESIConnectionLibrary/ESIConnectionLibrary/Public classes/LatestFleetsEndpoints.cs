using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestFleetsEndpoints : ILatestFleetsEndpoints
    {
        private readonly IInternalLatestFleets _internalLatestFleets;

        public LatestFleetsEndpoints(string userAgent)
        {
            _internalLatestFleets = new InternalLatestFleets(null, userAgent);
        }

        public V1GetFleet GetFleet(SsoToken token, long fleetId)
        {
            return _internalLatestFleets.GetFleet(token, fleetId);
        }
    }
}
