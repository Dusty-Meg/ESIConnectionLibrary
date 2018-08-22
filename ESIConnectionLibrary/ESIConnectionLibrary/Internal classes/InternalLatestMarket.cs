﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

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

        public IList<V2MarketCharactersOrders> GetCharactersMarketOrders(SsoToken token)
        {
            StaticMethods.CheckToken(token, MarketScopes.esi_markets_read_character_orders_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV2MarketCharactersOrders(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 1200));

            IList<EsiV2MarketCharactersOrders> esiV2MarketCharactersOrders = JsonConvert.DeserializeObject<IList<EsiV2MarketCharactersOrders>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2MarketCharactersOrders>, IList<V2MarketCharactersOrders>>(esiV2MarketCharactersOrders);
        }

        public async Task<IList<V2MarketCharactersOrders>> GetCharactersMarketOrdersAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, MarketScopes.esi_markets_read_character_orders_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV2MarketCharactersOrders(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 1200));

            IList<EsiV2MarketCharactersOrders> esiV2MarketCharactersOrders = JsonConvert.DeserializeObject<IList<EsiV2MarketCharactersOrders>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2MarketCharactersOrders>, IList<V2MarketCharactersOrders>>(esiV2MarketCharactersOrders);
        }

        public PagedModel<V1MarketCharacterHistoricOrders> GetCharactersMarketHistoricOrders(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, MarketScopes.esi_markets_read_character_orders_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1MarketCharactersHistoricOrders(token.CharacterId, page), _testing);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 1200));

            IList<EsiV1MarketCharacterHistoricOrders> esiV1MarketCharacterHistoricOrders = JsonConvert.DeserializeObject<IList<EsiV1MarketCharacterHistoricOrders>>(raw.Model);

            IList<V1MarketCharacterHistoricOrders> mapped = _mapper.Map<IList<EsiV1MarketCharacterHistoricOrders>, IList<V1MarketCharacterHistoricOrders>>(esiV1MarketCharacterHistoricOrders);

            return new PagedModel<V1MarketCharacterHistoricOrders>{ Model = mapped, MaxPages = raw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V1MarketCharacterHistoricOrders>> GetCharactersMarketHistoricOrdersAsync(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, MarketScopes.esi_markets_read_character_orders_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1MarketCharactersHistoricOrders(token.CharacterId, page), _testing);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 1200));

            IList<EsiV1MarketCharacterHistoricOrders> esiV1MarketCharacterHistoricOrders = JsonConvert.DeserializeObject<IList<EsiV1MarketCharacterHistoricOrders>>(raw.Model);

            IList<V1MarketCharacterHistoricOrders> mapped = _mapper.Map<IList<EsiV1MarketCharacterHistoricOrders>, IList<V1MarketCharacterHistoricOrders>>(esiV1MarketCharacterHistoricOrders);

            return new PagedModel<V1MarketCharacterHistoricOrders> { Model = mapped, MaxPages = raw.MaxPages, CurrentPage = page };
        }

        public V1MarketGroupInformation GetMarketGroupInformation(int marketGroupId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1GetMarketGroupInformation(marketGroupId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDt()));

            EsiV1MarketGroupInformation esiMarketGroup = JsonConvert.DeserializeObject<EsiV1MarketGroupInformation>(esiRaw.Model);

            return _mapper.Map<EsiV1MarketGroupInformation, V1MarketGroupInformation>(esiMarketGroup);
        }

        public async Task<V1MarketGroupInformation> GetMarketGroupInformationAsync(int marketGroupId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.MarketV1GetMarketGroupInformation(marketGroupId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDt()));

            EsiV1MarketGroupInformation esiMarketGroup = JsonConvert.DeserializeObject<EsiV1MarketGroupInformation>(esiRaw.Model);

            return _mapper.Map<EsiV1MarketGroupInformation, V1MarketGroupInformation>(esiMarketGroup);
        }
    }
}
