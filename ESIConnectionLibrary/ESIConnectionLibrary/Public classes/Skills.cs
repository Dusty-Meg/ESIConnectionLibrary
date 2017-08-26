using System.Collections.Generic;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class Skills
    {
        private IInternalSkills InternalSkills { get; }

        public Skills()
        {
            InternalSkills = new InternalSkills(null);
        }

        public IList<SkillQueueSkill> GetSkillQueue(SsoLogicToken token)
        {
            return InternalSkills.GetSkillQueue(token);
        }
    }
}
