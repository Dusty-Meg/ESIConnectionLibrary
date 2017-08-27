using System.Collections.Generic;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ISkillsEndpoints
    {
        IList<SkillQueueSkill> GetSkillQueue(SsoToken token);
        Skills GetSkills(SsoToken token);
    }
}