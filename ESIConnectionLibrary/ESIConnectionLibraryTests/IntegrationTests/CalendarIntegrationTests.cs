using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class CalendarIntegrationTests
    {
        [Fact]
        public void Summaries_successfully_returns_a_list_of_V1CalendarSummary()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CalendarScopes scopes = CalendarScopes.esi_calendar_read_calendar_events_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CalendarScopesFlags = scopes };

            LatestCalendarEndpoints internalLatestCalendar = new LatestCalendarEndpoints(string.Empty, true);

            IList<V1CalendarSummary> returnModel = internalLatestCalendar.Summaries(inputToken, 1);

            Assert.Single(returnModel);
            Assert.Equal(new DateTime(2016, 06, 26, 20, 00, 00), returnModel.First().EventDate);
            Assert.Equal(1386435, returnModel.First().EventId);
            Assert.Equal(V1CalendarSummaryEventResponses.Accepted, returnModel.First().EventResponse);
            Assert.Equal(0, returnModel.First().Importance);
            Assert.Equal("o7 The EVE Online Show", returnModel.First().Title);
        }

        [Fact]
        public async Task SummariesAsync_successfully_returns_a_list_of_V1CalendarSummary()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CalendarScopes scopes = CalendarScopes.esi_calendar_read_calendar_events_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CalendarScopesFlags = scopes };

            LatestCalendarEndpoints internalLatestCalendar = new LatestCalendarEndpoints(string.Empty, true);

            IList<V1CalendarSummary> returnModel = await internalLatestCalendar.SummariesAsync(inputToken, 1);

            Assert.Single(returnModel);
            Assert.Equal(new DateTime(2016, 06, 26, 20, 00, 00), returnModel.First().EventDate);
            Assert.Equal(1386435, returnModel.First().EventId);
            Assert.Equal(V1CalendarSummaryEventResponses.Accepted, returnModel.First().EventResponse);
            Assert.Equal(0, returnModel.First().Importance);
            Assert.Equal("o7 The EVE Online Show", returnModel.First().Title);
        }

        [Fact]
        public void Event_successfully_returns_a_V3CalendarEvent()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CalendarScopes scopes = CalendarScopes.esi_calendar_read_calendar_events_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CalendarScopesFlags = scopes };

            LatestCalendarEndpoints internalLatestCalendar = new LatestCalendarEndpoints(string.Empty, true);

            V3CalendarEvent returnModel = internalLatestCalendar.Event(inputToken, 1);

            Assert.Equal(new DateTime(2016, 06, 26, 21, 00, 00), returnModel.Date);
            Assert.Equal(60, returnModel.Duration);
            Assert.Equal(1386435, returnModel.EventId);
            Assert.Equal(1, returnModel.Importance);
            Assert.Equal("EVE System", returnModel.OwnerName);
            Assert.Equal(V3CalendarEventOwnerType.EveServer, returnModel.OwnerType);
            Assert.Equal("Undecided", returnModel.Response);
            Assert.Equal("o7: The EVE Online Show features latest developer news, fast paced action, community overviews and a lot more with CCP Guard and CCP Mimic. Join the thrilling o7 live broadcast at 20:00 EVE time (=UTC) on <a href=\"http://www.twitch.tv/ccp\">EVE TV</a>. Don't miss it!", returnModel.Text);
            Assert.Equal("o7 The EVE Online Show", returnModel.Title);
        }

        [Fact]
        public async Task EventAsync_successfully_returns_a_V3CalendarEvent()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CalendarScopes scopes = CalendarScopes.esi_calendar_read_calendar_events_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CalendarScopesFlags = scopes };

            LatestCalendarEndpoints internalLatestCalendar = new LatestCalendarEndpoints(string.Empty, true);

            V3CalendarEvent returnModel = await internalLatestCalendar.EventAsync(inputToken, 1);

            Assert.Equal(new DateTime(2016, 06, 26, 21, 00, 00), returnModel.Date);
            Assert.Equal(60, returnModel.Duration);
            Assert.Equal(1386435, returnModel.EventId);
            Assert.Equal(1, returnModel.Importance);
            Assert.Equal("EVE System", returnModel.OwnerName);
            Assert.Equal(V3CalendarEventOwnerType.EveServer, returnModel.OwnerType);
            Assert.Equal("Undecided", returnModel.Response);
            Assert.Equal("o7: The EVE Online Show features latest developer news, fast paced action, community overviews and a lot more with CCP Guard and CCP Mimic. Join the thrilling o7 live broadcast at 20:00 EVE time (=UTC) on <a href=\"http://www.twitch.tv/ccp\">EVE TV</a>. Don't miss it!", returnModel.Text);
            Assert.Equal("o7 The EVE Online Show", returnModel.Title);
        }

        [Fact]
        public void EventAttendees_successfully_returns_a_list_of_V1CalendarEventAttendee()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CalendarScopes scopes = CalendarScopes.esi_calendar_read_calendar_events_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CalendarScopesFlags = scopes };

            LatestCalendarEndpoints internalLatestCalendar = new LatestCalendarEndpoints(string.Empty, true);

            IList<V1CalendarEventAttendee> returnModel = internalLatestCalendar.EventAttendees(inputToken, 1);

            Assert.Equal(2, returnModel.Count);

            Assert.Equal(2112625428, returnModel[0].CharacterId);
            Assert.Equal(V1CalendarEventAttendeeResponses.Accepted, returnModel[0].EventResponse);

            Assert.Equal(95465499, returnModel[1].CharacterId);
            Assert.Equal(V1CalendarEventAttendeeResponses.Tentative, returnModel[1].EventResponse);
        }

        [Fact]
        public async Task EventAttendeesAsync_successfully_returns_a_list_of_V1CalendarEventAttendee()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CalendarScopes scopes = CalendarScopes.esi_calendar_read_calendar_events_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CalendarScopesFlags = scopes };

            LatestCalendarEndpoints internalLatestCalendar = new LatestCalendarEndpoints(string.Empty, true);

            IList<V1CalendarEventAttendee> returnModel = await internalLatestCalendar.EventAttendeesAsync(inputToken, 1);

            Assert.Equal(2, returnModel.Count);

            Assert.Equal(2112625428, returnModel[0].CharacterId);
            Assert.Equal(V1CalendarEventAttendeeResponses.Accepted, returnModel[0].EventResponse);

            Assert.Equal(95465499, returnModel[1].CharacterId);
            Assert.Equal(V1CalendarEventAttendeeResponses.Tentative, returnModel[1].EventResponse);
        }
    }
}
