using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestLocationEndpoints : ILatestLocationEndpoints
    {
        private readonly IInternalLatestLocation _internalLatestLocation;

        public LatestLocationEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestLocation = new InternalLatestLocation(null, userAgent, testing);
        }

        internal LatestLocationEndpoints(string userAgent, IWebClient webClient, bool testing = false)
        {
            _internalLatestLocation = new InternalLatestLocation(webClient, userAgent, testing);
        }

        public V1LocationLocation Location(SsoToken token)
        {
            return _internalLatestLocation.Location(token);
        }

        public async Task<V1LocationLocation> LocationAsync(SsoToken token)
        {
            return await _internalLatestLocation.LocationAsync(token);
        }

        public V2LocationOnline Online(SsoToken token)
        {
            return _internalLatestLocation.Online(token);
        }

        public async Task<V2LocationOnline> OnlineAsync(SsoToken token)
        {
            return await _internalLatestLocation.OnlineAsync(token);
        }

        public V1LocationShip Ship(SsoToken token)
        {
            return _internalLatestLocation.Ship(token);
        }

        public async Task<V1LocationShip> ShipAsync(SsoToken token)
        {
            return await _internalLatestLocation.ShipAsync(token);
        }
    }
}
