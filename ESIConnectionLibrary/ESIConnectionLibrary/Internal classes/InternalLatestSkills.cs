using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.Automapper_Profiles;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestSkills : IInternalLatestSkills
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestSkills(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<SkillsProfile>();
                });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public IList<V2SkillsSkillQueue> SkillQueue(SsoToken token)
        {
            StaticMethods.CheckToken(token, SkillScopes.esi_skills_read_skillqueue_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.SkillsV2SkillQueue(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 120));

            IList<EsiV2SkillsSkillQueue> esiModel = JsonConvert.DeserializeObject<IList<EsiV2SkillsSkillQueue>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2SkillsSkillQueue>, IList<V2SkillsSkillQueue>>(esiModel);
        }

        public async Task<IList<V2SkillsSkillQueue>> SkillQueueAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, SkillScopes.esi_skills_read_skillqueue_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.SkillsV2SkillQueue(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 120));

            IList<EsiV2SkillsSkillQueue> esiModel = JsonConvert.DeserializeObject<IList<EsiV2SkillsSkillQueue>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2SkillsSkillQueue>, IList<V2SkillsSkillQueue>>(esiModel);
        }

        public V4SkillsSkills Skills(SsoToken token)
        {
            StaticMethods.CheckToken(token, SkillScopes.esi_skills_read_skills_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.SkillsV4Skills(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 120));

            EsiV4SkillsSkills esiModel = JsonConvert.DeserializeObject<EsiV4SkillsSkills>(esiRaw.Model);

            return _mapper.Map<EsiV4SkillsSkills, V4SkillsSkills>(esiModel);
        }

        public async Task<V4SkillsSkills> SkillsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, SkillScopes.esi_skills_read_skills_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.SkillsV4Skills(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 120));

            EsiV4SkillsSkills esiModel = JsonConvert.DeserializeObject<EsiV4SkillsSkills>(esiRaw.Model);

            return _mapper.Map<EsiV4SkillsSkills, V4SkillsSkills>(esiModel);
        }

        public V1SkillsAttributes Attributes(SsoToken token)
        {
            StaticMethods.CheckToken(token, SkillScopes.esi_skills_read_skills_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.SkillsV1Attributes(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 120));

            EsiV1SkillsAttributes esiModel = JsonConvert.DeserializeObject<EsiV1SkillsAttributes>(esiRaw.Model);

            return _mapper.Map<EsiV1SkillsAttributes, V1SkillsAttributes>(esiModel);
        }

        public async Task<V1SkillsAttributes> AttributesAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, SkillScopes.esi_skills_read_skills_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.SkillsV1Attributes(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 120));

            EsiV1SkillsAttributes esiModel = JsonConvert.DeserializeObject<EsiV1SkillsAttributes>(esiRaw.Model);

            return _mapper.Map<EsiV1SkillsAttributes, V1SkillsAttributes>(esiModel);
        }
    }
}
