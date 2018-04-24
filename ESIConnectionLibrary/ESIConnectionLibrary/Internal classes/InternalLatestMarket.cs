using System;
using System.Collections.Generic;
using System.Text;
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
