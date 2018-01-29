using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class SkillsQueueMappings : Profile
    {
        public SkillsQueueMappings()
        {
            CreateMap<EsiSkillQueueSkill, SkillQueueSkill>();
        }
    }

    internal class SkillsMappings : Profile
    {
        public SkillsMappings()
        {
            CreateMap<EsiSkills, Skills>();
        }
    }

    internal class SkillsSkillMappings : Profile
    {
        public SkillsSkillMappings()
        {
            CreateMap<EsiSkillsSkill, SkillsSkill>();
        }
    }

    internal class AttributesMappings : Profile
    {
        public AttributesMappings()
        {
            CreateMap<EsiAttributes, Attributes>();
        }
    }
}
