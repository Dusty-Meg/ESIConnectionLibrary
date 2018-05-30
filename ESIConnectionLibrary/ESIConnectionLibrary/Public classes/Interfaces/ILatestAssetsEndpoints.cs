using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestAssetsEndpoints
    {
        PagedModel<V3GetCharacterAssets> GetCharactersAssets(SsoToken token, int page);
        Task<PagedModel<V3GetCharacterAssets>> GetCharactersAssetsAsync(SsoToken token, int page);
        IList<V2GetCharactersAssetsLocations> GetCharactersAssetsLocations(SsoToken token, IList<long> ids);
        Task<IList<V2GetCharactersAssetsLocations>> GetCharactersAssetsLocationsAsync(SsoToken token, IList<long> ids);
        IList<V1GetCharactersAssetsNames> GetCharactersAssetsNames(SsoToken token, IList<long> ids);
        Task<IList<V1GetCharactersAssetsNames>> GetCharactersAssetsNamesAsync(SsoToken token, IList<long> ids);
        PagedModel<V3GetCorporationsAssets> GetCorporationsAssets(SsoToken token, int corporationId, int page);
        Task<PagedModel<V3GetCorporationsAssets>> GetCorporationsAssetsAsync(SsoToken token, int corporationId, int page);
        IList<V2GetCorporationsAssetsLocations> GetCorporationsAssetsLocations(SsoToken token, int corporationId, IList<long> ids);
        Task<IList<V2GetCorporationsAssetsLocations>> GetCorporationsAssetsLocationsAsync(SsoToken token, int corporationId, IList<long> ids);
        IList<V1GetCorporationsAssetsNames> GetCorporationsAssetsNames(SsoToken token, int corporationId, IList<long> ids);
        Task<IList<V1GetCorporationsAssetsNames>> GetCorporationsAssetsNamesAsync(SsoToken token, int corporationId, IList<long> ids);
    }
}