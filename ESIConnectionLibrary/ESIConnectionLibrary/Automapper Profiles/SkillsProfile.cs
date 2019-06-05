using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class SkillsProfile : Profile
    {
        public SkillsProfile()
        {
            CreateMap<EsiV2SkillsSkillQueue, V2SkillsSkillQueue>();
            CreateMap<EsiV4SkillsSkills, V4SkillsSkills>();
            CreateMap<EsiV4SkillsSkillsSkill, V4SkillsSkillsSkill>();
            CreateMap<EsiV1SkillsAttributes, V1SkillsAttributes>();
        }
    }
}
