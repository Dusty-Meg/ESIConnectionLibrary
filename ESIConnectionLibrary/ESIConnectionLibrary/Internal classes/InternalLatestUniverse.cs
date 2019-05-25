using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestUniverse : IInternalLatestUniverse
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestUniverse(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
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

        public IList<V1UniverseAncestries> Ancestries()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Ancestries(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV1UniverseAncestries> esiModel = JsonConvert.DeserializeObject<IList<EsiV1UniverseAncestries>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1UniverseAncestries>, IList<V1UniverseAncestries>>(esiModel);
        }

        public async Task<IList<V1UniverseAncestries>> AncestriesAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Ancestries(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV1UniverseAncestries> esiModel = JsonConvert.DeserializeObject<IList<EsiV1UniverseAncestries>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1UniverseAncestries>, IList<V1UniverseAncestries>>(esiModel);
        }

        public V1UniverseAsteroidBelt AsteroidBelt(int asteroidBelId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1AsteroidBelt(asteroidBelId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseAsteroidBelt esiModel = JsonConvert.DeserializeObject<EsiV1UniverseAsteroidBelt>(esiRaw.Model);

            return _mapper.Map<V1UniverseAsteroidBelt>(esiModel);
        }

        public async Task<V1UniverseAsteroidBelt> AsteroidBeltAsync(int asteroidBelId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1AsteroidBelt(asteroidBelId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseAsteroidBelt esiModel = JsonConvert.DeserializeObject<EsiV1UniverseAsteroidBelt>(esiRaw.Model);

            return _mapper.Map<V1UniverseAsteroidBelt>(esiModel);
        }

        public IList<V1UniverseBloodlines> Bloodlines()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Bloodlines(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV1UniverseBloodlines> esiModel = JsonConvert.DeserializeObject<IList<EsiV1UniverseBloodlines>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1UniverseBloodlines>, IList<V1UniverseBloodlines>>(esiModel);
        }

        public async Task<IList<V1UniverseBloodlines>> BloodlinesAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Bloodlines(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV1UniverseBloodlines> esiModel = JsonConvert.DeserializeObject<IList<EsiV1UniverseBloodlines>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1UniverseBloodlines>, IList<V1UniverseBloodlines>>(esiModel);
        }

        public IList<int> Categories()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Categories(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> CategoriesAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Categories(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public V1UniverseCategory Category(int categoryId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Category(categoryId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseCategory esiModel = JsonConvert.DeserializeObject<EsiV1UniverseCategory>(esiRaw.Model);

            return _mapper.Map<V1UniverseCategory>(esiModel);
        }

        public async Task<V1UniverseCategory> CategoryAsync(int categoryId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Category(categoryId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseCategory esiModel = JsonConvert.DeserializeObject<EsiV1UniverseCategory>(esiRaw.Model);

            return _mapper.Map<V1UniverseCategory>(esiModel);
        }

        public IList<int> Constellations()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Constellations(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> ConstellationsAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Constellations(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public V1UniverseConstellation Constellation(int constellationId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Constellation(constellationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseConstellation esiModel = JsonConvert.DeserializeObject<EsiV1UniverseConstellation>(esiRaw.Model);

            return _mapper.Map<V1UniverseConstellation>(esiModel);
        }

        public async Task<V1UniverseConstellation> ConstellationAsync(int constellationId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Constellation(constellationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseConstellation esiModel = JsonConvert.DeserializeObject<EsiV1UniverseConstellation>(esiRaw.Model);

            return _mapper.Map<V1UniverseConstellation>(esiModel);
        }

        public IList<V2UniverseFactions> Factions()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV2Factions(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV2UniverseFactions> esiModel = JsonConvert.DeserializeObject<IList<EsiV2UniverseFactions>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2UniverseFactions>, IList<V2UniverseFactions>>(esiModel);
        }

        public async Task<IList<V2UniverseFactions>> FactionsAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV2Factions(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV2UniverseFactions> esiModel = JsonConvert.DeserializeObject<IList<EsiV2UniverseFactions>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2UniverseFactions>, IList<V2UniverseFactions>>(esiModel);
        }

        public IList<int> Graphics()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Graphics(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> GraphicsAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Graphics(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public V1UniverseGraphic Graphic(int graphicId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Graphic(graphicId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseGraphic esiModel = JsonConvert.DeserializeObject<EsiV1UniverseGraphic>(esiRaw.Model);

            return _mapper.Map<V1UniverseGraphic>(esiModel);
        }

        public async Task<V1UniverseGraphic> GraphicAsync(int graphicId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Graphic(graphicId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseGraphic esiModel = JsonConvert.DeserializeObject<EsiV1UniverseGraphic>(esiRaw.Model);

            return _mapper.Map<V1UniverseGraphic>(esiModel);
        }

        public PagedModel<int> Groups(int page)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Groups(page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<int> esiModel = JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);

            return new PagedModel<int>{Model = esiModel, MaxPages = esiRaw.MaxPages, CurrentPage = page};
        }

        public async Task<PagedModel<int>> GroupsAsync(int page)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Groups(page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<int> esiModel = JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);

            return new PagedModel<int> { Model = esiModel, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public V1UniverseGroup Group(int groupId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Group(groupId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseGroup esiModel = JsonConvert.DeserializeObject<EsiV1UniverseGroup>(esiRaw.Model);

            return _mapper.Map<V1UniverseGroup>(esiModel);
        }

        public async Task<V1UniverseGroup> GroupAsync(int groupId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Group(groupId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseGroup esiModel = JsonConvert.DeserializeObject<EsiV1UniverseGroup>(esiRaw.Model);

            return _mapper.Map<V1UniverseGroup>(esiModel);
        }

        public V1UniverseNamesToIds Ids(IList<string> names)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Ids(), _testing);

            string jsonObject = JsonConvert.SerializeObject(names);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(), url, jsonObject, SecondsToDT()));

            EsiV1UniverseNamesToIds esiModel = JsonConvert.DeserializeObject<EsiV1UniverseNamesToIds>(esiRaw.Model);

            return _mapper.Map<V1UniverseNamesToIds>(esiModel);
        }

        public async Task<V1UniverseNamesToIds> IdsAsync(IList<string> names)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Ids(), _testing);

            string jsonObject = JsonConvert.SerializeObject(names);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(), url, jsonObject, SecondsToDT()));

            EsiV1UniverseNamesToIds esiModel = JsonConvert.DeserializeObject<EsiV1UniverseNamesToIds>(esiRaw.Model);

            return _mapper.Map<V1UniverseNamesToIds>(esiModel);
        }

        public V1UniverseMoon Moon(int moonId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Moon(moonId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseMoon esiModel = JsonConvert.DeserializeObject<EsiV1UniverseMoon>(esiRaw.Model);

            return _mapper.Map<V1UniverseMoon>(esiModel);
        }

        public async Task<V1UniverseMoon> MoonAsync(int moonId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Moon(moonId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseMoon esiModel = JsonConvert.DeserializeObject<EsiV1UniverseMoon>(esiRaw.Model);

            return _mapper.Map<V1UniverseMoon>(esiModel);
        }

        public IList<V3UniverseNames> Names(IList<int> ids)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV3Names(), _testing);

            string jsonObject = JsonConvert.SerializeObject(ids);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(), url, jsonObject, SecondsToDT()));

            IList<EsiV3UniverseNames> esiModel = JsonConvert.DeserializeObject<IList<EsiV3UniverseNames>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV3UniverseNames>, IList<V3UniverseNames>>(esiModel);
        }

        public async Task<IList<V3UniverseNames>> NamesAsync(IList<int> ids)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV3Names(), _testing);

            string jsonObject = JsonConvert.SerializeObject(ids);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(), url, jsonObject, SecondsToDT()));

            IList<EsiV3UniverseNames> esiModel = JsonConvert.DeserializeObject<IList<EsiV3UniverseNames>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV3UniverseNames>, IList<V3UniverseNames>>(esiModel);
        }

        public V1UniversePlanet Planet(int planetId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Planet(planetId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniversePlanet esiModel = JsonConvert.DeserializeObject<EsiV1UniversePlanet>(esiRaw.Model);

            return _mapper.Map<V1UniversePlanet>(esiModel);
        }

        public async Task<V1UniversePlanet> PlanetAsync(int planetId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Planet(planetId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniversePlanet esiModel = JsonConvert.DeserializeObject<EsiV1UniversePlanet>(esiRaw.Model);

            return _mapper.Map<V1UniversePlanet>(esiModel);
        }

        public IList<V1UniverseRaces> Races()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Races(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV1UniverseRaces> esiModel = JsonConvert.DeserializeObject<IList<EsiV1UniverseRaces>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1UniverseRaces>, IList<V1UniverseRaces>>(esiModel);
        }

        public async Task<IList<V1UniverseRaces>> RacesAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Races(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV1UniverseRaces> esiModel = JsonConvert.DeserializeObject<IList<EsiV1UniverseRaces>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1UniverseRaces>, IList<V1UniverseRaces>>(esiModel);
        }

        public IList<int> Regions()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Regions(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> RegionsAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Regions(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public V1UniverseRegion Region(int regionId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Region(regionId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseRegion esiModel = JsonConvert.DeserializeObject<EsiV1UniverseRegion>(esiRaw.Model);

            return _mapper.Map<V1UniverseRegion>(esiModel);
        }

        public async Task<V1UniverseRegion> RegionAsync(int planetId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Region(planetId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseRegion esiModel = JsonConvert.DeserializeObject<EsiV1UniverseRegion>(esiRaw.Model);

            return _mapper.Map<V1UniverseRegion>(esiModel);
        }

        public V1UniverseStargate Stargate(int stargateId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Stargate(stargateId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseStargate esiModel = JsonConvert.DeserializeObject<EsiV1UniverseStargate>(esiRaw.Model);

            return _mapper.Map<V1UniverseStargate>(esiModel);
        }

        public async Task<V1UniverseStargate> StargateAsync(int stargateId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Stargate(stargateId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseStargate esiModel = JsonConvert.DeserializeObject<EsiV1UniverseStargate>(esiRaw.Model);

            return _mapper.Map<V1UniverseStargate>(esiModel);
        }

        public V1UniverseStar Star(int starId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Star(starId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseStar esiModel = JsonConvert.DeserializeObject<EsiV1UniverseStar>(esiRaw.Model);

            return _mapper.Map<V1UniverseStar>(esiModel);
        }

        public async Task<V1UniverseStar> StarAsync(int starId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Star(starId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1UniverseStar esiModel = JsonConvert.DeserializeObject<EsiV1UniverseStar>(esiRaw.Model);

            return _mapper.Map<V1UniverseStar>(esiModel);
        }

        public V2UniverseStation Station(int stationId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV2Station(stationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV2UniverseStation esiModel = JsonConvert.DeserializeObject<EsiV2UniverseStation>(esiRaw.Model);

            return _mapper.Map<V2UniverseStation>(esiModel);
        }

        public async Task<V2UniverseStation> StationAsync(int stationId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV2Station(stationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV2UniverseStation esiModel = JsonConvert.DeserializeObject<EsiV2UniverseStation>(esiRaw.Model);

            return _mapper.Map<V2UniverseStation>(esiModel);
        }

        public IList<long> Structures()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Structures(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            return JsonConvert.DeserializeObject<IList<long>>(esiRaw.Model);
        }

        public async Task<IList<long>> StructuresAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Structures(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            return JsonConvert.DeserializeObject<IList<long>>(esiRaw.Model);
        }

        public V2UniverseStructure Structure(SsoToken token, long structureId)
        {
            StaticMethods.CheckToken(token, UniverseScopes.esi_universe_read_structures_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV2Structure(structureId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV2UniverseStructure esiModel = JsonConvert.DeserializeObject<EsiV2UniverseStructure>(esiRaw.Model);

            return _mapper.Map<EsiV2UniverseStructure, V2UniverseStructure>(esiModel);
        }

        public async Task<V2UniverseStructure> StructureAsync(SsoToken token, long structureId)
        {
            StaticMethods.CheckToken(token, UniverseScopes.esi_universe_read_structures_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV2Structure(structureId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV2UniverseStructure esiModel = JsonConvert.DeserializeObject<EsiV2UniverseStructure>(esiRaw.Model);

            return _mapper.Map<EsiV2UniverseStructure, V2UniverseStructure>(esiModel);
        }

        public IList<V1UniverseSystemJumps> SystemJumps()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1SystemJumps(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1UniverseSystemJumps> esiModel = JsonConvert.DeserializeObject<IList<EsiV1UniverseSystemJumps>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1UniverseSystemJumps>, IList<V1UniverseSystemJumps>>(esiModel);
        }

        public async Task<IList<V1UniverseSystemJumps>> SystemJumpsAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1SystemJumps(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1UniverseSystemJumps> esiModel = JsonConvert.DeserializeObject<IList<EsiV1UniverseSystemJumps>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1UniverseSystemJumps>, IList<V1UniverseSystemJumps>>(esiModel);
        }

        public IList<V2UniverseSystemKills> SystemKills()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV2SystemKills(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV2UniverseSystemKills> esiModel = JsonConvert.DeserializeObject<IList<EsiV2UniverseSystemKills>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2UniverseSystemKills>, IList<V2UniverseSystemKills>>(esiModel);
        }

        public async Task<IList<V2UniverseSystemKills>> SystemKillsAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV2SystemKills(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV2UniverseSystemKills> esiModel = JsonConvert.DeserializeObject<IList<EsiV2UniverseSystemKills>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2UniverseSystemKills>, IList<V2UniverseSystemKills>>(esiModel);
        }

        public IList<int> Systems()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Systems(), _testing);

            EsiModel esiModel = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiModel.Model);
        }

        public async Task<IList<int>> SystemsAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Systems(), _testing);

            EsiModel esiModel = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            return JsonConvert.DeserializeObject<IList<int>>(esiModel.Model);
        }

        public V4UniverseSystem System(int systemId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV4System(systemId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV4UniverseSystem esiModel = JsonConvert.DeserializeObject<EsiV4UniverseSystem>(esiRaw.Model);

            return _mapper.Map<EsiV4UniverseSystem, V4UniverseSystem>(esiModel);
        }

        public async Task<V4UniverseSystem> SystemAsync(int systemId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV4System(systemId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV4UniverseSystem esiModel = JsonConvert.DeserializeObject<EsiV4UniverseSystem>(esiRaw.Model);

            return _mapper.Map<EsiV4UniverseSystem, V4UniverseSystem>(esiModel);
        }

        public PagedModel<int> Types(int page)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Types(page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<int> esiModel = JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);

            return new PagedModel<int> { Model = esiModel, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<int>> TypesAsync(int page)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV1Types(page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<int> esiModel = JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);

            return new PagedModel<int> { Model = esiModel, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public V3UniverseType Type(int typeId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV3Type(typeId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV3UniverseType esiModel = JsonConvert.DeserializeObject<EsiV3UniverseType>(esiRaw.Model);

            return _mapper.Map<EsiV3UniverseType, V3UniverseType>(esiModel);
        }

        public async Task<V3UniverseType> TypeAsync(int typeId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.UniverseV3Type(typeId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV3UniverseType esiModel = JsonConvert.DeserializeObject<EsiV3UniverseType>(esiRaw.Model);

            return _mapper.Map<EsiV3UniverseType, V3UniverseType>(esiModel);
        }
    }
}
