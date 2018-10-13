using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestSkills
    {
        IList<V2SkillsSkillQueue> SkillQueue(SsoToken token);
        Task<IList<V2SkillsSkillQueue>> SkillQueueAsync(SsoToken token);
        V4SkillsSkills Skills(SsoToken token);
        Task<V4SkillsSkills> SkillsAsync(SsoToken token);
        V1SkillsAttributes Attributes(SsoToken token);
        Task<V1SkillsAttributes> AttributesAsync(SsoToken token);
    }
}