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
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalSkills(IWebClient webClient)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SkillsMappings>();
                cfg.AddProfile<SkillsQueueMappings>();
                cfg.AddProfile<SkillsSkillMappings>();
                cfg.AddProfile<AttributesMappings>();
            } );

            _webClient = webClient ?? new WebClient();
            _mapper = new Mapper(provider);
        }

        public IList<SkillQueueSkill> GetSkillQueue(SsoToken token)
        {
            StaticMethods.CheckToken(token, Scopes.esi_skills_read_skillqueue_v1);

            string url = $@"https://esi.tech.ccp.is/v2/characters/{token.CharacterId}/skillqueue/";

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 120));

            IList<EsiSkillQueueSkill> esiSkillQueue = JsonConvert.DeserializeObject<IList<EsiSkillQueueSkill>>(esiRaw);

            return _mapper.Map<IList<EsiSkillQueueSkill>, IList<SkillQueueSkill>>(esiSkillQueue);
        }

        public Skills GetSkills(SsoToken token)
        {
            StaticMethods.CheckToken(token, Scopes.esi_skills_read_skills_v1);

            string url = $@"https://esi.tech.ccp.is/v3/characters/{token.CharacterId}/skills/";

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 120));

            EsiSkills esiSkills = JsonConvert.DeserializeObject<EsiSkills>(esiRaw);

            return _mapper.Map<EsiSkills, Skills>(esiSkills);
        }

        public Attributes GetAttributes(SsoToken token)
        {
            StaticMethods.CheckToken(token, Scopes.esi_skills_read_skills_v1);

            string url = $@"https://esi.tech.ccp.is/v1/characters/{token.CharacterId}/attributes/";

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 120));

            EsiAttributes esiAttributes = JsonConvert.DeserializeObject<EsiAttributes>(esiRaw);

            return _mapper.Map<EsiAttributes, Attributes>(esiAttributes);
        }
    }
}
