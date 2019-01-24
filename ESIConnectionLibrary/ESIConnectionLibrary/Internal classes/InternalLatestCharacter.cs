using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestCharacter : IInternalLatestCharacter
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestCharacter(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public V4CharactersPublicInfo GetCharactersPublicInfo(int characterId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV4CharactersPublicInfo(characterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV4CharactersPublicInfo esiV4PublicInfo = JsonConvert.DeserializeObject<EsiV4CharactersPublicInfo>(esiRaw.Model);

            return _mapper.Map<EsiV4CharactersPublicInfo, V4CharactersPublicInfo>(esiV4PublicInfo);
        }

        public async Task<V4CharactersPublicInfo> GetCharactersPublicInfoAsync(int characterId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV4CharactersPublicInfo(characterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV4CharactersPublicInfo esiV4PublicInfo = JsonConvert.DeserializeObject<EsiV4CharactersPublicInfo>(esiRaw.Model);

            return _mapper.Map<EsiV4CharactersPublicInfo, V4CharactersPublicInfo>(esiV4PublicInfo);
        }

        public IList<V1CharactersResearchAgents> GetCharactersResearchAgents(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_agents_research_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV1CharactersResearchAgents(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharactersResearchAgents> esiV1CharactersResearchAgents = JsonConvert.DeserializeObject<IList<EsiV1CharactersResearchAgents>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersResearchAgents>, IList<V1CharactersResearchAgents>>(esiV1CharactersResearchAgents);
        }

        public async Task<IList<V1CharactersResearchAgents>> GetCharactersResearchAgentsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_agents_research_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV1CharactersResearchAgents(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharactersResearchAgents> esiV1CharactersResearchAgents = JsonConvert.DeserializeObject<IList<EsiV1CharactersResearchAgents>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersResearchAgents>, IList<V1CharactersResearchAgents>>(esiV1CharactersResearchAgents);
        }

        public IList<V2CharactersBlueprints> GetCharactersBlueprint(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_blueprints_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharactersBlueprints(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CharactersBlueprints> esiv2CharactersBlueprints = JsonConvert.DeserializeObject<IList<EsiV2CharactersBlueprints>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersBlueprints>, IList<V2CharactersBlueprints>>(esiv2CharactersBlueprints);
        }

        public async Task<IList<V2CharactersBlueprints>> GetCharactersBlueprintAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_blueprints_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharactersBlueprints(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CharactersBlueprints> esiv2CharactersBlueprints = JsonConvert.DeserializeObject<IList<EsiV2CharactersBlueprints>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersBlueprints>, IList<V2CharactersBlueprints>>(esiv2CharactersBlueprints);
        }

        public IList<V1CharactersCorporationHistory> GetCharactersCorporationHistory(int characterId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV1CharactersCorporationHistory(characterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1CharactersCorporationHistory> esiV1CharactersCorporationHistory = JsonConvert.DeserializeObject<IList<EsiV1CharactersCorporationHistory>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersCorporationHistory>, IList<V1CharactersCorporationHistory>>(esiV1CharactersCorporationHistory);
        }

        public async Task<IList<V1CharactersCorporationHistory>> GetCharactersCorporationHistoryAsync(int characterId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV1CharactersCorporationHistory(characterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1CharactersCorporationHistory> esiV1CharactersCorporationHistory = JsonConvert.DeserializeObject<IList<EsiV1CharactersCorporationHistory>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersCorporationHistory>, IList<V1CharactersCorporationHistory>>(esiV1CharactersCorporationHistory);
        }

        public float GetCharactersCspaCost(SsoToken token, IList<int> characters)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV4CharactersCspa(token.CharacterId), _testing);

            string jsonObject = JsonConvert.SerializeObject(characters);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, jsonObject));

            float esiV4CharactersCspa = JsonConvert.DeserializeObject<float>(esiRaw.Model);

            return esiV4CharactersCspa;
        }

        public async Task<float> GetCharactersCspaCostAsync(SsoToken token, IList<int> characters)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV4CharactersCspa(token.CharacterId), _testing);

            string jsonObject = JsonConvert.SerializeObject(characters);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, jsonObject));

            float esiV4CharactersCspa = JsonConvert.DeserializeObject<float>(esiRaw.Model);

            return esiV4CharactersCspa;
        }

        public V1CharactersFatigue GetCharactersFatigue(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_fatigue_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV1CharactersFatigue(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            EsiV1CharactersFatigue esiV1CharactersFatigue = JsonConvert.DeserializeObject<EsiV1CharactersFatigue>(esiRaw.Model);

            return _mapper.Map<EsiV1CharactersFatigue, V1CharactersFatigue>(esiV1CharactersFatigue);
        }

        public async Task<V1CharactersFatigue> GetCharactersFatigueAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_fatigue_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV1CharactersFatigue(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            EsiV1CharactersFatigue esiV1CharactersFatigue = JsonConvert.DeserializeObject<EsiV1CharactersFatigue>(esiRaw.Model);

            return _mapper.Map<EsiV1CharactersFatigue, V1CharactersFatigue>(esiV1CharactersFatigue);
        }

        public IList<V1CharactersMedals> GetCharactersMedals(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_medals_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV1CharactersMedals(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharactersMedals> esiV1CharactersMedals = JsonConvert.DeserializeObject<IList<EsiV1CharactersMedals>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersMedals>, IList<V1CharactersMedals>>(esiV1CharactersMedals);
        }

        public async Task<IList<V1CharactersMedals>> GetCharactersMedalsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_medals_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV1CharactersMedals(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharactersMedals> esiV1CharactersMedals = JsonConvert.DeserializeObject<IList<EsiV1CharactersMedals>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersMedals>, IList<V1CharactersMedals>>(esiV1CharactersMedals);
        }

        public IList<V4CharactersNotifications> GetCharactersNotifications(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_notifications_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV4CharactersNotifications(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV4CharactersNotifications> esiV1Notifications = JsonConvert.DeserializeObject<IList<EsiV4CharactersNotifications>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV4CharactersNotifications>, IList<V4CharactersNotifications>>(esiV1Notifications);
        }

        public async Task<IList<V4CharactersNotifications>> GetCharactersNotificationsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_notifications_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV4CharactersNotifications(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV4CharactersNotifications> esiV1Notifications = JsonConvert.DeserializeObject<IList<EsiV4CharactersNotifications>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV4CharactersNotifications>, IList<V4CharactersNotifications>>(esiV1Notifications);
        }

        public IList<V1CharactersNotificationsContacts> GetCharactersNotificationsContacts(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_notifications_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV1CharactersNotificationsContacts(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV1CharactersNotificationsContacts> esiV1CharactersNotificationsContacts = JsonConvert.DeserializeObject<IList<EsiV1CharactersNotificationsContacts>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersNotificationsContacts>, IList<V1CharactersNotificationsContacts>>(esiV1CharactersNotificationsContacts);
        }

        public async Task<IList<V1CharactersNotificationsContacts>> GetCharactersNotificationsContactsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_notifications_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV1CharactersNotificationsContacts(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV1CharactersNotificationsContacts> esiV1CharactersNotificationsContacts = JsonConvert.DeserializeObject<IList<EsiV1CharactersNotificationsContacts>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersNotificationsContacts>, IList<V1CharactersNotificationsContacts>>(esiV1CharactersNotificationsContacts);
        }

        public V2CharactersPortrait GetCharactersPortrait(int characterId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharactersPortrait(characterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV2CharactersPortrait esiV2CharactersPortrait = JsonConvert.DeserializeObject<EsiV2CharactersPortrait>(esiRaw.Model);

            return _mapper.Map<EsiV2CharactersPortrait, V2CharactersPortrait>(esiV2CharactersPortrait);
        }

        public async Task<V2CharactersPortrait> GetCharactersPortraitAsync(int characterId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharactersPortrait(characterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV2CharactersPortrait esiV2CharactersPortrait = JsonConvert.DeserializeObject<EsiV2CharactersPortrait>(esiRaw.Model);

            return _mapper.Map<EsiV2CharactersPortrait, V2CharactersPortrait>(esiV2CharactersPortrait);
        }

        public V2CharacterRoles GetCharactersRoles(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_corporation_roles_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharacterRoles(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV2CharacterRoles esiV2CharacterRoles = JsonConvert.DeserializeObject<EsiV2CharacterRoles>(esiRaw.Model);

            return _mapper.Map<EsiV2CharacterRoles, V2CharacterRoles>(esiV2CharacterRoles);
        }

        public async Task<V2CharacterRoles> GetCharactersRolesAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_corporation_roles_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharacterRoles(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV2CharacterRoles esiV2CharacterRoles = JsonConvert.DeserializeObject<EsiV2CharacterRoles>(esiRaw.Model);

            return _mapper.Map<EsiV2CharacterRoles, V2CharacterRoles>(esiV2CharacterRoles);
        }

        public IList<V2CharactersStandings> GetCharactersStandings(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_standings_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharactersStandings(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CharactersStandings> esiV2CharactersStandings = JsonConvert.DeserializeObject<IList<EsiV2CharactersStandings>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersStandings>, IList<V2CharactersStandings>>(esiV2CharactersStandings);
        }

        public async Task<IList<V2CharactersStandings>> GetCharactersStandingsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_standings_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharactersStandings(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CharactersStandings> esiV2CharactersStandings = JsonConvert.DeserializeObject<IList<EsiV2CharactersStandings>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersStandings>, IList<V2CharactersStandings>>(esiV2CharactersStandings);
        }

        public IList<V2CharactersStats> GetCharactersStats(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characterstats_read_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharactersStats(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 86400));

            IList<EsiV2CharactersStats> esiV2CharactersStats = JsonConvert.DeserializeObject<IList<EsiV2CharactersStats>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersStats>, IList<V2CharactersStats>>(esiV2CharactersStats);
        }

        public async Task<IList<V2CharactersStats>> GetCharactersStatsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characterstats_read_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharactersStats(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 86400));

            IList<EsiV2CharactersStats> esiV2CharactersStats = JsonConvert.DeserializeObject<IList<EsiV2CharactersStats>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersStats>, IList<V2CharactersStats>>(esiV2CharactersStats);
        }

        public IList<V1CharacterTitles> GetCharactersTitles(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_titles_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV1CharacterTitles(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharacterTitles> esiV1CharacterTitles = JsonConvert.DeserializeObject<IList<EsiV1CharacterTitles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharacterTitles>, IList<V1CharacterTitles>>(esiV1CharacterTitles);
        }

        public async Task<IList<V1CharacterTitles>> GetCharactersTitlesAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_titles_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV1CharacterTitles(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharacterTitles> esiV1CharacterTitles = JsonConvert.DeserializeObject<IList<EsiV1CharacterTitles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharacterTitles>, IList<V1CharacterTitles>>(esiV1CharacterTitles);
        }

        public IList<V1CharacterAffiliations> GetCharactersAffiliation(IList<int> characters)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV1CharacterAffiliations(), _testing);

            string jsonObject = JsonConvert.SerializeObject(characters);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(), url, jsonObject, 3600));

            IList<EsiV1CharacterAffiliations> esiV1CharacterAffiliations = JsonConvert.DeserializeObject<IList<EsiV1CharacterAffiliations>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharacterAffiliations>, IList<V1CharacterAffiliations>>(esiV1CharacterAffiliations);
        }

        public async Task<IList<V1CharacterAffiliations>> GetCharactersAffiliationAsync(IList<int> characters)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV1CharacterAffiliations(), _testing);

            string jsonObject = JsonConvert.SerializeObject(characters);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(), url, jsonObject, 3600));

            IList<EsiV1CharacterAffiliations> esiV1CharacterAffiliations = JsonConvert.DeserializeObject<IList<EsiV1CharacterAffiliations>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharacterAffiliations>, IList<V1CharacterAffiliations>>(esiV1CharacterAffiliations);
        }
    }
}
