using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestPlanetaryInteraction : IInternalLatestPlanetaryInteraction
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalLatestPlanetaryInteraction(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PlanetaryInteractionMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public IList<V1PlanetaryInteractionCharactersPlanets> GetCharactersPlanets(SsoToken token)
        {
            StaticMethods.CheckToken(token, PlanetScopes.esi_planets_manage_planets_v1);

            string url = StaticConnectionStrings.PlanetaryInteractionV1CharactersPlanets(token.CharacterId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV1PlanetaryInteractionCharactersPlanets> esiPlanets = JsonConvert.DeserializeObject<IList<EsiV1PlanetaryInteractionCharactersPlanets>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1PlanetaryInteractionCharactersPlanets>, IList<V1PlanetaryInteractionCharactersPlanets>>(esiPlanets);
        }

        public async Task<IList<V1PlanetaryInteractionCharactersPlanets>> GetCharactersPlanetsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, PlanetScopes.esi_planets_manage_planets_v1);

            string url = StaticConnectionStrings.PlanetaryInteractionV1CharactersPlanets(token.CharacterId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV1PlanetaryInteractionCharactersPlanets> esiPlanets = JsonConvert.DeserializeObject<IList<EsiV1PlanetaryInteractionCharactersPlanets>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1PlanetaryInteractionCharactersPlanets>, IList<V1PlanetaryInteractionCharactersPlanets>>(esiPlanets);
        }

        public V3PlanetaryInteractionCharactersPlanet GetCharacterPlanet(SsoToken token, int planetId)
        {
            StaticMethods.CheckToken(token, PlanetScopes.esi_planets_manage_planets_v1);

            string url = StaticConnectionStrings.PlanetaryInteractionV3CharactersPlanet(token.CharacterId, planetId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 600));

            EsiV3PlanetaryInteractionCharactersPlanet esiPlanet = JsonConvert.DeserializeObject<EsiV3PlanetaryInteractionCharactersPlanet>(esiRaw.Model);

            return _mapper.Map<V3PlanetaryInteractionCharactersPlanet>(esiPlanet);
        }

        public async Task<V3PlanetaryInteractionCharactersPlanet> GetCharacterPlanetAsync(SsoToken token, int planetId)
        {
            StaticMethods.CheckToken(token, PlanetScopes.esi_planets_manage_planets_v1);

            string url = StaticConnectionStrings.PlanetaryInteractionV3CharactersPlanet(token.CharacterId, planetId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 600));

            EsiV3PlanetaryInteractionCharactersPlanet esiPlanet = JsonConvert.DeserializeObject<EsiV3PlanetaryInteractionCharactersPlanet>(esiRaw.Model);

            return _mapper.Map<V3PlanetaryInteractionCharactersPlanet>(esiPlanet);
        }

        public PagedModel<V1PlanetaryInteractionCorporationCustomsOffice> GetCorporationsCustomsOffices(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, PlanetScopes.esi_planets_read_customs_offices_v1);

            string url = StaticConnectionStrings.PlanetaryInteractionV1CorporationsCustomsOffices(corporationId, page);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1PlanetaryInteractionCorporationCustomsOffice> esiCustomOffices = JsonConvert.DeserializeObject<IList<EsiV1PlanetaryInteractionCorporationCustomsOffice>>(esiRaw.Model);

            IList<V1PlanetaryInteractionCorporationCustomsOffice> mapped = _mapper.Map<IList<EsiV1PlanetaryInteractionCorporationCustomsOffice>, IList<V1PlanetaryInteractionCorporationCustomsOffice>>(esiCustomOffices);

            return new PagedModel<V1PlanetaryInteractionCorporationCustomsOffice>{ Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V1PlanetaryInteractionCorporationCustomsOffice>> GetCorporationsCustomsOfficesAsync(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, PlanetScopes.esi_planets_read_customs_offices_v1);

            string url = StaticConnectionStrings.PlanetaryInteractionV1CorporationsCustomsOffices(corporationId, page);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1PlanetaryInteractionCorporationCustomsOffice> esiCustomOffices = JsonConvert.DeserializeObject<IList<EsiV1PlanetaryInteractionCorporationCustomsOffice>>(esiRaw.Model);

            IList<V1PlanetaryInteractionCorporationCustomsOffice> mapped = _mapper.Map<IList<EsiV1PlanetaryInteractionCorporationCustomsOffice>, IList<V1PlanetaryInteractionCorporationCustomsOffice>>(esiCustomOffices);

            return new PagedModel<V1PlanetaryInteractionCorporationCustomsOffice> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public V1PlanetaryInteractionSchematic GetSchematic(int schematicId)
        {
            string url = StaticConnectionStrings.PlanetaryInteractionV1Schematics(schematicId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1PlanetaryInteractionSchematic esiSchematic = JsonConvert.DeserializeObject<EsiV1PlanetaryInteractionSchematic>(esiRaw.Model);

            return _mapper.Map<V1PlanetaryInteractionSchematic>(esiSchematic);
        }

        public async Task<V1PlanetaryInteractionSchematic> GetSchematicAsync(int schematicId)
        {
            string url = StaticConnectionStrings.PlanetaryInteractionV1Schematics(schematicId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1PlanetaryInteractionSchematic esiSchematic = JsonConvert.DeserializeObject<EsiV1PlanetaryInteractionSchematic>(esiRaw.Model);

            return _mapper.Map<V1PlanetaryInteractionSchematic>(esiSchematic);
        }
    }
}
