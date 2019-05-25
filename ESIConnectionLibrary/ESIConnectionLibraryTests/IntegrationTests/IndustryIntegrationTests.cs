using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class IndustryIntegrationTests
    {
        [Fact]
        public void Character_successfully_returns_a_listV1IndustryCharacter()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_character_jobs_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };

            LatestIndustryEndpoints internalLatestIndustry = new LatestIndustryEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_character_jobs_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };

            LatestIndustryEndpoints internalLatestIndustry = new LatestIndustryEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_character_mining_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };

            LatestIndustryEndpoints internalLatestIndustry = new LatestIndustryEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_character_mining_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };

            LatestIndustryEndpoints internalLatestIndustry = new LatestIndustryEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_corporation_mining_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };

            LatestIndustryEndpoints internalLatestIndustry = new LatestIndustryEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_corporation_mining_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };

            LatestIndustryEndpoints internalLatestIndustry = new LatestIndustryEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_corporation_mining_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };

            LatestIndustryEndpoints internalLatestIndustry = new LatestIndustryEndpoints(string.Empty, true);

            IList<V1IndustryCorporationObservers> returnModel = internalLatestIndustry.CorporationObservers(inputToken, 22, 1);

            Assert.Single(returnModel);

            Assert.Equal(new DateTime(2017, 09, 19), returnModel[0].LastUpdated);
            Assert.Equal(1, returnModel[0].ObserverId);
            Assert.Equal(V1IndustryCorporationObserversType.Structure, returnModel[0].ObserverType);
        }

        [Fact]
        public async Task CorporationObserversAsync_successfully_returns_a_listV1IndustryCorporationObservers()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_corporation_mining_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };

            LatestIndustryEndpoints internalLatestIndustry = new LatestIndustryEndpoints(string.Empty, true);

            IList<V1IndustryCorporationObservers> returnModel = await internalLatestIndustry.CorporationObserversAsync(inputToken, 22, 1);

            Assert.Single(returnModel);

            Assert.Equal(new DateTime(2017, 09, 19), returnModel[0].LastUpdated);
            Assert.Equal(1, returnModel[0].ObserverId);
            Assert.Equal(V1IndustryCorporationObserversType.Structure, returnModel[0].ObserverType);
        }

        [Fact]
        public void CorporationObserver_successfully_returns_a_listV1IndustryCorporationObserver()
        {
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_corporation_mining_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };

            LatestIndustryEndpoints internalLatestIndustry = new LatestIndustryEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_corporation_mining_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };

            LatestIndustryEndpoints internalLatestIndustry = new LatestIndustryEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_corporation_jobs_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };

            LatestIndustryEndpoints internalLatestIndustry = new LatestIndustryEndpoints(string.Empty, true);

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
            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            IndustryScopes scopes = IndustryScopes.esi_industry_read_corporation_jobs_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, IndustryScopesFlags = scopes };

            LatestIndustryEndpoints internalLatestIndustry = new LatestIndustryEndpoints(string.Empty, true);

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
            LatestIndustryEndpoints internalLatestIndustry = new LatestIndustryEndpoints(string.Empty, true);

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
            LatestIndustryEndpoints internalLatestIndustry = new LatestIndustryEndpoints(string.Empty, true);

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
            LatestIndustryEndpoints internalLatestIndustry = new LatestIndustryEndpoints(string.Empty, true);

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
            LatestIndustryEndpoints internalLatestIndustry = new LatestIndustryEndpoints(string.Empty, true);

            IList<V1IndustrySystem> returnModel = await internalLatestIndustry.SystemsAsync();

            Assert.Single(returnModel);

            Assert.Single(returnModel[0].CostIndices);
            Assert.Equal(V1IndustrySystemCostIndicesActivity.Invention, returnModel[0].CostIndices[0].Activity);
            Assert.Equal(0.0048f, returnModel[0].CostIndices[0].CostIndex);

            Assert.Equal(30011392, returnModel[0].SolarSystemId);
        }
    }
}
