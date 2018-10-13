using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestPlanetaryInteraction : IInternalLatestPlanetaryInteraction
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestPlanetaryInteraction(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public IList<V1PlanetaryInteractionCharactersPlanets> CharactersPlanets(SsoToken token)
        {
            StaticMethods.CheckToken(token, PlanetScopes.esi_planets_manage_planets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.PlanetaryInteractionV1CharactersPlanets(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV1PlanetaryInteractionCharactersPlanets> esiPlanets = JsonConvert.DeserializeObject<IList<EsiV1PlanetaryInteractionCharactersPlanets>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1PlanetaryInteractionCharactersPlanets>, IList<V1PlanetaryInteractionCharactersPlanets>>(esiPlanets);
        }

        public async Task<IList<V1PlanetaryInteractionCharactersPlanets>> CharactersPlanetsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, PlanetScopes.esi_planets_manage_planets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.PlanetaryInteractionV1CharactersPlanets(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV1PlanetaryInteractionCharactersPlanets> esiPlanets = JsonConvert.DeserializeObject<IList<EsiV1PlanetaryInteractionCharactersPlanets>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1PlanetaryInteractionCharactersPlanets>, IList<V1PlanetaryInteractionCharactersPlanets>>(esiPlanets);
        }

        public V3PlanetaryInteractionCharactersPlanet CharacterPlanet(SsoToken token, int planetId)
        {
            StaticMethods.CheckToken(token, PlanetScopes.esi_planets_manage_planets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.PlanetaryInteractionV3CharactersPlanet(token.CharacterId, planetId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 600));

            EsiV3PlanetaryInteractionCharactersPlanet esiPlanet = JsonConvert.DeserializeObject<EsiV3PlanetaryInteractionCharactersPlanet>(esiRaw.Model);

            return _mapper.Map<V3PlanetaryInteractionCharactersPlanet>(esiPlanet);
        }

        public async Task<V3PlanetaryInteractionCharactersPlanet> CharacterPlanetAsync(SsoToken token, int planetId)
        {
            StaticMethods.CheckToken(token, PlanetScopes.esi_planets_manage_planets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.PlanetaryInteractionV3CharactersPlanet(token.CharacterId, planetId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 600));

            EsiV3PlanetaryInteractionCharactersPlanet esiPlanet = JsonConvert.DeserializeObject<EsiV3PlanetaryInteractionCharactersPlanet>(esiRaw.Model);

            return _mapper.Map<V3PlanetaryInteractionCharactersPlanet>(esiPlanet);
        }

        public PagedModel<V1PlanetaryInteractionCorporationCustomsOffice> CorporationsCustomsOffices(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, PlanetScopes.esi_planets_read_customs_offices_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.PlanetaryInteractionV1CorporationsCustomsOffices(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1PlanetaryInteractionCorporationCustomsOffice> esiCustomOffices = JsonConvert.DeserializeObject<IList<EsiV1PlanetaryInteractionCorporationCustomsOffice>>(esiRaw.Model);

            IList<V1PlanetaryInteractionCorporationCustomsOffice> mapped = _mapper.Map<IList<EsiV1PlanetaryInteractionCorporationCustomsOffice>, IList<V1PlanetaryInteractionCorporationCustomsOffice>>(esiCustomOffices);

            return new PagedModel<V1PlanetaryInteractionCorporationCustomsOffice>{ Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V1PlanetaryInteractionCorporationCustomsOffice>> CorporationsCustomsOfficesAsync(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, PlanetScopes.esi_planets_read_customs_offices_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.PlanetaryInteractionV1CorporationsCustomsOffices(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1PlanetaryInteractionCorporationCustomsOffice> esiCustomOffices = JsonConvert.DeserializeObject<IList<EsiV1PlanetaryInteractionCorporationCustomsOffice>>(esiRaw.Model);

            IList<V1PlanetaryInteractionCorporationCustomsOffice> mapped = _mapper.Map<IList<EsiV1PlanetaryInteractionCorporationCustomsOffice>, IList<V1PlanetaryInteractionCorporationCustomsOffice>>(esiCustomOffices);

            return new PagedModel<V1PlanetaryInteractionCorporationCustomsOffice> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public V1PlanetaryInteractionSchematic Schematic(int schematicId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.PlanetaryInteractionV1Schematics(schematicId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1PlanetaryInteractionSchematic esiSchematic = JsonConvert.DeserializeObject<EsiV1PlanetaryInteractionSchematic>(esiRaw.Model);

            return _mapper.Map<V1PlanetaryInteractionSchematic>(esiSchematic);
        }

        public async Task<V1PlanetaryInteractionSchematic> SchematicAsync(int schematicId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.PlanetaryInteractionV1Schematics(schematicId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1PlanetaryInteractionSchematic esiSchematic = JsonConvert.DeserializeObject<EsiV1PlanetaryInteractionSchematic>(esiRaw.Model);

            return _mapper.Map<V1PlanetaryInteractionSchematic>(esiSchematic);
        }
    }
}
