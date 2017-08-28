using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class GetFleetMappings : Profile
    {
        public GetFleetMappings()
        {
            CreateMap<EsiGetFleet, GetFleet>()
                .ForMember(x => x.IsFreeMove, m => m.MapFrom(a => a.is_free_move))
                .ForMember(x => x.IsRegistered, m => m.MapFrom(a => a.is_registered))
                .ForMember(x => x.IsVoiceEnabled, m => m.MapFrom(a => a.is_voice_enabled))
                .ForMember(x => x.Motd, m => m.MapFrom(a => a.motd))
                ;
        }
    }
}
