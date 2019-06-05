using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.Automapper_Profiles;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestOpportunities : IInternalLatestOpportunities
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestOpportunities(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<OpportunitiesProfile>();
                });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        private int SecondsToDT()
        {
            DateTime now = DateTime.Now;

            DateTime todaysDt = new DateTime(now.Year, now.Month, now.Day, 11, 5, 0);

            if ((todaysDt - now).TotalSeconds < 0)
            {
                return (int)(todaysDt.AddDays(1) - now).TotalSeconds;
            }

            return (int)(todaysDt - now).TotalSeconds;
        }

        public IList<V1OpportunitiesCharacter> Character(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_opportunities_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.OpportunitiesV1Character(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1OpportunitiesCharacter> esiModel = JsonConvert.DeserializeObject<IList<EsiV1OpportunitiesCharacter>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1OpportunitiesCharacter>, IList<V1OpportunitiesCharacter>>(esiModel);
        }

        public async Task<IList<V1OpportunitiesCharacter>> CharacterAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_opportunities_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.OpportunitiesV1Character(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1OpportunitiesCharacter> esiModel = JsonConvert.DeserializeObject<IList<EsiV1OpportunitiesCharacter>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1OpportunitiesCharacter>, IList<V1OpportunitiesCharacter>>(esiModel);
        }

        public IList<int> Groups()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.OpportunitiesV1Groups(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> GroupsAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.OpportunitiesV1Groups(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public V1OpportunitiesGroup Group(int groupId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.OpportunitiesV1Group(groupId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1OpportunitiesGroup esiModel = JsonConvert.DeserializeObject<EsiV1OpportunitiesGroup>(esiRaw.Model);

            return _mapper.Map<V1OpportunitiesGroup>(esiModel);
        }

        public async Task<V1OpportunitiesGroup> GroupAsync(int groupId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.OpportunitiesV1Group(groupId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1OpportunitiesGroup esiModel = JsonConvert.DeserializeObject<EsiV1OpportunitiesGroup>(esiRaw.Model);

            return _mapper.Map<V1OpportunitiesGroup>(esiModel);
        }

        public IList<int> Tasks()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.OpportunitiesV1Tasks(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> TasksAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.OpportunitiesV1Tasks(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public V1OpportunitiesTask Task(int taskId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.OpportunitiesV1Task(taskId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1OpportunitiesTask esiModel = JsonConvert.DeserializeObject<EsiV1OpportunitiesTask>(esiRaw.Model);

            return _mapper.Map<V1OpportunitiesTask>(esiModel);
        }

        public async Task<V1OpportunitiesTask> TaskAsync(int taskId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.OpportunitiesV1Task(taskId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1OpportunitiesTask esiModel = JsonConvert.DeserializeObject<EsiV1OpportunitiesTask>(esiRaw.Model);

            return _mapper.Map<V1OpportunitiesTask>(esiModel);
        }
    }
}
