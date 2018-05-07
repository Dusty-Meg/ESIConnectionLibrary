using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestLocationEndpoints
    {
        V1LocationCharacterLocation GetCharacterLocation(SsoToken token, int characterId);
        Task<V1LocationCharacterLocation> GetCharacterLocationAsync(SsoToken token, int characterId);
        V2LocationCharacterOnline GetCharacterOnlineStatus(SsoToken token, int characterId);
        Task<V2LocationCharacterOnline> GetCharacterOnlineStatusAsync(SsoToken token, int characterId);
        V1LocationCharacterShip GetCharacterShip(SsoToken token, int characterId);
        Task<V1LocationCharacterShip> GetCharacterShipAsync(SsoToken token, int characterId);
    }
}