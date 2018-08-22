using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestAlliance : IInternalLatestAlliance
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestAlliance(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public IList<int> GetActiveAlliances()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AlianceV1GetActiveAlliance(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<int> esiActiveAlliances = JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);

            return esiActiveAlliances;
        }

        public async Task<IList<int>> GetActiveAlliancesAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AlianceV1GetActiveAlliance(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<int> esiActiveAlliances = JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);

            return esiActiveAlliances;
        }

        public V3GetPublicAlliance GetPublicAllianceInfo(int allianceId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AllianceV3GetAlliancePublicInfo(allianceId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV3GetPublicAlliance esiPublicAlliance = JsonConvert.DeserializeObject<EsiV3GetPublicAlliance>(esiRaw.Model);

            return _mapper.Map<EsiV3GetPublicAlliance, V3GetPublicAlliance>(esiPublicAlliance);
        }

        public async Task<V3GetPublicAlliance> GetPublicAllianceInfoAsync(int allianceId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AllianceV3GetAlliancePublicInfo(allianceId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV3GetPublicAlliance esiPublicAlliance = JsonConvert.DeserializeObject<EsiV3GetPublicAlliance>(esiRaw.Model);

            return _mapper.Map<EsiV3GetPublicAlliance, V3GetPublicAlliance>(esiPublicAlliance);
        }

        public IList<int> GetAllianceCorporation(int allianceId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AllianceV1GetAllianceCorporations(allianceId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<int> esiAllianceCorporations = JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);

            return esiAllianceCorporations;
        }

        public async Task<IList<int>> GetAllianceCorporationAsync(int allianceId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AllianceV1GetAllianceCorporations(allianceId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<int> esiAllianceCorporations = JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);

            return esiAllianceCorporations;
        }

        public V1AllianceIcons GetAllianceIcons(int allianceId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AllianceV1GetAllianceIcons(allianceId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1AllianceIcons esiAllianceIcons = JsonConvert.DeserializeObject<EsiV1AllianceIcons>(esiRaw.Model);

            return _mapper.Map<EsiV1AllianceIcons, V1AllianceIcons>(esiAllianceIcons);
        }

        public async Task<V1AllianceIcons> GetAllianceIconsAsync(int allianceId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AllianceV1GetAllianceIcons(allianceId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1AllianceIcons esiAllianceIcons = JsonConvert.DeserializeObject<EsiV1AllianceIcons>(esiRaw.Model);

            return _mapper.Map<EsiV1AllianceIcons, V1AllianceIcons>(esiAllianceIcons);
        }
    }
}
