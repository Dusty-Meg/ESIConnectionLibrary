using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestFactionWarfare : IInternalLatestFactionWarfare
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestFactionWarfare(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

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

        public V1FwCharacterStats CharacterStats(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_fw_stats_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FactionWarfareV1CharacterStats(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, SecondsToDT()));

            EsiV1FwCharacterStats esiModel = JsonConvert.DeserializeObject<EsiV1FwCharacterStats>(esiRaw.Model);

            return _mapper.Map<EsiV1FwCharacterStats, V1FwCharacterStats>(esiModel);
        }

        public async Task<V1FwCharacterStats> CharacterStatsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_fw_stats_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FactionWarfareV1CharacterStats(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, SecondsToDT()));

            EsiV1FwCharacterStats esiModel = JsonConvert.DeserializeObject<EsiV1FwCharacterStats>(esiRaw.Model);

            return _mapper.Map<EsiV1FwCharacterStats, V1FwCharacterStats>(esiModel);
        }

        public V1FwCorporationStats CorporationStats(SsoToken token, int corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_fw_stats_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FactionWarfareV1CorporationStats(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, SecondsToDT()));

            EsiV1FwCorporationStats esiModel = JsonConvert.DeserializeObject<EsiV1FwCorporationStats>(esiRaw.Model);

            return _mapper.Map<EsiV1FwCorporationStats, V1FwCorporationStats>(esiModel);
        }

        public async Task<V1FwCorporationStats> CorporationStatsAsync(SsoToken token, int corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_fw_stats_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FactionWarfareV1CorporationStats(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, SecondsToDT()));

            EsiV1FwCorporationStats esiModel = JsonConvert.DeserializeObject<EsiV1FwCorporationStats>(esiRaw.Model);

            return _mapper.Map<EsiV1FwCorporationStats, V1FwCorporationStats>(esiModel);
        }

        public V1FwFactionLeaderboard FactionLeaderboard()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FactionWarfareV1FactionLeaderboard(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1FwFactionLeaderboard esiModel = JsonConvert.DeserializeObject<EsiV1FwFactionLeaderboard>(esiRaw.Model);

            return _mapper.Map<EsiV1FwFactionLeaderboard, V1FwFactionLeaderboard>(esiModel);
        }

        public async Task<V1FwFactionLeaderboard> FactionLeaderboardAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FactionWarfareV1FactionLeaderboard(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1FwFactionLeaderboard esiModel = JsonConvert.DeserializeObject<EsiV1FwFactionLeaderboard>(esiRaw.Model);

            return _mapper.Map<EsiV1FwFactionLeaderboard, V1FwFactionLeaderboard>(esiModel);
        }

        public V1FwCharacterLeaderboard CharacterLeaderboard()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FactionWarfareV1CharacterLeaderboard(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1FwCharacterLeaderboard esiModel = JsonConvert.DeserializeObject<EsiV1FwCharacterLeaderboard>(esiRaw.Model);

            return _mapper.Map<EsiV1FwCharacterLeaderboard, V1FwCharacterLeaderboard>(esiModel);
        }

        public async Task<V1FwCharacterLeaderboard> CharacterLeaderboardAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FactionWarfareV1CharacterLeaderboard(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1FwCharacterLeaderboard esiModel = JsonConvert.DeserializeObject<EsiV1FwCharacterLeaderboard>(esiRaw.Model);

            return _mapper.Map<EsiV1FwCharacterLeaderboard, V1FwCharacterLeaderboard>(esiModel);
        }

        public V1FwCorporationLeaderboard CorporationLeaderboard()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FactionWarfareV1CorporationLeaderboard(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1FwCorporationLeaderboard esiModel = JsonConvert.DeserializeObject<EsiV1FwCorporationLeaderboard>(esiRaw.Model);

            return _mapper.Map<EsiV1FwCorporationLeaderboard, V1FwCorporationLeaderboard>(esiModel);
        }

        public async Task<V1FwCorporationLeaderboard> CorporationLeaderboardAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FactionWarfareV1CorporationLeaderboard(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1FwCorporationLeaderboard esiModel = JsonConvert.DeserializeObject<EsiV1FwCorporationLeaderboard>(esiRaw.Model);

            return _mapper.Map<EsiV1FwCorporationLeaderboard, V1FwCorporationLeaderboard>(esiModel);
        }

        public IList<V1FwFactionStats> FactionStats()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FactionWarfareV1FactionStats(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV1FwFactionStats> esiModel = JsonConvert.DeserializeObject<IList<EsiV1FwFactionStats>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1FwFactionStats>, IList<V1FwFactionStats>>(esiModel);
        }

        public async Task<IList<V1FwFactionStats>> FactionStatsAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FactionWarfareV1FactionStats(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV1FwFactionStats> esiModel = JsonConvert.DeserializeObject<IList<EsiV1FwFactionStats>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1FwFactionStats>, IList<V1FwFactionStats>>(esiModel);
        }

        public IList<V2FwSystems> Systems()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FactionWarfareV2Systems(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 1800));

            IList<EsiV2FwSystems> esiModel = JsonConvert.DeserializeObject<IList<EsiV2FwSystems>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2FwSystems>, IList<V2FwSystems>>(esiModel);
        }

        public async Task<IList<V2FwSystems>> SystemsAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FactionWarfareV2Systems(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 1800));

            IList<EsiV2FwSystems> esiModel = JsonConvert.DeserializeObject<IList<EsiV2FwSystems>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2FwSystems>, IList<V2FwSystems>>(esiModel);
        }

        public IList<V1FwWars> Wars()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FactionWarfareV1Wars(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV1FwWars> esiModel = JsonConvert.DeserializeObject<IList<EsiV1FwWars>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1FwWars>, IList<V1FwWars>>(esiModel);
        }

        public async Task<IList<V1FwWars>> WarsAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FactionWarfareV1Wars(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV1FwWars> esiModel = JsonConvert.DeserializeObject<IList<EsiV1FwWars>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1FwWars>, IList<V1FwWars>>(esiModel);
        }
    }
}
