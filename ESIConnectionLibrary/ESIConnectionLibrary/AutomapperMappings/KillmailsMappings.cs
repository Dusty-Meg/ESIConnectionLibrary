using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class GetSingleKillmailMappings : Profile
    {
        public GetSingleKillmailMappings()
        {
            CreateMap<EsiKillmail, GetSingleKillmail>();
        }
    }

    internal class GetSingleKillmailVictimMappings : Profile
    {
        public GetSingleKillmailVictimMappings()
        {
            CreateMap<EsiGetSingleKillmailVictim, GetSingleKillmailVictim>();
        }
    }

    internal class GetSingleKillmailPositionMappings : Profile
    {
        public GetSingleKillmailPositionMappings()
        {
            CreateMap<EsiGetSingleKillmailPosition, GetSingleKillmailPosition>();
        }
    }

    internal class GetSingleKillmailItemMappings : Profile
    {
        public GetSingleKillmailItemMappings()
        {
            CreateMap<EsiGetSingleKillmailItem, GetSingleKillmailItem>();
        }
    }

    internal class GetSingleKillmailAttackerMappings : Profile
    {
        public GetSingleKillmailAttackerMappings()
        {
            CreateMap<EsiGetSingleKillmailAttacker, GetSingleKillmailAttacker>();
        }
    }
}
