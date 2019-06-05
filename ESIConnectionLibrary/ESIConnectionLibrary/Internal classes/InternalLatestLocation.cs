using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.Automapper_Profiles;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestLocation : IInternalLatestLocation
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestLocation(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<LocationProfile>();
                });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public V1LocationLocation Location(SsoToken token)
        {
            StaticMethods.CheckToken(token, LocationScopes.esi_location_read_location_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.LocationV1Location(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 5));

            EsiV1LocationLocation model = JsonConvert.DeserializeObject<EsiV1LocationLocation>(esiRaw.Model);

            return _mapper.Map<EsiV1LocationLocation, V1LocationLocation>(model);
        }

        public async Task<V1LocationLocation> LocationAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, LocationScopes.esi_location_read_location_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.LocationV1Location(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 5));

            EsiV1LocationLocation model = JsonConvert.DeserializeObject<EsiV1LocationLocation>(esiRaw.Model);

            return _mapper.Map<EsiV1LocationLocation, V1LocationLocation>(model);
        }

        public V2LocationOnline Online(SsoToken token)
        {
            StaticMethods.CheckToken(token, LocationScopes.esi_location_read_online_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.LocationV2LocationOnline(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 60));

            EsiV2LocationOnline model = JsonConvert.DeserializeObject<EsiV2LocationOnline>(esiRaw.Model);

            return _mapper.Map<EsiV2LocationOnline, V2LocationOnline>(model);
        }

        public async Task<V2LocationOnline> OnlineAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, LocationScopes.esi_location_read_online_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.LocationV2LocationOnline(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 60));

            EsiV2LocationOnline model = JsonConvert.DeserializeObject<EsiV2LocationOnline>(esiRaw.Model);

            return _mapper.Map<EsiV2LocationOnline, V2LocationOnline>(model);
        }

        public V1LocationShip Ship(SsoToken token)
        {
            StaticMethods.CheckToken(token, LocationScopes.esi_location_read_ship_type_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.LocationV1LocationShip(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 5));

            EsiV1LocationShip model = JsonConvert.DeserializeObject<EsiV1LocationShip>(esiRaw.Model);

            return _mapper.Map<EsiV1LocationShip, V1LocationShip>(model);
        }

        public async Task<V1LocationShip> ShipAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, LocationScopes.esi_location_read_ship_type_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.LocationV1LocationShip(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 5));

            EsiV1LocationShip model = JsonConvert.DeserializeObject<EsiV1LocationShip>(esiRaw.Model);

            return _mapper.Map<EsiV1LocationShip, V1LocationShip>(model);
        }
    }
}
