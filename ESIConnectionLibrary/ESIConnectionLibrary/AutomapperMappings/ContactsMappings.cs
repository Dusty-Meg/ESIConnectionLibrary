using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class ContactsMappings : Profile
    {
        public ContactsMappings()
        {
            CreateMap<EsiV2ContactsGetContacts, V2ContactsGetContacts>();
        }
    }
}
