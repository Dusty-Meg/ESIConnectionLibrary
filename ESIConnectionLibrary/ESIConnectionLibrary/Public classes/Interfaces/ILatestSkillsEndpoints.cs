using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestSkillsEndpoints
    {
        V1Attributes GetAttributes(SsoToken token);
        Task<V1Attributes> GetAttributesAsync(SsoToken token);
        IList<V2SkillQueueSkill> GetSkillQueue(SsoToken token);
        Task<IList<V2SkillQueueSkill>> GetSkillQueueAsync(SsoToken token);
        V4Skills GetSkills(SsoToken token);
        Task<V4Skills> GetSkillsAsync(SsoToken token);
    }
}