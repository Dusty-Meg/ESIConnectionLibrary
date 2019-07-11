using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.Automapper_Profiles;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestBookmarks : IInternalLatestBookmarks
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestBookmarks(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<BookmarksProfile>();
                });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public PagedModel<V2BookmarksCharacter> CharacterBookmarks(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, BookmarkScopes.esi_bookmarks_read_character_bookmarks_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.BookmarksV2Characters(token.CharacterId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2BookmarksCharacter> esiModel = JsonConvert.DeserializeObject<IList<EsiV2BookmarksCharacter>>(esiRaw.Model);

            IList<V2BookmarksCharacter> mapped = _mapper.Map<IList<EsiV2BookmarksCharacter>, IList<V2BookmarksCharacter>>(esiModel);

            return new PagedModel<V2BookmarksCharacter>{ Model = mapped, MaxPages = esiRaw .MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V2BookmarksCharacter>> CharacterBookmarksAsync(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, BookmarkScopes.esi_bookmarks_read_character_bookmarks_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.BookmarksV2Characters(token.CharacterId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2BookmarksCharacter> esiModel = JsonConvert.DeserializeObject<IList<EsiV2BookmarksCharacter>>(esiRaw.Model);

            IList<V2BookmarksCharacter> mapped = _mapper.Map<IList<EsiV2BookmarksCharacter>, IList<V2BookmarksCharacter>>(esiModel);

            return new PagedModel<V2BookmarksCharacter> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public PagedModel<V2BookmarksCharacterFolder> CharacterBookmarkFolders(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, BookmarkScopes.esi_bookmarks_read_character_bookmarks_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.BookmarksV2CharactersFolders(token.CharacterId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2BookmarksCharacterFolder> esiModel = JsonConvert.DeserializeObject<IList<EsiV2BookmarksCharacterFolder>>(esiRaw.Model);

            IList<V2BookmarksCharacterFolder> mapped = _mapper.Map<IList<EsiV2BookmarksCharacterFolder>, IList<V2BookmarksCharacterFolder>>(esiModel);

            return new PagedModel<V2BookmarksCharacterFolder> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V2BookmarksCharacterFolder>> CharacterBookmarkFoldersAsync(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, BookmarkScopes.esi_bookmarks_read_character_bookmarks_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.BookmarksV2CharactersFolders(token.CharacterId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2BookmarksCharacterFolder> esiModel = JsonConvert.DeserializeObject<IList<EsiV2BookmarksCharacterFolder>>(esiRaw.Model);

            IList<V2BookmarksCharacterFolder> mapped = _mapper.Map<IList<EsiV2BookmarksCharacterFolder>, IList<V2BookmarksCharacterFolder>>(esiModel);

            return new PagedModel<V2BookmarksCharacterFolder> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public PagedModel<V1BookmarksCorporation> CorporationBookmarks(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, BookmarkScopes.esi_bookmarks_read_corporation_bookmarks_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.BookmarksV1Corporations(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1BookmarksCorporation> esiModel = JsonConvert.DeserializeObject<IList<EsiV1BookmarksCorporation>>(esiRaw.Model);

            IList<V1BookmarksCorporation> mapped = _mapper.Map<IList<EsiV1BookmarksCorporation>, IList<V1BookmarksCorporation>>(esiModel);

            return new PagedModel<V1BookmarksCorporation> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V1BookmarksCorporation>> CorporationBookmarksAsync(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, BookmarkScopes.esi_bookmarks_read_corporation_bookmarks_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.BookmarksV1Corporations(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1BookmarksCorporation> esiModel = JsonConvert.DeserializeObject<IList<EsiV1BookmarksCorporation>>(esiRaw.Model);

            IList<V1BookmarksCorporation> mapped = _mapper.Map<IList<EsiV1BookmarksCorporation>, IList<V1BookmarksCorporation>>(esiModel);

            return new PagedModel<V1BookmarksCorporation> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public PagedModel<V1BookmarksCorporationFolder> CorporationBookmarkFolders(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, BookmarkScopes.esi_bookmarks_read_corporation_bookmarks_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.BookmarksV1CorporationsFolders(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1BookmarksCorporationFolder> esiModel = JsonConvert.DeserializeObject<IList<EsiV1BookmarksCorporationFolder>>(esiRaw.Model);

            IList<V1BookmarksCorporationFolder> mapped = _mapper.Map<IList<EsiV1BookmarksCorporationFolder>, IList<V1BookmarksCorporationFolder>>(esiModel);

            return new PagedModel<V1BookmarksCorporationFolder> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V1BookmarksCorporationFolder>> CorporationBookmarkFoldersAsync(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, BookmarkScopes.esi_bookmarks_read_corporation_bookmarks_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.BookmarksV1CorporationsFolders(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1BookmarksCorporationFolder> esiModel = JsonConvert.DeserializeObject<IList<EsiV1BookmarksCorporationFolder>>(esiRaw.Model);

            IList<V1BookmarksCorporationFolder> mapped = _mapper.Map<IList<EsiV1BookmarksCorporationFolder>, IList<V1BookmarksCorporationFolder>>(esiModel);

            return new PagedModel<V1BookmarksCorporationFolder> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }
    }
}
