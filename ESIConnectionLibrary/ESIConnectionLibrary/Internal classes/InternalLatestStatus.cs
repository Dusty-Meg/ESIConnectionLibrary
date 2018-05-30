using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestStatus : IInternalLatestStatus
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalLatestStatus(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UniverseMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public V1Status GetStatus()
        {
            string url = StaticConnectionStrings.StatusV1Status();

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 30));

            EsiV1Status esiStatus = JsonConvert.DeserializeObject<EsiV1Status>(esiRaw);

            return _mapper.Map<V1Status>(esiStatus);
        }

        public async Task<V1Status> GetStatusAsync()
        {
            string url = StaticConnectionStrings.StatusV1Status();

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 30));

            EsiV1Status esiStatus = JsonConvert.DeserializeObject<EsiV1Status>(esiRaw);

            return _mapper.Map<V1Status>(esiStatus);
        }
    }
}
