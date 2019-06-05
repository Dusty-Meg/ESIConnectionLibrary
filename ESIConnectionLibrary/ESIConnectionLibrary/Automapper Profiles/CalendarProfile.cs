using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class CalendarProfile : Profile
    {
        public CalendarProfile()
        {
            CreateMap<EsiV1CalendarSummary, V1CalendarSummary>();
            CreateMap<EsiV3CalendarEvent, V3CalendarEvent>();
            CreateMap<EsiV1CalendarEventAttendee, V1CalendarEventAttendee>();
        }
    }
}
