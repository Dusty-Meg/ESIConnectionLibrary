using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class CorporationRolesMappings : Profile
    {
        public CorporationRolesMappings()
        {
            CreateMap<EsiCorporationsRoles, CorporationsRoles>();
        }
    }
}
