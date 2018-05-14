using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestLocation
    {
        V1LocationCharacterLocation GetCharacterLocation(SsoToken token);
        Task<V1LocationCharacterLocation> GetCharacterLocationAsync(SsoToken token);
        V2LocationCharacterOnline GetCharacterOnlineStatus(SsoToken token);
        Task<V2LocationCharacterOnline> GetCharacterOnlineStatusAsync(SsoToken token);
        V1LocationCharacterShip GetCharacterShip(SsoToken token);
        Task<V1LocationCharacterShip> GetCharacterShipAsync(SsoToken token);
    }
}