using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestLocation
    {
        V1LocationLocation Location(SsoToken token);
        Task<V1LocationLocation> LocationAsync(SsoToken token);
        V2LocationOnline Online(SsoToken token);
        Task<V2LocationOnline> OnlineAsync(SsoToken token);
        V1LocationShip Ship(SsoToken token);
        Task<V1LocationShip> ShipAsync(SsoToken token);
    }
}