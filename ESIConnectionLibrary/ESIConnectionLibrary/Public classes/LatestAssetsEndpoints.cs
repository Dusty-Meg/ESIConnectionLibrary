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

        public LatestAssetsEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestAssets = new InternalLatestAssets(null, userAgent, testing);
        }

        internal LatestAssetsEndpoints(string userAgent, IWebClient webClient, bool testing = false)
        {
            _internalLatestAssets = new InternalLatestAssets(webClient, userAgent);
        }

        public PagedModel<V3AssetsCharacter> Characters(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestAssets.Characters(token, page);
        }

        public async Task<PagedModel<V3AssetsCharacter>> CharactersAsync(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestAssets.CharactersAsync(token, page);
        }

        public IList<V2AssetsCharacterLocation> CharacterLocations(SsoToken token, IList<long> ids)
        {
            return _internalLatestAssets.CharacterLocations(token, ids);
        }

        public async Task<IList<V2AssetsCharacterLocation>> CharacterLocationAsync(SsoToken token, IList<long> ids)
        {
            return await _internalLatestAssets.CharacterLocationAsync(token, ids);
        }

        public IList<V1AssetsCharacterName> CharacterNames(SsoToken token, IList<long> ids)
        {
            return _internalLatestAssets.CharacterNames(token, ids);
        }

        public async Task<IList<V1AssetsCharacterName>> CharacterNamesAsync(SsoToken token, IList<long> ids)
        {
            return await _internalLatestAssets.CharacterNamesAsync(token, ids);
        }

        public PagedModel<V3AssetsCorporations> Corporations(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestAssets.Corporations(token, corporationId, page);
        }

        public async Task<PagedModel<V3AssetsCorporations>> CorporationsAsync(SsoToken token, int corporationId, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestAssets.CorporationsAsync(token, corporationId, page);
        }

        public IList<V2AssetsCorporationLocation> CorporationLocations(SsoToken token, int corporationId, IList<long> ids)
        {
            return _internalLatestAssets.CorporationLocations(token, corporationId, ids);
        }

        public async Task<IList<V2AssetsCorporationLocation>> CorporationLocationsAsync(SsoToken token, int corporationId, IList<long> ids)
        {
            return await _internalLatestAssets.CorporationLocationsAsync(token, corporationId, ids);
        }

        public IList<V1AssetsCorporationName> CorporationNames(SsoToken token, int corporationId, IList<long> ids)
        {
            return _internalLatestAssets.CorporationNames(token, corporationId, ids);
        }

        public async Task<IList<V1AssetsCorporationName>> CorporationNamesAsync(SsoToken token, int corporationId, IList<long> ids)
        {
            return await _internalLatestAssets.CorporationNamesAsync(token, corporationId, ids);
        }
    }
}
