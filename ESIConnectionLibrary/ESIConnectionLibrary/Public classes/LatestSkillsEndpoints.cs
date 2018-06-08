using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestSkillsEndpoints : ILatestSkillsEndpoints
    {
        private readonly IInternalLatestSkills _internalLatestSkills;

        public LatestSkillsEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestSkills = new InternalLatestSkills(null, userAgent, testing);
        }

        public IList<V2SkillQueueSkill> GetSkillQueue(SsoToken token)
        {
            return _internalLatestSkills.GetSkillQueue(token);
        }

        public async Task<IList<V2SkillQueueSkill>> GetSkillQueueAsync(SsoToken token)
        {
            return await _internalLatestSkills.GetSkillQueueAsync(token);
        }

        public V4Skills GetSkills(SsoToken token)
        {
            return _internalLatestSkills.GetSkills(token);
        }

        public async Task<V4Skills> GetSkillsAsync(SsoToken token)
        {
            return await _internalLatestSkills.GetSkillsAsync(token);
        }

        public V1Attributes GetAttributes(SsoToken token)
        {
            return _internalLatestSkills.GetAttributes(token);
        }

        public async Task<V1Attributes> GetAttributesAsync(SsoToken token)
        {
            return await _internalLatestSkills.GetAttributesAsync(token);
        }
    }
}
