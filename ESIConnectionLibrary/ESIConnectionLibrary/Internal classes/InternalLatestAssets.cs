using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestAssets : IInternalLatestAssets
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalLatestAssets(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AssetsMappings>();
                cfg.AddProfile<GeneralMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public PagedModel<V3GetCharacterAssets> GetCharactersAssets(SsoToken token, int characterId, int page)
        {
            StaticMethods.CheckToken(token, Scopes.esi_assets_read_assets_v1);

            string url = StaticConnectionStrings.AssetsV3GetCharactersAssets(characterId, page);

            PagedJson raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.GetPaged(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV3GetCharacterAssets> esiCharacterAssets = JsonConvert.DeserializeObject<IList<EsiV3GetCharacterAssets>>(raw.Response);

            IList<V3GetCharacterAssets> mapped = _mapper.Map<IList<EsiV3GetCharacterAssets>, IList<V3GetCharacterAssets>>(esiCharacterAssets);

            return new PagedModel<V3GetCharacterAssets>{Model = mapped, MaxPages = raw.MaxPages.GetValueOrDefault(), CurrentPage = page};
        }

        public async Task<PagedModel<V3GetCharacterAssets>> GetCharactersAssetsAsync(SsoToken token, int characterId, int page)
        {
            StaticMethods.CheckToken(token, Scopes.esi_assets_read_assets_v1);

            string url = StaticConnectionStrings.AssetsV3GetCharactersAssets(characterId, page);

            PagedJson raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetPagedAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV3GetCharacterAssets> esiCharacterAssets = JsonConvert.DeserializeObject<IList<EsiV3GetCharacterAssets>>(raw.Response);

            IList<V3GetCharacterAssets> mapped = _mapper.Map<IList<EsiV3GetCharacterAssets>, IList<V3GetCharacterAssets>>(esiCharacterAssets);

            return new PagedModel<V3GetCharacterAssets> { Model = mapped, MaxPages = raw.MaxPages.GetValueOrDefault(), CurrentPage = page };
        }

        public IList<V2GetCharactersAssetsLocations> GetCharactersAssetsLocations(SsoToken token, int characterId, IList<long> ids)
        {
            StaticMethods.CheckToken(token, Scopes.esi_assets_read_assets_v1);

            string url = StaticConnectionStrings.AssetsV2GetCharactersAssetsLocations(characterId);

            string jsonObject = JsonConvert.SerializeObject(ids);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, jsonObject));

            IList<EsiV2GetCharactersAssetsLocations> esiAssetsLocations = JsonConvert.DeserializeObject<IList<EsiV2GetCharactersAssetsLocations>>(esiRaw);

            return _mapper.Map<IList<EsiV2GetCharactersAssetsLocations>, IList<V2GetCharactersAssetsLocations>>(esiAssetsLocations);
        }

        public async Task<IList<V2GetCharactersAssetsLocations>> GetCharactersAssetsLocationsAsync(SsoToken token, int characterId, IList<long> ids)
        {
            StaticMethods.CheckToken(token, Scopes.esi_assets_read_assets_v1);

            string url = StaticConnectionStrings.AssetsV2GetCharactersAssetsLocations(characterId);

            string jsonObject = JsonConvert.SerializeObject(ids);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, jsonObject));

            IList<EsiV2GetCharactersAssetsLocations> esiAssetsLocations = JsonConvert.DeserializeObject<IList<EsiV2GetCharactersAssetsLocations>>(esiRaw);

            return _mapper.Map<IList<EsiV2GetCharactersAssetsLocations>, IList<V2GetCharactersAssetsLocations>>(esiAssetsLocations);
        }

        public IList<V1GetCharactersAssetsNames> GetCharactersAssetsNames(SsoToken token, int characterId, IList<long> ids)
        {
            StaticMethods.CheckToken(token, Scopes.esi_assets_read_assets_v1);

            string url = StaticConnectionStrings.AssetsV1GetCharactersAssetsNames(characterId);

            string jsonObject = JsonConvert.SerializeObject(ids);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, jsonObject));

            IList<EsiV1GetCharactersAssetsNames> esiAssetsNames = JsonConvert.DeserializeObject<IList<EsiV1GetCharactersAssetsNames>>(esiRaw);

            return _mapper.Map<IList<EsiV1GetCharactersAssetsNames>, IList<V1GetCharactersAssetsNames>>(esiAssetsNames);
        }

        public async Task<IList<V1GetCharactersAssetsNames>> GetCharactersAssetsNamesAsync(SsoToken token, int characterId, IList<long> ids)
        {
            StaticMethods.CheckToken(token, Scopes.esi_assets_read_assets_v1);

            string url = StaticConnectionStrings.AssetsV1GetCharactersAssetsNames(characterId);

            string jsonObject = JsonConvert.SerializeObject(ids);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, jsonObject));

            IList<EsiV1GetCharactersAssetsNames> esiAssetsNames = JsonConvert.DeserializeObject<IList<EsiV1GetCharactersAssetsNames>>(esiRaw);

            return _mapper.Map<IList<EsiV1GetCharactersAssetsNames>, IList<V1GetCharactersAssetsNames>>(esiAssetsNames);
        }

        public PagedModel<V2GetCorporationsAssets> GetCorporationsAssets(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, Scopes.esi_assets_read_corporation_assets_v1);

            string url = StaticConnectionStrings.AssetsV2GetCorporationsAssets(corporationId, page);

            PagedJson raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.GetPaged(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2GetCorporationsAssets> esiCorporationAssets = JsonConvert.DeserializeObject<IList<EsiV2GetCorporationsAssets>>(raw.Response);

            IList<V2GetCorporationsAssets> mapped = _mapper.Map<IList<EsiV2GetCorporationsAssets>, IList<V2GetCorporationsAssets>>(esiCorporationAssets);

            return new PagedModel<V2GetCorporationsAssets> { Model = mapped, MaxPages = raw.MaxPages.GetValueOrDefault(), CurrentPage = page };
        }

        public async Task<PagedModel<V2GetCorporationsAssets>> GetCorporationsAssetsAsync(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, Scopes.esi_assets_read_corporation_assets_v1);

            string url = StaticConnectionStrings.AssetsV2GetCorporationsAssets(corporationId, page);

            PagedJson raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetPagedAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2GetCorporationsAssets> esiCorporationAssets = JsonConvert.DeserializeObject<IList<EsiV2GetCorporationsAssets>>(raw.Response);

            IList<V2GetCorporationsAssets> mapped = _mapper.Map<IList<EsiV2GetCorporationsAssets>, IList<V2GetCorporationsAssets>>(esiCorporationAssets);

            return new PagedModel<V2GetCorporationsAssets> { Model = mapped, MaxPages = raw.MaxPages.GetValueOrDefault(), CurrentPage = page };
        }

        public IList<V2GetCorporationsAssetsLocations> GetCorporationsAssetsLocations(SsoToken token, int corporationId, IList<long> ids)
        {
            StaticMethods.CheckToken(token, Scopes.esi_assets_read_corporation_assets_v1);

            string url = StaticConnectionStrings.AssetsV2GetCorporationsAssetsLocations(corporationId);

            string jsonObject = JsonConvert.SerializeObject(ids);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, jsonObject));

            IList<EsiV2GetCorporationsAssetsLocations> esiAssetsLocations = JsonConvert.DeserializeObject<IList<EsiV2GetCorporationsAssetsLocations>>(esiRaw);

            return _mapper.Map<IList<EsiV2GetCorporationsAssetsLocations>, IList<V2GetCorporationsAssetsLocations>>(esiAssetsLocations);
        }

        public async Task<IList<V2GetCorporationsAssetsLocations>> GetCorporationsAssetsLocationsAsync(SsoToken token, int corporationId, IList<long> ids)
        {
            StaticMethods.CheckToken(token, Scopes.esi_assets_read_corporation_assets_v1);

            string url = StaticConnectionStrings.AssetsV2GetCorporationsAssetsLocations(corporationId);

            string jsonObject = JsonConvert.SerializeObject(ids);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, jsonObject));

            IList<EsiV2GetCorporationsAssetsLocations> esiAssetsLocations = JsonConvert.DeserializeObject<IList<EsiV2GetCorporationsAssetsLocations>>(esiRaw);

            return _mapper.Map<IList<EsiV2GetCorporationsAssetsLocations>, IList<V2GetCorporationsAssetsLocations>>(esiAssetsLocations);
        }

        public IList<V1GetCorporationsAssetsNames> GetCorporationsAssetsNames(SsoToken token, int corporationId, IList<long> ids)
        {
            StaticMethods.CheckToken(token, Scopes.esi_assets_read_corporation_assets_v1);

            string url = StaticConnectionStrings.AssetsV1GetCorporationsAssetsNames(corporationId);

            string jsonObject = JsonConvert.SerializeObject(ids);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, jsonObject));

            IList<EsiV1GetCorporationsAssetsNames> esiAssetsNames = JsonConvert.DeserializeObject<IList<EsiV1GetCorporationsAssetsNames>>(esiRaw);

            return _mapper.Map<IList<EsiV1GetCorporationsAssetsNames>, IList<V1GetCorporationsAssetsNames>>(esiAssetsNames);
        }

        public async Task<IList<V1GetCorporationsAssetsNames>> GetCorporationsAssetsNamesAsync(SsoToken token, int corporationId, IList<long> ids)
        {
            StaticMethods.CheckToken(token, Scopes.esi_assets_read_corporation_assets_v1);

            string url = StaticConnectionStrings.AssetsV1GetCorporationsAssetsNames(corporationId);

            string jsonObject = JsonConvert.SerializeObject(ids);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, jsonObject));

            IList<EsiV1GetCorporationsAssetsNames> esiAssetsNames = JsonConvert.DeserializeObject<IList<EsiV1GetCorporationsAssetsNames>>(esiRaw);

            return _mapper.Map<IList<EsiV1GetCorporationsAssetsNames>, IList<V1GetCorporationsAssetsNames>>(esiAssetsNames);
        }
    }
}
