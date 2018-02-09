using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestAlliance : IInternalLatestAlliance
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalLatestAlliance(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AllianceMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public IList<int> GetActiveAlliances()
        {
            string url = StaticConnectionStrings.AlianceV1GetActiveAlliance();

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<int> esiActiveAlliances = JsonConvert.DeserializeObject<IList<int>>(esiRaw);

            return esiActiveAlliances;
        }

        public async Task<IList<int>> GetActiveAlliancesAsync()
        {
            string url = StaticConnectionStrings.AlianceV1GetActiveAlliance();

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<int> esiActiveAlliances = JsonConvert.DeserializeObject<IList<int>>(esiRaw);

            return esiActiveAlliances;
        }

        public V3GetPublicAlliance GetPublicAllianceInfo(int allianceId)
        {
            string url = StaticConnectionStrings.AllianceV3GetAlliancePublicInfo(allianceId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV3GetPublicAlliance esiPublicAlliance = JsonConvert.DeserializeObject<EsiV3GetPublicAlliance>(esiRaw);

            return _mapper.Map<EsiV3GetPublicAlliance, V3GetPublicAlliance>(esiPublicAlliance);
        }

        public async Task<V3GetPublicAlliance> GetPublicAllianceInfoAsync(int allianceId)
        {
            string url = StaticConnectionStrings.AllianceV3GetAlliancePublicInfo(allianceId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV3GetPublicAlliance esiPublicAlliance = JsonConvert.DeserializeObject<EsiV3GetPublicAlliance>(esiRaw);

            return _mapper.Map<EsiV3GetPublicAlliance, V3GetPublicAlliance>(esiPublicAlliance);
        }

        public IList<int> GetAllianceCorporation(int allianceId)
        {
            string url = StaticConnectionStrings.AllianceV1GetAllianceCorporations(allianceId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<int> esiAllianceCorporations = JsonConvert.DeserializeObject<IList<int>>(esiRaw);

            return esiAllianceCorporations;
        }

        public async Task<IList<int>> GetAllianceCorporationAsync(int allianceId)
        {
            string url = StaticConnectionStrings.AllianceV1GetAllianceCorporations(allianceId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<int> esiAllianceCorporations = JsonConvert.DeserializeObject<IList<int>>(esiRaw);

            return esiAllianceCorporations;
        }

        public V1AllianceIcons GetAllianceIcons(int allianceId)
        {
            string url = StaticConnectionStrings.AllianceV1GetAllianceIcons(allianceId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1AllianceIcons esiAllianceIcons = JsonConvert.DeserializeObject<EsiV1AllianceIcons>(esiRaw);

            return _mapper.Map<EsiV1AllianceIcons, V1AllianceIcons>(esiAllianceIcons);
        }

        public async Task<V1AllianceIcons> GetAllianceIconsAsync(int allianceId)
        {
            string url = StaticConnectionStrings.AllianceV1GetAllianceIcons(allianceId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1AllianceIcons esiAllianceIcons = JsonConvert.DeserializeObject<EsiV1AllianceIcons>(esiRaw);

            return _mapper.Map<EsiV1AllianceIcons, V1AllianceIcons>(esiAllianceIcons);
        }

        public IList<V2AllianceIdsToNames> GetAllianceNamesFromIds(IList<int> allianceIds)
        {
            string url = StaticConnectionStrings.AllianceV2IdsToNames(allianceIds);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV2AllianceIdsToNames> esiAllianceNames = JsonConvert.DeserializeObject<IList<EsiV2AllianceIdsToNames>>(esiRaw);

            return _mapper.Map<IList<EsiV2AllianceIdsToNames>, IList<V2AllianceIdsToNames>>(esiAllianceNames);
        }

        public async Task<IList<V2AllianceIdsToNames>> GetAllianceNamesFromIdsAsync(IList<int> allianceIds)
        {
            string url = StaticConnectionStrings.AllianceV2IdsToNames(allianceIds);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV2AllianceIdsToNames> esiAllianceNames = JsonConvert.DeserializeObject<IList<EsiV2AllianceIdsToNames>>(esiRaw);

            return _mapper.Map<IList<EsiV2AllianceIdsToNames>, IList<V2AllianceIdsToNames>>(esiAllianceNames);
        }
    }
}
