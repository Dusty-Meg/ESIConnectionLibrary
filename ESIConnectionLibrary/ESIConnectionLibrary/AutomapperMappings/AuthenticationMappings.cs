using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class AuthenticationMappings : Profile
    {
        public AuthenticationMappings()
        {
            CreateMap<EsiRevokeTokenType, RevokeTokenType>();
        }
    }
}
