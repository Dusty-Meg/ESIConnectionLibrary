using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestFleets : IInternalLatestFleets
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalLatestFleets(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GetFleetMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public V1GetFleet GetFleet(SsoToken token, long fleetId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_read_fleet_v1);

            string url = StaticConnectionStrings.FleetsGetFleet(fleetId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 5));

            EsiV1GetFleet esiV1GetFleet = JsonConvert.DeserializeObject<EsiV1GetFleet>(esiRaw);

            return _mapper.Map<EsiV1GetFleet, V1GetFleet>(esiV1GetFleet);
        }

        public async Task<V1GetFleet> GetFleetAsync(SsoToken token, long fleetId)
        {
            StaticMethods.CheckToken(token, FleetScopes.esi_fleets_read_fleet_v1);

            string url = StaticConnectionStrings.FleetsGetFleet(fleetId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 5));

            EsiV1GetFleet esiV1GetFleet = JsonConvert.DeserializeObject<EsiV1GetFleet>(esiRaw);

            return _mapper.Map<EsiV1GetFleet, V1GetFleet>(esiV1GetFleet);
        }
    }
}
