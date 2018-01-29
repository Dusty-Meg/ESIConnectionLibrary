using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestIndustry : IInternalLatestIndustry
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalLatestIndustry(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CharacterIndustryJobsMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public IList<V1CharacterIndustryJob> GetCharactersIndustryJobs(SsoToken token, bool includeCompletedJobs)
        {
            StaticMethods.CheckToken(token, Scopes.esi_industry_read_character_jobs_v1);

            string url = StaticConnectionStrings.IndustryCharacterJobs(token.CharacterId, includeCompletedJobs);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1CharacterIndustryJob> esiSkillQueue = JsonConvert.DeserializeObject<IList<EsiV1CharacterIndustryJob>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharacterIndustryJob>, IList<V1CharacterIndustryJob>>(esiSkillQueue);
        }

        public async Task<IList<V1CharacterIndustryJob>> GetCharactersIndustryJobsAsync(SsoToken token, bool includeCompletedJobs)
        {
            StaticMethods.CheckToken(token, Scopes.esi_industry_read_character_jobs_v1);

            string url = StaticConnectionStrings.IndustryCharacterJobs(token.CharacterId, includeCompletedJobs);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1CharacterIndustryJob> esiSkillQueue = JsonConvert.DeserializeObject<IList<EsiV1CharacterIndustryJob>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharacterIndustryJob>, IList<V1CharacterIndustryJob>>(esiSkillQueue);
        }
    }
}
