using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestLocationEndpoints
    {
        V1LocationCharacterLocation GetCharacterLocation(SsoToken token);
        Task<V1LocationCharacterLocation> GetCharacterLocationAsync(SsoToken token);
        V2LocationCharacterOnline GetCharacterOnlineStatus(SsoToken token);
        Task<V2LocationCharacterOnline> GetCharacterOnlineStatusAsync(SsoToken token);
        V1LocationCharacterShip GetCharacterShip(SsoToken token);
        Task<V1LocationCharacterShip> GetCharacterShipAsync(SsoToken token);
    }
}