using System.Collections.Generic;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalSkills
    {
        IList<SkillQueueSkill> GetSkillQueue(SsoLogicToken token);
        Skills GetSkills(SsoLogicToken token);
    }
}