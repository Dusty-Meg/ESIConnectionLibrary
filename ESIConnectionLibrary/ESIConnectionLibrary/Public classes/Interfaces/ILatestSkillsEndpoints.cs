using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestSkillsEndpoints
    {
        V1SkillsAttributes Attributes(SsoToken token);
        Task<V1SkillsAttributes> AttributesAsync(SsoToken token);
        IList<V2SkillsSkillQueue> SkillQueue(SsoToken token);
        Task<IList<V2SkillsSkillQueue>> SkillQueueAsync(SsoToken token);
        V4SkillsSkills Skills(SsoToken token);
        Task<V4SkillsSkills> SkillsAsync(SsoToken token);
    }
}