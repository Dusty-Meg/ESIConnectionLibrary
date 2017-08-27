using System.Collections.Generic;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class SkillsEndpoints
    {
        private IInternalSkills InternalSkills { get; }

        public SkillsEndpoints()
        {
            InternalSkills = new InternalSkills(null);
        }

        public IList<SkillQueueSkill> GetSkillQueue(SsoLogicToken token)
        {
            return InternalSkills.GetSkillQueue(token);
        }

        public Skills GetSkills(SsoLogicToken token)
        {
            return InternalSkills.GetSkills(token);
        }
    }
}
