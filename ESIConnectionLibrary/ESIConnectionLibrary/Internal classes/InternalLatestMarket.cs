using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.Automapper_Profiles;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestMarket : IInternalLatestMarket
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestMarket(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MarketProfile>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        private int SecondsToDt()
        {
            DateTime now = DateTime.Now;

            DateTime todaysDt = new DateTime(now.Year, now.Month, now.Day, 11, 5, 0);

            if ((todaysDt - now).TotalSeconds < 0)
            {
                return (int)(todaysDt.AddDays(1) - now).TotalSeconds;
            }

            return (int)(todaysDt - now).TotalSeconds;
        }

        public IList<V2MarketCharactersOrders> CharacterOrders(SsoToken token)
        {
            StaticMethods.CheckToken(token, MarketScopes.esi_markets_read_character_orders_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV2CharacterOrders(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 1200));

            IList<EsiV2MarketCharactersOrders> esiModel = JsonConvert.DeserializeObject<IList<EsiV2MarketCharactersOrders>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2MarketCharactersOrders>, IList<V2MarketCharactersOrders>>(esiModel);
        }

        public async Task<IList<V2MarketCharactersOrders>> CharacterOrdersAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, MarketScopes.esi_markets_read_character_orders_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV2CharacterOrders(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 1200));

            IList<EsiV2MarketCharactersOrders> esiModel = JsonConvert.DeserializeObject<IList<EsiV2MarketCharactersOrders>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2MarketCharactersOrders>, IList<V2MarketCharactersOrders>>(esiModel);
        }

        public PagedModel<V1MarketCharacterHistoricOrders> CharacterOrdersHistoric(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, MarketScopes.esi_markets_read_character_orders_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1CharacterOrdersHistoric(token.CharacterId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1MarketCharacterHistoricOrders> esiModel = JsonConvert.DeserializeObject<IList<EsiV1MarketCharacterHistoricOrders>>(esiRaw.Model);

            IList<V1MarketCharacterHistoricOrders> mapped = _mapper.Map<IList<EsiV1MarketCharacterHistoricOrders>, IList<V1MarketCharacterHistoricOrders>>(esiModel);

            return new PagedModel<V1MarketCharacterHistoricOrders>{ Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V1MarketCharacterHistoricOrders>> CharacterOrdersHistoricAsync(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, MarketScopes.esi_markets_read_character_orders_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1CharacterOrdersHistoric(token.CharacterId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1MarketCharacterHistoricOrders> esiModel = JsonConvert.DeserializeObject<IList<EsiV1MarketCharacterHistoricOrders>>(esiRaw.Model);

            IList<V1MarketCharacterHistoricOrders> mapped = _mapper.Map<IList<EsiV1MarketCharacterHistoricOrders>, IList<V1MarketCharacterHistoricOrders>>(esiModel);

            return new PagedModel<V1MarketCharacterHistoricOrders> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public PagedModel<V3MarketCorporationOrders> CorporationOrders(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, MarketScopes.esi_markets_read_corporation_orders_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV3CorporationOrders(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 1200));

            IList<EsiV3MarketCorporationOrders> esiModel = JsonConvert.DeserializeObject<IList<EsiV3MarketCorporationOrders>>(esiRaw.Model);

            IList<V3MarketCorporationOrders> mapped = _mapper.Map<IList<EsiV3MarketCorporationOrders>, IList<V3MarketCorporationOrders>>(esiModel);

            return new PagedModel<V3MarketCorporationOrders> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V3MarketCorporationOrders>> CorporationOrdersAsync(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, MarketScopes.esi_markets_read_corporation_orders_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV3CorporationOrders(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 1200));

            IList<EsiV3MarketCorporationOrders> esiModel = JsonConvert.DeserializeObject<IList<EsiV3MarketCorporationOrders>>(esiRaw.Model);

            IList<V3MarketCorporationOrders> mapped = _mapper.Map<IList<EsiV3MarketCorporationOrders>, IList<V3MarketCorporationOrders>>(esiModel);

            return new PagedModel<V3MarketCorporationOrders> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public PagedModel<V3MarketCorporationOrdersHistoric> CorporationOrdersHistoric(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, MarketScopes.esi_markets_read_corporation_orders_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV2CorporationOrdersHistoric(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV3MarketCorporationOrdersHistoric> esiModel = JsonConvert.DeserializeObject<IList<EsiV3MarketCorporationOrdersHistoric>>(esiRaw.Model);

            IList<V3MarketCorporationOrdersHistoric> mapped = _mapper.Map<IList<EsiV3MarketCorporationOrdersHistoric>, IList<V3MarketCorporationOrdersHistoric>>(esiModel);

            return new PagedModel<V3MarketCorporationOrdersHistoric> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V3MarketCorporationOrdersHistoric>> CorporationOrdersHistoricAsync(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, MarketScopes.esi_markets_read_corporation_orders_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV2CorporationOrdersHistoric(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV3MarketCorporationOrdersHistoric> esiModel = JsonConvert.DeserializeObject<IList<EsiV3MarketCorporationOrdersHistoric>>(esiRaw.Model);

            IList<V3MarketCorporationOrdersHistoric> mapped = _mapper.Map<IList<EsiV3MarketCorporationOrdersHistoric>, IList<V3MarketCorporationOrdersHistoric>>(esiModel);

            return new PagedModel<V3MarketCorporationOrdersHistoric> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public IList<V1MarketHistory> History(int regionId, int typeId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1History(regionId, typeId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDt()));

            IList<EsiV1MarketHistory> esiModel = JsonConvert.DeserializeObject<IList<EsiV1MarketHistory>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1MarketHistory>, IList<V1MarketHistory>>(esiModel);
        }

        public async Task<IList<V1MarketHistory>> HistoryAsync(int regionId, int typeId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1History(regionId, typeId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDt()));

            IList<EsiV1MarketHistory> esiModel = JsonConvert.DeserializeObject<IList<EsiV1MarketHistory>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1MarketHistory>, IList<V1MarketHistory>>(esiModel);
        }

        public PagedModel<V1MarketOrders> Orders(int regionId, OrderType orderType, int page, int? typeId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1Orders(regionId, orderType, page, typeId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 300));

            IList<EsiV1MarketOrders> esiModel = JsonConvert.DeserializeObject<IList<EsiV1MarketOrders>>(esiRaw.Model);

            IList<V1MarketOrders> mapped = _mapper.Map<IList<EsiV1MarketOrders>, IList<V1MarketOrders>>(esiModel);

            return new PagedModel<V1MarketOrders> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V1MarketOrders>> OrdersAsync(int regionId, OrderType orderType, int page, int? typeId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1Orders(regionId, orderType, page, typeId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 300));

            IList<EsiV1MarketOrders> esiModel = JsonConvert.DeserializeObject<IList<EsiV1MarketOrders>>(esiRaw.Model);

            IList<V1MarketOrders> mapped = _mapper.Map<IList<EsiV1MarketOrders>, IList<V1MarketOrders>>(esiModel);

            return new PagedModel<V1MarketOrders> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public PagedModel<int> Types(int regionId, int page)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1Types(regionId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 600));

            IList<int> esiModel = JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);

            return new PagedModel<int> { Model = esiModel, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<int>> TypesAsync(int regionId, int page)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1Types(regionId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 600));

            IList<int> esiModel = JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);

            return new PagedModel<int> { Model = esiModel, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public IList<int> Groups()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1Groups(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDt()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> GroupsAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1Groups(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDt()));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public V1MarketGroupInformation Group(int marketGroupId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1Group(marketGroupId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDt()));

            EsiV1MarketGroupInformation esiModel = JsonConvert.DeserializeObject<EsiV1MarketGroupInformation>(esiRaw.Model);

            return _mapper.Map<V1MarketGroupInformation>(esiModel);
        }

        public async Task<V1MarketGroupInformation> GroupAsync(int marketGroupId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1Group(marketGroupId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDt()));

            EsiV1MarketGroupInformation esiModel = JsonConvert.DeserializeObject<EsiV1MarketGroupInformation>(esiRaw.Model);

            return _mapper.Map<V1MarketGroupInformation>(esiModel);
        }

        public IList<V1MarketPrice> Prices()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1Prices(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1MarketPrice> esiModel = JsonConvert.DeserializeObject<IList<EsiV1MarketPrice>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1MarketPrice>, IList<V1MarketPrice>>(esiModel);
        }

        public async Task<IList<V1MarketPrice>> PricesAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1Prices(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1MarketPrice> esiModel = JsonConvert.DeserializeObject<IList<EsiV1MarketPrice>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1MarketPrice>, IList<V1MarketPrice>>(esiModel);
        }

        public PagedModel<V1MarketStructure> Structure(SsoToken token, long structureId, int page)
        {
            StaticMethods.CheckToken(token, MarketScopes.esi_markets_structure_markets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1Structure(structureId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1MarketStructure> esiModel = JsonConvert.DeserializeObject<IList<EsiV1MarketStructure>>(esiRaw.Model);

            IList<V1MarketStructure> mapped = _mapper.Map<IList<EsiV1MarketStructure>, IList<V1MarketStructure>>(esiModel);

            return new PagedModel<V1MarketStructure> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V1MarketStructure>> StructureAsync(SsoToken token, long structureId, int page)
        {
            StaticMethods.CheckToken(token, MarketScopes.esi_markets_structure_markets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1Structure(structureId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1MarketStructure> esiModel = JsonConvert.DeserializeObject<IList<EsiV1MarketStructure>>(esiRaw.Model);

            IList<V1MarketStructure> mapped = _mapper.Map<IList<EsiV1MarketStructure>, IList<V1MarketStructure>>(esiModel);

            return new PagedModel<V1MarketStructure> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }
    }
}
