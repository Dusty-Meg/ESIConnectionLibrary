using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalSkills
    {
        IList<SkillQueueSkill> GetSkillQueue(SsoToken token);
        Task<IList<SkillQueueSkill>> GetSkillQueueAsync(SsoToken token);
        Skills GetSkills(SsoToken token);
        Task<Skills> GetSkillsAsync(SsoToken token);
        Attributes GetAttributes(SsoToken token);
        Task<Attributes> GetAttributesAsync(SsoToken token);
    }
}