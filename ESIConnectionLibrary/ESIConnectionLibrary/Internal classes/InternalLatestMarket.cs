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
    internal class InternalLatestMarket : IInternalLatestMarket
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalLatestMarket(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MarketMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        private int SecondsToDT()
        {
            DateTime now = DateTime.Now;

            DateTime todaysDT = new DateTime(now.Year, now.Month, now.Day, 11, 5, 0);

            if ((todaysDT - now).TotalSeconds < 0)
            {
                return (int)(todaysDT.AddDays(1) - now).TotalSeconds;
            }

            return (int)(todaysDT - now).TotalSeconds;
        }

        public IList<V2MarketCharactersOrders> GetCharactersMarketOrders(SsoToken token)
        {
            StaticMethods.CheckToken(token, MarketScopes.esi_markets_read_character_orders_v1);

            string url = StaticConnectionStrings.MarketV2MarketCharactersOrders(token.CharacterId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 1200));

            IList<EsiV2MarketCharactersOrders> esiV2MarketCharactersOrders = JsonConvert.DeserializeObject<IList<EsiV2MarketCharactersOrders>>(esiRaw);

            return _mapper.Map<IList<EsiV2MarketCharactersOrders>, IList<V2MarketCharactersOrders>>(esiV2MarketCharactersOrders);
        }

        public async Task<IList<V2MarketCharactersOrders>> GetCharactersMarketOrdersAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, MarketScopes.esi_markets_read_character_orders_v1);

            string url = StaticConnectionStrings.MarketV2MarketCharactersOrders(token.CharacterId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 1200));

            IList<EsiV2MarketCharactersOrders> esiV2MarketCharactersOrders = JsonConvert.DeserializeObject<IList<EsiV2MarketCharactersOrders>>(esiRaw);

            return _mapper.Map<IList<EsiV2MarketCharactersOrders>, IList<V2MarketCharactersOrders>>(esiV2MarketCharactersOrders);
        }

        public PagedModel<V1MarketCharacterHistoricOrders> GetCharactersMarketHistoricOrders(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, MarketScopes.esi_markets_read_character_orders_v1);

            string url = StaticConnectionStrings.MarketV1MarketCharactersHistoricOrders(token.CharacterId, page);

            PagedJson raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.GetPaged(StaticMethods.CreateHeaders(token), url, 1200));

            IList<EsiV1MarketCharacterHistoricOrders> esiV1MarketCharacterHistoricOrders = JsonConvert.DeserializeObject<IList<EsiV1MarketCharacterHistoricOrders>>(raw.Response);

            IList<V1MarketCharacterHistoricOrders> mapped = _mapper.Map<IList<EsiV1MarketCharacterHistoricOrders>, IList<V1MarketCharacterHistoricOrders>>(esiV1MarketCharacterHistoricOrders);

            return new PagedModel<V1MarketCharacterHistoricOrders>{ Model = mapped, MaxPages = raw.MaxPages.GetValueOrDefault(), CurrentPage = page };
        }

        public async Task<PagedModel<V1MarketCharacterHistoricOrders>> GetCharactersMarketHistoricOrdersAsync(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, MarketScopes.esi_markets_read_character_orders_v1);

            string url = StaticConnectionStrings.MarketV1MarketCharactersHistoricOrders(token.CharacterId, page);

            PagedJson raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetPagedAsync(StaticMethods.CreateHeaders(token), url, 1200));

            IList<EsiV1MarketCharacterHistoricOrders> esiV1MarketCharacterHistoricOrders = JsonConvert.DeserializeObject<IList<EsiV1MarketCharacterHistoricOrders>>(raw.Response);

            IList<V1MarketCharacterHistoricOrders> mapped = _mapper.Map<IList<EsiV1MarketCharacterHistoricOrders>, IList<V1MarketCharacterHistoricOrders>>(esiV1MarketCharacterHistoricOrders);

            return new PagedModel<V1MarketCharacterHistoricOrders> { Model = mapped, MaxPages = raw.MaxPages.GetValueOrDefault(), CurrentPage = page };
        }

        public V1MarketGroupInformation GetMarketGroupInformation(int marketGroupId)
        {
            string url = StaticConnectionStrings.MarketV1GetMarketGroupInformation(marketGroupId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1MarketGroupInformation esiMarketGroup = JsonConvert.DeserializeObject<EsiV1MarketGroupInformation>(esiRaw);

            return _mapper.Map<EsiV1MarketGroupInformation, V1MarketGroupInformation>(esiMarketGroup);
        }

        public async Task<V1MarketGroupInformation> GetMarketGroupInformationAsync(int marketGroupId)
        {
            string url = StaticConnectionStrings.MarketV1GetMarketGroupInformation(marketGroupId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            EsiV1MarketGroupInformation esiMarketGroup = JsonConvert.DeserializeObject<EsiV1MarketGroupInformation>(esiRaw);

            return _mapper.Map<EsiV1MarketGroupInformation, V1MarketGroupInformation>(esiMarketGroup);
        }
    }
}
