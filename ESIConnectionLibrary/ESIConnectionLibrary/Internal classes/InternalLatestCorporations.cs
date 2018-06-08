using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestCorporations : IInternalLatestCorporations
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestCorporations(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CorporationRolesMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public IList<V1CorporationsRoles> GetCorporationRoles(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_corporation_membership_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1CorporationRoles(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() =>_webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationsRoles> esiCorporationsRoles = JsonConvert.DeserializeObject<IList<EsiV1CorporationsRoles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CorporationsRoles>, IList<V1CorporationsRoles>>(esiCorporationsRoles);
        }

        public async Task<IList<V1CorporationsRoles>> GetCorporationRolesAsync(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_corporation_membership_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1CorporationRoles(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationsRoles> esiCorporationsRoles = JsonConvert.DeserializeObject<IList<EsiV1CorporationsRoles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CorporationsRoles>, IList<V1CorporationsRoles>>(esiCorporationsRoles);
        }

        public IList<V1CorporationMemberTitle> GetCorporationMemberTitles(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_titles_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1CorporationMemberTitles(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationMemberTitle> esiV1CorporationMemberTitles = JsonConvert.DeserializeObject<IList<EsiV1CorporationMemberTitle>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CorporationMemberTitle>, IList<V1CorporationMemberTitle>>(esiV1CorporationMemberTitles);
        }

        public async Task<IList<V1CorporationMemberTitle>> GetCorporationMemberTitlesAsync(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_titles_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1CorporationMemberTitles(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationMemberTitle> esiV1CorporationMemberTitles = JsonConvert.DeserializeObject<IList<EsiV1CorporationMemberTitle>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CorporationMemberTitle>, IList<V1CorporationMemberTitle>>(esiV1CorporationMemberTitles);
        }

        public IList<V1CorporationTitles> GetCorporationTitles(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_titles_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1CorporationTitles(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationTitles> esiV1CorporationTitles = JsonConvert.DeserializeObject<IList<EsiV1CorporationTitles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CorporationTitles>, IList<V1CorporationTitles>>(esiV1CorporationTitles);
        }

        public async Task<IList<V1CorporationTitles>> GetCorporationTitlesAsync(SsoToken token, long corporationId)
        {
            StaticMethods.CheckToken(token, CorporationScopes.esi_corporations_read_titles_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CorporationV1CorporationTitles(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CorporationTitles> esiV1CorporationTitles = JsonConvert.DeserializeObject<IList<EsiV1CorporationTitles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CorporationTitles>, IList<V1CorporationTitles>>(esiV1CorporationTitles);
        }
    }
}
