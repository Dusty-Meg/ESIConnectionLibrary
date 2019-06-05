using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.Automapper_Profiles;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestInsurance : IInternalLatestInsurance
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestInsurance(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<InsuranceProfile>();
                });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public IList<V1InsuranceInsurance> Insurance()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.InsuranceV1Insurance(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1InsuranceInsurance> esiInsuranceShips = JsonConvert.DeserializeObject<IList<EsiV1InsuranceInsurance>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1InsuranceInsurance>, IList<V1InsuranceInsurance>>(esiInsuranceShips);
        }

        public async Task<IList<V1InsuranceInsurance>> InsuranceAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.InsuranceV1Insurance(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1InsuranceInsurance> esiInsuranceShips = JsonConvert.DeserializeObject<IList<EsiV1InsuranceInsurance>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1InsuranceInsurance>, IList<V1InsuranceInsurance>>(esiInsuranceShips);
        }
    }
}
