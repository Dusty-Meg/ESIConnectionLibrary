using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibrary.Tests.IntegrationTests
{
    public class CorporationIntegrationTests
    {
        [Fact]
        public void PublicInfo_successully_returns_a_V4CorporationPublicInfo()
        {
            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            V4CorporationPublicInfo returnModel = internalLatestCorporations.PublicInfo(18888888);

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
        public async Task PublicInfoAsync_successully_returns_a_V4CorporationPublicInfo()
        {
            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            IList<V2CorporationAllianceHistory> returnModel = internalLatestCorporations.AllianceHistory(18888888);

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(99000006, returnModel.First().AllianceId);
            Assert.True(returnModel.First().IsDeleted);
            Assert.Equal(23, returnModel.First().RecordId);
            Assert.Equal(new DateTime(2016, 10, 25, 14, 46, 00), returnModel.First().StartDate);
            Assert.Equal(1, returnModel[1].RecordId);
            Assert.Equal(new DateTime(2015, 07, 06, 20, 56, 00), returnModel[1].StartDate);
        }

        [Fact]
        public async Task AllianceHistoryAsync_successully_returns_a_list_of_V2CorporationAllianceHistory()
        {
            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_blueprints_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_blueprints_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_container_logs_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_container_logs_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_divisions_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_divisions_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_facilities_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            IList<V1CorporationFacilities> returnModel = internalLatestCorporations.Facilities(inputToken, 123123);

            Assert.Single(returnModel);
            Assert.Equal(123, returnModel.First().FacilityId);
            Assert.Equal(45678, returnModel.First().SystemId);
            Assert.Equal(2502, returnModel.First().TypeId);
        }

        [Fact]
        public async Task FacilitiesAsync_succesfully_returns_a_list_of_V1CorporationFacilities()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_facilities_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            IList<V1CorporationFacilities> returnModel = await internalLatestCorporations.FacilitiesAsync(inputToken, 123123);

            Assert.Single(returnModel);
            Assert.Equal(123, returnModel.First().FacilityId);
            Assert.Equal(45678, returnModel.First().SystemId);
            Assert.Equal(2502, returnModel.First().TypeId);
        }

        [Fact]
        public void Icons_successully_returns_a_V1CorporationIcons()
        {
            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            V1CorporationIcons returnModel = internalLatestCorporations.Icons(18888888);

            Assert.Equal("https://images.evetech.net/corporations/1000010/logo?tenant=tranquility&size=128", returnModel.Px128X128);
            Assert.Equal("https://images.evetech.net/corporations/1000010/logo?tenant=tranquility&size=256", returnModel.Px256X256);
            Assert.Equal("https://images.evetech.net/corporations/1000010/logo?tenant=tranquility&size=64", returnModel.Px64X64);
        }

        [Fact]
        public async Task IconsAsync_successully_returns_a_V1CorporationIcons()
        {
            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            V1CorporationIcons returnModel = await internalLatestCorporations.IconsAsync(18888888);

            Assert.Equal("https://images.evetech.net/corporations/1000010/logo?tenant=tranquility&size=128", returnModel.Px128X128);
            Assert.Equal("https://images.evetech.net/corporations/1000010/logo?tenant=tranquility&size=256", returnModel.Px256X256);
            Assert.Equal("https://images.evetech.net/corporations/1000010/logo?tenant=tranquility&size=64", returnModel.Px64X64);
        }

        [Fact]
        public void Medals_succesfully_returns_a_list_of_V1CorporationMedals()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_medals_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_medals_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_medals_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_medals_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_corporation_membership_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            IList<int> returnModel = internalLatestCorporations.Members(inputToken, 123123);

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(90000001, returnModel[0]);
            Assert.Equal(90000002, returnModel[1]);
        }

        [Fact]
        public async Task MembersAsync_succesfully_returns_a_list_of_int()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_corporation_membership_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            IList<int> returnModel = await internalLatestCorporations.MembersAsync(inputToken, 123123);

            Assert.Equal(2, returnModel.Count);
            Assert.Equal(90000001, returnModel[0]);
            Assert.Equal(90000002, returnModel[1]);
        }

        [Fact]
        public void MembersLimit_succesfully_returns_a_int()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_track_members_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            int returnModel = internalLatestCorporations.MembersLimit(inputToken, 123123);

            Assert.Equal(40, returnModel);
        }

        [Fact]
        public async Task MembersLimitAsync_succesfully_returns_a_int()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_track_members_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            int returnModel = await internalLatestCorporations.MembersLimitAsync(inputToken, 123123);

            Assert.Equal(40, returnModel);
        }

        [Fact]
        public void MembersTitles_succesfully_returns_a_list_of_V1CorporationMembersTitles()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            IList<V1CorporationMembersTitles> returnModel = internalLatestCorporations.MembersTitles(inputToken, 123123);

            Assert.Single(returnModel);
            Assert.Equal(12345, returnModel.First().CharacterId);
            Assert.Empty(returnModel.First().Titles);
        }

        [Fact]
        public async Task MembersTitlesAsync_succesfully_returns_a_list_of_V1CorporationMembersTitles()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            IList<V1CorporationMembersTitles> returnModel = await internalLatestCorporations.MembersTitlesAsync(inputToken, 123123);

            Assert.Single(returnModel);
            Assert.Equal(12345, returnModel.First().CharacterId);
            Assert.Empty(returnModel.First().Titles);
        }

        [Fact]
        public void MemberTracking_succesfully_returns_a_list_of_V1CorporationMemberTracking()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_track_members_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_track_members_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_corporation_membership_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_corporation_membership_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_corporation_membership_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_corporation_membership_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            WalletScopes scopes = WalletScopes.esi_wallet_read_corporation_wallets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, WalletScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            WalletScopes scopes = WalletScopes.esi_wallet_read_corporation_wallets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, WalletScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_standings_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_standings_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_starbases_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            PagedModel<V1CorporationStarbases> returnModel = internalLatestCorporations.Starbases(inputToken, 123123, 1);

            Assert.Single(returnModel.Model);

            Assert.Equal(12345, returnModel.Model[0].StarbaseId);
            Assert.Equal(123456, returnModel.Model[0].SystemId);
            Assert.Equal(456, returnModel.Model[0].TypeId);
        }

        [Fact]
        public async Task StarbasesAsync_succesfully_returns_a_list_of_V1CorporationStarbases()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_starbases_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            PagedModel<V1CorporationStarbases> returnModel = await internalLatestCorporations.StarbasesAsync(inputToken, 123123, 1);

            Assert.Single(returnModel.Model);

            Assert.Equal(12345, returnModel.Model[0].StarbaseId);
            Assert.Equal(123456, returnModel.Model[0].SystemId);
            Assert.Equal(456, returnModel.Model[0].TypeId);
        }

        [Fact]
        public void Structures_succesfully_returns_a_list_of_V2CorporationStructures()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_structures_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_structures_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            CorporationScopes scopes = CorporationScopes.esi_corporations_read_titles_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, CorporationScopesFlags = scopes };

            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

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
            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            IList<int> returnModel = internalLatestCorporations.NpcCorps();

            Assert.Equal(1000001, returnModel[0]);
            Assert.Equal(1000002, returnModel[1]);
            Assert.Equal(1000003, returnModel[2]);
        }

        [Fact]
        public async Task NpcCorpsAsync_successully_returns_a_list_of_ints()
        {
            LatestCorporationsEndpoints internalLatestCorporations = new LatestCorporationsEndpoints(string.Empty, true);

            IList<int> returnModel = await internalLatestCorporations.NpcCorpsAsync();

            Assert.Equal(1000001, returnModel[0]);
            Assert.Equal(1000002, returnModel[1]);
            Assert.Equal(1000003, returnModel[2]);
        }
    }
}
