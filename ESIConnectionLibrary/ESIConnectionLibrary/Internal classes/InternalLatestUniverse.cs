using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestUniverse : IInternalLatestUniverse
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalLatestUniverse(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UniverseMappings>();
                cfg.AddProfile<GeneralMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        private int SecondsToDT()
        {
            DateTime now = DateTime.Now;

            DateTime todaysDt = new DateTime(now.Year, now.Month, now.Day, 11, 5, 0);

            if ((todaysDt - now).TotalSeconds < 0)
            {
                return (int)(todaysDt.AddDays(1) - now).TotalSeconds;
            }

            return (int) (todaysDt - now).TotalSeconds;
        }

        public IList<V1UniverseAncestries> GetAncestries()
        {
            string url = StaticConnectionStrings.UniverseV1Ancestries();

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV1UniverseAncestries> esiUniverseNames = JsonConvert.DeserializeObject<IList<EsiV1UniverseAncestries>>(esiRaw);

            return _mapper.Map<IList<EsiV1UniverseAncestries>, IList<V1UniverseAncestries>>(esiUniverseNames);
        }

        public async Task<IList<V1UniverseAncestries>> GetAncestriesAsync()
        {
            string url = StaticConnectionStrings.UniverseV1Ancestries();

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV1UniverseAncestries> esiUniverseNames = JsonConvert.DeserializeObject<IList<EsiV1UniverseAncestries>>(esiRaw);

            return _mapper.Map<IList<EsiV1UniverseAncestries>, IList<V1UniverseAncestries>>(esiUniverseNames);
        }

        public V1UniverseAsteroidBelt GetAsteroidBelt(int asteroidBelId)
        {
            string url = StaticConnectionStrings.UniverseV1AsteroidBelt(asteroidBelId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseAsteroidBelt esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseAsteroidBelt>(esiRaw);

            return _mapper.Map<V1UniverseAsteroidBelt>(esiUniverseNames);
        }

        public async Task<V1UniverseAsteroidBelt> GetAsteroidBeltAsync(int asteroidBelId)
        {
            string url = StaticConnectionStrings.UniverseV1AsteroidBelt(asteroidBelId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseAsteroidBelt esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseAsteroidBelt>(esiRaw);

            return _mapper.Map<V1UniverseAsteroidBelt>(esiUniverseNames);
        }

        public IList<V1UniverseBloodlines> GetBloodlines()
        {
            string url = StaticConnectionStrings.UniverseV1Bloodlines();

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV1UniverseBloodlines> esiUniverseNames = JsonConvert.DeserializeObject<IList<EsiV1UniverseBloodlines>>(esiRaw);

            return _mapper.Map<IList<EsiV1UniverseBloodlines>, IList<V1UniverseBloodlines>>(esiUniverseNames);
        }

        public async Task<IList<V1UniverseBloodlines>> GetBloodlinesAsync()
        {
            string url = StaticConnectionStrings.UniverseV1Bloodlines();

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV1UniverseBloodlines> esiUniverseNames = JsonConvert.DeserializeObject<IList<EsiV1UniverseBloodlines>>(esiRaw);

            return _mapper.Map<IList<EsiV1UniverseBloodlines>, IList<V1UniverseBloodlines>>(esiUniverseNames);
        }

        public IList<int> GetCategories()
        {
            string url = StaticConnectionStrings.UniverseV1Categories();

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw);
        }

        public async Task<IList<int>> GetCategoriesAsync()
        {
            string url = StaticConnectionStrings.UniverseV1Categories();

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw);
        }

        public V1UniverseCategory GetCategory(int categoryId)
        {
            string url = StaticConnectionStrings.UniverseV1Category(categoryId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseCategory esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseCategory>(esiRaw);

            return _mapper.Map<V1UniverseCategory>(esiUniverseNames);
        }

        public async Task<V1UniverseCategory> GetCategoryAsync(int categoryId)
        {
            string url = StaticConnectionStrings.UniverseV1Category(categoryId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseCategory esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseCategory>(esiRaw);

            return _mapper.Map<V1UniverseCategory>(esiUniverseNames);
        }

        public IList<int> GetConstellations()
        {
            string url = StaticConnectionStrings.UniverseV1Constellations();

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw);
        }

        public async Task<IList<int>> GetConstellationsAsync()
        {
            string url = StaticConnectionStrings.UniverseV1Constellations();

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw);
        }

        public V1UniverseConstellation GetConstellation(int constellationId)
        {
            string url = StaticConnectionStrings.UniverseV1Constellation(constellationId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseConstellation esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseConstellation>(esiRaw);

            return _mapper.Map<V1UniverseConstellation>(esiUniverseNames);
        }

        public async Task<V1UniverseConstellation> GetConstellationAsync(int constellationId)
        {
            string url = StaticConnectionStrings.UniverseV1Constellation(constellationId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseConstellation esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseConstellation>(esiRaw);

            return _mapper.Map<V1UniverseConstellation>(esiUniverseNames);
        }

        public IList<V2UniverseFactions> GetFactions()
        {
            string url = StaticConnectionStrings.UniverseV2Factions();

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV2UniverseFactions> esiUniverseNames = JsonConvert.DeserializeObject<IList<EsiV2UniverseFactions>>(esiRaw);

            return _mapper.Map<IList<EsiV2UniverseFactions>, IList<V2UniverseFactions>>(esiUniverseNames);
        }

        public async Task<IList<V2UniverseFactions>> GetFactionsAsync()
        {
            string url = StaticConnectionStrings.UniverseV2Factions();

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV2UniverseFactions> esiUniverseNames = JsonConvert.DeserializeObject<IList<EsiV2UniverseFactions>>(esiRaw);

            return _mapper.Map<IList<EsiV2UniverseFactions>, IList<V2UniverseFactions>>(esiUniverseNames);
        }

        public IList<int> GetGraphics()
        {
            string url = StaticConnectionStrings.UniverseV1Graphics();

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw);
        }

        public async Task<IList<int>> GetGraphicsAsync()
        {
            string url = StaticConnectionStrings.UniverseV1Graphics();

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw);
        }

        public V1UniverseGraphic GetGraphic(int graphicId)
        {
            string url = StaticConnectionStrings.UniverseV1Graphic(graphicId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseGraphic esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseGraphic>(esiRaw);

            return _mapper.Map<V1UniverseGraphic>(esiUniverseNames);
        }

        public async Task<V1UniverseGraphic> GetGraphicAsync(int graphicId)
        {
            string url = StaticConnectionStrings.UniverseV1Graphic(graphicId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseGraphic esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseGraphic>(esiRaw);

            return _mapper.Map<V1UniverseGraphic>(esiUniverseNames);
        }

        public PagedModel<int> GetGroups(int page)
        {
            string url = StaticConnectionStrings.UniverseV1Groups(page);

            PagedJson raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.GetPaged(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<int> esi = JsonConvert.DeserializeObject<IList<int>>(raw.Response);

            return new PagedModel<int>{Model = esi, MaxPages = raw.MaxPages.GetValueOrDefault(), CurrentPage = page};
        }

        public async Task<PagedModel<int>> GetGroupsAsync(int page)
        {
            string url = StaticConnectionStrings.UniverseV1Groups(page);

            PagedJson raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetPagedAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<int> esi = JsonConvert.DeserializeObject<IList<int>>(raw.Response);

            return new PagedModel<int> { Model = esi, MaxPages = raw.MaxPages.GetValueOrDefault(), CurrentPage = page };
        }

        public V1UniverseGroup GetGroup(int groupId)
        {
            string url = StaticConnectionStrings.UniverseV1Group(groupId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseGroup esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseGroup>(esiRaw);

            return _mapper.Map<V1UniverseGroup>(esiUniverseNames);
        }

        public async Task<V1UniverseGroup> GetGroupAsync(int groupId)
        {
            string url = StaticConnectionStrings.UniverseV1Group(groupId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseGroup esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseGroup>(esiRaw);

            return _mapper.Map<V1UniverseGroup>(esiUniverseNames);
        }

        public V1UniverseNamesToIds GetIds(IList<string> names)
        {
            string url = StaticConnectionStrings.UniverseV1Ids();

            string jsonObject = JsonConvert.SerializeObject(names);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(), url, jsonObject, SecondsToDT()));

            EsiV1UniverseNamesToIds esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseNamesToIds>(esiRaw);

            return _mapper.Map<V1UniverseNamesToIds>(esiUniverseNames);
        }

        public async Task<V1UniverseNamesToIds> GetIdsAsync(IList<string> names)
        {
            string url = StaticConnectionStrings.UniverseV1Ids();

            string jsonObject = JsonConvert.SerializeObject(names);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(), url, jsonObject, SecondsToDT()));

            EsiV1UniverseNamesToIds esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseNamesToIds>(esiRaw);

            return _mapper.Map<V1UniverseNamesToIds>(esiUniverseNames);
        }

        public V1UniverseMoon GetMoon(int moonId)
        {
            string url = StaticConnectionStrings.UniverseV1Moon(moonId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseMoon esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseMoon>(esiRaw);

            return _mapper.Map<V1UniverseMoon>(esiUniverseNames);
        }

        public async Task<V1UniverseMoon> GetMoonAsync(int moonId)
        {
            string url = StaticConnectionStrings.UniverseV1Moon(moonId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseMoon esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseMoon>(esiRaw);

            return _mapper.Map<V1UniverseMoon>(esiUniverseNames);
        }

        public IList<V2UniverseNames> GetNames(IList<int> ids)
        {
            string url = StaticConnectionStrings.UniverseV2Names();

            string jsonObject = JsonConvert.SerializeObject(ids);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(), url, jsonObject, SecondsToDT()));

            IList<EsiV2UniverseNames> esiUniverseNames = JsonConvert.DeserializeObject<IList<EsiV2UniverseNames>>(esiRaw);

            return _mapper.Map<IList<EsiV2UniverseNames>, IList<V2UniverseNames>>(esiUniverseNames);
        }

        public async Task<IList<V2UniverseNames>> GetNamesAsync(IList<int> ids)
        {
            string url = StaticConnectionStrings.UniverseV2Names();

            string jsonObject = JsonConvert.SerializeObject(ids);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(), url, jsonObject, SecondsToDT()));

            IList<EsiV2UniverseNames> esiUniverseNames = JsonConvert.DeserializeObject<IList<EsiV2UniverseNames>>(esiRaw);

            return _mapper.Map<IList<EsiV2UniverseNames>, IList<V2UniverseNames>>(esiUniverseNames);
        }

        public V1UniversePlanet GetPlanet(int planetId)
        {
            string url = StaticConnectionStrings.UniverseV1Planet(planetId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniversePlanet esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniversePlanet>(esiRaw);

            return _mapper.Map<V1UniversePlanet>(esiUniverseNames);
        }

        public async Task<V1UniversePlanet> GetPlanetAsync(int planetId)
        {
            string url = StaticConnectionStrings.UniverseV1Planet(planetId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniversePlanet esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniversePlanet>(esiRaw);

            return _mapper.Map<V1UniversePlanet>(esiUniverseNames);
        }

        public IList<V1UniverseRaces> GetRaces()
        {
            string url = StaticConnectionStrings.UniverseV1Races();

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV1UniverseRaces> esiUniverseNames = JsonConvert.DeserializeObject<IList<EsiV1UniverseRaces>>(esiRaw);

            return _mapper.Map<IList<EsiV1UniverseRaces>, IList<V1UniverseRaces>>(esiUniverseNames);
        }

        public async Task<IList<V1UniverseRaces>> GetRacesAsync()
        {
            string url = StaticConnectionStrings.UniverseV1Races();

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV1UniverseRaces> esiUniverseNames = JsonConvert.DeserializeObject<IList<EsiV1UniverseRaces>>(esiRaw);

            return _mapper.Map<IList<EsiV1UniverseRaces>, IList<V1UniverseRaces>>(esiUniverseNames);
        }

        public IList<int> GetRegions()
        {
            string url = StaticConnectionStrings.UniverseV1Regions();

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw);
        }

        public async Task<IList<int>> GetRegionsAsync()
        {
            string url = StaticConnectionStrings.UniverseV1Regions();

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw);
        }

        public V1UniverseRegion GetRegion(int regionId)
        {
            string url = StaticConnectionStrings.UniverseV1Region(regionId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseRegion esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseRegion>(esiRaw);

            return _mapper.Map<V1UniverseRegion>(esiUniverseNames);
        }

        public async Task<V1UniverseRegion> GetRegionAsync(int planetId)
        {
            string url = StaticConnectionStrings.UniverseV1Region(planetId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseRegion esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseRegion>(esiRaw);

            return _mapper.Map<V1UniverseRegion>(esiUniverseNames);
        }

        public V1UniverseStargate GetStargate(int stargateId)
        {
            string url = StaticConnectionStrings.UniverseV1Stargate(stargateId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseStargate esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseStargate>(esiRaw);

            return _mapper.Map<V1UniverseStargate>(esiUniverseNames);
        }

        public async Task<V1UniverseStargate> GetStargateAsync(int stargateId)
        {
            string url = StaticConnectionStrings.UniverseV1Stargate(stargateId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseStargate esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseStargate>(esiRaw);

            return _mapper.Map<V1UniverseStargate>(esiUniverseNames);
        }

        public V1UniverseStar GetStar(int starId)
        {
            string url = StaticConnectionStrings.UniverseV1Star(starId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseStar esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseStar>(esiRaw);

            return _mapper.Map<V1UniverseStar>(esiUniverseNames);
        }

        public async Task<V1UniverseStar> GetStarAsync(int starId)
        {
            string url = StaticConnectionStrings.UniverseV1Star(starId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseStar esiUniverseNames = JsonConvert.DeserializeObject<EsiV1UniverseStar>(esiRaw);

            return _mapper.Map<V1UniverseStar>(esiUniverseNames);
        }

        public V2UniverseStation GetStation(int stationId)
        {
            string url = StaticConnectionStrings.UniverseV2Station(stationId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV2UniverseStation esiUniverseNames = JsonConvert.DeserializeObject<EsiV2UniverseStation>(esiRaw);

            return _mapper.Map<V2UniverseStation>(esiUniverseNames);
        }

        public async Task<V2UniverseStation> GetStationAsync(int stationId)
        {
            string url = StaticConnectionStrings.UniverseV2Station(stationId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV2UniverseStation esiUniverseNames = JsonConvert.DeserializeObject<EsiV2UniverseStation>(esiRaw);

            return _mapper.Map<V2UniverseStation>(esiUniverseNames);
        }

        public IList<long> GetStructures()
        {
            string url = StaticConnectionStrings.UniverseV1Structures();

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            return JsonConvert.DeserializeObject<IList<long>>(esiRaw);
        }

        public async Task<IList<long>> GetStructuresAsync()
        {
            string url = StaticConnectionStrings.UniverseV1Structures();

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            return JsonConvert.DeserializeObject<IList<long>>(esiRaw);
        }

        public V1UniverseStructure GetStructure(SsoToken token, long structureId)
        {
            StaticMethods.CheckToken(token, UniverseScopes.esi_universe_read_structures_v1);

            string url = StaticConnectionStrings.UniverseV1Structure(structureId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV1UniverseStructure esiV1GetFleet = JsonConvert.DeserializeObject<EsiV1UniverseStructure>(esiRaw);

            return _mapper.Map<EsiV1UniverseStructure, V1UniverseStructure>(esiV1GetFleet);
        }

        public async Task<V1UniverseStructure> GetStructureAsync(SsoToken token, long structureId)
        {
            StaticMethods.CheckToken(token, UniverseScopes.esi_universe_read_structures_v1);

            string url = StaticConnectionStrings.UniverseV1Structure(structureId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV1UniverseStructure esiV1GetFleet = JsonConvert.DeserializeObject<EsiV1UniverseStructure>(esiRaw);

            return _mapper.Map<EsiV1UniverseStructure, V1UniverseStructure>(esiV1GetFleet);
        }

        public IList<V1UniverseSystemJumps> GetSystemJumps()
        {
            string url = StaticConnectionStrings.UniverseV1SystemJumps();

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1UniverseSystemJumps> esiUniverseNames = JsonConvert.DeserializeObject<IList<EsiV1UniverseSystemJumps>>(esiRaw);

            return _mapper.Map<IList<EsiV1UniverseSystemJumps>, IList<V1UniverseSystemJumps>>(esiUniverseNames);
        }

        public async Task<IList<V1UniverseSystemJumps>> GetSystemJumpsAsync()
        {
            string url = StaticConnectionStrings.UniverseV1SystemJumps();

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1UniverseSystemJumps> esiUniverseNames = JsonConvert.DeserializeObject<IList<EsiV1UniverseSystemJumps>>(esiRaw);

            return _mapper.Map<IList<EsiV1UniverseSystemJumps>, IList<V1UniverseSystemJumps>>(esiUniverseNames);
        }

        public IList<V2UniverseSystemKills> GetSystemKills()
        {
            string url = StaticConnectionStrings.UniverseV2SystemKills();

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV2UniverseSystemKills> esiUniverseNames = JsonConvert.DeserializeObject<IList<EsiV2UniverseSystemKills>>(esiRaw);

            return _mapper.Map<IList<EsiV2UniverseSystemKills>, IList<V2UniverseSystemKills>>(esiUniverseNames);
        }

        public async Task<IList<V2UniverseSystemKills>> GetSystemKillsAsync()
        {
            string url = StaticConnectionStrings.UniverseV2SystemKills();

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV2UniverseSystemKills> esiUniverseNames = JsonConvert.DeserializeObject<IList<EsiV2UniverseSystemKills>>(esiRaw);

            return _mapper.Map<IList<EsiV2UniverseSystemKills>, IList<V2UniverseSystemKills>>(esiUniverseNames);
        }

        public IList<int> GetSystems()
        {
            string url = StaticConnectionStrings.UniverseV1Systems();

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw);
        }

        public async Task<IList<int>> GetSystemsAsync()
        {
            string url = StaticConnectionStrings.UniverseV1Systems();

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw);
        }

        public V3UniverseSystem GetSystem(int systemId)
        {
            string url = StaticConnectionStrings.UniverseV3System(systemId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV3UniverseSystem esiV3UniverseGetType = JsonConvert.DeserializeObject<EsiV3UniverseSystem>(esiRaw);

            return _mapper.Map<EsiV3UniverseSystem, V3UniverseSystem>(esiV3UniverseGetType);
        }

        public async Task<V3UniverseSystem> GetSystemAsync(int systemId)
        {
            string url = StaticConnectionStrings.UniverseV3System(systemId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV3UniverseSystem esiV3UniverseGetType = JsonConvert.DeserializeObject<EsiV3UniverseSystem>(esiRaw);

            return _mapper.Map<EsiV3UniverseSystem, V3UniverseSystem>(esiV3UniverseGetType);
        }

        public PagedModel<int> GetTypes(int page)
        {
            string url = StaticConnectionStrings.UniverseV1Types(page);

            PagedJson raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.GetPaged(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<int> esi = JsonConvert.DeserializeObject<IList<int>>(raw.Response);

            return new PagedModel<int> { Model = esi, MaxPages = raw.MaxPages.GetValueOrDefault(), CurrentPage = page };
        }

        public async Task<PagedModel<int>> GetTypesAsync(int page)
        {
            string url = StaticConnectionStrings.UniverseV1Types(page);

            PagedJson raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetPagedAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<int> esi = JsonConvert.DeserializeObject<IList<int>>(raw.Response);

            return new PagedModel<int> { Model = esi, MaxPages = raw.MaxPages.GetValueOrDefault(), CurrentPage = page };
        }

        public V3UniverseType GetType(int typeId)
        {
            string url = StaticConnectionStrings.UniverseV3Type(typeId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV3UniverseType esiV3UniverseGetType = JsonConvert.DeserializeObject<EsiV3UniverseType>(esiRaw);

            return _mapper.Map<EsiV3UniverseType, V3UniverseType>(esiV3UniverseGetType);
        }

        public async Task<V3UniverseType> GetTypeAsync(int typeId)
        {
            string url = StaticConnectionStrings.UniverseV3Type(typeId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV3UniverseType esiV3UniverseGetType = JsonConvert.DeserializeObject<EsiV3UniverseType>(esiRaw);

            return _mapper.Map<EsiV3UniverseType, V3UniverseType>(esiV3UniverseGetType);
        }
    }
}
