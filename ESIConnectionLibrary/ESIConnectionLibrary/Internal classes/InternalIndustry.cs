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
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalIndustry(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CharacterIndustryJobsMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public IList<CharacterIndustryJob> GetCharactersIndustryJobs(SsoToken token, bool includeCompletedJobs)
        {
            StaticMethods.CheckToken(token, Scopes.esi_industry_read_character_jobs_v1);

            string url = StaticConnectionStrings.IndustryCharacterJobs(token.CharacterId, includeCompletedJobs);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiCharacterIndustryJob> esiSkillQueue = JsonConvert.DeserializeObject<IList<EsiCharacterIndustryJob>>(esiRaw);

            return _mapper.Map<IList<EsiCharacterIndustryJob>, IList<CharacterIndustryJob>>(esiSkillQueue);
        }
    }
}
