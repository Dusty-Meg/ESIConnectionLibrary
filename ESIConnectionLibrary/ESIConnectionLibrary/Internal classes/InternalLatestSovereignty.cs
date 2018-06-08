using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestSovereignty : IInternalLatestSovereignty
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestSovereignty(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SovereigntyMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public IList<V1SovereigntyCampaigns> GetCampaigns()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.SovereigntyV1Campaigns(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 5));

            IList<EsiV1SovereigntyCampaigns> esiModel = JsonConvert.DeserializeObject<IList<EsiV1SovereigntyCampaigns>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1SovereigntyCampaigns>, IList<V1SovereigntyCampaigns>>(esiModel);
        }

        public async Task<IList<V1SovereigntyCampaigns>> GetCampaignsAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.SovereigntyV1Campaigns(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 5));

            IList<EsiV1SovereigntyCampaigns> esiModel = JsonConvert.DeserializeObject<IList<EsiV1SovereigntyCampaigns>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1SovereigntyCampaigns>, IList<V1SovereigntyCampaigns>>(esiModel);
        }

        public IList<V1SovereigntyMap> GetMap()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.SovereigntyV1Map(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1SovereigntyMap> esiModel = JsonConvert.DeserializeObject<IList<EsiV1SovereigntyMap>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1SovereigntyMap>, IList<V1SovereigntyMap>>(esiModel);
        }

        public async Task<IList<V1SovereigntyMap>> GetMapAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.SovereigntyV1Map(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1SovereigntyMap> esiModel = JsonConvert.DeserializeObject<IList<EsiV1SovereigntyMap>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1SovereigntyMap>, IList<V1SovereigntyMap>>(esiModel);
        }

        public IList<V1SovereigntyStructures> GetStructures()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.SovereigntyV1Structures(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 120));

            IList<EsiV1SovereigntyStructures> esiModel = JsonConvert.DeserializeObject<IList<EsiV1SovereigntyStructures>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1SovereigntyStructures>, IList<V1SovereigntyStructures>>(esiModel);
        }

        public async Task<IList<V1SovereigntyStructures>> GetStructuresAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.SovereigntyV1Structures(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 120));

            IList<EsiV1SovereigntyStructures> esiModel = JsonConvert.DeserializeObject<IList<EsiV1SovereigntyStructures>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1SovereigntyStructures>, IList<V1SovereigntyStructures>>(esiModel);
        }
    }
}
