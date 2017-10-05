using System.Collections.Generic;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalInsurance : IInternalInsurance
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalInsurance(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InsuranceShipPricesMappings>();
                cfg.AddProfile<InsuranceShipPriceLevelsMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public IList<InsuranceShipPrices> GetInsurancePrices()
        {
            string url = StaticConnectionStrings.InsuranceGetPrices();

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiInsuranceShipPrices> esiInsuranceShips = JsonConvert.DeserializeObject<IList<EsiInsuranceShipPrices>>(esiRaw);

            return _mapper.Map<IList<EsiInsuranceShipPrices>, IList<InsuranceShipPrices>>(esiInsuranceShips);
        }
    }
}
