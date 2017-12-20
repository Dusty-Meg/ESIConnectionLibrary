using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class SkillsEndpoints : ISkillsEndpoints
    {
        private readonly IInternalSkills _internalSkills;

        public SkillsEndpoints(string userAgent)
        {
            _internalSkills = new InternalSkills(null, userAgent);
        }

        public IList<SkillQueueSkill> GetSkillQueue(SsoToken token)
        {
            return _internalSkills.GetSkillQueue(token);
        }

        public async Task<IList<SkillQueueSkill>> GetSkillQueueAsync(SsoToken token)
        {
            return await _internalSkills.GetSkillQueueAsync(token);
        }

        public Skills GetSkills(SsoToken token)
        {
            return _internalSkills.GetSkills(token);
        }

        public async Task<Skills> GetSkillsAsync(SsoToken token)
        {
            return await _internalSkills.GetSkillsAsync(token);
        }

        public Attributes GetAttributes(SsoToken token)
        {
            return _internalSkills.GetAttributes(token);
        }

        public async Task<Attributes> GetAttributesAsync(SsoToken token)
        {
            return await _internalSkills.GetAttributesAsync(token);
        }
    }
}
