using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class SkillsQueueMappings : Profile
    {
        public SkillsQueueMappings()
        {
            CreateMap<EsiSkillQueueSkill, SkillQueueSkill>()
                .ForMember(x => x.FinishDate, m => m.MapFrom(a => a.finish_date))
                .ForMember(x => x.FinishedLevel, m => m.MapFrom(a => a.finished_level))
                .ForMember(x => x.QueuePosition, m => m.MapFrom(a => a.queue_position))
                .ForMember(x => x.SkillId, m => m.MapFrom(a => a.skill_id))
                .ForMember(x => x.StartDate, m => m.MapFrom(a => a.start_date))
                ;
        }
    }

    internal class SkillsMappings : Profile
    {
        public SkillsMappings()
        {
            CreateMap<EsiSkills, Skills>()
                .ForMember(x => x.TotalSp, m => m.MapFrom(a => a.total_sp))
                .ForMember(x => x.skills, m => m.MapFrom(a => a.skills))
                ;
        }
    }

    internal class SkillsSkillMappings : Profile
    {
        public SkillsSkillMappings()
        {
            CreateMap<EsiSkillsSkill, SkillsSkill>()
                .ForMember(x => x.SkillId, m => m.MapFrom(a => a.skill_id))
                .ForMember(x => x.SkillpointsInSkill, m => m.MapFrom(a => a.skillpoints_in_skill))
                .ForMember(x => x.CurrentSkillLevel, m => m.MapFrom(a => a.current_skill_level))
                ;
        }
    }
}
