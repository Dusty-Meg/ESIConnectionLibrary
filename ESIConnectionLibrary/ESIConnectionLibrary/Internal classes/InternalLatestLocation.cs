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

        public InternalLatestLocation(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<LocationMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public V1LocationCharacterLocation GetCharacterLocation(SsoToken token)
        {
            StaticMethods.CheckToken(token, LocationScopes.esi_location_read_location_v1);

            string url = StaticConnectionStrings.LocationV1LocationCharacterLocation(token.CharacterId);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 5));

            EsiV1LocationCharacterLocation esiLocation = JsonConvert.DeserializeObject<EsiV1LocationCharacterLocation>(raw.Model);

            return _mapper.Map<EsiV1LocationCharacterLocation, V1LocationCharacterLocation>(esiLocation);
        }

        public async Task<V1LocationCharacterLocation> GetCharacterLocationAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, LocationScopes.esi_location_read_location_v1);

            string url = StaticConnectionStrings.LocationV1LocationCharacterLocation(token.CharacterId);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 5));

            EsiV1LocationCharacterLocation esiLocation = JsonConvert.DeserializeObject<EsiV1LocationCharacterLocation>(raw.Model);

            return _mapper.Map<EsiV1LocationCharacterLocation, V1LocationCharacterLocation>(esiLocation);
        }

        public V2LocationCharacterOnline GetCharacterOnlineStatus(SsoToken token)
        {
            StaticMethods.CheckToken(token, LocationScopes.esi_location_read_online_v1);

            string url = StaticConnectionStrings.LocationV2LocationCharacterOnline(token.CharacterId);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 60));

            EsiV2LocationCharacterOnline esiLocation = JsonConvert.DeserializeObject<EsiV2LocationCharacterOnline>(raw.Model);

            return _mapper.Map<EsiV2LocationCharacterOnline, V2LocationCharacterOnline>(esiLocation);
        }

        public async Task<V2LocationCharacterOnline> GetCharacterOnlineStatusAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, LocationScopes.esi_location_read_online_v1);

            string url = StaticConnectionStrings.LocationV2LocationCharacterOnline(token.CharacterId);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 60));

            EsiV2LocationCharacterOnline esiLocation = JsonConvert.DeserializeObject<EsiV2LocationCharacterOnline>(raw.Model);

            return _mapper.Map<EsiV2LocationCharacterOnline, V2LocationCharacterOnline>(esiLocation);
        }

        public V1LocationCharacterShip GetCharacterShip(SsoToken token)
        {
            StaticMethods.CheckToken(token, LocationScopes.esi_location_read_ship_type_v1);

            string url = StaticConnectionStrings.LocationV1LocationCharacterShip(token.CharacterId);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 5));

            EsiV1LocationCharacterShip esiLocation = JsonConvert.DeserializeObject<EsiV1LocationCharacterShip>(raw.Model);

            return _mapper.Map<EsiV1LocationCharacterShip, V1LocationCharacterShip>(esiLocation);
        }

        public async Task<V1LocationCharacterShip> GetCharacterShipAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, LocationScopes.esi_location_read_ship_type_v1);

            string url = StaticConnectionStrings.LocationV1LocationCharacterShip(token.CharacterId);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 5));

            EsiV1LocationCharacterShip esiLocation = JsonConvert.DeserializeObject<EsiV1LocationCharacterShip>(raw.Model);

            return _mapper.Map<EsiV1LocationCharacterShip, V1LocationCharacterShip>(esiLocation);
        }
    }
}
