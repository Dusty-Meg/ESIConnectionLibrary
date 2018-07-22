using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class CalendarMappings : Profile
    {
        public CalendarMappings()
        {
            CreateMap<EsiV1CalendarEventAttendee, V1CalendarEventAttendee>();
            CreateMap<EsiV1CalendarSummary, V1CalendarSummary>();
            CreateMap<EsiV3CalendarEvent, V3CalendarEvent>();
        }
    }
}
