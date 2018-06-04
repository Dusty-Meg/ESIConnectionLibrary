using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestContacts : IInternalLatestContacts
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalLatestContacts(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ContactsMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public PagedModel<V1ContactsGetContacts> GetCharactersContacts(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_contacts_v1);

            string url = StaticConnectionStrings.ContactsV1GetCharactersContacts(token.CharacterId, page);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1ContactsGetContacts> esiCharacterContacts = JsonConvert.DeserializeObject<IList<EsiV1ContactsGetContacts>>(raw.Model);

            IList<V1ContactsGetContacts> mapped = _mapper.Map<IList<EsiV1ContactsGetContacts>, IList<V1ContactsGetContacts>>(esiCharacterContacts);

            return new PagedModel<V1ContactsGetContacts>{Model = mapped, MaxPages = raw.MaxPages, CurrentPage = page};
        }

        public async Task<PagedModel<V1ContactsGetContacts>> GetCharactersContactsAsync(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_contacts_v1);

            string url = StaticConnectionStrings.ContactsV1GetCharactersContacts(token.CharacterId, page);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1ContactsGetContacts> esiCharacterContacts = JsonConvert.DeserializeObject<IList<EsiV1ContactsGetContacts>>(raw.Model);

            IList<V1ContactsGetContacts> mapped = _mapper.Map<IList<EsiV1ContactsGetContacts>, IList<V1ContactsGetContacts>>(esiCharacterContacts);

            return new PagedModel<V1ContactsGetContacts> { Model = mapped, MaxPages = raw.MaxPages, CurrentPage = page };
        }
    }
}
