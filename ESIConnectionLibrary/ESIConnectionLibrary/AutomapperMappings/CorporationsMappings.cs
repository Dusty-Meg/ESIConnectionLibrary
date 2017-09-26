using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class CorporationRolesMappings : Profile
    {
        public CorporationRolesMappings()
        {
            CreateMap<EsiCorporationsRoles, CorporationsRoles>()
                .ForMember(x => x.CharacterId, m => m.MapFrom(a => a.character_id))
                .ForMember(x => x.GrantableRoles, m => m.MapFrom(a => a.grantable_roles))
                .ForMember(x => x.GrantableRolesAtBase, m => m.MapFrom(a => a.grantable_roles_at_base))
                .ForMember(x => x.GrantableRolesAtHq, m => m.MapFrom(a => a.grantable_roles_at_hq))
                .ForMember(x => x.GrantableRolesAtOther, m => m.MapFrom(a => a.grantable_roles_at_other))
                .ForMember(x => x.Roles, m => m.MapFrom(a => a.roles))
                .ForMember(x => x.RolesAtBase, m => m.MapFrom(a => a.roles_at_base))
                .ForMember(x => x.RolesAtHq, m => m.MapFrom(a => a.roles_at_hq))
                .ForMember(x => x.RolesAtOther, m => m.MapFrom(a => a.roles_at_other))
                ;
        }
    }
}
