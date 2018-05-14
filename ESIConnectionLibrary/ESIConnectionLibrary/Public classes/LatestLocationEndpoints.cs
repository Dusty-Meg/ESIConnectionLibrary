using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestLocationEndpoints : ILatestLocationEndpoints
    {
        private readonly IInternalLatestLocation _internalLatestLocation;

        public LatestLocationEndpoints(string userAgent)
        {
            _internalLatestLocation = new InternalLatestLocation(null, userAgent);
        }

        public V1LocationCharacterLocation GetCharacterLocation(SsoToken token)
        {
            return _internalLatestLocation.GetCharacterLocation(token);
        }

        public async Task<V1LocationCharacterLocation> GetCharacterLocationAsync(SsoToken token)
        {
            return await _internalLatestLocation.GetCharacterLocationAsync(token);
        }

        public V2LocationCharacterOnline GetCharacterOnlineStatus(SsoToken token)
        {
            return _internalLatestLocation.GetCharacterOnlineStatus(token);
        }

        public async Task<V2LocationCharacterOnline> GetCharacterOnlineStatusAsync(SsoToken token)
        {
            return await _internalLatestLocation.GetCharacterOnlineStatusAsync(token);
        }

        public V1LocationCharacterShip GetCharacterShip(SsoToken token)
        {
            return _internalLatestLocation.GetCharacterShip(token);
        }

        public async Task<V1LocationCharacterShip> GetCharacterShipAsync(SsoToken token)
        {
            return await _internalLatestLocation.GetCharacterShipAsync(token);
        }
    }
}
