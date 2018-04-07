﻿using System;
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
            Assert.True(SwaggerSpec.Contains(GetPrivateString(endpoint)));
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
            Assert.True(SwaggerSpec.Contains(GetPrivateString(endpoint)));
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
            Assert.True(SwaggerSpec.Contains(GetPrivateString(endpoint)));
        }

        [Fact]
        public void SkillsSkillsEndpoint()
        {
            Assert.True(SwaggerSpec.Contains(GetPrivateString("SkillsSkillsRaw")));
        }

        [Fact]
        public void SkillsAttributesEndpoint()
        {
            Assert.True(SwaggerSpec.Contains(GetPrivateString("SkillsAttributesRaw")));
        }

        [Fact]
        public void SkillsSkillQueueEndpoint()
        {
            Assert.True(SwaggerSpec.Contains(GetPrivateString("SkillsSkillQueueRaw")));
        }

        [Fact]
        public void IndustryCharacterJobs()
        {
            Assert.True(SwaggerSpec.Contains(GetPrivateString("IndustryCharacterJobsRaw")));
        }

        [Fact]
        public void FleetsGetFleet()
        {
            Assert.True(SwaggerSpec.Contains(GetPrivateString("FleetsGetFleetRaw")));
        }

        [Theory]
        [InlineData("KillmailsGetSingleKillmailRaw")]
        public void KillmailsEndpoints(string endpoint)
        {
            Assert.True(SwaggerSpec.Contains(GetPrivateString(endpoint)));
        }

        [Theory]
        [InlineData("CorporationsGetRolesRaw")]
        public void CorporationsEndpoints(string endpoint)
        {
            Assert.True(SwaggerSpec.Contains(GetPrivateString(endpoint)));
        }

        [Theory]
        [InlineData("InsuranceGetPricesRaw")]
        public void InsuranceEndpoints(string endpoint)
        {
            Assert.True(SwaggerSpec.Contains(GetPrivateString(endpoint)));
        }

        [Theory]
        [InlineData("UniverseNamesRaw")]
        [InlineData("UniverseGetTypeRaw")]
        public void UniverseEndpoints(string endpoint)
        {
            Assert.True(SwaggerSpec.Contains(GetPrivateString(endpoint)));
        }
    }
}
