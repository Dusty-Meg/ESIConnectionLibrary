using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestStatus : IInternalLatestStatus
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestStatus(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public V1Status Status()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.StatusV1Status(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 30));

            EsiV1Status esiModel = JsonConvert.DeserializeObject<EsiV1Status>(esiRaw.Model);

            return _mapper.Map<V1Status>(esiModel);
        }

        public async Task<V1Status> StatusAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.StatusV1Status(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 30));

            EsiV1Status esiModel = JsonConvert.DeserializeObject<EsiV1Status>(esiRaw.Model);

            return _mapper.Map<V1Status>(esiModel);
        }
    }
}
