using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalFleets : IInternalFleets
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalFleets(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GetFleetMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public GetFleet GetFleet(SsoToken token, long fleetId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_fleets_read_fleet_v1);

            string url = $@"{StaticMethods.EsiBaseUrl}/v1/fleets/{fleetId}/";

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 5));

            EsiGetFleet esiGetFleet = JsonConvert.DeserializeObject<EsiGetFleet>(esiRaw);

            return _mapper.Map<EsiGetFleet, GetFleet>(esiGetFleet);
        }
    }
}
