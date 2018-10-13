using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestRoutes : IInternalLatestRoutes
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestRoutes(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public IList<int> Route(int origin, int destination, V1RoutesFlag flag, IList<int> avoid, IList<IList<int>> connections)
        {
            EsiV1RoutesFlag esiFlag = _mapper.Map<EsiV1RoutesFlag>(flag);

            string avoidJson = JsonConvert.SerializeObject(avoid);

            string connectionsJson = JsonConvert.SerializeObject(connections);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.RoutesV1Route(origin, destination, esiFlag, avoidJson, connectionsJson), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 86400));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> RouteAsync(int origin, int destination, V1RoutesFlag flag, IList<int> avoid, IList<IList<int>> connections)
        {
            EsiV1RoutesFlag esiFlag = _mapper.Map<EsiV1RoutesFlag>(flag);

            string avoidJson = JsonConvert.SerializeObject(avoid);

            string connectionsJson = JsonConvert.SerializeObject(connections);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.RoutesV1Route(origin, destination, esiFlag, avoidJson, connectionsJson), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 86400));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }
    }
}
