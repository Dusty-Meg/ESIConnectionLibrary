using System.Collections.Generic;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class SkillsEndpoints : ISkillsEndpoints
    {
        private readonly IInternalSkills _internalSkills;

        public SkillsEndpoints()
        {
            _internalSkills = new InternalSkills(null);
        }

        public IList<SkillQueueSkill> GetSkillQueue(SsoToken token)
        {
            return _internalSkills.GetSkillQueue(token);
        }

        public Skills GetSkills(SsoToken token)
        {
            return _internalSkills.GetSkills(token);
        }

        public Attributes GetAttributes(SsoToken token)
        {
            return _internalSkills.GetAttributes(token);
        }
    }
}
