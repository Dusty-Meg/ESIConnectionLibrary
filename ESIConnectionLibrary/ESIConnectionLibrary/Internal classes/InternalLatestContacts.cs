using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.Automapper_Profiles;
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
                cfg.AddProfile<ContactsProfile>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public PagedModel<V2ContactAlliance> Alliance(SsoToken token, int allianceId, int page)
        {
            StaticMethods.CheckToken(token, AllianceScopes.esi_alliances_read_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV2Alliance(allianceId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV2ContactAlliance> esiModel = JsonConvert.DeserializeObject<IList<EsiV2ContactAlliance>>(esiRaw.Model);

            IList<V2ContactAlliance> mapped = _mapper.Map<IList<EsiV2ContactAlliance>, IList<V2ContactAlliance>>(esiModel);

            return new PagedModel<V2ContactAlliance> {Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page};
        }

        public async Task<PagedModel<V2ContactAlliance>> AllianceAsync(SsoToken token, int allianceId, int page)
        {
            StaticMethods.CheckToken(token, AllianceScopes.esi_alliances_read_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV2Alliance(allianceId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV2ContactAlliance> esiModel = JsonConvert.DeserializeObject<IList<EsiV2ContactAlliance>>(esiRaw.Model);

            IList<V2ContactAlliance> mapped = _mapper.Map<IList<EsiV2ContactAlliance>, IList<V2ContactAlliance>>(esiModel);

            return new PagedModel<V2ContactAlliance> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public IList<V1ContactAllianceLabel> AllianceLabels(SsoToken token, int allianceId)
        {
            StaticMethods.CheckToken(token, AllianceScopes.esi_alliances_read_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV1AllianceLabels(allianceId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1ContactAllianceLabel> esiModel = JsonConvert.DeserializeObject<IList<EsiV1ContactAllianceLabel>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1ContactAllianceLabel>, IList<V1ContactAllianceLabel>>(esiModel);
        }

        public async Task<IList<V1ContactAllianceLabel>> AllianceLabelsAsync(SsoToken token, int allianceId)
        {
            StaticMethods.CheckToken(token, AllianceScopes.esi_alliances_read_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV1AllianceLabels(allianceId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1ContactAllianceLabel> esiModel = JsonConvert.DeserializeObject<IList<EsiV1ContactAllianceLabel>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1ContactAllianceLabel>, IList<V1ContactAllianceLabel>>(esiModel);
        }

        public void CharacterDelete(SsoToken token, IList<int> contactIds)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_write_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV2CharacterDelete(token.CharacterId), _testing);

            string jsonObject = JsonConvert.SerializeObject(contactIds);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Delete(StaticMethods.CreateHeaders(token), url, jsonObject));
        }

        public async Task CharacterDeleteAsync(SsoToken token, IList<int> contactIds)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_write_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV2CharacterDelete(token.CharacterId), _testing);

            string jsonObject = JsonConvert.SerializeObject(contactIds);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.DeleteAsync(StaticMethods.CreateHeaders(token), url, jsonObject));
        }

        public PagedModel<V2ContactCharacter> Character(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV2Character(token.CharacterId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV2ContactCharacter> esiModel = JsonConvert.DeserializeObject<IList<EsiV2ContactCharacter>>(esiRaw.Model);

            IList<V2ContactCharacter> mapped = _mapper.Map<IList<EsiV2ContactCharacter>, IList<V2ContactCharacter>>(esiModel);

            return new PagedModel<V2ContactCharacter> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V2ContactCharacter>> CharacterAsync(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV2Character(token.CharacterId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV2ContactCharacter> esiModel = JsonConvert.DeserializeObject<IList<EsiV2ContactCharacter>>(esiRaw.Model);

            IList<V2ContactCharacter> mapped = _mapper.Map<IList<EsiV2ContactCharacter>, IList<V2ContactCharacter>>(esiModel);

            return new PagedModel<V2ContactCharacter> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public IList<int> CharacterAdd(SsoToken token, V2ContactCharacterAdd model)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_write_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV2CharacterAdd(token.CharacterId, model), _testing);

            string jsonObject = JsonConvert.SerializeObject(model.ContactIds);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, jsonObject));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> CharacterAddAsync(SsoToken token, V2ContactCharacterAdd model)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_write_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV2CharacterAdd(token.CharacterId, model), _testing);

            string jsonObject = JsonConvert.SerializeObject(model.ContactIds);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, jsonObject));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public void CharacterEdit(SsoToken token, V2ContactCharacterEdit model)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_write_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV2CharacterEdit(token.CharacterId, model), _testing);

            string jsonObject = JsonConvert.SerializeObject(model.ContactIds);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Put(StaticMethods.CreateHeaders(token), url, jsonObject));
        }

        public async Task CharacterEditAsync(SsoToken token, V2ContactCharacterEdit model)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_write_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV2CharacterEdit(token.CharacterId, model), _testing);

            string jsonObject = JsonConvert.SerializeObject(model.ContactIds);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PutAsync(StaticMethods.CreateHeaders(token), url, jsonObject));
        }

        public IList<V1ContactCharacterLabel> CharacterLabels(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV1CharacterLabels(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1ContactCharacterLabel> esiModel = JsonConvert.DeserializeObject<IList<EsiV1ContactCharacterLabel>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1ContactCharacterLabel>, IList<V1ContactCharacterLabel>>(esiModel);
        }

        public async Task<IList<V1ContactCharacterLabel>> CharacterLabelsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV1CharacterLabels(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1ContactCharacterLabel> esiModel = JsonConvert.DeserializeObject<IList<EsiV1ContactCharacterLabel>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1ContactCharacterLabel>, IList<V1ContactCharacterLabel>>(esiModel);
        }

        public PagedModel<V2ContactCorporation> Corporation(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV2Corporation(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV2ContactCorporation> esiModel = JsonConvert.DeserializeObject<IList<EsiV2ContactCorporation>>(esiRaw.Model);

            IList<V2ContactCorporation> mapped = _mapper.Map<IList<EsiV2ContactCorporation>, IList<V2ContactCorporation>>(esiModel);

            return new PagedModel<V2ContactCorporation> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V2ContactCorporation>> CorporationAsync(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV2Corporation(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV2ContactCorporation> esiModel = JsonConvert.DeserializeObject<IList<EsiV2ContactCorporation>>(esiRaw.Model);

            IList<V2ContactCorporation> mapped = _mapper.Map<IList<EsiV2ContactCorporation>, IList<V2ContactCorporation>>(esiModel);

            return new PagedModel<V2ContactCorporation> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public IList<V1ContactCorporationLabel> CorporationLabels(SsoToken token, int corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV1CorporationLabels(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1ContactCorporationLabel> esiModel = JsonConvert.DeserializeObject<IList<EsiV1ContactCorporationLabel>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1ContactCorporationLabel>, IList<V1ContactCorporationLabel>>(esiModel);
        }

        public async Task<IList<V1ContactCorporationLabel>> CorporationLabelsAsync(SsoToken token, int corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContactsV1CorporationLabels(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1ContactCorporationLabel> esiModel = JsonConvert.DeserializeObject<IList<EsiV1ContactCorporationLabel>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1ContactCorporationLabel>, IList<V1ContactCorporationLabel>>(esiModel);
        }
    }
}
