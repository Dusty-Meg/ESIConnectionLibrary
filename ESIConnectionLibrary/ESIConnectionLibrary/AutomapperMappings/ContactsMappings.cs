using AutoMapper;
using ESIConnectionLibrary.ESIModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class ContactsMappings : Profile
    {
        public ContactsMappings()
        {
            CreateMap<EsiV1ContactsGetContacts, EsiV1ContactsGetContacts>();
        }
    }
}
