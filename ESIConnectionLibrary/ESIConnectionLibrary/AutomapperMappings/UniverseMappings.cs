using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class UniverseNamesMappings : Profile
    {
        public UniverseNamesMappings()
        {
            CreateMap<EsiUniverseNames, UniverseNames>()
                .ForMember(x => x.Id, m => m.MapFrom(a => a.id))
                .ForMember(x => x.Category, m => m.MapFrom(a => a.category))
                .ForMember(x => x.Name, m => m.MapFrom(a => a.name))
                ;
        }
    }
}
