using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class KillMailsProfile : Profile
    {
        public KillMailsProfile()
        {
            CreateMap<EsiV1KillmailCharacter, V1KillmailCharacter>();
            CreateMap<EsiV1KillmailKillmail, V1KillmailKillmail>();
            CreateMap<EsiV1KillmailKillmailAttacker, V1KillmailKillmailAttacker>();
            CreateMap<EsiV1KillmailKillmailVictim, V1KillmailKillmailVictim>();
            CreateMap<EsiV1KillmailKillmailVictimItem, V1KillmailKillmailVictimItem>();
            CreateMap<EsiV1KillmailKillmailVictimPosition, V1KillmailKillmailVictimPosition>();
            CreateMap<EsiV1KillmailCorporation, V1KillmailCorporation>();
        }
    }
}
