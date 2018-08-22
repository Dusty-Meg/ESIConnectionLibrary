using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestCalendar : IInternalLatestCalendar
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestCalendar(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public IList<V1CalendarSummary> Summaries(SsoToken token, int fromEvent)
        {
            StaticMethods.CheckToken(token, CalendarScopes.esi_calendar_read_calendar_events_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CalendarV1Summaries(token.CharacterId, fromEvent), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 5));

            IList<EsiV1CalendarSummary> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CalendarSummary>>(esiRaw.Model);

            return _mapper.Map<IList<V1CalendarSummary>>(esiModel);
        }

        public async Task<IList<V1CalendarSummary>> SummariesAsync(SsoToken token, int fromEvent)
        {
            StaticMethods.CheckToken(token, CalendarScopes.esi_calendar_read_calendar_events_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CalendarV1Summaries(token.CharacterId, fromEvent), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 5));

            IList<EsiV1CalendarSummary> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CalendarSummary>>(esiRaw.Model);

            return _mapper.Map<IList<V1CalendarSummary>>(esiModel);
        }

        public V3CalendarEvent Event(SsoToken token, int eventId)
        {
            StaticMethods.CheckToken(token, CalendarScopes.esi_calendar_read_calendar_events_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CalendarV3Event(token.CharacterId, eventId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 5));

            EsiV3CalendarEvent esiModel = JsonConvert.DeserializeObject<EsiV3CalendarEvent>(esiRaw.Model);

            return _mapper.Map<V3CalendarEvent>(esiModel);
        }

        public async Task<V3CalendarEvent> EventAsync(SsoToken token, int eventId)
        {
            StaticMethods.CheckToken(token, CalendarScopes.esi_calendar_read_calendar_events_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CalendarV3Event(token.CharacterId, eventId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 5));

            EsiV3CalendarEvent esiModel = JsonConvert.DeserializeObject<EsiV3CalendarEvent>(esiRaw.Model);

            return _mapper.Map<V3CalendarEvent>(esiModel);
        }

        public void RespondEvent(SsoToken token, int eventId, V3CalendarResponse response)
        {
            StaticMethods.CheckToken(token, CalendarScopes.esi_calendar_respond_calendar_events_v1);

            EsiV3CalendarResponse esiResponse = _mapper.Map<EsiV3CalendarResponse>(response);

            string jsonResponse = JsonConvert.SerializeObject(esiResponse);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CalendarV3EventResponse(token.CharacterId, eventId), _testing);

            PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Put(StaticMethods.CreateHeaders(token), url, jsonResponse));
        }

        public async Task RespondEventAsync(SsoToken token, int eventId, V3CalendarResponse response)
        {
            StaticMethods.CheckToken(token, CalendarScopes.esi_calendar_respond_calendar_events_v1);

            EsiV3CalendarResponse esiResponse = _mapper.Map<EsiV3CalendarResponse>(response);

            string jsonResponse = JsonConvert.SerializeObject(esiResponse);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CalendarV3EventResponse(token.CharacterId, eventId), _testing);

            await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PutAsync(StaticMethods.CreateHeaders(token), url, jsonResponse));
        }

        public IList<V1CalendarEventAttendee> EventAttendees(SsoToken token, int eventId)
        {
            StaticMethods.CheckToken(token, CalendarScopes.esi_calendar_read_calendar_events_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CalendarV1EventAttendees(token.CharacterId, eventId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV1CalendarEventAttendee> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CalendarEventAttendee>>(esiRaw.Model);

            return _mapper.Map<IList<V1CalendarEventAttendee>>(esiModel);
        }

        public async Task<IList<V1CalendarEventAttendee>> EventAttendeesAsync(SsoToken token, int eventId)
        {
            StaticMethods.CheckToken(token, CalendarScopes.esi_calendar_read_calendar_events_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.CalendarV1EventAttendees(token.CharacterId, eventId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV1CalendarEventAttendee> esiModel = JsonConvert.DeserializeObject<IList<EsiV1CalendarEventAttendee>>(esiRaw.Model);

            return _mapper.Map<IList<V1CalendarEventAttendee>>(esiModel);
        }
    }
}
