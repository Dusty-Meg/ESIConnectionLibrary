using System.Collections.Generic;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class SkillsEndpoints : ISkillsEndpoints
    {
        private IInternalSkills InternalSkills { get; }

        public SkillsEndpoints()
        {
            InternalSkills = new InternalSkills(null);
        }

        public IList<SkillQueueSkill> GetSkillQueue(SsoToken token)
        {
            return InternalSkills.GetSkillQueue(token);
        }

        public Skills GetSkills(SsoToken token)
        {
            return InternalSkills.GetSkills(token);
        }
    }
}
