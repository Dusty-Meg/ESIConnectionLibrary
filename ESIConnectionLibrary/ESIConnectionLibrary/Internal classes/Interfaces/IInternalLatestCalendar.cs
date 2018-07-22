using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestCalendar
    {
        V3CalendarEvent Event(SsoToken token, int eventId);
        Task<V3CalendarEvent> EventAsync(SsoToken token, int eventId);
        IList<V1CalendarEventAttendee> EventAttendees(SsoToken token, int eventId);
        Task<IList<V1CalendarEventAttendee>> EventAttendeesAsync(SsoToken token, int eventId);
        void RespondEvent(SsoToken token, int eventId, V3CalendarResponse response);
        Task RespondEventAsync(SsoToken token, int eventId, V3CalendarResponse response);
        IList<V1CalendarSummary> Summaries(SsoToken token, int fromEvent);
        Task<IList<V1CalendarSummary>> SummariesAsync(SsoToken token, int fromEvent);
    }
}