using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class FleetsEndpoints
    {
        private readonly IInternalFleets _internalFleets;

        public FleetsEndpoints(string userAgent)
        {
            _internalFleets = new InternalFleets(null, userAgent);
        }

        public GetFleet GetFleet(SsoToken token, long fleetId)
        {
            return _internalFleets.GetFleet(token, fleetId);
        }
    }
}
