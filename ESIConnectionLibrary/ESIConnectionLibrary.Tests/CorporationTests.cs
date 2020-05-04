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
    public class CorporationTests
    {
        [Fact]
        public void PublicInfo_successully_returns_a_V4CorporationPublicInfo()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"alliance_id\": 434243723,\r\n  \"ceo_id\": 180548812,\r\n  \"creator_id\": 180548812,\r\n  \"date_founded\": \"2004-11-28T16:42:51Z\",\r\n  \"description\": \"This is a corporation description, it\'s basically just a string\",\r\n  \"member_count\": 656,\r\n  \"name\": \"C C P\",\r\n  \"tax_rate\": 0.256,\r\n  \"ticker\": \"-CCP-\",\r\n  \"url\": \"http://www.eveonline.com\"\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            V4CorporationPublicInfo returnModel = internalLatestCorporations.PublicInfo(18888888);

            Assert.Equal(434243723, returnModel.AllianceId);
            Assert.Equal(180548812, returnModel.CeoId);
            Assert.Equal(180548812, returnModel.CreatorId);
            Assert.Equal(new DateTime(2004,11,28,16,42,51), returnModel.DateFounded);
            Assert.Equal("This is a corporation description, it's basically just a string", returnModel.Description);
            Assert.Equal(656, returnModel.MemberCount);
            Assert.Equal("C C P", returnModel.Name);
            Assert.Equal(0.256f, returnModel.TaxRate);
            Assert.Equal("-CCP-", returnModel.Ticker);
            Assert.Equal("http://www.eveonline.com", returnModel.Url);
        }

        [Fact]
        public async Task PublicInfoAsync_successully_returns_a_V4CorporationPublicInfo()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"alliance_id\": 434243723,\r\n  \"ceo_id\": 180548812,\r\n  \"creator_id\": 180548812,\r\n  \"date_founded\": \"2004-11-28T16:42:51Z\",\r\n  \"description\": \"This is a corporation description, it\'s basically just a string\",\r\n  \"member_count\": 656,\r\n  \"name\": \"C C P\",\r\n  \"tax_rate\": 0.256,\r\n  \"ticker\": \"-CCP-\",\r\n  \"url\": \"http://www.eveonline.com\"\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            V4CorporationPublicInfo returnModel = await internalLatestCorporations.PublicInfoAsync(18888888);

            Assert.Equal(434243723, returnModel.AllianceId);
            Assert.Equal(180548812, returnModel.CeoId);
            Assert.Equal(180548812, returnModel.CreatorId);
            Assert.Equal(new DateTime(2004, 11, 28, 16, 42, 51), returnModel.DateFounded);
            Assert.Equal("This is a corporation description, it's basically just a string", returnModel.Description);
            Assert.Equal(656, returnModel.MemberCount);
            Assert.Equal("C C P", returnModel.Name);
            Assert.Equal(0.256f, returnModel.TaxRate);
            Assert.Equal("-CCP-", returnModel.Ticker);
            Assert.Equal("http://www.eveonline.com", returnModel.Url);
        }

        [Fact]
        public void AllianceHistory_successully_returns_a_list_of_V2CorporationAllianceHistory()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"alliance_id\": 99000006,\r\n    \"is_deleted\": true,\r\n    \"record_id\": 23,\r\n    \"start_date\": \"2016-10-25T14:46:00Z\"\r\n  },\r\n  {\r\n    \"record_id\": 1,\r\n    \"start_date\": \"2015-07-06T20:56:00Z\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            IList<V2CorporationAllianceHistory> returnModel = internalLatestCorporations.AllianceHistory(18888888);

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(99000006, returnModel.First().AllianceId);
            Assert.True(returnModel.First().IsDeleted);
            Assert.Equal(23, returnModel.First().RecordId);
            Assert.Equal(new DateTime(2016,10,25,14,46,00), returnModel.First().StartDate);
            Assert.Equal(1, returnModel[1].RecordId);
            Assert.Equal(new DateTime(2015, 07, 06, 20, 56, 00), returnModel[1].StartDate);
        }

        [Fact]
        public async Task AllianceHistoryAsync_successully_returns_a_list_of_V2CorporationAllianceHistory()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"alliance_id\": 99000006,\r\n    \"is_deleted\": true,\r\n    \"record_id\": 23,\r\n    \"start_date\": \"2016-10-25T14:46:00Z\"\r\n  },\r\n  {\r\n    \"record_id\": 1,\r\n    \"start_date\": \"2015-07-06T20:56:00Z\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            IList<V2CorporationAllianceHistory> returnModel = await internalLatestCorporations.AllianceHistoryAsync(18888888);

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(99000006, returnModel.First().AllianceId);
            Assert.True(returnModel.First().IsDeleted);
            Assert.Equal(23, returnModel.First().RecordId);
            Assert.Equal(new DateTime(2016, 10, 25, 14, 46, 00), returnModel.First().StartDate);
            Assert.Equal(1, returnModel[1].RecordId);
            Assert.Equal(new DateTime(2015, 07, 06, 20, 56, 00), returnModel[1].StartDate);
        }

        [Fact]
        public void Blueprints_succesfully_returns_a_list_of_V2CorporationBlueprints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_blueprints_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"item_id\": 1000000010495,\r\n    \"location_flag\": \"CorpSAG1\",\r\n    \"location_id\": 60014719,\r\n    \"material_efficiency\": 0,\r\n    \"quantity\": 1,\r\n    \"runs\": -1,\r\n    \"time_efficiency\": 0,\r\n    \"type_id\": 691\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            PagedModel<V2CorporationBlueprints> returnModel = internalLatestCorporations.Blueprints(inputToken, 123123, 1);

            Assert.Single(returnModel.Model);
            Assert.Equal(1000000010495, returnModel.Model.First().ItemId);
            Assert.Equal(LocationFlagCorporation.CorpSag1, returnModel.Model.First().LocationFlag);
            Assert.Equal(60014719, returnModel.Model.First().LocationId);
            Assert.Equal(0, returnModel.Model.First().MaterialEfficiency);
            Assert.Equal(1, returnModel.Model.First().Quantity);
            Assert.Equal(-1, returnModel.Model.First().Runs);
            Assert.Equal(0, returnModel.Model.First().TimeEfficiency);
            Assert.Equal(691, returnModel.Model.First().TypeId);
        }

        [Fact]
        public async Task BlueprintsAsync_succesfully_returns_a_list_of_V2CorporationBlueprints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_blueprints_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"item_id\": 1000000010495,\r\n    \"location_flag\": \"CorpSAG1\",\r\n    \"location_id\": 60014719,\r\n    \"material_efficiency\": 0,\r\n    \"quantity\": 1,\r\n    \"runs\": -1,\r\n    \"time_efficiency\": 0,\r\n    \"type_id\": 691\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            PagedModel<V2CorporationBlueprints> returnModel = await internalLatestCorporations.BlueprintsAsync(inputToken, 123123, 1);

            Assert.Single(returnModel.Model);
            Assert.Equal(1000000010495, returnModel.Model.First().ItemId);
            Assert.Equal(LocationFlagCorporation.CorpSag1, returnModel.Model.First().LocationFlag);
            Assert.Equal(60014719, returnModel.Model.First().LocationId);
            Assert.Equal(0, returnModel.Model.First().MaterialEfficiency);
            Assert.Equal(1, returnModel.Model.First().Quantity);
            Assert.Equal(-1, returnModel.Model.First().Runs);
            Assert.Equal(0, returnModel.Model.First().TimeEfficiency);
            Assert.Equal(691, returnModel.Model.First().TypeId);
        }

        [Fact]
        public void ContainerLogs_succesfully_returns_a_list_of_V2CorporationContainerLogs()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_container_logs_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"action\": \"set_password\",\r\n    \"character_id\": 2112625428,\r\n    \"container_id\": 1000000012279,\r\n    \"container_type_id\": 17365,\r\n    \"location_flag\": \"CorpSAG1\",\r\n    \"location_id\": 1000000012278,\r\n    \"logged_at\": \"2017-10-10T14:00:00Z\",\r\n    \"password_type\": \"general\"\r\n  },\r\n  {\r\n    \"action\": \"lock\",\r\n    \"character_id\": 2112625428,\r\n    \"container_id\": 1000000012279,\r\n    \"container_type_id\": 17365,\r\n    \"location_flag\": \"CorpSAG1\",\r\n    \"location_id\": 1000000012278,\r\n    \"logged_at\": \"2017-10-11T12:04:33Z\",\r\n    \"quantity\": 30,\r\n    \"type_id\": 1230\r\n  },\r\n  {\r\n    \"action\": \"configure\",\r\n    \"character_id\": 2112625428,\r\n    \"container_id\": 1000000012279,\r\n    \"container_type_id\": 17365,\r\n    \"location_flag\": \"CorpSAG2\",\r\n    \"location_id\": 1000000012278,\r\n    \"logged_at\": \"2017-10-11T12:06:29Z\",\r\n    \"new_config_bitmask\": 31,\r\n    \"old_config_bitmask\": 23\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            PagedModel<V2CorporationContainerLogs> returnModel = internalLatestCorporations.ContainerLogs(inputToken, 123123, 1);

            Assert.Equal(3, returnModel.Model.Count);

            Assert.Equal(V2CorporationContainerLogAction.SetPassword, returnModel.Model.First().Action);
            Assert.Equal(2112625428, returnModel.Model.First().CharacterId);
            Assert.Equal(1000000012279, returnModel.Model.First().ContainerId);
            Assert.Equal(17365, returnModel.Model.First().ContainerTypeId);
            Assert.Equal(LocationFlagCorporation.CorpSag1, returnModel.Model.First().LocationFlag);
            Assert.Equal(1000000012278, returnModel.Model.First().LocationId);
            Assert.Equal(new DateTime(2017, 10, 10, 14, 00, 00), returnModel.Model.First().LoggedAt);
            Assert.Equal(V2CorporationContainerLogPasswordType.General, returnModel.Model.First().PasswordType);

            Assert.Equal(V2CorporationContainerLogAction.Lock, returnModel.Model[1].Action);
            Assert.Equal(2112625428, returnModel.Model[1].CharacterId);
            Assert.Equal(1000000012279, returnModel.Model[1].ContainerId);
            Assert.Equal(17365, returnModel.Model[1].ContainerTypeId);
            Assert.Equal(LocationFlagCorporation.CorpSag1, returnModel.Model[1].LocationFlag);
            Assert.Equal(1000000012278, returnModel.Model[1].LocationId);
            Assert.Equal(new DateTime(2017, 10, 11, 12, 04, 33), returnModel.Model[1].LoggedAt);
            Assert.Equal(30, returnModel.Model[1].Quantity);
            Assert.Equal(1230, returnModel.Model[1].TypeId);

            Assert.Equal(V2CorporationContainerLogAction.Configure, returnModel.Model[2].Action);
            Assert.Equal(2112625428, returnModel.Model[2].CharacterId);
            Assert.Equal(1000000012279, returnModel.Model[2].ContainerId);
            Assert.Equal(17365, returnModel.Model[2].ContainerTypeId);
            Assert.Equal(LocationFlagCorporation.CorpSag2, returnModel.Model[2].LocationFlag);
            Assert.Equal(1000000012278, returnModel.Model[2].LocationId);
            Assert.Equal(new DateTime(2017, 10, 11, 12, 06, 29), returnModel.Model[2].LoggedAt);
            Assert.Equal(31, returnModel.Model[2].NewConfigBitmask);
            Assert.Equal(23, returnModel.Model[2].OldConfigBitmask);
        }

        [Fact]
        public async Task ContainerLogsAsync_succesfully_returns_a_list_of_V2CorporationContainerLogs()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_container_logs_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"action\": \"set_password\",\r\n    \"character_id\": 2112625428,\r\n    \"container_id\": 1000000012279,\r\n    \"container_type_id\": 17365,\r\n    \"location_flag\": \"CorpSAG1\",\r\n    \"location_id\": 1000000012278,\r\n    \"logged_at\": \"2017-10-10T14:00:00Z\",\r\n    \"password_type\": \"general\"\r\n  },\r\n  {\r\n    \"action\": \"lock\",\r\n    \"character_id\": 2112625428,\r\n    \"container_id\": 1000000012279,\r\n    \"container_type_id\": 17365,\r\n    \"location_flag\": \"CorpSAG1\",\r\n    \"location_id\": 1000000012278,\r\n    \"logged_at\": \"2017-10-11T12:04:33Z\",\r\n    \"quantity\": 30,\r\n    \"type_id\": 1230\r\n  },\r\n  {\r\n    \"action\": \"configure\",\r\n    \"character_id\": 2112625428,\r\n    \"container_id\": 1000000012279,\r\n    \"container_type_id\": 17365,\r\n    \"location_flag\": \"CorpSAG2\",\r\n    \"location_id\": 1000000012278,\r\n    \"logged_at\": \"2017-10-11T12:06:29Z\",\r\n    \"new_config_bitmask\": 31,\r\n    \"old_config_bitmask\": 23\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            PagedModel<V2CorporationContainerLogs> returnModel = await internalLatestCorporations.ContainerLogsAsync(inputToken, 123123, 1);

            Assert.Equal(3, returnModel.Model.Count);

            Assert.Equal(V2CorporationContainerLogAction.SetPassword, returnModel.Model.First().Action);
            Assert.Equal(2112625428, returnModel.Model.First().CharacterId);
            Assert.Equal(1000000012279, returnModel.Model.First().ContainerId);
            Assert.Equal(17365, returnModel.Model.First().ContainerTypeId);
            Assert.Equal(LocationFlagCorporation.CorpSag1, returnModel.Model.First().LocationFlag);
            Assert.Equal(1000000012278, returnModel.Model.First().LocationId);
            Assert.Equal(new DateTime(2017, 10, 10, 14, 00, 00), returnModel.Model.First().LoggedAt);
            Assert.Equal(V2CorporationContainerLogPasswordType.General, returnModel.Model.First().PasswordType);

            Assert.Equal(V2CorporationContainerLogAction.Lock, returnModel.Model[1].Action);
            Assert.Equal(2112625428, returnModel.Model[1].CharacterId);
            Assert.Equal(1000000012279, returnModel.Model[1].ContainerId);
            Assert.Equal(17365, returnModel.Model[1].ContainerTypeId);
            Assert.Equal(LocationFlagCorporation.CorpSag1, returnModel.Model[1].LocationFlag);
            Assert.Equal(1000000012278, returnModel.Model[1].LocationId);
            Assert.Equal(new DateTime(2017, 10, 11, 12, 04, 33), returnModel.Model[1].LoggedAt);
            Assert.Equal(30, returnModel.Model[1].Quantity);
            Assert.Equal(1230, returnModel.Model[1].TypeId);

            Assert.Equal(V2CorporationContainerLogAction.Configure, returnModel.Model[2].Action);
            Assert.Equal(2112625428, returnModel.Model[2].CharacterId);
            Assert.Equal(1000000012279, returnModel.Model[2].ContainerId);
            Assert.Equal(17365, returnModel.Model[2].ContainerTypeId);
            Assert.Equal(LocationFlagCorporation.CorpSag2, returnModel.Model[2].LocationFlag);
            Assert.Equal(1000000012278, returnModel.Model[2].LocationId);
            Assert.Equal(new DateTime(2017, 10, 11, 12, 06, 29), returnModel.Model[2].LoggedAt);
            Assert.Equal(31, returnModel.Model[2].NewConfigBitmask);
            Assert.Equal(23, returnModel.Model[2].OldConfigBitmask);
        }

        [Fact]
        public void Divisions_succesfully_returns_a_V1CorporationDivisions()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_divisions_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "{\r\n  \"hangar\": [\r\n    {\r\n      \"division\": 1,\r\n      \"name\": \"Awesome Hangar 1\"\r\n    }\r\n  ],\r\n  \"wallet\": [\r\n    {\r\n      \"division\": 1,\r\n      \"name\": \"Rich Wallet 1\"\r\n    }\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            V1CorporationDivisions returnModel = internalLatestCorporations.Divisions(inputToken, 123123);

            Assert.Single(returnModel.Hangar);
            Assert.Single(returnModel.Wallet);

            Assert.Equal(1, returnModel.Hangar.First().Division);
            Assert.Equal("Awesome Hangar 1", returnModel.Hangar.First().Name);
            Assert.Equal(1, returnModel.Wallet.First().Division);
            Assert.Equal("Rich Wallet 1", returnModel.Wallet.First().Name);
        }

        [Fact]
        public async Task DivisionsAsync_succesfully_returns_a_V1CorporationDivisions()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_divisions_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "{\r\n  \"hangar\": [\r\n    {\r\n      \"division\": 1,\r\n      \"name\": \"Awesome Hangar 1\"\r\n    }\r\n  ],\r\n  \"wallet\": [\r\n    {\r\n      \"division\": 1,\r\n      \"name\": \"Rich Wallet 1\"\r\n    }\r\n  ]\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            V1CorporationDivisions returnModel = await internalLatestCorporations.DivisionsAsync(inputToken, 123123);

            Assert.Single(returnModel.Hangar);
            Assert.Single(returnModel.Wallet);

            Assert.Equal(1, returnModel.Hangar.First().Division);
            Assert.Equal("Awesome Hangar 1", returnModel.Hangar.First().Name);
            Assert.Equal(1, returnModel.Wallet.First().Division);
            Assert.Equal("Rich Wallet 1", returnModel.Wallet.First().Name);
        }

        [Fact]
        public void Facilities_succesfully_returns_a_list_of_V1CorporationFacilities()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_facilities_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"facility_id\": 123,\r\n    \"system_id\": 45678,\r\n    \"type_id\": 2502\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            IList<V1CorporationFacilities> returnModel = internalLatestCorporations.Facilities(inputToken, 123123);

            Assert.Single(returnModel);
            Assert.Equal(123, returnModel.First().FacilityId);
            Assert.Equal(45678, returnModel.First().SystemId);
            Assert.Equal(2502, returnModel.First().TypeId);
        }

        [Fact]
        public async Task FacilitiesAsync_succesfully_returns_a_list_of_V1CorporationFacilities()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_facilities_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"facility_id\": 123,\r\n    \"system_id\": 45678,\r\n    \"type_id\": 2502\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            IList<V1CorporationFacilities> returnModel = await internalLatestCorporations.FacilitiesAsync(inputToken, 123123);

            Assert.Single(returnModel);
            Assert.Equal(123, returnModel.First().FacilityId);
            Assert.Equal(45678, returnModel.First().SystemId);
            Assert.Equal(2502, returnModel.First().TypeId);
        }

        [Fact]
        public void Icons_successully_returns_a_V1CorporationIcons()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"px128x128\": \"https://images.evetech.net/Corporation/1000010_128.png\",\r\n  \"px256x256\": \"https://images.evetech.net/Corporation/1000010_256.png\",\r\n  \"px64x64\": \"https://images.evetech.net/Corporation/1000010_64.png\"\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            V1CorporationIcons returnModel = internalLatestCorporations.Icons(18888888);

            Assert.Equal("https://images.evetech.net/Corporation/1000010_128.png", returnModel.Px128X128);
            Assert.Equal("https://images.evetech.net/Corporation/1000010_256.png", returnModel.Px256X256);
            Assert.Equal("https://images.evetech.net/Corporation/1000010_64.png", returnModel.Px64X64);
        }

        [Fact]
        public async Task IconsAsync_successully_returns_a_V1CorporationIcons()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"px128x128\": \"https://images.evetech.net/Corporation/1000010_128.png\",\r\n  \"px256x256\": \"https://images.evetech.net/Corporation/1000010_256.png\",\r\n  \"px64x64\": \"https://images.evetech.net/Corporation/1000010_64.png\"\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            V1CorporationIcons returnModel = await internalLatestCorporations.IconsAsync(18888888);

            Assert.Equal("https://images.evetech.net/Corporation/1000010_128.png", returnModel.Px128X128);
            Assert.Equal("https://images.evetech.net/Corporation/1000010_256.png", returnModel.Px256X256);
            Assert.Equal("https://images.evetech.net/Corporation/1000010_64.png", returnModel.Px64X64);
        }

        [Fact]
        public void Medals_succesfully_returns_a_list_of_V1CorporationMedals()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_medals_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"created_at\": \"2017-10-10T14:00:00Z\",\r\n    \"creator_id\": 46578,\r\n    \"description\": \"An Awesome Medal\",\r\n    \"medal_id\": 123,\r\n    \"title\": \"Awesome Medal\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            PagedModel<V1CorporationMedals> returnModel = internalLatestCorporations.Medals(inputToken, 123123, 1);

            Assert.Single(returnModel.Model);
            Assert.Equal(new DateTime(2017, 10, 10, 14, 00, 00), returnModel.Model.First().CreatedAt);
            Assert.Equal(46578, returnModel.Model.First().CreatorId);
            Assert.Equal("An Awesome Medal", returnModel.Model.First().Description);
            Assert.Equal(123, returnModel.Model.First().MedalId);
            Assert.Equal("Awesome Medal", returnModel.Model.First().Title);
        }

        [Fact]
        public async Task MedalsAsync_succesfully_returns_a_list_of_V1CorporationMedals()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_medals_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"created_at\": \"2017-10-10T14:00:00Z\",\r\n    \"creator_id\": 46578,\r\n    \"description\": \"An Awesome Medal\",\r\n    \"medal_id\": 123,\r\n    \"title\": \"Awesome Medal\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            PagedModel<V1CorporationMedals> returnModel = await internalLatestCorporations.MedalsAsync(inputToken, 123123, 1);

            Assert.Single(returnModel.Model);
            Assert.Equal(new DateTime(2017, 10, 10, 14, 00, 00), returnModel.Model.First().CreatedAt);
            Assert.Equal(46578, returnModel.Model.First().CreatorId);
            Assert.Equal("An Awesome Medal", returnModel.Model.First().Description);
            Assert.Equal(123, returnModel.Model.First().MedalId);
            Assert.Equal("Awesome Medal", returnModel.Model.First().Title);
        }

        [Fact]
        public void IssuedMedals_succesfully_returns_a_list_of_V1CorporationMedalsIssued()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_medals_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"character_id\": 45678,\r\n    \"issued_at\": \"2017-10-10T14:00:00Z\",\r\n    \"issuer_id\": 67890,\r\n    \"medal_id\": 123,\r\n    \"reason\": \"Awesome Reason\",\r\n    \"status\": \"private\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            PagedModel<V1CorporationMedalsIssued> returnModel = internalLatestCorporations.IssuedMedals(inputToken, 123123, 1);

            Assert.Single(returnModel.Model);
            Assert.Equal(45678, returnModel.Model.First().CharacterId);
            Assert.Equal(new DateTime(2017, 10, 10, 14, 00, 00), returnModel.Model.First().IssuedAt);
            Assert.Equal(67890, returnModel.Model.First().IssuerId);
            Assert.Equal(123, returnModel.Model.First().MedalId);
            Assert.Equal("Awesome Reason", returnModel.Model.First().Reason);
            Assert.Equal(V1CorporationMedalsIssuedStatus.Private, returnModel.Model.First().Status);
        }

        [Fact]
        public async Task IssuedMedalsAsync_succesfully_returns_a_list_of_V1CorporationMedalsIssued()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_medals_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"character_id\": 45678,\r\n    \"issued_at\": \"2017-10-10T14:00:00Z\",\r\n    \"issuer_id\": 67890,\r\n    \"medal_id\": 123,\r\n    \"reason\": \"Awesome Reason\",\r\n    \"status\": \"private\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            PagedModel<V1CorporationMedalsIssued> returnModel = await internalLatestCorporations.IssuedMedalsAsync(inputToken, 123123, 1);

            Assert.Single(returnModel.Model);
            Assert.Equal(45678, returnModel.Model.First().CharacterId);
            Assert.Equal(new DateTime(2017, 10, 10, 14, 00, 00), returnModel.Model.First().IssuedAt);
            Assert.Equal(67890, returnModel.Model.First().IssuerId);
            Assert.Equal(123, returnModel.Model.First().MedalId);
            Assert.Equal("Awesome Reason", returnModel.Model.First().Reason);
            Assert.Equal(V1CorporationMedalsIssuedStatus.Private, returnModel.Model.First().Status);
        }

        [Fact]
        public void Members_succesfully_returns_a_list_of_int()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_corporation_membership_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  90000001,\r\n  90000002\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            IList<int> returnModel = internalLatestCorporations.Members(inputToken, 123123);

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(90000001, returnModel[0]);
            Assert.Equal(90000002, returnModel[1]);
        }

        [Fact]
        public async Task MembersAsync_succesfully_returns_a_list_of_int()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_corporation_membership_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  90000001,\r\n  90000002\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            IList<int> returnModel = await internalLatestCorporations.MembersAsync(inputToken, 123123);

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(90000001, returnModel[0]);
            Assert.Equal(90000002, returnModel[1]);
        }

        [Fact]
        public void MembersLimit_succesfully_returns_a_int()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_track_members_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "40";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            int returnModel = internalLatestCorporations.MembersLimit(inputToken, 123123);

            Assert.Equal(40, returnModel);
        }

        [Fact]
        public async Task MembersLimitAsync_succesfully_returns_a_int()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_track_members_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "40";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            int returnModel = await internalLatestCorporations.MembersLimitAsync(inputToken, 123123);

            Assert.Equal(40, returnModel);
        }

        [Fact]
        public void MembersTitles_succesfully_returns_a_list_of_V1CorporationMembersTitles()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"character_id\": 12345,\r\n    \"titles\": []\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            IList<V1CorporationMembersTitles> returnModel = internalLatestCorporations.MembersTitles(inputToken, 123123);

            Assert.Single(returnModel);
            Assert.Equal(12345, returnModel.First().CharacterId);
            Assert.Empty(returnModel.First().Titles);
        }

        [Fact]
        public async Task MembersTitlesAsync_succesfully_returns_a_list_of_V1CorporationMembersTitles()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"character_id\": 12345,\r\n    \"titles\": []\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            IList<V1CorporationMembersTitles> returnModel = await internalLatestCorporations.MembersTitlesAsync(inputToken, 123123);

            Assert.Single(returnModel);
            Assert.Equal(12345, returnModel.First().CharacterId);
            Assert.Empty(returnModel.First().Titles);
        }

        [Fact]
        public void MemberTracking_succesfully_returns_a_list_of_V1CorporationMemberTracking()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_track_members_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"character_id\": 2112000001,\r\n    \"location_id\": 30003657,\r\n    \"logoff_date\": \"2017-08-03T14:31:16Z\",\r\n    \"logon_date\": \"2017-08-03T14:22:03Z\",\r\n    \"ship_type_id\": 22464,\r\n    \"start_date\": \"2017-07-10T14:46:00Z\"\r\n  },\r\n  {\r\n    \"character_id\": 2112000002,\r\n    \"location_id\": 30003657,\r\n    \"logoff_date\": \"2017-07-25T11:07:40Z\",\r\n    \"logon_date\": \"2017-07-25T10:54:00Z\",\r\n    \"ship_type_id\": 670,\r\n    \"start_date\": \"2017-07-10T14:50:00Z\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            IList<V1CorporationMemberTracking> returnModel = internalLatestCorporations.MemberTracking(inputToken, 123123);

            Assert.Equal(2, returnModel.Count);

            Assert.Equal(2112000001, returnModel.First().CharacterId);
            Assert.Equal(30003657, returnModel.First().LocationId);
            Assert.Equal(new DateTime(2017, 08, 03, 14, 31, 16), returnModel.First().LogoffDate);
            Assert.Equal(new DateTime(2017, 08, 03, 14, 22, 03), returnModel.First().LogonDate);
            Assert.Equal(22464, returnModel.First().ShipTypeId);
            Assert.Equal(new DateTime(2017, 07, 10, 14, 46, 00), returnModel.First().StartDate);

            Assert.Equal(2112000002, returnModel[1].CharacterId);
            Assert.Equal(30003657, returnModel[1].LocationId);
            Assert.Equal(new DateTime(2017, 07, 25, 11, 07, 40), returnModel[1].LogoffDate);
            Assert.Equal(new DateTime(2017, 07, 25, 10, 54, 00), returnModel[1].LogonDate);
            Assert.Equal(670, returnModel[1].ShipTypeId);
            Assert.Equal(new DateTime(2017, 07, 10, 14, 50, 00), returnModel[1].StartDate);
        }

        [Fact]
        public async Task MemberTrackingAsync_succesfully_returns_a_list_of_V1CorporationMemberTracking()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_track_members_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"character_id\": 2112000001,\r\n    \"location_id\": 30003657,\r\n    \"logoff_date\": \"2017-08-03T14:31:16Z\",\r\n    \"logon_date\": \"2017-08-03T14:22:03Z\",\r\n    \"ship_type_id\": 22464,\r\n    \"start_date\": \"2017-07-10T14:46:00Z\"\r\n  },\r\n  {\r\n    \"character_id\": 2112000002,\r\n    \"location_id\": 30003657,\r\n    \"logoff_date\": \"2017-07-25T11:07:40Z\",\r\n    \"logon_date\": \"2017-07-25T10:54:00Z\",\r\n    \"ship_type_id\": 670,\r\n    \"start_date\": \"2017-07-10T14:50:00Z\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            IList<V1CorporationMemberTracking> returnModel = await internalLatestCorporations.MemberTrackingAsync(inputToken, 123123);

            Assert.Equal(2, returnModel.Count);

            Assert.Equal(2112000001, returnModel.First().CharacterId);
            Assert.Equal(30003657, returnModel.First().LocationId);
            Assert.Equal(new DateTime(2017, 08, 03, 14, 31, 16), returnModel.First().LogoffDate);
            Assert.Equal(new DateTime(2017, 08, 03, 14, 22, 03), returnModel.First().LogonDate);
            Assert.Equal(22464, returnModel.First().ShipTypeId);
            Assert.Equal(new DateTime(2017, 07, 10, 14, 46, 00), returnModel.First().StartDate);

            Assert.Equal(2112000002, returnModel[1].CharacterId);
            Assert.Equal(30003657, returnModel[1].LocationId);
            Assert.Equal(new DateTime(2017, 07, 25, 11, 07, 40), returnModel[1].LogoffDate);
            Assert.Equal(new DateTime(2017, 07, 25, 10, 54, 00), returnModel[1].LogonDate);
            Assert.Equal(670, returnModel[1].ShipTypeId);
            Assert.Equal(new DateTime(2017, 07, 10, 14, 50, 00), returnModel[1].StartDate);
        }

        [Fact]
        public void Roles_succesfully_returns_a_list_of_V1CorporationRoles()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_corporation_membership_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"character_id\": 1000171,\r\n    \"roles\": [\r\n      \"Director\",\r\n      \"Station_Manager\"\r\n    ]\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            IList<V1CorporationRoles> returnModel = internalLatestCorporations.Roles(inputToken, 123123);

            Assert.Single(returnModel);

            Assert.Equal(1000171, returnModel.First().CharacterId);
            Assert.Equal(2, returnModel.First().Roles.Count);

            Assert.Equal(CorporationRoles.Director, returnModel.First().Roles[0]);
            Assert.Equal(CorporationRoles.StationManager, returnModel.First().Roles[1]);
        }

        [Fact]
        public async Task RolesAsync_succesfully_returns_a_list_of_V1CorporationRoles()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_corporation_membership_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"character_id\": 1000171,\r\n    \"roles\": [\r\n      \"Director\",\r\n      \"Station_Manager\"\r\n    ]\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            IList<V1CorporationRoles> returnModel = await internalLatestCorporations.RolesAsync(inputToken, 123123);

            Assert.Single(returnModel);

            Assert.Equal(1000171, returnModel.First().CharacterId);
            Assert.Equal(2, returnModel.First().Roles.Count);

            Assert.Equal(CorporationRoles.Director, returnModel.First().Roles[0]);
            Assert.Equal(CorporationRoles.StationManager, returnModel.First().Roles[1]);
        }

        [Fact]
        public void RoleHistory_succesfully_returns_a_list_of_V1CorporationRolesHistory()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_corporation_membership_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"changed_at\": \"2016-10-25T14:46:00Z\",\r\n    \"character_id\": 12345,\r\n    \"issuer_id\": 45678,\r\n    \"new_roles\": [\r\n      \"Station_Manager\"\r\n    ],\r\n    \"old_roles\": [\r\n      \"Diplomat\"\r\n    ],\r\n    \"role_type\": \"roles\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            PagedModel<V1CorporationRolesHistory> returnModel = internalLatestCorporations.RoleHistory(inputToken, 123123, 1);

            Assert.Single(returnModel.Model);

            Assert.Equal(new DateTime(2016, 10, 25, 14, 46, 00), returnModel.Model.First().ChangedAt);
            Assert.Equal(12345, returnModel.Model.First().CharacterId);
            Assert.Equal(45678, returnModel.Model.First().IssuerId);
            Assert.Single(returnModel.Model.First().NewRoles);
            Assert.Equal(CorporationRoles.StationManager, returnModel.Model.First().NewRoles.First());
            Assert.Single(returnModel.Model.First().OldRoles);
            Assert.Equal(CorporationRoles.Diplomat, returnModel.Model.First().OldRoles.First());
            Assert.Equal(V1CorporationRolesHistoryRoleType.Roles, returnModel.Model.First().RoleType);
        }

        [Fact]
        public async Task RoleHistoryAsync_succesfully_returns_a_list_of_V1CorporationRolesHistory()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_corporation_membership_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"changed_at\": \"2016-10-25T14:46:00Z\",\r\n    \"character_id\": 12345,\r\n    \"issuer_id\": 45678,\r\n    \"new_roles\": [\r\n      \"Station_Manager\"\r\n    ],\r\n    \"old_roles\": [\r\n      \"Diplomat\"\r\n    ],\r\n    \"role_type\": \"roles\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            PagedModel<V1CorporationRolesHistory> returnModel = await internalLatestCorporations.RoleHistoryAsync(inputToken, 123123, 1);

            Assert.Single(returnModel.Model);

            Assert.Equal(new DateTime(2016, 10, 25, 14, 46, 00), returnModel.Model.First().ChangedAt);
            Assert.Equal(12345, returnModel.Model.First().CharacterId);
            Assert.Equal(45678, returnModel.Model.First().IssuerId);
            Assert.Single(returnModel.Model.First().NewRoles);
            Assert.Equal(CorporationRoles.StationManager, returnModel.Model.First().NewRoles.First());
            Assert.Single(returnModel.Model.First().OldRoles);
            Assert.Equal(CorporationRoles.Diplomat, returnModel.Model.First().OldRoles.First());
            Assert.Equal(V1CorporationRolesHistoryRoleType.Roles, returnModel.Model.First().RoleType);
        }

        [Fact]
        public void Shareholders_succesfully_returns_a_list_of_V1CorporationShareholders()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            WalletScopes scopes = WalletScopes.esi_wallet_read_corporation_wallets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, WalletScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"share_count\": 580,\r\n    \"shareholder_id\": 98000001,\r\n    \"shareholder_type\": \"corporation\"\r\n  },\r\n  {\r\n    \"share_count\": 20,\r\n    \"shareholder_id\": 2112000003,\r\n    \"shareholder_type\": \"character\"\r\n  },\r\n  {\r\n    \"share_count\": 300,\r\n    \"shareholder_id\": 2112000004,\r\n    \"shareholder_type\": \"character\"\r\n  },\r\n  {\r\n    \"share_count\": 100,\r\n    \"shareholder_id\": 2112000001,\r\n    \"shareholder_type\": \"character\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            PagedModel<V1CorporationShareholders> returnModel = internalLatestCorporations.Shareholders(inputToken, 123123, 1);

            Assert.Equal(4, returnModel.Model.Count);

            Assert.Equal(580, returnModel.Model[0].ShareCount);
            Assert.Equal(98000001, returnModel.Model[0].ShareholderId);
            Assert.Equal(V1CorporationShareholdersShareholdersType.Corporation, returnModel.Model[0].ShareholderType);

            Assert.Equal(20, returnModel.Model[1].ShareCount);
            Assert.Equal(2112000003, returnModel.Model[1].ShareholderId);
            Assert.Equal(V1CorporationShareholdersShareholdersType.Character, returnModel.Model[1].ShareholderType);

            Assert.Equal(300, returnModel.Model[2].ShareCount);
            Assert.Equal(2112000004, returnModel.Model[2].ShareholderId);
            Assert.Equal(V1CorporationShareholdersShareholdersType.Character, returnModel.Model[2].ShareholderType);

            Assert.Equal(100, returnModel.Model[3].ShareCount);
            Assert.Equal(2112000001, returnModel.Model[3].ShareholderId);
            Assert.Equal(V1CorporationShareholdersShareholdersType.Character, returnModel.Model[3].ShareholderType);
        }

        [Fact]
        public async Task ShareholdersAsync_succesfully_returns_a_list_of_V1CorporationShareholders()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            WalletScopes scopes = WalletScopes.esi_wallet_read_corporation_wallets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, WalletScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"share_count\": 580,\r\n    \"shareholder_id\": 98000001,\r\n    \"shareholder_type\": \"corporation\"\r\n  },\r\n  {\r\n    \"share_count\": 20,\r\n    \"shareholder_id\": 2112000003,\r\n    \"shareholder_type\": \"character\"\r\n  },\r\n  {\r\n    \"share_count\": 300,\r\n    \"shareholder_id\": 2112000004,\r\n    \"shareholder_type\": \"character\"\r\n  },\r\n  {\r\n    \"share_count\": 100,\r\n    \"shareholder_id\": 2112000001,\r\n    \"shareholder_type\": \"character\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            PagedModel<V1CorporationShareholders> returnModel = await internalLatestCorporations.ShareholdersAsync(inputToken, 123123, 1);

            Assert.Equal(4, returnModel.Model.Count);

            Assert.Equal(580, returnModel.Model[0].ShareCount);
            Assert.Equal(98000001, returnModel.Model[0].ShareholderId);
            Assert.Equal(V1CorporationShareholdersShareholdersType.Corporation, returnModel.Model[0].ShareholderType);

            Assert.Equal(20, returnModel.Model[1].ShareCount);
            Assert.Equal(2112000003, returnModel.Model[1].ShareholderId);
            Assert.Equal(V1CorporationShareholdersShareholdersType.Character, returnModel.Model[1].ShareholderType);

            Assert.Equal(300, returnModel.Model[2].ShareCount);
            Assert.Equal(2112000004, returnModel.Model[2].ShareholderId);
            Assert.Equal(V1CorporationShareholdersShareholdersType.Character, returnModel.Model[2].ShareholderType);

            Assert.Equal(100, returnModel.Model[3].ShareCount);
            Assert.Equal(2112000001, returnModel.Model[3].ShareholderId);
            Assert.Equal(V1CorporationShareholdersShareholdersType.Character, returnModel.Model[3].ShareholderType);
        }

        [Fact]
        public void Standings_succesfully_returns_a_list_of_V1CorporationStandings()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_standings_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"from_id\": 3009841,\r\n    \"from_type\": \"agent\",\r\n    \"standing\": 0.1\r\n  },\r\n  {\r\n    \"from_id\": 1000061,\r\n    \"from_type\": \"npc_corp\",\r\n    \"standing\": 0\r\n  },\r\n  {\r\n    \"from_id\": 500003,\r\n    \"from_type\": \"faction\",\r\n    \"standing\": -1\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            PagedModel<V1CorporationStandings> returnModel = internalLatestCorporations.Standings(inputToken, 123123, 1);

            Assert.Equal(3, returnModel.Model.Count);

            Assert.Equal(3009841, returnModel.Model[0].FromId);
            Assert.Equal(V1CorporationStandingsFromType.Agent, returnModel.Model[0].FromType);
            Assert.Equal(0.1f, returnModel.Model[0].Standing);

            Assert.Equal(1000061, returnModel.Model[1].FromId);
            Assert.Equal(V1CorporationStandingsFromType.NpcCorp, returnModel.Model[1].FromType);
            Assert.Equal(0, returnModel.Model[1].Standing);

            Assert.Equal(500003, returnModel.Model[2].FromId);
            Assert.Equal(V1CorporationStandingsFromType.Faction, returnModel.Model[2].FromType);
            Assert.Equal(-1, returnModel.Model[2].Standing);
        }

        [Fact]
        public async Task StandingsAsync_succesfully_returns_a_list_of_V1CorporationStandings()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_standings_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"from_id\": 3009841,\r\n    \"from_type\": \"agent\",\r\n    \"standing\": 0.1\r\n  },\r\n  {\r\n    \"from_id\": 1000061,\r\n    \"from_type\": \"npc_corp\",\r\n    \"standing\": 0\r\n  },\r\n  {\r\n    \"from_id\": 500003,\r\n    \"from_type\": \"faction\",\r\n    \"standing\": -1\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            PagedModel<V1CorporationStandings> returnModel = await internalLatestCorporations.StandingsAsync(inputToken, 123123, 1);

            Assert.Equal(3, returnModel.Model.Count);

            Assert.Equal(3009841, returnModel.Model[0].FromId);
            Assert.Equal(V1CorporationStandingsFromType.Agent, returnModel.Model[0].FromType);
            Assert.Equal(0.1f, returnModel.Model[0].Standing);

            Assert.Equal(1000061, returnModel.Model[1].FromId);
            Assert.Equal(V1CorporationStandingsFromType.NpcCorp, returnModel.Model[1].FromType);
            Assert.Equal(0, returnModel.Model[1].Standing);

            Assert.Equal(500003, returnModel.Model[2].FromId);
            Assert.Equal(V1CorporationStandingsFromType.Faction, returnModel.Model[2].FromType);
            Assert.Equal(-1, returnModel.Model[2].Standing);
        }

        [Fact]
        public void Starbases_succesfully_returns_a_list_of_V1CorporationStarbases()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_starbases_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"starbase_id\": 12345,\r\n    \"system_id\": 123456,\r\n    \"type_id\": 456\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            PagedModel<V1CorporationStarbases> returnModel = internalLatestCorporations.Starbases(inputToken, 123123, 1);

            Assert.Single(returnModel.Model);

            Assert.Equal(12345, returnModel.Model[0].StarbaseId);
            Assert.Equal(123456, returnModel.Model[0].SystemId);
            Assert.Equal(456, returnModel.Model[0].TypeId);
        }

        [Fact]
        public async Task StarbasesAsync_succesfully_returns_a_list_of_V1CorporationStarbases()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_starbases_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"starbase_id\": 12345,\r\n    \"system_id\": 123456,\r\n    \"type_id\": 456\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            PagedModel<V1CorporationStarbases> returnModel = await internalLatestCorporations.StarbasesAsync(inputToken, 123123, 1);

            Assert.Single(returnModel.Model);

            Assert.Equal(12345, returnModel.Model[0].StarbaseId);
            Assert.Equal(123456, returnModel.Model[0].SystemId);
            Assert.Equal(456, returnModel.Model[0].TypeId);
        }

        [Fact]
        public void Starbase_succesfully_returns_a_V1CorporationStarbase()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_starbases_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "{\r\n  \"allow_alliance_members\": false,\r\n  \"allow_corporation_members\": true,\r\n  \"anchor\": \"config_starbase_equipment_role\",\r\n  \"attack_if_at_war\": true,\r\n  \"attack_if_other_security_status_dropping\": false,\r\n  \"fuel_bay_take\": \"config_starbase_equipment_role\",\r\n  \"fuel_bay_view\": \"config_starbase_equipment_role\",\r\n  \"offline\": \"config_starbase_equipment_role\",\r\n  \"online\": \"config_starbase_equipment_role\",\r\n  \"unanchor\": \"config_starbase_equipment_role\",\r\n  \"use_alliance_standings\": false\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            V1CorporationStarbase returnModel = internalLatestCorporations.Starbase(inputToken, 123123, 112323);

            Assert.False(returnModel.AllowAllianceMembers);
            Assert.True(returnModel.AllowCorporationMembers);
            Assert.Equal(V1CorporationStarbaseRoles.ConfigStarbaseEquipmentRole, returnModel.Anchor);
            Assert.True(returnModel.AttackIfAtWar);
            Assert.False(returnModel.AttackIfOtherSecurityStatusDropping);
            Assert.Equal(V1CorporationStarbaseRoles.ConfigStarbaseEquipmentRole, returnModel.FuelBayTake);
            Assert.Equal(V1CorporationStarbaseRoles.ConfigStarbaseEquipmentRole, returnModel.FuelBayView);
            Assert.Equal(V1CorporationStarbaseRoles.ConfigStarbaseEquipmentRole, returnModel.Offline);
            Assert.Equal(V1CorporationStarbaseRoles.ConfigStarbaseEquipmentRole, returnModel.Online);
            Assert.Equal(V1CorporationStarbaseRoles.ConfigStarbaseEquipmentRole, returnModel.Unanchor);
            Assert.False(returnModel.UseAllianceStandings);
        }

        [Fact]
        public async Task StarbaseAsync_succesfully_returns_a_V1CorporationStarbase()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_starbases_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "{\r\n  \"allow_alliance_members\": false,\r\n  \"allow_corporation_members\": true,\r\n  \"anchor\": \"config_starbase_equipment_role\",\r\n  \"attack_if_at_war\": true,\r\n  \"attack_if_other_security_status_dropping\": false,\r\n  \"fuel_bay_take\": \"config_starbase_equipment_role\",\r\n  \"fuel_bay_view\": \"config_starbase_equipment_role\",\r\n  \"offline\": \"config_starbase_equipment_role\",\r\n  \"online\": \"config_starbase_equipment_role\",\r\n  \"unanchor\": \"config_starbase_equipment_role\",\r\n  \"use_alliance_standings\": false\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            V1CorporationStarbase returnModel = await internalLatestCorporations.StarbaseAsync(inputToken, 123123, 112323);

            Assert.False(returnModel.AllowAllianceMembers);
            Assert.True(returnModel.AllowCorporationMembers);
            Assert.Equal(V1CorporationStarbaseRoles.ConfigStarbaseEquipmentRole, returnModel.Anchor);
            Assert.True(returnModel.AttackIfAtWar);
            Assert.False(returnModel.AttackIfOtherSecurityStatusDropping);
            Assert.Equal(V1CorporationStarbaseRoles.ConfigStarbaseEquipmentRole, returnModel.FuelBayTake);
            Assert.Equal(V1CorporationStarbaseRoles.ConfigStarbaseEquipmentRole, returnModel.FuelBayView);
            Assert.Equal(V1CorporationStarbaseRoles.ConfigStarbaseEquipmentRole, returnModel.Offline);
            Assert.Equal(V1CorporationStarbaseRoles.ConfigStarbaseEquipmentRole, returnModel.Online);
            Assert.Equal(V1CorporationStarbaseRoles.ConfigStarbaseEquipmentRole, returnModel.Unanchor);
            Assert.False(returnModel.UseAllianceStandings);
        }

        [Fact]
        public void Structures_succesfully_returns_a_list_of_V2CorporationStructures()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_structures_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"corporation_id\": 667531913,\r\n    \"profile_id\": 11237,\r\n    \"reinforce_hour\": 22,\r\n    \"reinforce_weekday\": 2,\r\n    \"state\": \"shield_vulnerable\",\r\n    \"structure_id\": 1021975535893,\r\n    \"system_id\": 30004763,\r\n    \"type_id\": 35833\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            PagedModel<V3CorporationStructures> returnModel = internalLatestCorporations.Structures(inputToken, 123123, 1);

            Assert.Single(returnModel.Model);

            Assert.Equal(667531913, returnModel.Model[0].CorporationId);
            Assert.Equal(11237, returnModel.Model[0].ProfileId);
            Assert.Equal(22, returnModel.Model[0].ReinforceHour);
            Assert.Equal(V3CorporationStructuresState.ShieldVulnerable, returnModel.Model[0].State);
            Assert.Equal(1021975535893, returnModel.Model[0].StructureId);
            Assert.Equal(30004763, returnModel.Model[0].SystemId);
            Assert.Equal(35833, returnModel.Model[0].TypeId);
        }

        [Fact]
        public async Task StructuresAsync_succesfully_returns_a_list_of_V2CorporationStructures()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_structures_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"corporation_id\": 667531913,\r\n    \"profile_id\": 11237,\r\n    \"reinforce_hour\": 22,\r\n    \"reinforce_weekday\": 2,\r\n    \"state\": \"shield_vulnerable\",\r\n    \"structure_id\": 1021975535893,\r\n    \"system_id\": 30004763,\r\n    \"type_id\": 35833\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            PagedModel<V3CorporationStructures> returnModel = await internalLatestCorporations.StructuresAsync(inputToken, 123123, 1);

            Assert.Single(returnModel.Model);

            Assert.Equal(667531913, returnModel.Model[0].CorporationId);
            Assert.Equal(11237, returnModel.Model[0].ProfileId);
            Assert.Equal(22, returnModel.Model[0].ReinforceHour);
            Assert.Equal(V3CorporationStructuresState.ShieldVulnerable, returnModel.Model[0].State);
            Assert.Equal(1021975535893, returnModel.Model[0].StructureId);
            Assert.Equal(30004763, returnModel.Model[0].SystemId);
            Assert.Equal(35833, returnModel.Model[0].TypeId);
        }

        [Fact]
        public void Titles_successully_returns_a_list_of_V1CorporationTitles()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[{\"name\": \"Awesome Title\",\"roles\": [\"Hangar_Take_6\",\"Hangar_Query_2\"],\"title_id\": 1}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            IList<V1CorporationTitles> corporationRoles = internalLatestCorporations.Titles(inputToken, 18888888);

            Assert.Equal(1, corporationRoles.Count);
            Assert.Equal("Awesome Title", corporationRoles.First().Name);
            Assert.Equal(1, corporationRoles.First().TitleId);
            Assert.Equal(2, corporationRoles.First().Roles.Count);
            Assert.Equal(CorporationRoles.HangarTake6, corporationRoles.First().Roles.First());
        }

        [Fact]
        public async Task TitlesAsync_successully_returns_a_list_of_V1CorporationTitles()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };
            string json = "[{\"name\": \"Awesome Title\",\"roles\": [\"Hangar_Take_6\",\"Hangar_Query_2\"],\"title_id\": 1}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            IList<V1CorporationTitles> corporationRoles = await internalLatestCorporations.TitlesAsync(inputToken, 18888888);

            Assert.Equal(1, corporationRoles.Count);
            Assert.Equal("Awesome Title", corporationRoles.First().Name);
            Assert.Equal(1, corporationRoles.First().TitleId);
            Assert.Equal(2, corporationRoles.First().Roles.Count);
            Assert.Equal(CorporationRoles.HangarTake6, corporationRoles.First().Roles.First());
        }

        [Fact]
        public void NpcCorps_successully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1000001,\r\n  1000002,\r\n  1000003\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            IList<int> returnModel = internalLatestCorporations.NpcCorps();

            Assert.Equal(1000001, returnModel[0]);
            Assert.Equal(1000002, returnModel[1]);
            Assert.Equal(1000003, returnModel[2]);
        }

        [Fact]
        public async Task NpcCorpsAsync_successully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1000001,\r\n  1000002,\r\n  1000003\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestCorporations internalLatestCorporations = new InternalLatestCorporations(mockedWebClient.Object, string.Empty);

            IList<int> returnModel = await internalLatestCorporations.NpcCorpsAsync();

            Assert.Equal(1000001, returnModel[0]);
            Assert.Equal(1000002, returnModel[1]);
            Assert.Equal(1000003, returnModel[2]);
        }
    }
}
