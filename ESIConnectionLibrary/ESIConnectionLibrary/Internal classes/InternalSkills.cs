using System.Collections.Generic;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalSkills : IInternalSkills
    {
        private IWebClient WebClient { get; }
        private IMapper Mapper { get; }

        public InternalSkills(IWebClient webClient)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SkillsMappings>();
                cfg.AddProfile<SkillsQueueMappings>();
                cfg.AddProfile<SkillsSkillMappings>();
            } );

            WebClient = webClient ?? new WebClient();
            Mapper = new Mapper(provider);
        }

        public IList<SkillQueueSkill> GetSkillQueue(SsoLogicToken token)
        {
            StaticMethods.CheckToken(token, Scopes.esi_skills_read_skillqueue_v1);

            string url = $@"https://esi.tech.ccp.is/v2/characters/{token.CharacterId}/skillqueue/";

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => WebClient.Get(StaticMethods.CreateHeaders(token), url, 120));

            IList<EsiSkillQueueSkill> esiSkillQueue = JsonConvert.DeserializeObject<IList<EsiSkillQueueSkill>>(esiRaw);

            return Mapper.Map<IList<EsiSkillQueueSkill>, IList<SkillQueueSkill>>(esiSkillQueue);
        }

        public Skills GetSkills(SsoLogicToken token)
        {
            StaticMethods.CheckToken(token, Scopes.esi_skills_read_skills_v1);

            string url = $@"https://esi.tech.ccp.is/v3/characters/{token.CharacterId}/skills/";

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => WebClient.Get(StaticMethods.CreateHeaders(token), url, 120));

            EsiSkills esiSkills = JsonConvert.DeserializeObject<EsiSkills>(esiRaw);

            return Mapper.Map<EsiSkills, Skills>(esiSkills);
        }
    }
}
