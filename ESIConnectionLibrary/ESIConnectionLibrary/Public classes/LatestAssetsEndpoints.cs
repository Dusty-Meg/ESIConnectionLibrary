using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Exceptions;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestAssetsEndpoints : ILatestAssetsEndpoints
    {
        private readonly IInternalLatestAssets _internalLatestAssets;

        public LatestAssetsEndpoints(string userAgent)
        {
            _internalLatestAssets = new InternalLatestAssets(null, userAgent);
        }

        public PagedModel<V3GetCharacterAssets> GetCharactersAssets(SsoToken token, int characterId, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return _internalLatestAssets.GetCharactersAssets(token, characterId, page);
        }

        public async Task<PagedModel<V3GetCharacterAssets>> GetCharactersAssetsAsync(SsoToken token, int characterId, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return await _internalLatestAssets.GetCharactersAssetsAsync(token, characterId, page);
        }

        public IList<V2GetCharactersAssetsLocations> GetCharactersAssetsLocations(SsoToken token, int characterId, IList<long> ids)
        {
            return _internalLatestAssets.GetCharactersAssetsLocations(token, characterId, ids);
        }

        public async Task<IList<V2GetCharactersAssetsLocations>> GetCharactersAssetsLocationsAsync(SsoToken token, int characterId, IList<long> ids)
        {
            return await _internalLatestAssets.GetCharactersAssetsLocationsAsync(token, characterId, ids);
        }

        public IList<V1GetCharactersAssetsNames> GetCharactersAssetsNames(SsoToken token, int characterId, IList<long> ids)
        {
            return _internalLatestAssets.GetCharactersAssetsNames(token, characterId, ids);
        }

        public async Task<IList<V1GetCharactersAssetsNames>> GetCharactersAssetsNamesAsync(SsoToken token, int characterId, IList<long> ids)
        {
            return await _internalLatestAssets.GetCharactersAssetsNamesAsync(token, characterId, ids);
        }

        public PagedModel<V2GetCorporationsAssets> GetCorporationsAssets(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return _internalLatestAssets.GetCorporationsAssets(token, corporationId, page);
        }

        public async Task<PagedModel<V2GetCorporationsAssets>> GetCorporationsAssetsAsync(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return await _internalLatestAssets.GetCorporationsAssetsAsync(token, corporationId, page);
        }

        public IList<V2GetCorporationsAssetsLocations> GetCorporationsAssetsLocations(SsoToken token, int corporationId, IList<long> ids)
        {
            return _internalLatestAssets.GetCorporationsAssetsLocations(token, corporationId, ids);
        }

        public async Task<IList<V2GetCorporationsAssetsLocations>> GetCorporationsAssetsLocationsAsync(SsoToken token, int corporationId, IList<long> ids)
        {
            return await _internalLatestAssets.GetCorporationsAssetsLocationsAsync(token, corporationId, ids);
        }

        public IList<V1GetCorporationsAssetsNames> GetCorporationsAssetsNames(SsoToken token, int corporationId, IList<long> ids)
        {
            return _internalLatestAssets.GetCorporationsAssetsNames(token, corporationId, ids);
        }

        public async Task<IList<V1GetCorporationsAssetsNames>> GetCorporationsAssetsNamesAsync(SsoToken token, int corporationId, IList<long> ids)
        {
            return await _internalLatestAssets.GetCorporationsAssetsNamesAsync(token, corporationId, ids);
        }
    }
}
