using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestLoyalty : IInternalLatestLoyalty
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestLoyalty(IWebClient webClient, string userAgent, bool testing = false)
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

            return (int)(todaysDt - now).TotalSeconds;
        }

        public IList<V1LoyaltyPoint> Points(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_loyalty_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.LoyaltyV1Points(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1LoyaltyPoint> model = JsonConvert.DeserializeObject<IList<EsiV1LoyaltyPoint>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1LoyaltyPoint>, IList<V1LoyaltyPoint>>(model);
        }

        public async Task<IList<V1LoyaltyPoint>> PointsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_loyalty_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.LoyaltyV1Points(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1LoyaltyPoint> model = JsonConvert.DeserializeObject<IList<EsiV1LoyaltyPoint>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1LoyaltyPoint>, IList<V1LoyaltyPoint>>(model);
        }

        public IList<V1LoyaltyOffer> Offers(int corporationId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.LoyaltyV1Offers(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV1LoyaltyOffer> model = JsonConvert.DeserializeObject<IList<EsiV1LoyaltyOffer>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1LoyaltyOffer>, IList<V1LoyaltyOffer>>(model);
        }

        public async Task<IList<V1LoyaltyOffer>> OffersAsync(int corporationId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.LoyaltyV1Offers(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, SecondsToDT()));

            IList<EsiV1LoyaltyOffer> model = JsonConvert.DeserializeObject<IList<EsiV1LoyaltyOffer>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1LoyaltyOffer>, IList<V1LoyaltyOffer>>(model);
        }
    }
}
