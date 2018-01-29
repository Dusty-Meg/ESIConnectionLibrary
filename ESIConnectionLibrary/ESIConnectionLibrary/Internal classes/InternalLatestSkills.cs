using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestSkills : IInternalLatestSkills
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalLatestSkills(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SkillsMappings>();
                cfg.AddProfile<SkillsQueueMappings>();
                cfg.AddProfile<SkillsSkillMappings>();
                cfg.AddProfile<AttributesMappings>();
            } );

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public IList<V2SkillQueueSkill> GetSkillQueue(SsoToken token)
        {
            StaticMethods.CheckToken(token, Scopes.esi_skills_read_skillqueue_v1);

            string url = StaticConnectionStrings.SkillsSkillQueue(token.CharacterId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 120));

            IList<EsiV2SkillQueueSkill> esiSkillQueue = JsonConvert.DeserializeObject<IList<EsiV2SkillQueueSkill>>(esiRaw);

            return _mapper.Map<IList<EsiV2SkillQueueSkill>, IList<V2SkillQueueSkill>>(esiSkillQueue);
        }

        public async Task<IList<V2SkillQueueSkill>> GetSkillQueueAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, Scopes.esi_skills_read_skillqueue_v1);

            string url = StaticConnectionStrings.SkillsSkillQueue(token.CharacterId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 120));

            IList<EsiV2SkillQueueSkill> esiSkillQueue = JsonConvert.DeserializeObject<IList<EsiV2SkillQueueSkill>>(esiRaw);

            return _mapper.Map<IList<EsiV2SkillQueueSkill>, IList<V2SkillQueueSkill>>(esiSkillQueue);
        }

        public V4Skills GetSkills(SsoToken token)
        {
            StaticMethods.CheckToken(token, Scopes.esi_skills_read_skills_v1);

            string url = StaticConnectionStrings.SkillsSkills(token.CharacterId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 120));

            EsiV4Skills esiV4Skills = JsonConvert.DeserializeObject<EsiV4Skills>(esiRaw);

            return _mapper.Map<EsiV4Skills, V4Skills>(esiV4Skills);
        }

        public async Task<V4Skills> GetSkillsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, Scopes.esi_skills_read_skills_v1);

            string url = StaticConnectionStrings.SkillsSkills(token.CharacterId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 120));

            EsiV4Skills esiV4Skills = JsonConvert.DeserializeObject<EsiV4Skills>(esiRaw);

            return _mapper.Map<EsiV4Skills, V4Skills>(esiV4Skills);
        }

        public V1Attributes GetAttributes(SsoToken token)
        {
            StaticMethods.CheckToken(token, Scopes.esi_skills_read_skills_v1);

            string url = StaticConnectionStrings.SkillsAttributes(token.CharacterId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 120));

            EsiV1Attributes esiV1Attributes = JsonConvert.DeserializeObject<EsiV1Attributes>(esiRaw);

            return _mapper.Map<EsiV1Attributes, V1Attributes>(esiV1Attributes);
        }

        public async Task<V1Attributes> GetAttributesAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, Scopes.esi_skills_read_skills_v1);

            string url = StaticConnectionStrings.SkillsAttributes(token.CharacterId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 120));

            EsiV1Attributes esiV1Attributes = JsonConvert.DeserializeObject<EsiV1Attributes>(esiRaw);

            return _mapper.Map<EsiV1Attributes, V1Attributes>(esiV1Attributes);
        }
    }
}
