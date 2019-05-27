using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestCalendarEndpoints : ILatestCalendarEndpoints
    {
        private readonly IInternalLatestCalendar _internalLatestCalendar;

        public LatestCalendarEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestCalendar = new InternalLatestCalendar(null, userAgent, testing);
        }

        internal LatestCalendarEndpoints(string userAgent, IWebClient webClient, bool testing = false)
        {
            _internalLatestCalendar = new InternalLatestCalendar(webClient, userAgent, testing);
        }

        public IList<V1CalendarSummary> Summaries(SsoToken token, int fromEvent)
        {
            return _internalLatestCalendar.Summaries(token, fromEvent);
        }

        public async Task<IList<V1CalendarSummary>> SummariesAsync(SsoToken token, int fromEvent)
        {
            return await _internalLatestCalendar.SummariesAsync(token, fromEvent);
        }

        public V3CalendarEvent Event(SsoToken token, int eventId)
        {
            return _internalLatestCalendar.Event(token, eventId);
        }

        public async Task<V3CalendarEvent> EventAsync(SsoToken token, int eventId)
        {
            return await _internalLatestCalendar.EventAsync(token, eventId);
        }

        public void RespondEvent(SsoToken token, int eventId, V3CalendarResponse response)
        {
            _internalLatestCalendar.RespondEvent(token, eventId, response);
        }

        public async Task RespondEventAsync(SsoToken token, int eventId, V3CalendarResponse response)
        {
            await _internalLatestCalendar.RespondEventAsync(token, eventId, response);
        }

        public IList<V1CalendarEventAttendee> EventAttendees(SsoToken token, int eventId)
        {
            return _internalLatestCalendar.EventAttendees(token, eventId);
        }

        public async Task<IList<V1CalendarEventAttendee>> EventAttendeesAsync(SsoToken token, int eventId)
        {
            return await _internalLatestCalendar.EventAttendeesAsync(token, eventId);
        }
    }
}
