using System;
using System.Reflection;
using ESIConnectionLibrary.Internal_classes;
using Xunit;
using WebClient = System.Net.WebClient;

namespace ESIConnectionLibraryTests
{
    public class EndpointTesting
    {
        private string _swaggerSpec;

        private string SwaggerSpec
        {
            get
            {
                if (_swaggerSpec == null)
                {
                    WebClient client = new WebClient
                    {
                        Headers = { ["UserAgent"] = "Dusty Meg Tests" }
                    };

                    _swaggerSpec = client.DownloadString("https://esi.tech.ccp.is/latest/swagger.json?datasource=tranquility");
                }

                return _swaggerSpec;
            }
        }

        private string GetPrivateString(string privateMethodName)
        {
            Type type = typeof(StaticConnectionStrings);

            PropertyInfo info = type.GetProperty(privateMethodName, BindingFlags.NonPublic | BindingFlags.Static);

            return info.GetValue(null) as string;
        }

        [Theory]
        [InlineData("AllianceV1GetActiveAllianceRaw")]
        [InlineData("AllianceV3GetAlliancePublicInfoRaw")]
        [InlineData("AllianceV1GetAllianceCorporationsRaw")]
        [InlineData("AllianceV1GetAllianceIconsRaw")]
        [InlineData("AllianceV2IdsToNamesRaw")]
        public void AllianceEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec);
        }

        [Theory]
        [InlineData("AssetsV3GetCharactersAssetsRaw")]
        [InlineData("AssetsV2GetCharactersAssetsLocationsRaw")]
        [InlineData("AssetsV1GetCharactersAssetsNamesRaw")]
        [InlineData("AssetsV2GetCorporationsAssetsRaw")]
        [InlineData("AssetsV2GetCorporationsAssetsLocationsRaw")]
        [InlineData("AssetsV1GetCorporationsAssetsNamesRaw")]
        public void AssetsEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec);
        }

        [Theory]
        [InlineData("EsiV4CharactersPublicInfoRaw")]
        [InlineData("EsiV1CharactersResearchAgentsRaw")]
        [InlineData("EsiV2CharactersBlueprintsRaw")]
        [InlineData("EsiV1CharactersChatChannelsRaw")]
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
        [InlineData("EsiV1CharactersNamesRaw")]
        public void CharacterEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec);
        }

        [Theory]
        [InlineData("ContactsV1GetCharactersContactsRaw")]
        public void ContactsEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec);
        }

        [Theory]
        [InlineData("MailV1MailGetCharactersMailRaw")]
        [InlineData("MailV1MailGetMailRaw")]
        public void MailEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec);
        }

        [Theory]
        [InlineData("MarketV1GetMarketGroupInformationRaw")]
        public void MarketEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec);
        }

        [Theory]
        [InlineData("SkillsSkillsRaw")]
        [InlineData("SkillsAttributesRaw")]
        [InlineData("SkillsSkillQueueRaw")]
        public void SkillsEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec);
        }

        [Theory]
        [InlineData("IndustryCharacterJobsRaw")]
        public void IndustryEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec);
        }

        [Theory]
        [InlineData("FleetsGetFleetRaw")]
        public void FleetEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec);
        }

        [Theory]
        [InlineData("KillmailsGetSingleKillmailRaw")]
        public void KillmailsEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec);
        }

        [Theory]
        [InlineData("CorporationsGetRolesRaw")]
        public void CorporationsEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec);
        }

        [Theory]
        [InlineData("InsuranceGetPricesRaw")]
        public void InsuranceEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec);
        }

        [Theory]
        [InlineData("UniverseNamesRaw")]
        [InlineData("UniverseGetTypeRaw")]
        public void UniverseEndpoints(string endpoint)
        {
            Assert.Contains(GetPrivateString(endpoint), SwaggerSpec);
        }
    }
}
