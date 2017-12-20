using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ISkillsEndpoints
    {
        Attributes GetAttributes(SsoToken token);
        Task<Attributes> GetAttributesAsync(SsoToken token);
        IList<SkillQueueSkill> GetSkillQueue(SsoToken token);
        Task<IList<SkillQueueSkill>> GetSkillQueueAsync(SsoToken token);
        Skills GetSkills(SsoToken token);
        Task<Skills> GetSkillsAsync(SsoToken token);
    }
}