using System;
using System.Reflection;
using ESIConnectionLibrary.Internal_classes;
using Xunit;

namespace ESIConnectionLibraryTests
{
    [Collection("Swagger Tests")]
    public class EndpointTesting : IClassFixture<SwaggerSpecFixture>
    {
        private SwaggerSpecFixture SwaggerSpec;

        public EndpointTesting(SwaggerSpecFixture swaggerSpec)
        {
            SwaggerSpec = swaggerSpec;
        }

        private static string GetPrivateString(string privateMethodName)
        {
            Type type = typeof(StaticConnectionStrings);

            PropertyInfo info = type.GetProperty(privateMethodName, BindingFlags.NonPublic | BindingFlags.Static);

            return $"`{info.GetValue(null) as string}`";
        }

        [Theory]
        [InlineData("AllianceV1GetActiveAllianceRaw")]
        [InlineData("AllianceV3GetAlliancePublicInfoRaw")]
        [InlineData("AllianceV1GetAllianceCorporationsRaw")]
        [InlineData("AllianceV1GetAllianceIconsRaw")]
        public void AllianceEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("AssetsV3GetCharactersAssetsRaw")]
        [InlineData("AssetsV2GetCharactersAssetsLocationsRaw")]
        [InlineData("AssetsV1GetCharactersAssetsNamesRaw")]
        [InlineData("AssetsV3GetCorporationsAssetsRaw")]
        [InlineData("AssetsV2GetCorporationsAssetsLocationsRaw")]
        [InlineData("AssetsV1GetCorporationsAssetsNamesRaw")]
        public void AssetsEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("BookmarksV2CharactersRaw")]
        [InlineData("BookmarksV2CharactersFoldersRaw")]
        [InlineData("BookmarksV1CorporationsRaw")]
        [InlineData("BookmarksV1CorporationsFoldersRaw")]
        public void BookmarksEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("CalendarV1SummariesRaw")]
        [InlineData("CalendarV3EventRaw")]
        [InlineData("CalendarV3EventResponseRaw")]
        [InlineData("CalendarV1EventAttendeesRaw")]
        public void CalendarEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("EsiV4CharactersPublicInfoRaw")]
        [InlineData("EsiV1CharactersResearchAgentsRaw")]
        [InlineData("EsiV2CharactersBlueprintsRaw")]
        [InlineData("EsiV1CharactersCorporationHistoryRaw")]
        [InlineData("EsiV4CharactersCspaRaw")]
        [InlineData("EsiV1CharactersFatigueRaw")]
        [InlineData("EsiV1CharactersMedalsRaw")]
        [InlineData("EsiV2CharactersNotificationsRaw")]
        [InlineData("EsiV1CharactersNotificationsContactsRaw")]
        [InlineData("EsiV2CharactersPortraitRaw")]
        [InlineData("EsiV2CharacterRolesRaw")]
        [InlineData("EsiV2CharactersStandingsRaw")]
        [InlineData("EsiV2CharactersStatsRaw")]
        [InlineData("EsiV1CharacterTitlesRaw")]
        [InlineData("EsiV1CharacterAffiliationsRaw")]
        public void CharacterEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("ClonesV3GetCharactersClonesRaw")]
        [InlineData("ClonesV3GetCharactersActiveImplantsRaw")]
        public void CloneEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("ContactsV2GetCharactersContactsRaw")]
        public void ContactsEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("ContractsV1GetCharactersContractsRaw")]
        public void ContractsEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("CorporationV4PublicInfoRaw")]
        [InlineData("CorporationV2AllianceHistoryRaw")]
        [InlineData("CorporationV2BluepintsRaw")]
        [InlineData("CorporationV2ContainersLogsRaw")]
        [InlineData("CorporationV1DivisionsRaw")]
        [InlineData("CorporationV1FacilitiesRaw")]
        [InlineData("CorporationV1IconsRaw")]
        [InlineData("CorporationV1MedalsRaw")]
        [InlineData("CorporationV1MedalsIssuedRaw")]
        [InlineData("CorporationV3MembersRaw")]
        [InlineData("CorporationV1MembersLimitRaw")]
        [InlineData("CorporationV1CorporationMemberTitlesRaw")]
        [InlineData("CorporationV1MemberTrackingRaw")]
        [InlineData("CorporationV1RolesRaw")]
        [InlineData("CorporationV1RolesHistoryRaw")]
        [InlineData("CorporationV1ShareHoldersRaw")]
        [InlineData("CorporationV1StandingsRaw")]
        [InlineData("CorporationV1StarbasesRaw")]
        [InlineData("CorporationV1StarbaseRaw")]
        [InlineData("CorporationV2StructuresRaw")]
        [InlineData("CorporationV1CorporationTitlesRaw")]
        [InlineData("CorporationV1NpcCorpsRaw")]
        public void CorporationsEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("FleetsGetFleetRaw")]
        public void FleetEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("IndustryCharacterJobsRaw")]
        public void IndustryEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("InsuranceGetPricesRaw")]
        public void InsuranceEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("KillmailsGetSingleKillmailRaw")]
        public void KillmailsEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("LocationV1LocationCharacterLocationRaw")]
        [InlineData("LocationV2LocationCharacterOnlineRaw")]
        [InlineData("LocationV1LocationCharacterShipRaw")]
        public void LocationEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("MailV1MailGetCharactersMailRaw")]
        [InlineData("MailV1MailGetMailRaw")]
        public void MailEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("MarketV2MarketCharactersOrdersRaw")]
        [InlineData("MarketV1MarketCharactersHistoricOrdersRaw")]
        [InlineData("MarketV1GetMarketGroupInformationRaw")]
        public void MarketEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("PlanetaryInteractionV1CharactersPlanetsRaw")]
        [InlineData("PlanetaryInteractionV3CharactersPlanetRaw")]
        [InlineData("PlanetaryInteractionV1CorporationsCustomsOfficesRaw")]
        [InlineData("PlanetaryInteractionV1SchematicsRaw")]
        public void PlanetaryInteractionEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("SkillsSkillsRaw")]
        [InlineData("SkillsAttributesRaw")]
        [InlineData("SkillsSkillQueueRaw")]
        public void SkillsEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("SovereigntyV1CampaignsRaw")]
        [InlineData("SovereigntyV1MapRaw")]
        [InlineData("SovereigntyV1StructuresRaw")]
        public void SovereigntyEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("StatusV1StatusRaw")]
        public void StatusEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("UniverseV1AncestriesRaw")]
        [InlineData("UniverseV1AsteroidBeltRaw")]
        [InlineData("UniverseV1BloodlinesRaw")]
        [InlineData("UniverseV1CategoriesRaw")]
        [InlineData("UniverseV1CategoryRaw")]
        [InlineData("UniverseV1ConstellationsRaw")]
        [InlineData("UniverseV1ConstellationRaw")]
        [InlineData("UniverseV2FactionsRaw")]
        [InlineData("UniverseV1GraphicsRaw")]
        [InlineData("UniverseV1GraphicRaw")]
        [InlineData("UniverseV1GroupsRaw")]
        [InlineData("UniverseV1GroupRaw")]
        [InlineData("UniverseV1IdsRaw")]
        [InlineData("UniverseV1MoonRaw")]
        [InlineData("UniverseV2NamesRaw")]
        [InlineData("UniverseV1PlanetRaw")]
        [InlineData("UniverseV1RacesRaw")]
        [InlineData("UniverseV1RegionsRaw")]
        [InlineData("UniverseV1RegionRaw")]
        [InlineData("UniverseV1StargateRaw")]
        [InlineData("UniverseV1StarRaw")]
        [InlineData("UniverseV2StationRaw")]
        [InlineData("UniverseV1StructuresRaw")]
        [InlineData("UniverseV2StructureRaw")]
        [InlineData("UniverseV1SystemJumpsRaw")]
        [InlineData("UniverseV2SystemKillsRaw")]
        [InlineData("UniverseV1SystemsRaw")]
        [InlineData("UniverseV4SystemRaw")]
        [InlineData("UniverseV1TypesRaw")]
        [InlineData("UniverseV3TypeRaw")]
        public void UniverseEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("UiV2AddWaypointRaw")]
        [InlineData("UiV1OpenContractWindowRaw")]
        [InlineData("UiV1OpenInformationWindowRaw")]
        [InlineData("UiV1OpenMarketDataWindowRaw")]
        [InlineData("UiV1OpenNewMailWindowRaw")]
        public void UiEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("WalletV1CharactersWalletRaw")]
        [InlineData("WalletV4CharactersWalletJournalRaw")]
        [InlineData("WalletV4CharactersWalletTransactionRaw")]
        [InlineData("WalletV1CorporationWalletsRaw")]
        [InlineData("WalletV3CorporationDivisionsJournalRaw")]
        [InlineData("WalletV1CorporationDivisionsTransactionsRaw")]
        public void WalletEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("WarsV1WarsRaw")]
        [InlineData("WarsV1WarRaw")]
        [InlineData("WarsV1WarKillmailsRaw")]
        public void WarsEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }
    }
}
