using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class GetSingleKillmailMappings : Profile
    {
        public GetSingleKillmailMappings()
        {
            CreateMap<EsiV1Killmail, V1GetSingleKillmail>();
        }
    }

    internal class GetSingleKillmailVictimMappings : Profile
    {
        public GetSingleKillmailVictimMappings()
        {
            CreateMap<EsiV1GetSingleKillmailVictim, V1GetSingleKillmailVictim>();
        }
    }

    internal class GetSingleKillmailPositionMappings : Profile
    {
        public GetSingleKillmailPositionMappings()
        {
            CreateMap<EsiV1GetSingleKillmailPosition, V1GetSingleKillmailPosition>();
        }
    }

    internal class GetSingleKillmailItemMappings : Profile
    {
        public GetSingleKillmailItemMappings()
        {
            CreateMap<EsiV1GetSingleKillmailItem, V1GetSingleKillmailItem>();
        }
    }

    internal class GetSingleKillmailAttackerMappings : Profile
    {
        public GetSingleKillmailAttackerMappings()
        {
            CreateMap<EsiV1GetSingleKillmailAttacker, V1GetSingleKillmailAttacker>();
        }
    }
}
