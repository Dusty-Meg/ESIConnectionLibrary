﻿using System;
using System.Reflection;
using ESIConnectionLibrary.Internal_classes;
using Xunit;

namespace ESIConnectionLibrary.Tests
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
        [InlineData("AllianceV1AlliancesRaw")]
        [InlineData("AllianceV3PublicInfoRaw")]
        [InlineData("AllianceV1CorporationsRaw")]
        [InlineData("AllianceV1IconsRaw")]
        public void AllianceEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("AssetsV5CharactersRaw")]
        [InlineData("AssetsV2CharacterLocationsRaw")]
        [InlineData("AssetsV1CharacterNamesRaw")]
        [InlineData("AssetsV5CorporationsRaw")]
        [InlineData("AssetsV2CorporationLocationsRaw")]
        [InlineData("AssetsV1CorporationNamesRaw")]
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
        [InlineData("EsiV5CharactersPublicInfoRaw")]
        [InlineData("EsiV2CharactersResearchAgentsRaw")]
        [InlineData("EsiV3CharactersBlueprintsRaw")]
        [InlineData("EsiV2CharactersCorporationHistoryRaw")]
        [InlineData("EsiV5CharactersCspaRaw")]
        [InlineData("EsiV2CharactersFatigueRaw")]
        [InlineData("EsiV2CharactersMedalsRaw")]
        [InlineData("EsiV6CharactersNotificationsRaw")]
        [InlineData("EsiV2CharactersNotificationsContactsRaw")]
        [InlineData("EsiV2CharactersPortraitRaw")]
        [InlineData("EsiV3CharacterRolesRaw")]
        [InlineData("EsiV2CharactersStandingsRaw")]
        [InlineData("EsiV2CharacterTitlesRaw")]
        [InlineData("EsiV2CharacterAffiliationsRaw")]
        public void CharacterEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("ClonesV3ClonesRaw")]
        [InlineData("ClonesV3ActiveImplantsRaw")]
        public void CloneEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("ContactsV2AllianceRaw")]
        [InlineData("ContactsV1AllianceLabelsRaw")]
        [InlineData("ContactsV2CharacterDeleteRaw")]
        [InlineData("ContactsV2CharacterRaw")]
        [InlineData("ContactsV2CharacterAddRaw")]
        [InlineData("ContactsV2CharacterEditRaw")]
        [InlineData("ContactsV1CharacterLabelsRaw")]
        [InlineData("ContactsV2CorporationRaw")]
        [InlineData("ContactsV1CorporationLabelsRaw")]
        public void ContactsEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("ContractsV1CharacterRaw")]
        [InlineData("ContractsV1CharacterBidsRaw")]
        [InlineData("ContractsV1CharacterItemsRaw")]
        [InlineData("ContractsV1CorporationRaw")]
        [InlineData("ContractsV1CorporationBidsRaw")]
        [InlineData("ContractsV1CorporationItemsRaw")]
        [InlineData("ContractsV1PublicRaw")]
        [InlineData("ContractsV1PublicBidsRaw")]
        [InlineData("ContractsV1PublicItemsRaw")]
        public void ContractsEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("CorporationV5PublicInfoRaw")]
        [InlineData("CorporationV3AllianceHistoryRaw")]
        [InlineData("CorporationV3BluepintsRaw")]
        [InlineData("CorporationV3ContainersLogsRaw")]
        [InlineData("CorporationV2DivisionsRaw")]
        [InlineData("CorporationV2FacilitiesRaw")]
        [InlineData("CorporationV2IconsRaw")]
        [InlineData("CorporationV2MedalsRaw")]
        [InlineData("CorporationV2MedalsIssuedRaw")]
        [InlineData("CorporationV4MembersRaw")]
        [InlineData("CorporationV2MembersLimitRaw")]
        [InlineData("CorporationV2CorporationMemberTitlesRaw")]
        [InlineData("CorporationV2MemberTrackingRaw")]
        [InlineData("CorporationV2RolesRaw")]
        [InlineData("CorporationV2RolesHistoryRaw")]
        [InlineData("CorporationV1ShareHoldersRaw")]
        [InlineData("CorporationV2StandingsRaw")]
        [InlineData("CorporationV2StarbasesRaw")]
        [InlineData("CorporationV2StarbaseRaw")]
        [InlineData("CorporationV4StructuresRaw")]
        [InlineData("CorporationV2CorporationTitlesRaw")]
        [InlineData("CorporationV2NpcCorpsRaw")]
        public void CorporationsEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("DogmaV1AttributesRaw")]
        [InlineData("DogmaV1AttributeRaw")]
        [InlineData("DogmaV1DynamicItemRaw")]
        [InlineData("DogmaV1EffectsRaw")]
        [InlineData("DogmaV2EffectRaw")]
        public void DogmaEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("FactionWarfareV1CharacterStatsRaw")]
        [InlineData("FactionWarfareV1CorporationStatsRaw")]
        [InlineData("FactionWarfareV1FactionLeaderboardRaw")]
        [InlineData("FactionWarfareV1CharacterLeaderboardRaw")]
        [InlineData("FactionWarfareV1CorporationLeaderboardRaw")]
        [InlineData("FactionWarfareV1FactionStatsRaw")]
        [InlineData("FactionWarfareV2SystemsRaw")]
        [InlineData("FactionWarfareV1WarsRaw")]
        public void FactionWarfareEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("FittingsV2CharacterGetRaw")]
        [InlineData("FittingsV2CharacterUpdateRaw")]
        [InlineData("FittingsV1CharacterDeleteRaw")]
        public void FittingsEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("FleetsV1CharacterFleetRaw")]
        [InlineData("FleetsV1FleetGetRaw")]
        [InlineData("FleetsV1FleetUpdateRaw")]
        [InlineData("FleetsV1MembersGetRaw")]
        [InlineData("FleetsV1MembersInviteRaw")]
        [InlineData("FleetsV1MemberKickRaw")]
        [InlineData("FleetsV1MemberMoveRaw")]
        [InlineData("FleetsV1SquadDeleteRaw")]
        [InlineData("FleetsV1SquadRenameRaw")]
        [InlineData("FleetsV1WingsGetRaw")]
        [InlineData("FleetsV1WingsCreateRaw")]
        [InlineData("FleetsV1WingsDeleteRaw")]
        [InlineData("FleetsV1WingsRenameRaw")]
        [InlineData("FleetsV1SquadCreateRaw")]
        public void FleetEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("IncursionsV1IncursionsRaw")]
        public void IncursionsEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("IndustryV1CharacterJobsRaw")]
        [InlineData("IndustryV1CharacterMiningRaw")]
        [InlineData("IndustryV1CorporationExtractionsRaw")]
        [InlineData("IndustryV1CorporationObserversRaw")]
        [InlineData("IndustryV1CorporationObserverRaw")]
        [InlineData("IndustryV1CorporationJobsRaw")]
        [InlineData("IndustryV1FacilitiesRaw")]
        [InlineData("IndustryV1SystemsRaw")]
        public void IndustryEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("InsuranceV1InsuranceRaw")]
        public void InsuranceEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("KillmailsV1CharacterRaw")]
        [InlineData("KillmailsV1CorporationRaw")]
        [InlineData("KillmailsV1KillmailRaw")]
        public void KillmailsEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("LocationV1LocationRaw")]
        [InlineData("LocationV2LocationOnlineRaw")]
        [InlineData("LocationV1LocationShipRaw")]
        public void LocationEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("LoyaltyV1PointsRaw")]
        [InlineData("LoyaltyV1OffersRaw")]
        public void LoyaltyEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("MailV1CharacterRaw")]
        [InlineData("MailV1SendRaw")]
        [InlineData("MailV1DeleteRaw")]
        [InlineData("MailV1MailRaw")]
        [InlineData("MailV1MetadataRaw")]
        [InlineData("MailV3LabelsAndUnreadCountRaw")]
        [InlineData("MailV2CreateLabelRaw")]
        [InlineData("MailV1DeleteLabelRaw")]
        [InlineData("MailV1MailingListRaw")]
        public void MailEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("MarketV2CharacterOrdersRaw")]
        [InlineData("MarketV1CharacterOrdersHistoricRaw")]
        [InlineData("MarketV3CorporationOrdersRaw")]
        [InlineData("MarketV2CorporationOrdersHistoricRaw")]
        [InlineData("MarketV1HistoryRaw")]
        [InlineData("MarketV1OrdersRaw")]
        [InlineData("MarketV1TypesRaw")]
        [InlineData("MarketV1GroupsRaw")]
        [InlineData("MarketV1GroupRaw")]
        [InlineData("MarketV1PricesRaw")]
        [InlineData("MarketV1StructureRaw")]
        public void MarketEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("OpportunitiesV1CharacterRaw")]
        [InlineData("OpportunitiesV1GroupsRaw")]
        [InlineData("OpportunitiesV1GroupRaw")]
        [InlineData("OpportunitiesV1TasksRaw")]
        [InlineData("OpportunitiesV1TaskRaw")]
        public void OpportunitiesEndpoints(string endpoint)
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
        [InlineData("SearchV3AuthSearchRaw")]
        [InlineData("SearchV2SearchRaw")]
        public void RoutesEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("RoutesV1RouteRaw")]
        public void SearchEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec.SwaggerSpec);
        }

        [Theory]
        [InlineData("SkillsV4SkillsRaw")]
        [InlineData("SkillsV1AttributesRaw")]
        [InlineData("SkillsV2SkillQueueRaw")]
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
        [InlineData("UniverseV3NamesRaw")]
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
        [InlineData("WalletV6CharactersWalletJournalRaw")]
        [InlineData("WalletV4CharactersWalletTransactionRaw")]
        [InlineData("WalletV1CorporationWalletsRaw")]
        [InlineData("WalletV4CorporationDivisionsJournalRaw")]
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
