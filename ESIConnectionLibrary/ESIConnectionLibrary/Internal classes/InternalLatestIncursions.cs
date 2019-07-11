using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.Automapper_Profiles;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestIncursions : IInternalLatestIncursions
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestIncursions(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<IncursionsProfile>();
                });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public IList<V1Incursion> Incursions()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IncursionsV1Incursions(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 300));

            IList<EsiV1Incursion> model = JsonConvert.DeserializeObject<IList<EsiV1Incursion>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1Incursion>, IList<V1Incursion>>(model);
        }

        public async Task<IList<V1Incursion>> IncursionsAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IncursionsV1Incursions(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 300));

            IList<EsiV1Incursion> model = JsonConvert.DeserializeObject<IList<EsiV1Incursion>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1Incursion>, IList<V1Incursion>>(model);
        }
    }
}
