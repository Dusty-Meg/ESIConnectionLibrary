using System.Collections.Generic;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestInsurance : IInternalLatestInsurance
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalLatestInsurance(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InsuranceShipPricesMappings>();
                cfg.AddProfile<InsuranceShipPriceLevelsMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public IList<V1InsuranceShipPrices> GetInsurancePrices()
        {
            string url = StaticConnectionStrings.InsuranceGetPrices();

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1InsuranceShipPrices> esiInsuranceShips = JsonConvert.DeserializeObject<IList<EsiV1InsuranceShipPrices>>(esiRaw);

            return _mapper.Map<IList<EsiV1InsuranceShipPrices>, IList<V1InsuranceShipPrices>>(esiInsuranceShips);
        }
    }
}
