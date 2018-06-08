using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
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
                cfg.AddProfile<LocationMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public V1LocationCharacterLocation GetCharacterLocation(SsoToken token)
        {
            StaticMethods.CheckToken(token, LocationScopes.esi_location_read_location_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.LocationV1LocationCharacterLocation(token.CharacterId), _testing);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 5));

            EsiV1LocationCharacterLocation esiLocation = JsonConvert.DeserializeObject<EsiV1LocationCharacterLocation>(raw.Model);

            return _mapper.Map<EsiV1LocationCharacterLocation, V1LocationCharacterLocation>(esiLocation);
        }

        public async Task<V1LocationCharacterLocation> GetCharacterLocationAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, LocationScopes.esi_location_read_location_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.LocationV1LocationCharacterLocation(token.CharacterId), _testing);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 5));

            EsiV1LocationCharacterLocation esiLocation = JsonConvert.DeserializeObject<EsiV1LocationCharacterLocation>(raw.Model);

            return _mapper.Map<EsiV1LocationCharacterLocation, V1LocationCharacterLocation>(esiLocation);
        }

        public V2LocationCharacterOnline GetCharacterOnlineStatus(SsoToken token)
        {
            StaticMethods.CheckToken(token, LocationScopes.esi_location_read_online_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.LocationV2LocationCharacterOnline(token.CharacterId), _testing);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 60));

            EsiV2LocationCharacterOnline esiLocation = JsonConvert.DeserializeObject<EsiV2LocationCharacterOnline>(raw.Model);

            return _mapper.Map<EsiV2LocationCharacterOnline, V2LocationCharacterOnline>(esiLocation);
        }

        public async Task<V2LocationCharacterOnline> GetCharacterOnlineStatusAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, LocationScopes.esi_location_read_online_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.LocationV2LocationCharacterOnline(token.CharacterId), _testing);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 60));

            EsiV2LocationCharacterOnline esiLocation = JsonConvert.DeserializeObject<EsiV2LocationCharacterOnline>(raw.Model);

            return _mapper.Map<EsiV2LocationCharacterOnline, V2LocationCharacterOnline>(esiLocation);
        }

        public V1LocationCharacterShip GetCharacterShip(SsoToken token)
        {
            StaticMethods.CheckToken(token, LocationScopes.esi_location_read_ship_type_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.LocationV1LocationCharacterShip(token.CharacterId), _testing);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 5));

            EsiV1LocationCharacterShip esiLocation = JsonConvert.DeserializeObject<EsiV1LocationCharacterShip>(raw.Model);

            return _mapper.Map<EsiV1LocationCharacterShip, V1LocationCharacterShip>(esiLocation);
        }

        public async Task<V1LocationCharacterShip> GetCharacterShipAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, LocationScopes.esi_location_read_ship_type_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.LocationV1LocationCharacterShip(token.CharacterId), _testing);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 5));

            EsiV1LocationCharacterShip esiLocation = JsonConvert.DeserializeObject<EsiV1LocationCharacterShip>(raw.Model);

            return _mapper.Map<EsiV1LocationCharacterShip, V1LocationCharacterShip>(esiLocation);
        }
    }
}
