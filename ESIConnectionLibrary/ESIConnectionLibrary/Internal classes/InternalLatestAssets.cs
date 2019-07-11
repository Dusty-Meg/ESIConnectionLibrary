using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.Automapper_Profiles;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestAssets : IInternalLatestAssets
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestAssets(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AssetsProfile>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public PagedModel<V3AssetsCharacter> Characters(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, AssetScopes.esi_assets_read_assets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AssetsV3Characters(token.CharacterId, page), _testing);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV3AssetsCharacter> esiCharacterAssets = JsonConvert.DeserializeObject<IList<EsiV3AssetsCharacter>>(raw.Model);

            IList<V3AssetsCharacter> mapped = _mapper.Map<IList<EsiV3AssetsCharacter>, IList<V3AssetsCharacter>>(esiCharacterAssets);

            return new PagedModel<V3AssetsCharacter>{Model = mapped, MaxPages = raw.MaxPages, CurrentPage = page};
        }

        public async Task<PagedModel<V3AssetsCharacter>> CharactersAsync(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, AssetScopes.esi_assets_read_assets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AssetsV3Characters(token.CharacterId, page), _testing);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV3AssetsCharacter> esiCharacterAssets = JsonConvert.DeserializeObject<IList<EsiV3AssetsCharacter>>(raw.Model);

            IList<V3AssetsCharacter> mapped = _mapper.Map<IList<EsiV3AssetsCharacter>, IList<V3AssetsCharacter>>(esiCharacterAssets);

            return new PagedModel<V3AssetsCharacter> { Model = mapped, MaxPages = raw.MaxPages, CurrentPage = page };
        }

        public IList<V2AssetsCharacterLocation> CharacterLocations(SsoToken token, IList<long> ids)
        {
            StaticMethods.CheckToken(token, AssetScopes.esi_assets_read_assets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AssetsV2CharacterLocations(token.CharacterId), _testing);

            string jsonObject = JsonConvert.SerializeObject(ids);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, jsonObject));

            IList<EsiV2AssetsCharacterLocation> esiAssetsLocations = JsonConvert.DeserializeObject<IList<EsiV2AssetsCharacterLocation>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2AssetsCharacterLocation>, IList<V2AssetsCharacterLocation>>(esiAssetsLocations);
        }

        public async Task<IList<V2AssetsCharacterLocation>> CharacterLocationAsync(SsoToken token, IList<long> ids)
        {
            StaticMethods.CheckToken(token, AssetScopes.esi_assets_read_assets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AssetsV2CharacterLocations(token.CharacterId), _testing);

            string jsonObject = JsonConvert.SerializeObject(ids);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, jsonObject));

            IList<EsiV2AssetsCharacterLocation> esiAssetsLocations = JsonConvert.DeserializeObject<IList<EsiV2AssetsCharacterLocation>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2AssetsCharacterLocation>, IList<V2AssetsCharacterLocation>>(esiAssetsLocations);
        }

        public IList<V1AssetsCharacterName> CharacterNames(SsoToken token, IList<long> ids)
        {
            StaticMethods.CheckToken(token, AssetScopes.esi_assets_read_assets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AssetsV1CharacterNames(token.CharacterId), _testing);

            string jsonObject = JsonConvert.SerializeObject(ids);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, jsonObject));

            IList<EsiV1AssetsCharacterNames> esiAssetsNames = JsonConvert.DeserializeObject<IList<EsiV1AssetsCharacterNames>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1AssetsCharacterNames>, IList<V1AssetsCharacterName>>(esiAssetsNames);
        }

        public async Task<IList<V1AssetsCharacterName>> CharacterNamesAsync(SsoToken token, IList<long> ids)
        {
            StaticMethods.CheckToken(token, AssetScopes.esi_assets_read_assets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AssetsV1CharacterNames(token.CharacterId), _testing);

            string jsonObject = JsonConvert.SerializeObject(ids);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, jsonObject));

            IList<EsiV1AssetsCharacterNames> esiAssetsNames = JsonConvert.DeserializeObject<IList<EsiV1AssetsCharacterNames>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1AssetsCharacterNames>, IList<V1AssetsCharacterName>>(esiAssetsNames);
        }

        public PagedModel<V3AssetsCorporations> Corporations(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, AssetScopes.esi_assets_read_corporation_assets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AssetsV3Corporations(corporationId, page), _testing);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV3AssetsCorporations> esiCorporationAssets = JsonConvert.DeserializeObject<IList<EsiV3AssetsCorporations>>(raw.Model);

            IList<V3AssetsCorporations> mapped = _mapper.Map<IList<EsiV3AssetsCorporations>, IList<V3AssetsCorporations>>(esiCorporationAssets);

            return new PagedModel<V3AssetsCorporations> { Model = mapped, MaxPages = raw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V3AssetsCorporations>> CorporationsAsync(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, AssetScopes.esi_assets_read_corporation_assets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AssetsV3Corporations(corporationId, page), _testing);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV3AssetsCorporations> esiCorporationAssets = JsonConvert.DeserializeObject<IList<EsiV3AssetsCorporations>>(raw.Model);

            IList<V3AssetsCorporations> mapped = _mapper.Map<IList<EsiV3AssetsCorporations>, IList<V3AssetsCorporations>>(esiCorporationAssets);

            return new PagedModel<V3AssetsCorporations> { Model = mapped, MaxPages = raw.MaxPages, CurrentPage = page };
        }

        public IList<V2AssetsCorporationLocation> CorporationLocations(SsoToken token, int corporationId, IList<long> ids)
        {
            StaticMethods.CheckToken(token, AssetScopes.esi_assets_read_corporation_assets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AssetsV2CorporationLocations(corporationId), _testing);

            string jsonObject = JsonConvert.SerializeObject(ids);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, jsonObject));

            IList<EsiV2AssetsCorporationLocation> esiAssetsLocations = JsonConvert.DeserializeObject<IList<EsiV2AssetsCorporationLocation>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2AssetsCorporationLocation>, IList<V2AssetsCorporationLocation>>(esiAssetsLocations);
        }

        public async Task<IList<V2AssetsCorporationLocation>> CorporationLocationsAsync(SsoToken token, int corporationId, IList<long> ids)
        {
            StaticMethods.CheckToken(token, AssetScopes.esi_assets_read_corporation_assets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AssetsV2CorporationLocations(corporationId), _testing);

            string jsonObject = JsonConvert.SerializeObject(ids);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, jsonObject));

            IList<EsiV2AssetsCorporationLocation> esiAssetsLocations = JsonConvert.DeserializeObject<IList<EsiV2AssetsCorporationLocation>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2AssetsCorporationLocation>, IList<V2AssetsCorporationLocation>>(esiAssetsLocations);
        }

        public IList<V1AssetsCorporationName> CorporationNames(SsoToken token, int corporationId, IList<long> ids)
        {
            StaticMethods.CheckToken(token, AssetScopes.esi_assets_read_corporation_assets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AssetsV1CorporationNames(corporationId), _testing);

            string jsonObject = JsonConvert.SerializeObject(ids);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, jsonObject));

            IList<EsiV1AssetsCorporationName> esiAssetsNames = JsonConvert.DeserializeObject<IList<EsiV1AssetsCorporationName>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1AssetsCorporationName>, IList<V1AssetsCorporationName>>(esiAssetsNames);
        }

        public async Task<IList<V1AssetsCorporationName>> CorporationNamesAsync(SsoToken token, int corporationId, IList<long> ids)
        {
            StaticMethods.CheckToken(token, AssetScopes.esi_assets_read_corporation_assets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AssetsV1CorporationNames(corporationId), _testing);

            string jsonObject = JsonConvert.SerializeObject(ids);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, jsonObject));

            IList<EsiV1AssetsCorporationName> esiAssetsNames = JsonConvert.DeserializeObject<IList<EsiV1AssetsCorporationName>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1AssetsCorporationName>, IList<V1AssetsCorporationName>>(esiAssetsNames);
        }
    }
}
