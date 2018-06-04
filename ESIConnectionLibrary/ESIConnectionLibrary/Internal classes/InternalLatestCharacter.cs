using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestCharacter : IInternalLatestCharacter
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalLatestCharacter(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CharacterMappings>();
                cfg.AddProfile<GeneralMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public V4CharactersPublicInfo GetCharactersPublicInfo(int characterId)
        {
            string url = StaticConnectionStrings.EsiV4CharactersPublicInfo(characterId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV4CharactersPublicInfo esiV4PublicInfo = JsonConvert.DeserializeObject<EsiV4CharactersPublicInfo>(esiRaw.Model);

            return _mapper.Map<EsiV4CharactersPublicInfo, V4CharactersPublicInfo>(esiV4PublicInfo);
        }

        public async Task<V4CharactersPublicInfo> GetCharactersPublicInfoAsync(int characterId)
        {
            string url = StaticConnectionStrings.EsiV4CharactersPublicInfo(characterId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV4CharactersPublicInfo esiV4PublicInfo = JsonConvert.DeserializeObject<EsiV4CharactersPublicInfo>(esiRaw.Model);

            return _mapper.Map<EsiV4CharactersPublicInfo, V4CharactersPublicInfo>(esiV4PublicInfo);
        }

        public IList<V1CharactersResearchAgents> GetCharactersResearchAgents(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_agents_research_v1);

            string url = StaticConnectionStrings.EsiV1CharactersResearchAgents(token.CharacterId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharactersResearchAgents> esiV1CharactersResearchAgents = JsonConvert.DeserializeObject<IList<EsiV1CharactersResearchAgents>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersResearchAgents>, IList<V1CharactersResearchAgents>>(esiV1CharactersResearchAgents);
        }

        public async Task<IList<V1CharactersResearchAgents>> GetCharactersResearchAgentsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_agents_research_v1);

            string url = StaticConnectionStrings.EsiV1CharactersResearchAgents(token.CharacterId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharactersResearchAgents> esiV1CharactersResearchAgents = JsonConvert.DeserializeObject<IList<EsiV1CharactersResearchAgents>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersResearchAgents>, IList<V1CharactersResearchAgents>>(esiV1CharactersResearchAgents);
        }

        public IList<V2CharactersBlueprints> GetCharactersBlueprint(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_blueprints_v1);

            string url = StaticConnectionStrings.EsiV2CharactersBlueprints(token.CharacterId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CharactersBlueprints> esiv2CharactersBlueprints = JsonConvert.DeserializeObject<IList<EsiV2CharactersBlueprints>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersBlueprints>, IList<V2CharactersBlueprints>>(esiv2CharactersBlueprints);
        }

        public async Task<IList<V2CharactersBlueprints>> GetCharactersBlueprintAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_blueprints_v1);

            string url = StaticConnectionStrings.EsiV2CharactersBlueprints(token.CharacterId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CharactersBlueprints> esiv2CharactersBlueprints = JsonConvert.DeserializeObject<IList<EsiV2CharactersBlueprints>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersBlueprints>, IList<V2CharactersBlueprints>>(esiv2CharactersBlueprints);
        }

        public IList<V1CharactersCorporationHistory> GetCharactersCorporationHistory(int characterId)
        {
            string url = StaticConnectionStrings.EsiV1CharactersCorporationHistory(characterId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1CharactersCorporationHistory> esiV1CharactersCorporationHistory = JsonConvert.DeserializeObject<IList<EsiV1CharactersCorporationHistory>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersCorporationHistory>, IList<V1CharactersCorporationHistory>>(esiV1CharactersCorporationHistory);
        }

        public async Task<IList<V1CharactersCorporationHistory>> GetCharactersCorporationHistoryAsync(int characterId)
        {
            string url = StaticConnectionStrings.EsiV1CharactersCorporationHistory(characterId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1CharactersCorporationHistory> esiV1CharactersCorporationHistory = JsonConvert.DeserializeObject<IList<EsiV1CharactersCorporationHistory>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersCorporationHistory>, IList<V1CharactersCorporationHistory>>(esiV1CharactersCorporationHistory);
        }

        public float GetCharactersCspaCost(SsoToken token, IList<int> characters)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_contacts_v1);

            string url = StaticConnectionStrings.EsiV4CharactersCspa(token.CharacterId);

            string jsonObject = JsonConvert.SerializeObject(characters);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, jsonObject));

            float esiV4CharactersCspa = JsonConvert.DeserializeObject<float>(esiRaw);

            return esiV4CharactersCspa;
        }

        public async Task<float> GetCharactersCspaCostAsync(SsoToken token, IList<int> characters)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_contacts_v1);

            string url = StaticConnectionStrings.EsiV4CharactersCspa(token.CharacterId);

            string jsonObject = JsonConvert.SerializeObject(characters);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, jsonObject));

            float esiV4CharactersCspa = JsonConvert.DeserializeObject<float>(esiRaw);

            return esiV4CharactersCspa;
        }

        public V1CharactersFatigue GetCharactersFatigue(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_fatigue_v1);

            string url = StaticConnectionStrings.EsiV1CharactersFatigue(token.CharacterId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            EsiV1CharactersFatigue esiV1CharactersFatigue = JsonConvert.DeserializeObject<EsiV1CharactersFatigue>(esiRaw.Model);

            return _mapper.Map<EsiV1CharactersFatigue, V1CharactersFatigue>(esiV1CharactersFatigue);
        }

        public async Task<V1CharactersFatigue> GetCharactersFatigueAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_fatigue_v1);

            string url = StaticConnectionStrings.EsiV1CharactersFatigue(token.CharacterId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            EsiV1CharactersFatigue esiV1CharactersFatigue = JsonConvert.DeserializeObject<EsiV1CharactersFatigue>(esiRaw.Model);

            return _mapper.Map<EsiV1CharactersFatigue, V1CharactersFatigue>(esiV1CharactersFatigue);
        }

        public IList<V1CharactersMedals> GetCharactersMedals(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_medals_v1);

            string url = StaticConnectionStrings.EsiV1CharactersMedals(token.CharacterId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharactersMedals> esiV1CharactersMedals = JsonConvert.DeserializeObject<IList<EsiV1CharactersMedals>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersMedals>, IList<V1CharactersMedals>>(esiV1CharactersMedals);
        }

        public async Task<IList<V1CharactersMedals>> GetCharactersMedalsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_medals_v1);

            string url = StaticConnectionStrings.EsiV1CharactersMedals(token.CharacterId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharactersMedals> esiV1CharactersMedals = JsonConvert.DeserializeObject<IList<EsiV1CharactersMedals>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersMedals>, IList<V1CharactersMedals>>(esiV1CharactersMedals);
        }

        public IList<V2CharactersNotifications> GetCharactersNotifications(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_notifications_v1);

            string url = StaticConnectionStrings.EsiV2CharactersNotifications(token.CharacterId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV2CharactersNotifications> esiV1Notifications = JsonConvert.DeserializeObject<IList<EsiV2CharactersNotifications>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersNotifications>, IList<V2CharactersNotifications>>(esiV1Notifications);
        }

        public async Task<IList<V2CharactersNotifications>> GetCharactersNotificationsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_notifications_v1);

            string url = StaticConnectionStrings.EsiV2CharactersNotifications(token.CharacterId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV2CharactersNotifications> esiV1Notifications = JsonConvert.DeserializeObject<IList<EsiV2CharactersNotifications>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersNotifications>, IList<V2CharactersNotifications>>(esiV1Notifications);
        }

        public IList<V1CharactersNotificationsContacts> GetCharactersNotificationsContacts(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_notifications_v1);

            string url = StaticConnectionStrings.EsiV1CharactersNotificationsContacts(token.CharacterId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV1CharactersNotificationsContacts> esiV1CharactersNotificationsContacts = JsonConvert.DeserializeObject<IList<EsiV1CharactersNotificationsContacts>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersNotificationsContacts>, IList<V1CharactersNotificationsContacts>>(esiV1CharactersNotificationsContacts);
        }

        public async Task<IList<V1CharactersNotificationsContacts>> GetCharactersNotificationsContactsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_notifications_v1);

            string url = StaticConnectionStrings.EsiV1CharactersNotificationsContacts(token.CharacterId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV1CharactersNotificationsContacts> esiV1CharactersNotificationsContacts = JsonConvert.DeserializeObject<IList<EsiV1CharactersNotificationsContacts>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersNotificationsContacts>, IList<V1CharactersNotificationsContacts>>(esiV1CharactersNotificationsContacts);
        }

        public V2CharactersPortrait GetCharactersPortrait(int characterId)
        {
            string url = StaticConnectionStrings.EsiV2CharactersPortrait(characterId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV2CharactersPortrait esiV2CharactersPortrait = JsonConvert.DeserializeObject<EsiV2CharactersPortrait>(esiRaw.Model);

            return _mapper.Map<EsiV2CharactersPortrait, V2CharactersPortrait>(esiV2CharactersPortrait);
        }

        public async Task<V2CharactersPortrait> GetCharactersPortraitAsync(int characterId)
        {
            string url = StaticConnectionStrings.EsiV2CharactersPortrait(characterId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV2CharactersPortrait esiV2CharactersPortrait = JsonConvert.DeserializeObject<EsiV2CharactersPortrait>(esiRaw.Model);

            return _mapper.Map<EsiV2CharactersPortrait, V2CharactersPortrait>(esiV2CharactersPortrait);
        }

        public V2CharacterRoles GetCharactersRoles(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_corporation_roles_v1);

            string url = StaticConnectionStrings.EsiV2CharacterRoles(token.CharacterId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV2CharacterRoles esiV2CharacterRoles = JsonConvert.DeserializeObject<EsiV2CharacterRoles>(esiRaw.Model);

            return _mapper.Map<EsiV2CharacterRoles, V2CharacterRoles>(esiV2CharacterRoles);
        }

        public async Task<V2CharacterRoles> GetCharactersRolesAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_corporation_roles_v1);

            string url = StaticConnectionStrings.EsiV2CharacterRoles(token.CharacterId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV2CharacterRoles esiV2CharacterRoles = JsonConvert.DeserializeObject<EsiV2CharacterRoles>(esiRaw.Model);

            return _mapper.Map<EsiV2CharacterRoles, V2CharacterRoles>(esiV2CharacterRoles);
        }

        public IList<V2CharactersStandings> GetCharactersStandings(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_standings_v1);

            string url = StaticConnectionStrings.EsiV2CharactersStandings(token.CharacterId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CharactersStandings> esiV2CharactersStandings = JsonConvert.DeserializeObject<IList<EsiV2CharactersStandings>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersStandings>, IList<V2CharactersStandings>>(esiV2CharactersStandings);
        }

        public async Task<IList<V2CharactersStandings>> GetCharactersStandingsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_standings_v1);

            string url = StaticConnectionStrings.EsiV2CharactersStandings(token.CharacterId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CharactersStandings> esiV2CharactersStandings = JsonConvert.DeserializeObject<IList<EsiV2CharactersStandings>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersStandings>, IList<V2CharactersStandings>>(esiV2CharactersStandings);
        }

        public IList<V2CharactersStats> GetCharactersStats(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characterstats_read_v1);

            string url = StaticConnectionStrings.EsiV2CharactersStats(token.CharacterId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 86400));

            IList<EsiV2CharactersStats> esiV2CharactersStats = JsonConvert.DeserializeObject<IList<EsiV2CharactersStats>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersStats>, IList<V2CharactersStats>>(esiV2CharactersStats);
        }

        public async Task<IList<V2CharactersStats>> GetCharactersStatsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characterstats_read_v1);

            string url = StaticConnectionStrings.EsiV2CharactersStats(token.CharacterId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 86400));

            IList<EsiV2CharactersStats> esiV2CharactersStats = JsonConvert.DeserializeObject<IList<EsiV2CharactersStats>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersStats>, IList<V2CharactersStats>>(esiV2CharactersStats);
        }

        public IList<V1CharacterTitles> GetCharactersTitles(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_titles_v1);

            string url = StaticConnectionStrings.EsiV1CharacterTitles(token.CharacterId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharacterTitles> esiV1CharacterTitles = JsonConvert.DeserializeObject<IList<EsiV1CharacterTitles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharacterTitles>, IList<V1CharacterTitles>>(esiV1CharacterTitles);
        }

        public async Task<IList<V1CharacterTitles>> GetCharactersTitlesAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_titles_v1);

            string url = StaticConnectionStrings.EsiV1CharacterTitles(token.CharacterId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharacterTitles> esiV1CharacterTitles = JsonConvert.DeserializeObject<IList<EsiV1CharacterTitles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharacterTitles>, IList<V1CharacterTitles>>(esiV1CharacterTitles);
        }

        public IList<V1CharacterAffiliations> GetCharactersAffiliation(IList<int> characters)
        {
            string url = StaticConnectionStrings.EsiV1CharacterAffiliations();

            string jsonObject = JsonConvert.SerializeObject(characters);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(), url, jsonObject, 3600));

            IList<EsiV1CharacterAffiliations> esiV1CharacterAffiliations = JsonConvert.DeserializeObject<IList<EsiV1CharacterAffiliations>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharacterAffiliations>, IList<V1CharacterAffiliations>>(esiV1CharacterAffiliations);
        }

        public async Task<IList<V1CharacterAffiliations>> GetCharactersAffiliationAsync(IList<int> characters)
        {
            string url = StaticConnectionStrings.EsiV1CharacterAffiliations();

            string jsonObject = JsonConvert.SerializeObject(characters);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(), url, jsonObject, 3600));

            IList<EsiV1CharacterAffiliations> esiV1CharacterAffiliations = JsonConvert.DeserializeObject<IList<EsiV1CharacterAffiliations>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharacterAffiliations>, IList<V1CharacterAffiliations>>(esiV1CharacterAffiliations);
        }

        public IList<V1CharactersNames> GetCharactersNames(IList<int> characters)
        {
            string url = StaticConnectionStrings.EsiV1CharactersNames(characters);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1CharactersNames> esiV1CharactersNames = JsonConvert.DeserializeObject<IList<EsiV1CharactersNames>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersNames>, IList<V1CharactersNames>>(esiV1CharactersNames);
        }

        public async Task<IList<V1CharactersNames>> GetCharactersNamesAsync(IList<int> characters)
        {
            string url = StaticConnectionStrings.EsiV1CharactersNames(characters);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1CharactersNames> esiV1CharactersNames = JsonConvert.DeserializeObject<IList<EsiV1CharactersNames>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersNames>, IList<V1CharactersNames>>(esiV1CharactersNames);
        }
    }
}
