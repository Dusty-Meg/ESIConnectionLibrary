using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibrary.Tests
{
    public class IndustryTests
    {
        [Fact]
        public void Character_successfully_returns_a_listV1IndustryCharacter()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_character_jobs_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"activity_id\": 1,\r\n    \"blueprint_id\": 1015116533326,\r\n    \"blueprint_location_id\": 60006382,\r\n    \"blueprint_type_id\": 2047,\r\n    \"cost\": 118.01,\r\n    \"duration\": 548,\r\n    \"end_date\": \"2014-07-19T15:56:14Z\",\r\n    \"facility_id\": 60006382,\r\n    \"installer_id\": 498338451,\r\n    \"job_id\": 229136101,\r\n    \"licensed_runs\": 200,\r\n    \"output_location_id\": 60006382,\r\n    \"runs\": 1,\r\n    \"start_date\": \"2014-07-19T15:47:06Z\",\r\n    \"station_id\": 60006382,\r\n    \"status\": \"active\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestIndustry internalLatestIndustry = new InternalLatestIndustry(mockedWebClient.Object, string.Empty);

            IList<V1IndustryCharacter> returnModel = internalLatestIndustry.Character(inputToken, false);

            Assert.Single(returnModel);

            Assert.Equal(1, returnModel[0].ActivityId);
            Assert.Equal(1015116533326, returnModel[0].BlueprintId);
            Assert.Equal(60006382, returnModel[0].BlueprintLocationId);
            Assert.Equal(2047, returnModel[0].BlueprintTypeId);
            Assert.Equal(118.01, returnModel[0].Cost);
            Assert.Equal(548, returnModel[0].Duration);
            Assert.Equal(new DateTime(2014, 07, 19, 15, 56, 14), returnModel[0].EndDate);
            Assert.Equal(60006382, returnModel[0].FacilityId);
            Assert.Equal(498338451, returnModel[0].InstallerId);
            Assert.Equal(229136101, returnModel[0].JobId);
            Assert.Equal(200, returnModel[0].LicensedRuns);
            Assert.Equal(60006382, returnModel[0].OutputLocationId);
            Assert.Equal(1, returnModel[0].Runs);
            Assert.Equal(new DateTime(2014, 07, 19, 15, 47, 06), returnModel[0].StartDate);
            Assert.Equal(60006382, returnModel[0].StationId);
            Assert.Equal(V1IndustryCharacterStatus.Active, returnModel[0].Status);
        }

        [Fact]
        public async Task CharacterAsync_successfully_returns_a_listV1IndustryCharacter()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_character_jobs_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"activity_id\": 1,\r\n    \"blueprint_id\": 1015116533326,\r\n    \"blueprint_location_id\": 60006382,\r\n    \"blueprint_type_id\": 2047,\r\n    \"cost\": 118.01,\r\n    \"duration\": 548,\r\n    \"end_date\": \"2014-07-19T15:56:14Z\",\r\n    \"facility_id\": 60006382,\r\n    \"installer_id\": 498338451,\r\n    \"job_id\": 229136101,\r\n    \"licensed_runs\": 200,\r\n    \"output_location_id\": 60006382,\r\n    \"runs\": 1,\r\n    \"start_date\": \"2014-07-19T15:47:06Z\",\r\n    \"station_id\": 60006382,\r\n    \"status\": \"active\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestIndustry internalLatestIndustry = new InternalLatestIndustry(mockedWebClient.Object, string.Empty);

            IList<V1IndustryCharacter> returnModel = await internalLatestIndustry.CharacterAsync(inputToken, false);

            Assert.Single(returnModel);

            Assert.Equal(1, returnModel[0].ActivityId);
            Assert.Equal(1015116533326, returnModel[0].BlueprintId);
            Assert.Equal(60006382, returnModel[0].BlueprintLocationId);
            Assert.Equal(2047, returnModel[0].BlueprintTypeId);
            Assert.Equal(118.01, returnModel[0].Cost);
            Assert.Equal(548, returnModel[0].Duration);
            Assert.Equal(new DateTime(2014, 07, 19, 15, 56, 14), returnModel[0].EndDate);
            Assert.Equal(60006382, returnModel[0].FacilityId);
            Assert.Equal(498338451, returnModel[0].InstallerId);
            Assert.Equal(229136101, returnModel[0].JobId);
            Assert.Equal(200, returnModel[0].LicensedRuns);
            Assert.Equal(60006382, returnModel[0].OutputLocationId);
            Assert.Equal(1, returnModel[0].Runs);
            Assert.Equal(new DateTime(2014, 07, 19, 15, 47, 06), returnModel[0].StartDate);
            Assert.Equal(60006382, returnModel[0].StationId);
            Assert.Equal(V1IndustryCharacterStatus.Active, returnModel[0].Status);
        }

        [Fact]
        public void CharacterMining_successfully_returns_a_listV1IndustryCharacterMining()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_character_mining_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"date\": \"2017-09-19\",\r\n    \"quantity\": 7004,\r\n    \"solar_system_id\": 30003707,\r\n    \"type_id\": 17471\r\n  },\r\n  {\r\n    \"date\": \"2017-09-18\",\r\n    \"quantity\": 5199,\r\n    \"solar_system_id\": 30003707,\r\n    \"type_id\": 17471\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestIndustry internalLatestIndustry = new InternalLatestIndustry(mockedWebClient.Object, string.Empty);

            IList<V1IndustryCharacterMining> returnModel = internalLatestIndustry.CharacterMining(inputToken, 1);

            Assert.Equal(2, returnModel.Count);

            Assert.Equal(new DateTime(2017, 09, 19), returnModel[0].Date);
            Assert.Equal(7004, returnModel[0].Quantity);
            Assert.Equal(30003707, returnModel[0].SolarSystemId);
            Assert.Equal(17471, returnModel[0].TypeId);

            Assert.Equal(new DateTime(2017, 09, 18), returnModel[1].Date);
            Assert.Equal(5199, returnModel[1].Quantity);
            Assert.Equal(30003707, returnModel[1].SolarSystemId);
            Assert.Equal(17471, returnModel[1].TypeId);
        }

        [Fact]
        public async Task CharacterMiningAsync_successfully_returns_a_listV1IndustryCharacterMining()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_character_mining_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"date\": \"2017-09-19\",\r\n    \"quantity\": 7004,\r\n    \"solar_system_id\": 30003707,\r\n    \"type_id\": 17471\r\n  },\r\n  {\r\n    \"date\": \"2017-09-18\",\r\n    \"quantity\": 5199,\r\n    \"solar_system_id\": 30003707,\r\n    \"type_id\": 17471\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestIndustry internalLatestIndustry = new InternalLatestIndustry(mockedWebClient.Object, string.Empty);

            IList<V1IndustryCharacterMining> returnModel = await internalLatestIndustry.CharacterMiningAsync(inputToken, 1);

            Assert.Equal(2, returnModel.Count);

            Assert.Equal(new DateTime(2017, 09, 19), returnModel[0].Date);
            Assert.Equal(7004, returnModel[0].Quantity);
            Assert.Equal(30003707, returnModel[0].SolarSystemId);
            Assert.Equal(17471, returnModel[0].TypeId);

            Assert.Equal(new DateTime(2017, 09, 18), returnModel[1].Date);
            Assert.Equal(5199, returnModel[1].Quantity);
            Assert.Equal(30003707, returnModel[1].SolarSystemId);
            Assert.Equal(17471, returnModel[1].TypeId);
        }

        [Fact]
        public void CorporationExtractions_successfully_returns_a_listV1IndustryCorporationExtractions()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_corporation_mining_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"chunk_arrival_time\": \"2017-10-17T11:00:59Z\",\r\n    \"extraction_start_time\": \"2017-10-11T10:37:04Z\",\r\n    \"moon_id\": 40307229,\r\n    \"natural_decay_time\": \"2017-10-17T14:00:59Z\",\r\n    \"structure_id\": 1000000010579\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestIndustry internalLatestIndustry = new InternalLatestIndustry(mockedWebClient.Object, string.Empty);

            IList<V1IndustryCorporationExtractions> returnModel = internalLatestIndustry.CorporationExtractions(inputToken, 22, 1);

            Assert.Single(returnModel);

            Assert.Equal(new DateTime(2017, 10, 17, 11, 00, 59), returnModel[0].ChunkArrivalTime);
            Assert.Equal(new DateTime(2017, 10, 11, 10, 37, 04), returnModel[0].ExtractionStartTime);
            Assert.Equal(40307229, returnModel[0].MoonId);
            Assert.Equal(new DateTime(2017, 10, 17, 14, 00, 59), returnModel[0].NaturalDecayTime);
            Assert.Equal(1000000010579, returnModel[0].StructureId);
        }

        [Fact]
        public async Task CorporationExtractionsAsync_successfully_returns_a_listV1IndustryCorporationExtractions()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_corporation_mining_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"chunk_arrival_time\": \"2017-10-17T11:00:59Z\",\r\n    \"extraction_start_time\": \"2017-10-11T10:37:04Z\",\r\n    \"moon_id\": 40307229,\r\n    \"natural_decay_time\": \"2017-10-17T14:00:59Z\",\r\n    \"structure_id\": 1000000010579\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestIndustry internalLatestIndustry = new InternalLatestIndustry(mockedWebClient.Object, string.Empty);

            IList<V1IndustryCorporationExtractions> returnModel = await internalLatestIndustry.CorporationExtractionsAsync(inputToken, 22, 1);

            Assert.Single(returnModel);

            Assert.Equal(new DateTime(2017, 10, 17, 11, 00, 59), returnModel[0].ChunkArrivalTime);
            Assert.Equal(new DateTime(2017, 10, 11, 10, 37, 04), returnModel[0].ExtractionStartTime);
            Assert.Equal(40307229, returnModel[0].MoonId);
            Assert.Equal(new DateTime(2017, 10, 17, 14, 00, 59), returnModel[0].NaturalDecayTime);
            Assert.Equal(1000000010579, returnModel[0].StructureId);
        }

        [Fact]
        public void CorporationObservers_successfully_returns_a_listV1IndustryCorporationObservers()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_corporation_mining_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"last_updated\": \"2017-09-19\",\r\n    \"observer_id\": 1,\r\n    \"observer_type\": \"structure\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestIndustry internalLatestIndustry = new InternalLatestIndustry(mockedWebClient.Object, string.Empty);

            IList<V1IndustryCorporationObservers> returnModel = internalLatestIndustry.CorporationObservers(inputToken, 22, 1);

            Assert.Single(returnModel);

            Assert.Equal(new DateTime(2017, 09, 19), returnModel[0].LastUpdated);
            Assert.Equal(1, returnModel[0].ObserverId);
            Assert.Equal(V1IndustryCorporationObserversType.Structure, returnModel[0].ObserverType);
        }

        [Fact]
        public async Task CorporationObserversAsync_successfully_returns_a_listV1IndustryCorporationObservers()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_corporation_mining_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"last_updated\": \"2017-09-19\",\r\n    \"observer_id\": 1,\r\n    \"observer_type\": \"structure\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestIndustry internalLatestIndustry = new InternalLatestIndustry(mockedWebClient.Object, string.Empty);

            IList<V1IndustryCorporationObservers> returnModel = await internalLatestIndustry.CorporationObserversAsync(inputToken, 22, 1);

            Assert.Single(returnModel);

            Assert.Equal(new DateTime(2017, 09, 19), returnModel[0].LastUpdated);
            Assert.Equal(1, returnModel[0].ObserverId);
            Assert.Equal(V1IndustryCorporationObserversType.Structure, returnModel[0].ObserverType);
        }

        [Fact]
        public void CorporationObserver_successfully_returns_a_listV1IndustryCorporationObserver()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_corporation_mining_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"character_id\": 95465499,\r\n    \"last_updated\": \"2017-09-19\",\r\n    \"quantity\": 500,\r\n    \"recorded_corporation_id\": 109299958,\r\n    \"type_id\": 1230\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestIndustry internalLatestIndustry = new InternalLatestIndustry(mockedWebClient.Object, string.Empty);

            IList<V1IndustryCorporationObserver> returnModel = internalLatestIndustry.CorporationObserver(inputToken, 22, 22, 1);

            Assert.Single(returnModel);

            Assert.Equal(95465499, returnModel[0].CharacterId);
            Assert.Equal(new DateTime(2017, 09, 19), returnModel[0].LastUpdated);
            Assert.Equal(500, returnModel[0].Quantity);
            Assert.Equal(109299958, returnModel[0].RecordedCorporationId);
            Assert.Equal(1230, returnModel[0].TypeId);
        }

        [Fact]
        public async Task CorporationObserverAsync_successfully_returns_a_listV1IndustryCorporationObserver()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_corporation_mining_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"character_id\": 95465499,\r\n    \"last_updated\": \"2017-09-19\",\r\n    \"quantity\": 500,\r\n    \"recorded_corporation_id\": 109299958,\r\n    \"type_id\": 1230\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestIndustry internalLatestIndustry = new InternalLatestIndustry(mockedWebClient.Object, string.Empty);

            IList<V1IndustryCorporationObserver> returnModel = await internalLatestIndustry.CorporationObserverAsync(inputToken, 22, 22, 1);

            Assert.Single(returnModel);

            Assert.Equal(95465499, returnModel[0].CharacterId);
            Assert.Equal(new DateTime(2017, 09, 19), returnModel[0].LastUpdated);
            Assert.Equal(500, returnModel[0].Quantity);
            Assert.Equal(109299958, returnModel[0].RecordedCorporationId);
            Assert.Equal(1230, returnModel[0].TypeId);
        }

        [Fact]
        public void Corporation_successfully_returns_a_listV1IndustryCorporation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_corporation_jobs_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"activity_id\": 1,\r\n    \"blueprint_id\": 1015116533326,\r\n    \"blueprint_location_id\": 60006382,\r\n    \"blueprint_type_id\": 2047,\r\n    \"cost\": 118.01,\r\n    \"duration\": 548,\r\n    \"end_date\": \"2014-07-19T15:56:14Z\",\r\n    \"facility_id\": 60006382,\r\n    \"installer_id\": 498338451,\r\n    \"job_id\": 229136101,\r\n    \"licensed_runs\": 200,\r\n    \"location_id\": 60006382,\r\n    \"output_location_id\": 60006382,\r\n    \"runs\": 1,\r\n    \"start_date\": \"2014-07-19T15:47:06Z\",\r\n    \"status\": \"active\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestIndustry internalLatestIndustry = new InternalLatestIndustry(mockedWebClient.Object, string.Empty);

            IList<V1IndustryCorporation> returnModel = internalLatestIndustry.Corporation(inputToken, 23, false, 1);

            Assert.Single(returnModel);

            Assert.Equal(1, returnModel[0].ActivityId);
            Assert.Equal(1015116533326, returnModel[0].BlueprintId);
            Assert.Equal(60006382, returnModel[0].BlueprintLocationId);
            Assert.Equal(2047, returnModel[0].BlueprintTypeId);
            Assert.Equal(118.01, returnModel[0].Cost);
            Assert.Equal(548, returnModel[0].Duration);
            Assert.Equal(new DateTime(2014, 07, 19, 15, 56, 14), returnModel[0].EndDate);
            Assert.Equal(60006382, returnModel[0].FacilityId);
            Assert.Equal(498338451, returnModel[0].InstallerId);
            Assert.Equal(229136101, returnModel[0].JobId);
            Assert.Equal(200, returnModel[0].LicensedRuns);
            Assert.Equal(60006382, returnModel[0].LocationId);
            Assert.Equal(60006382, returnModel[0].OutputLocationId);
            Assert.Equal(1, returnModel[0].Runs);
            Assert.Equal(new DateTime(2014, 07, 19, 15, 47, 06), returnModel[0].StartDate);
            Assert.Equal(V1IndustryCorporationStatus.Active, returnModel[0].Status);
        }

        [Fact]
        public async Task CorporationAsync_successfully_returns_a_listV1IndustryCorporation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_corporation_jobs_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"activity_id\": 1,\r\n    \"blueprint_id\": 1015116533326,\r\n    \"blueprint_location_id\": 60006382,\r\n    \"blueprint_type_id\": 2047,\r\n    \"cost\": 118.01,\r\n    \"duration\": 548,\r\n    \"end_date\": \"2014-07-19T15:56:14Z\",\r\n    \"facility_id\": 60006382,\r\n    \"installer_id\": 498338451,\r\n    \"job_id\": 229136101,\r\n    \"licensed_runs\": 200,\r\n    \"location_id\": 60006382,\r\n    \"output_location_id\": 60006382,\r\n    \"runs\": 1,\r\n    \"start_date\": \"2014-07-19T15:47:06Z\",\r\n    \"status\": \"active\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestIndustry internalLatestIndustry = new InternalLatestIndustry(mockedWebClient.Object, string.Empty);

            IList<V1IndustryCorporation> returnModel = await internalLatestIndustry.CorporationAsync(inputToken, 23, false, 1);

            Assert.Single(returnModel);

            Assert.Equal(1, returnModel[0].ActivityId);
            Assert.Equal(1015116533326, returnModel[0].BlueprintId);
            Assert.Equal(60006382, returnModel[0].BlueprintLocationId);
            Assert.Equal(2047, returnModel[0].BlueprintTypeId);
            Assert.Equal(118.01, returnModel[0].Cost);
            Assert.Equal(548, returnModel[0].Duration);
            Assert.Equal(new DateTime(2014, 07, 19, 15, 56, 14), returnModel[0].EndDate);
            Assert.Equal(60006382, returnModel[0].FacilityId);
            Assert.Equal(498338451, returnModel[0].InstallerId);
            Assert.Equal(229136101, returnModel[0].JobId);
            Assert.Equal(200, returnModel[0].LicensedRuns);
            Assert.Equal(60006382, returnModel[0].LocationId);
            Assert.Equal(60006382, returnModel[0].OutputLocationId);
            Assert.Equal(1, returnModel[0].Runs);
            Assert.Equal(new DateTime(2014, 07, 19, 15, 47, 06), returnModel[0].StartDate);
            Assert.Equal(V1IndustryCorporationStatus.Active, returnModel[0].Status);
        }

        [Fact]
        public void Facilities_successfully_returns_a_listV1IndustryFacility()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"facility_id\": 60012544,\r\n    \"owner_id\": 1000126,\r\n    \"region_id\": 10000001,\r\n    \"solar_system_id\": 30000032,\r\n    \"tax\": 0.1,\r\n    \"type_id\": 2502\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel {Model = json});

            InternalLatestIndustry internalLatestIndustry = new InternalLatestIndustry(mockedWebClient.Object, string.Empty);

            IList<V1IndustryFacility> returnModel = internalLatestIndustry.Facilities();

            Assert.Single(returnModel);

            Assert.Equal(60012544, returnModel[0].FacilityId);
            Assert.Equal(1000126, returnModel[0].OwnerId);
            Assert.Equal(10000001, returnModel[0].RegionId);
            Assert.Equal(30000032, returnModel[0].SolarSystemId);
            Assert.Equal(0.1f, returnModel[0].Tax);
            Assert.Equal(2502, returnModel[0].TypeId);
        }

        [Fact]
        public async Task FacilitiesAsync_successfully_returns_a_listV1IndustryFacility()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"facility_id\": 60012544,\r\n    \"owner_id\": 1000126,\r\n    \"region_id\": 10000001,\r\n    \"solar_system_id\": 30000032,\r\n    \"tax\": 0.1,\r\n    \"type_id\": 2502\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestIndustry internalLatestIndustry = new InternalLatestIndustry(mockedWebClient.Object, string.Empty);

            IList<V1IndustryFacility> returnModel = await internalLatestIndustry.FacilitiesAsync();

            Assert.Single(returnModel);

            Assert.Equal(60012544, returnModel[0].FacilityId);
            Assert.Equal(1000126, returnModel[0].OwnerId);
            Assert.Equal(10000001, returnModel[0].RegionId);
            Assert.Equal(30000032, returnModel[0].SolarSystemId);
            Assert.Equal(0.1f, returnModel[0].Tax);
            Assert.Equal(2502, returnModel[0].TypeId);
        }

        [Fact]
        public void Systems_successfully_returns_a_listV1IndustrySystem()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"cost_indices\": [\r\n      {\r\n        \"activity\": \"invention\",\r\n        \"cost_index\": 0.0048\r\n      }\r\n    ],\r\n    \"solar_system_id\": 30011392\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestIndustry internalLatestIndustry = new InternalLatestIndustry(mockedWebClient.Object, string.Empty);

            IList<V1IndustrySystem> returnModel = internalLatestIndustry.Systems();

            Assert.Single(returnModel);

            Assert.Single(returnModel[0].CostIndices);
            Assert.Equal(V1IndustrySystemCostIndicesActivity.Invention, returnModel[0].CostIndices[0].Activity);
            Assert.Equal(0.0048f, returnModel[0].CostIndices[0].CostIndex);

            Assert.Equal(30011392, returnModel[0].SolarSystemId);
        }

        [Fact]
        public async Task SystemsAsync_successfully_returns_a_listV1IndustrySystem()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"cost_indices\": [\r\n      {\r\n        \"activity\": \"invention\",\r\n        \"cost_index\": 0.0048\r\n      }\r\n    ],\r\n    \"solar_system_id\": 30011392\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestIndustry internalLatestIndustry = new InternalLatestIndustry(mockedWebClient.Object, string.Empty);

            IList<V1IndustrySystem> returnModel = await internalLatestIndustry.SystemsAsync();

            Assert.Single(returnModel);

            Assert.Single(returnModel[0].CostIndices);
            Assert.Equal(V1IndustrySystemCostIndicesActivity.Invention, returnModel[0].CostIndices[0].Activity);
            Assert.Equal(0.0048f, returnModel[0].CostIndices[0].CostIndex);

            Assert.Equal(30011392, returnModel[0].SolarSystemId);
        }
    }
}
