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

        public V1LocationCharacterLocation GetCharacterLocation(SsoToken token, int characterId)
        {
            return _internalLatestLocation.GetCharacterLocation(token, characterId);
        }

        public async Task<V1LocationCharacterLocation> GetCharacterLocationAsync(SsoToken token, int characterId)
        {
            return await _internalLatestLocation.GetCharacterLocationAsync(token, characterId);
        }

        public V2LocationCharacterOnline GetCharacterOnlineStatus(SsoToken token, int characterId)
        {
            return _internalLatestLocation.GetCharacterOnlineStatus(token, characterId);
        }

        public async Task<V2LocationCharacterOnline> GetCharacterOnlineStatusAsync(SsoToken token, int characterId)
        {
            return await _internalLatestLocation.GetCharacterOnlineStatusAsync(token, characterId);
        }

        public V1LocationCharacterShip GetCharacterShip(SsoToken token, int characterId)
        {
            return _internalLatestLocation.GetCharacterShip(token, characterId);
        }

        public async Task<V1LocationCharacterShip> GetCharacterShipAsync(SsoToken token, int characterId)
        {
            return await _internalLatestLocation.GetCharacterShipAsync(token, characterId);
        }
    }
}
