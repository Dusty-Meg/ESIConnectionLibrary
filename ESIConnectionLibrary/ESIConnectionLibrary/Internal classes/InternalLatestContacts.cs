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
        private readonly bool _testing;

        public InternalLatestContacts(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ContactsMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public PagedModel<V2ContactsGetContacts> GetCharactersContacts(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV2GetCharactersContacts(token.CharacterId, page), _testing);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV2ContactsGetContacts> esiCharacterContacts = JsonConvert.DeserializeObject<IList<EsiV2ContactsGetContacts>>(raw.Model);

            IList<V2ContactsGetContacts> mapped = _mapper.Map<IList<EsiV2ContactsGetContacts>, IList<V2ContactsGetContacts>>(esiCharacterContacts);

            return new PagedModel<V2ContactsGetContacts>{Model = mapped, MaxPages = raw.MaxPages, CurrentPage = page};
        }

        public async Task<PagedModel<V2ContactsGetContacts>> GetCharactersContactsAsync(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV2GetCharactersContacts(token.CharacterId, page), _testing);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV2ContactsGetContacts> esiCharacterContacts = JsonConvert.DeserializeObject<IList<EsiV2ContactsGetContacts>>(raw.Model);

            IList<V2ContactsGetContacts> mapped = _mapper.Map<IList<EsiV2ContactsGetContacts>, IList<V2ContactsGetContacts>>(esiCharacterContacts);

            return new PagedModel<V2ContactsGetContacts> { Model = mapped, MaxPages = raw.MaxPages, CurrentPage = page };
        }
    }
}
