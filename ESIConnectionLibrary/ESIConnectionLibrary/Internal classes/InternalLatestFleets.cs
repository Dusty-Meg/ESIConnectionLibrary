using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestFleets : IInternalLatestFleets
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestFleets(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public V1GetFleet GetFleet(SsoToken token, long fleetId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_read_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsGetFleet(fleetId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 5));

            EsiV1GetFleet esiV1GetFleet = JsonConvert.DeserializeObject<EsiV1GetFleet>(esiRaw.Model);

            return _mapper.Map<EsiV1GetFleet, V1GetFleet>(esiV1GetFleet);
        }

        public async Task<V1GetFleet> GetFleetAsync(SsoToken token, long fleetId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_read_fleet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.FleetsGetFleet(fleetId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 5));

            EsiV1GetFleet esiV1GetFleet = JsonConvert.DeserializeObject<EsiV1GetFleet>(esiRaw.Model);

            return _mapper.Map<EsiV1GetFleet, V1GetFleet>(esiV1GetFleet);
        }
    }
}
