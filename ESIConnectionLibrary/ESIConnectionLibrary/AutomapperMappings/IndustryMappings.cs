using System;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class CharacterIndustryJobsMappings : Profile
    {
        public CharacterIndustryJobsMappings()
        {
            CreateMap<EsiCharacterIndustryJob, CharacterIndustryJob>()
                .ForMember(x => x.ActivityId, m => m.MapFrom(a => a.activity_id))
                .ForMember(x => x.BlueprintId, m => m.MapFrom(a => a.blueprint_id))
                .ForMember(x => x.BlueprintLocationId, m => m.MapFrom(a => a.blueprint_location_id))
                .ForMember(x => x.BlueprintTypeId, m => m.MapFrom(a => a.blueprint_type_id))
                .ForMember(x => x.CompletedCharacterId, m => m.MapFrom(a => a.completed_character_id))
                .ForMember(x => x.CompletedDate, m => m.MapFrom(a => a.completed_date))
                .ForMember(x => x.Cost, m => m.MapFrom(a => a.cost))
                .ForMember(x => x.Duration, m => m.MapFrom(a => a.duration))
                .ForMember(x => x.EndDate, m => m.MapFrom(a => a.end_date))
                .ForMember(x => x.FacilityId, m => m.MapFrom(a => a.facility_id))
                .ForMember(x => x.InstallerId, m => m.MapFrom(a => a.installer_id))
                .ForMember(x => x.JobId, m => m.MapFrom(a => a.job_id))
                .ForMember(x => x.LicensedRuns, m => m.MapFrom(a => a.licensed_runs))
                .ForMember(x => x.OutputLocationId, m => m.MapFrom(a => a.output_location_id))
                .ForMember(x => x.PauseDate, m => m.MapFrom(a => a.pause_date))
                .ForMember(x => x.Probability, m => m.MapFrom(a => a.probability))
                .ForMember(x => x.ProductTypeId, m => m.MapFrom(a => a.product_type_id))
                .ForMember(x => x.Runs, m => m.MapFrom(a => a.runs))
                .ForMember(x => x.StartDate, m => m.MapFrom(a => a.start_date))
                .ForMember(x => x.StationId, m => m.MapFrom(a => a.station_id))
                .ForMember(x => x.Status, m => m.MapFrom(a => Enum.Parse(typeof(IndustryJobStatus), a.status, true)))
                .ForMember(x => x.SuccessfulRuns, m => m.MapFrom(a => a.successful_runs))
                ;
        }
    }
}
