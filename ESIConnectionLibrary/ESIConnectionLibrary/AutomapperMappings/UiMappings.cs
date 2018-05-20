using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class UiMappings : Profile
    {
        public UiMappings()
        {
            CreateMap<V1UiSendMail, EsiV1UiSendMail>();
        }
    }
}
