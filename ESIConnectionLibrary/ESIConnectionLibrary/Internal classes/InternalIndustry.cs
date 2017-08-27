using System.Collections.Generic;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalIndustry : IInternalIndustry
    {
        private IWebClient WebClient { get; }
        private IMapper Mapper { get; }

        public InternalIndustry(IWebClient webClient)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CharacterIndustryJobsMappings>();
            });

            WebClient = webClient ?? new WebClient();
            Mapper = new Mapper(provider);
        }

        public IList<CharacterIndustryJob> GetChractersIndustryJobs(SsoToken token, bool includeCompletedJobs)
        {
            StaticMethods.CheckToken(token, Scopes.esi_industry_read_character_jobs_v1);

            string url = $@"https://esi.tech.ccp.is: /v1/characters/{token.CharacterId}/industry/jobs/?include_completed={includeCompletedJobs}";

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => WebClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiCharacterIndustryJob> esiSkillQueue = JsonConvert.DeserializeObject<IList<EsiCharacterIndustryJob>>(esiRaw);

            return Mapper.Map<IList<EsiCharacterIndustryJob>, IList<CharacterIndustryJob>>(esiSkillQueue);
        }
    }
}
