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
                .ForMember(x => x.LevelEndSp, m => m.MapFrom(a => a.level_end_sp))
                .ForMember(x => x.LevelStartSp, m => m.MapFrom(a => a.level_start_sp))
                .ForMember(x => x.QueuePosition, m => m.MapFrom(a => a.queue_position))
                .ForMember(x => x.SkillId, m => m.MapFrom(a => a.skill_id))
                .ForMember(x => x.StartDate, m => m.MapFrom(a => a.start_date))
                .ForMember(x => x.TrainingStartSp, m => m.MapFrom(a => a.training_start_sp))
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
                .ForMember(x => x.UnallocatedSp, m => m.MapFrom(a => a.unallocated_sp))
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
                .ForMember(x => x.TrainedSkillLevel, m => m.MapFrom(a => a.trained_skill_level))
                .ForMember(x => x.ActiveSkillLevel, m => m.MapFrom(a => a.active_skill_level))
                ;
        }
    }

    internal class AttributesMappings : Profile
    {
        public AttributesMappings()
        {
            CreateMap<EsiAttributes, Attributes>()
                .ForMember(x => x.AccruedRemapCooldownDate, m => m.MapFrom(a => a.accrued_remap_cooldown_date))
                .ForMember(x => x.BonusRemaps, m => m.MapFrom(a => a.bonus_remaps))
                .ForMember(x => x.Charisma, m => m.MapFrom(a => a.charisma))
                .ForMember(x => x.Intelligence, m => m.MapFrom(a => a.intelligence))
                .ForMember(x => x.LastRemapDate, m => m.MapFrom(a => a.last_remap_date))
                .ForMember(x => x.Memory, m => m.MapFrom(a => a.memory))
                .ForMember(x => x.Perception, m => m.MapFrom(a => a.perception))
                .ForMember(x => x.Willpower, m => m.MapFrom(a => a.willpower))
                ;
        }
    }
}
