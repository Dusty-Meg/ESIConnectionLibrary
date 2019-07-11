using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.Automapper_Profiles;
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
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<AllianceProfile>();
                });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public IList<int> Alliances()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AllianceV1Alliance(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<int> esiActiveAlliances = JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);

            return esiActiveAlliances;
        }

        public async Task<IList<int>> AlliancesAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AllianceV1Alliance(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<int> esiActiveAlliances = JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);

            return esiActiveAlliances;
        }

        public V3AlliancePublicInfo PublicInfo(int allianceId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AllianceV3PublicInfo(allianceId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV3AlliancePublicInfo esiPublicInfo = JsonConvert.DeserializeObject<EsiV3AlliancePublicInfo>(esiRaw.Model);

            return _mapper.Map<EsiV3AlliancePublicInfo, V3AlliancePublicInfo>(esiPublicInfo);
        }

        public async Task<V3AlliancePublicInfo> PublicInfoAsync(int allianceId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AllianceV3PublicInfo(allianceId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV3AlliancePublicInfo esiPublicInfo = JsonConvert.DeserializeObject<EsiV3AlliancePublicInfo>(esiRaw.Model);

            return _mapper.Map<EsiV3AlliancePublicInfo, V3AlliancePublicInfo>(esiPublicInfo);
        }

        public IList<int> Corporations(int allianceId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AllianceV1Corporations(allianceId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<int> esiAllianceCorporations = JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);

            return esiAllianceCorporations;
        }

        public async Task<IList<int>> CorporationsAsync(int allianceId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AllianceV1Corporations(allianceId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<int> esiAllianceCorporations = JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);

            return esiAllianceCorporations;
        }

        public V1AllianceIcons Icons(int allianceId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AllianceV1Icons(allianceId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1AllianceIcons esiAllianceIcons = JsonConvert.DeserializeObject<EsiV1AllianceIcons>(esiRaw.Model);

            return _mapper.Map<EsiV1AllianceIcons, V1AllianceIcons>(esiAllianceIcons);
        }

        public async Task<V1AllianceIcons> IconsAsync(int allianceId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.AllianceV1Icons(allianceId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1AllianceIcons esiAllianceIcons = JsonConvert.DeserializeObject<EsiV1AllianceIcons>(esiRaw.Model);

            return _mapper.Map<EsiV1AllianceIcons, V1AllianceIcons>(esiAllianceIcons);
        }
    }
}
