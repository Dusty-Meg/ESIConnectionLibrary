using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class SkillsQueueMappings : Profile
    {
        public SkillsQueueMappings()
        {
            CreateMap<EsiV2SkillQueueSkill, V2SkillQueueSkill>();
        }
    }

    internal class SkillsMappings : Profile
    {
        public SkillsMappings()
        {
            CreateMap<EsiV4Skills, V4Skills>();
        }
    }

    internal class SkillsSkillMappings : Profile
    {
        public SkillsSkillMappings()
        {
            CreateMap<EsiV4SkillsSkill, V4SkillsSkill>();
        }
    }

    internal class AttributesMappings : Profile
    {
        public AttributesMappings()
        {
            CreateMap<EsiV1Attributes, V1Attributes>();
        }
    }
}
