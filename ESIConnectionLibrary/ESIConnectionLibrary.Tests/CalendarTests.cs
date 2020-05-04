using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibrary.Tests
{
    public class CalendarTests
    {
        [Fact]
        public void Summaries_successfully_returns_a_list_of_V1CalendarSummary()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CalendarScopes scopes = CalendarScopes.esi_calendar_read_calendar_events_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CalendarScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"event_date\": \"2016-06-26T20:00:00Z\",\r\n    \"event_id\": 1386435,\r\n    \"event_response\": \"accepted\",\r\n    \"importance\": 0,\r\n    \"title\": \"o7 The EVE Online Show\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCalendar internalLatestCalendar = new InternalLatestCalendar(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CalendarScopes scopes = CalendarScopes.esi_calendar_read_calendar_events_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CalendarScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"event_date\": \"2016-06-26T20:00:00Z\",\r\n    \"event_id\": 1386435,\r\n    \"event_response\": \"accepted\",\r\n    \"importance\": 0,\r\n    \"title\": \"o7 The EVE Online Show\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCalendar internalLatestCalendar = new InternalLatestCalendar(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CalendarScopes scopes = CalendarScopes.esi_calendar_read_calendar_events_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CalendarScopesFlags = scopes };
            string json = "{\r\n  \"date\": \"2016-06-26T21:00:00Z\",\r\n  \"duration\": 60,\r\n  \"event_id\": 1386435,\r\n  \"importance\": 1,\r\n  \"owner_id\": 1,\r\n  \"owner_name\": \"EVE System\",\r\n  \"owner_type\": \"eve_server\",\r\n  \"response\": \"Undecided\",\r\n  \"text\": \"o7: The EVE Online Show features latest developer news, fast paced action, community overviews and a lot more with CCP Guard and CCP Mimic. Join the thrilling o7 live broadcast at 20:00 EVE time (=UTC) on <a href=\\\"http://www.twitch.tv/ccp\\\">EVE TV</a>. Don\'t miss it!\",\r\n  \"title\": \"o7 The EVE Online Show\"\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCalendar internalLatestCalendar = new InternalLatestCalendar(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CalendarScopes scopes = CalendarScopes.esi_calendar_read_calendar_events_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CalendarScopesFlags = scopes };
            string json = "{\r\n  \"date\": \"2016-06-26T21:00:00Z\",\r\n  \"duration\": 60,\r\n  \"event_id\": 1386435,\r\n  \"importance\": 1,\r\n  \"owner_id\": 1,\r\n  \"owner_name\": \"EVE System\",\r\n  \"owner_type\": \"eve_server\",\r\n  \"response\": \"Undecided\",\r\n  \"text\": \"o7: The EVE Online Show features latest developer news, fast paced action, community overviews and a lot more with CCP Guard and CCP Mimic. Join the thrilling o7 live broadcast at 20:00 EVE time (=UTC) on <a href=\\\"http://www.twitch.tv/ccp\\\">EVE TV</a>. Don\'t miss it!\",\r\n  \"title\": \"o7 The EVE Online Show\"\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCalendar internalLatestCalendar = new InternalLatestCalendar(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CalendarScopes scopes = CalendarScopes.esi_calendar_read_calendar_events_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CalendarScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"character_id\": 2112625428,\r\n    \"event_response\": \"accepted\"\r\n  },\r\n  {\r\n    \"character_id\": 95465499,\r\n    \"event_response\": \"tentative\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCalendar internalLatestCalendar = new InternalLatestCalendar(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CalendarScopes scopes = CalendarScopes.esi_calendar_read_calendar_events_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CalendarScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"character_id\": 2112625428,\r\n    \"event_response\": \"accepted\"\r\n  },\r\n  {\r\n    \"character_id\": 95465499,\r\n    \"event_response\": \"tentative\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCalendar internalLatestCalendar = new InternalLatestCalendar(mockedWebClient.Object, string.Empty);

            IList<V1CalendarEventAttendee> returnModel = await internalLatestCalendar.EventAttendeesAsync(inputToken, 1);

            Assert.Equal(2, returnModel.Count);

            Assert.Equal(2112625428, returnModel[0].CharacterId);
            Assert.Equal(V1CalendarEventAttendeeResponses.Accepted, returnModel[0].EventResponse);

            Assert.Equal(95465499, returnModel[1].CharacterId);
            Assert.Equal(V1CalendarEventAttendeeResponses.Tentative, returnModel[1].EventResponse);
        }
    }
}
