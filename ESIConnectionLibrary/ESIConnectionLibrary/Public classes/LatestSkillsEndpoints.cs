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

        public IList<V2SkillsSkillQueue> SkillQueue(SsoToken token)
        {
            return _internalLatestSkills.SkillQueue(token);
        }

        public async Task<IList<V2SkillsSkillQueue>> SkillQueueAsync(SsoToken token)
        {
            return await _internalLatestSkills.SkillQueueAsync(token);
        }

        public V4SkillsSkills Skills(SsoToken token)
        {
            return _internalLatestSkills.Skills(token);
        }

        public async Task<V4SkillsSkills> SkillsAsync(SsoToken token)
        {
            return await _internalLatestSkills.SkillsAsync(token);
        }

        public V1SkillsAttributes Attributes(SsoToken token)
        {
            return _internalLatestSkills.Attributes(token);
        }

        public async Task<V1SkillsAttributes> AttributesAsync(SsoToken token)
        {
            return await _internalLatestSkills.AttributesAsync(token);
        }
    }
}
