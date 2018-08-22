using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestIndustry : IInternalLatestIndustry
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestIndustry(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public IList<V1CharacterIndustryJob> GetCharactersIndustryJobs(SsoToken token, bool includeCompletedJobs)
        {
            StaticMethods.CheckToken(token, IndustryScopes.esi_industry_read_character_jobs_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IndustryCharacterJobs(token.CharacterId, includeCompletedJobs), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1CharacterIndustryJob> esiSkillQueue = JsonConvert.DeserializeObject<IList<EsiV1CharacterIndustryJob>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharacterIndustryJob>, IList<V1CharacterIndustryJob>>(esiSkillQueue);
        }

        public async Task<IList<V1CharacterIndustryJob>> GetCharactersIndustryJobsAsync(SsoToken token, bool includeCompletedJobs)
        {
            StaticMethods.CheckToken(token, IndustryScopes.esi_industry_read_character_jobs_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IndustryCharacterJobs(token.CharacterId, includeCompletedJobs), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1CharacterIndustryJob> esiSkillQueue = JsonConvert.DeserializeObject<IList<EsiV1CharacterIndustryJob>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharacterIndustryJob>, IList<V1CharacterIndustryJob>>(esiSkillQueue);
        }
    }
}
