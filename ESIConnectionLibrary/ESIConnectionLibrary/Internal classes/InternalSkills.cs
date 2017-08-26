using System.Collections.Generic;
using System.Net;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.Exceptions;
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
                cfg.CreateMap<ESISkillQueueSkill, SkillQueueSkill>();
            } );

            WebClient = webClient ?? new WebClient();
            Mapper = new Mapper(provider);
        }

        public IList<SkillQueueSkill> GetSkillQueue(SsoLogicToken token)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.ScopeList == null || !token.ScopeList.Contains(Scopes.esi_skills_read_skillqueue_v1))
            {
                throw new ESIException("This token does not have esi-skills.read_skillqueue.v1");
            }
            
            WebHeaderCollection headers = new WebHeaderCollection
            {
                [HttpRequestHeader.Authorization] = $"Bearer {token.AccessToken}",
                [HttpRequestHeader.Accept] = "application/json"
            };

            string membersUrl = $@"https://esi.tech.ccp.is/latest/characters/{token.CharacterId}/skillqueue/";

            string skillsRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => WebClient.Get(headers, membersUrl, 120));
            IList<ESISkillQueueSkill> esiSkillQueue = JsonConvert.DeserializeObject<IList<ESISkillQueueSkill>>(skillsRaw);

            return Mapper.Map<IList<ESISkillQueueSkill>, IList<SkillQueueSkill>>(esiSkillQueue);
        }
    }
}
