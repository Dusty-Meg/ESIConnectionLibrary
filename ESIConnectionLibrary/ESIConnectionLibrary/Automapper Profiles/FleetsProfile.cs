using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class FleetsProfile : Profile
    {
        public FleetsProfile()
        {
            CreateMap<EsiV1FleetWing, V1FleetWing>();
            CreateMap<EsiV1FleetWingSquad, V1FleetWingSquad>();
            CreateMap<EsiV1FleetMemberMove, V1FleetMemberMove>();
            CreateMap<EsiV1FleetMemberInvite, V1FleetMemberInvite>();
            CreateMap<EsiV1FleetMember, V1FleetMember>();
            CreateMap<EsiV1FleetUpdate, V1FleetUpdate>();
            CreateMap<EsiV1Fleet, V1Fleet>();
            CreateMap<EsiV1FleetCharacter, V1FleetCharacter>();
        }
    }
}
