using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ESIConnectionLibrary.Exceptions;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class StaticMethods
    {
        public static void CheckToken(SsoToken token, AllianceScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.AllianceScopesFlags == AllianceScopes.None || !token.AllianceScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.AllianceScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, AssetScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.AssetScopesFlags == AssetScopes.None || !token.AssetScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.AssetScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, BookmarkScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.BookmarkScopesFlags == BookmarkScopes.None || !token.BookmarkScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.BookmarkScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, CalendarScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.CalendarScopesFlags == CalendarScopes.None || !token.CalendarScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.CalendarScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, CharacterScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.CharacterScopesFlags == CharacterScopes.None || !token.CharacterScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.CharacterScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, CloneScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.CloneScopesFlags == CloneScopes.None || !token.CloneScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.CloneScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, ContractScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.ContractScopesFlags == ContractScopes.None || !token.ContractScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.ContractScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, CorporationScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.CorporationScopesFlags == CorporationScopes.None || !token.CorporationScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.CorporationScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, FittingScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.FittingScopesFlags == FittingScopes.None || !token.FittingScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.FittingScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, FleetScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.FleetScopesFlags == FleetScopes.None || !token.FleetScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.FleetScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, IndustryScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.IndustryScopesFlags == IndustryScopes.None || !token.IndustryScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.IndustryScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, KillmailScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.KillmailScopesFlags == KillmailScopes.None || !token.KillmailScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.KillmailScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, LocationScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.LocationScopesFlags == LocationScopes.None || !token.LocationScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.LocationScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, MailScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.MailScopesFlags == MailScopes.None || !token.MailScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.MailScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, MarketScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.MarketScopesFlags == MarketScopes.None || !token.MarketScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.MarketScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, PlanetScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.PlanetScopesFlags == PlanetScopes.None || !token.PlanetScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.PlanetScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, SearchScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.SearchScopesFlags == SearchScopes.None || !token.SearchScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.SearchScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, SkillScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.SkillScopesFlags == SkillScopes.None || !token.SkillScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.SkillScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, UiScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.UiScopesFlags == UiScopes.None || !token.UiScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.UiScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, UniverseScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.UniverseScopesFlags == UniverseScopes.None || !token.UniverseScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.UniverseScopesFlags}");
            }
        }

        public static void CheckToken(SsoToken token, WalletScopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.WalletScopesFlags == WalletScopes.None || !token.WalletScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} it has: {token.WalletScopesFlags}");
            }
        }

        public static WebHeaderCollection CreateHeaders(SsoToken token)
        {
            return new WebHeaderCollection
            {
                [HttpRequestHeader.Authorization] = $"Bearer {token.AccessToken}",
                [HttpRequestHeader.Accept] = "application/json",
                [HttpRequestHeader.ContentType] = "application/json"
            };
        }

        public static WebHeaderCollection CreateHeaders()
        {
            return new WebHeaderCollection
            {
                [HttpRequestHeader.Accept] = "application/json",
                [HttpRequestHeader.ContentType] = "application/json"
            };
        }
    }

    internal class StaticConnectionStrings
    {
        private static string UrlBuilder(string rawUrl, params string[] urls)
        {
            int count = urls.Length;
            string urlBuilder = rawUrl;

            for (int i = 0; i < count; i += 2)
            {
                urlBuilder = urlBuilder.Replace(urls[i], urls[i + 1]);
            }

            return EsiBaseUrl + urlBuilder;
        }

        private static string UrlBuilder(string rawUrl, string prefix, IList<string> variables)
        {
            string urlBuilder = rawUrl + "?" + prefix + "=";

            for (int i = 0; i < variables.Count; i++)
            {
                if (i != 0)
                {
                    urlBuilder = urlBuilder + ",";
                }

                urlBuilder = urlBuilder + variables[i];
            }

            return urlBuilder;
        }

        private static string EsiBaseUrl => "https://esi.tech.ccp.is";

        #region Authentication

        private static string AuthenticationVerifyRaw => "/verify/";

        public static string AuthenticationVerify()
        {
            return UrlBuilder(AuthenticationVerifyRaw);
        }

        #endregion

        #region Alliances

        private static string AllianceV1GetActiveAllianceRaw => "/v1/alliances/";
        private static string AllianceV3GetAlliancePublicInfoRaw => "/v3/alliances/{alliance_id}/";
        private static string AllianceV1GetAllianceCorporationsRaw => "/v1/alliances/{alliance_id}/corporations/";
        private static string AllianceV1GetAllianceIconsRaw => "/v1/alliances/{alliance_id}/icons/";
        private static string AllianceV2IdsToNamesRaw => "/v2/alliances/names/";

        public static string AlianceV1GetActiveAlliance()
        {
            return UrlBuilder(AllianceV1GetActiveAllianceRaw);
        }

        public static string AllianceV3GetAlliancePublicInfo(int allianceId)
        {
            return UrlBuilder(AllianceV3GetAlliancePublicInfoRaw, "{alliance_id}", allianceId.ToString());
        }

        public static string AllianceV1GetAllianceCorporations(int allianceId)
        {
            return UrlBuilder(AllianceV1GetAllianceCorporationsRaw, "{alliance_id}", allianceId.ToString());
        }

        public static string AllianceV1GetAllianceIcons(int allianceId)
        {
            return UrlBuilder(AllianceV1GetAllianceIconsRaw, "{alliance_id}", allianceId.ToString());
        }

        public static string AllianceV2IdsToNames(IList<int> allianceIds)
        {
            return UrlBuilder(AllianceV2IdsToNamesRaw, "alliance_ids", allianceIds.Select(x => x.ToString()).ToList());
        }

        #endregion

        #region Assets

        private static string AssetsV3GetCharactersAssetsRaw => "/v3/characters/{character_id}/assets/";
        private static string AssetsV2GetCharactersAssetsLocationsRaw => "/v2/characters/{character_id}/assets/locations/";
        private static string AssetsV1GetCharactersAssetsNamesRaw => "/v1/characters/{character_id}/assets/names/";
        private static string AssetsV2GetCorporationsAssetsRaw => "/v2/corporations/{corporation_id}/assets/";
        private static string AssetsV2GetCorporationsAssetsLocationsRaw => "/v2/corporations/{corporation_id}/assets/locations/";
        private static string AssetsV1GetCorporationsAssetsNamesRaw => "/v1/corporations/{corporation_id}/assets/names/";

        public static string AssetsV3GetCharactersAssets(int characterId, int page)
        {
            return UrlBuilder(AssetsV3GetCharactersAssetsRaw, "{character_id}", characterId.ToString()) + $"?page={page}";
        }

        public static string AssetsV2GetCharactersAssetsLocations(int characterId)
        {
            return UrlBuilder(AssetsV2GetCharactersAssetsLocationsRaw, "{character_id}", characterId.ToString());
        }

        public static string AssetsV1GetCharactersAssetsNames(int characterId)
        {
            return UrlBuilder(AssetsV1GetCharactersAssetsNamesRaw, "{character_id}", characterId.ToString());
        }

        public static string AssetsV2GetCorporationsAssets(int corporationId, int page)
        {
            return UrlBuilder(AssetsV2GetCorporationsAssetsRaw, "{corporation_id}", corporationId.ToString()) + $"?page={page}";
        }

        public static string AssetsV2GetCorporationsAssetsLocations(int corporationId)
        {
            return UrlBuilder(AssetsV2GetCorporationsAssetsLocationsRaw, "{corporation_id}", corporationId.ToString());
        }

        public static string AssetsV1GetCorporationsAssetsNames(int corporationId)
        {
            return UrlBuilder(AssetsV1GetCorporationsAssetsNamesRaw, "{corporation_id}", corporationId.ToString());
        }

        #endregion

        #region Character

        private static string EsiV4CharactersPublicInfoRaw => "/v4/characters/{character_id}/";
        private static string EsiV1CharactersResearchAgentsRaw => "/v1/characters/{character_id}/agents_research/";
        private static string EsiV2CharactersBlueprintsRaw => "/v2/characters/{character_id}/blueprints/";
        private static string EsiV1CharactersChatChannelsRaw => "/v1/characters/{character_id}/chat_channels/";
        private static string EsiV1CharactersCorporationHistoryRaw => "/v1/characters/{character_id}/corporationhistory/";
        private static string EsiV4CharactersCspaRaw => "/v4/characters/{character_id}/cspa/";
        private static string EsiV1CharactersFatigueRaw => "/v1/characters/{character_id}/fatigue/";
        private static string EsiV1CharactersMedalsRaw => "/v1/characters/{character_id}/medals/";
        private static string EsiV2CharactersNotificationsRaw => "/v2/characters/{character_id}/notifications/";
        private static string EsiV1CharactersNotificationsContactsRaw => "/v1/characters/{character_id}/notifications/contacts/";
        private static string EsiV2CharactersPortraitRaw => "/v2/characters/{character_id}/portrait/";
        private static string EsiV2CharacterRolesRaw => "/v2/characters/{character_id}/roles/";
        private static string EsiV2CharactersStandingsRaw => "/v1/characters/{character_id}/standings/";
        private static string EsiV2CharactersStatsRaw => "/v2/characters/{character_id}/stats/";
        private static string EsiV1CharacterTitlesRaw => "/v1/characters/{character_id}/titles/";
        private static string EsiV1CharacterAffiliationsRaw => "/v1/characters/affiliation/";
        private static string EsiV1CharactersNamesRaw => "/v1/characters/names/";

        public static string EsiV4CharactersPublicInfo(int characterId)
        {
            return UrlBuilder(EsiV4CharactersPublicInfoRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV1CharactersResearchAgents(int characterId)
        {
            return UrlBuilder(EsiV1CharactersResearchAgentsRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV2CharactersBlueprints(int characterId)
        {
            return UrlBuilder(EsiV2CharactersBlueprintsRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV1CharactersChatChannels(int characterId)
        {
            return UrlBuilder(EsiV1CharactersChatChannelsRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV1CharactersCorporationHistory(int characterId)
        {
            return UrlBuilder(EsiV1CharactersCorporationHistoryRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV4CharactersCspa(int characterId)
        {
            return UrlBuilder(EsiV4CharactersCspaRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV1CharactersFatigue(int characterId)
        {
            return UrlBuilder(EsiV1CharactersFatigueRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV1CharactersMedals(int characterId)
        {
            return UrlBuilder(EsiV1CharactersMedalsRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV2CharactersNotifications(int characterId)
        {
            return UrlBuilder(EsiV2CharactersNotificationsRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV1CharactersNotificationsContacts(int characterId)
        {
            return UrlBuilder(EsiV1CharactersNotificationsContactsRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV2CharactersPortrait(int characterId)
        {
            return UrlBuilder(EsiV2CharactersPortraitRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV2CharacterRoles(int characterId)
        {
            return UrlBuilder(EsiV2CharacterRolesRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV2CharactersStandings(int characterId)
        {
            return UrlBuilder(EsiV2CharactersStandingsRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV2CharactersStats(int characterId)
        {
            return UrlBuilder(EsiV2CharactersStatsRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV1CharacterTitles(int characterId)
        {
            return UrlBuilder(EsiV1CharacterTitlesRaw, "{character_id}", characterId.ToString());
        }

        public static string EsiV1CharacterAffiliations()
        {
            return UrlBuilder(EsiV1CharacterAffiliationsRaw);
        }

        public static string EsiV1CharactersNames(IList<int> characterIds)
        {
            return UrlBuilder(EsiV1CharactersNamesRaw, "character_ids", characterIds.Select(x => x.ToString()).ToList());
        }

        #endregion

        #region Skills

        private static string SkillsSkillsRaw => "/v4/characters/{character_id}/skills/";
        private static string SkillsAttributesRaw => "/v1/characters/{character_id}/attributes/";
        private static string SkillsSkillQueueRaw => "/v2/characters/{character_id}/skillqueue/";

        public static string SkillsSkills(long characterId)
        {
            return UrlBuilder(SkillsSkillsRaw, "{character_id}", characterId.ToString());
        }

        public static string SkillsAttributes(long characterId)
        {
            return UrlBuilder(SkillsAttributesRaw, "{character_id}", characterId.ToString());
        }

        public static string SkillsSkillQueue(long characterId)
        {
            return UrlBuilder(SkillsSkillQueueRaw, "{character_id}", characterId.ToString());
        }

        #endregion

        #region Industry

        private static string IndustryCharacterJobsRaw => "/v1/characters/{character_id}/industry/jobs/";

        public static string IndustryCharacterJobs(long characterId, bool includeCompletedJobs)
        {
            return $"{UrlBuilder(IndustryCharacterJobsRaw, "{character_id}", characterId.ToString())}?include_completed={includeCompletedJobs}";
        }

        #endregion

        #region Fleets

        private static string FleetsGetFleetRaw => "/v1/fleets/{fleet_id}/";

        public static string FleetsGetFleet(long fleetId)
        {
            return UrlBuilder(FleetsGetFleetRaw, "{fleet_id}", fleetId.ToString());
        }

        #endregion

        #region Killmails

        private static string KillmailsGetSingleKillmailRaw => "/v1/killmails/{killmail_id}/{killmail_hash}/";

        public static string KillmailsGetSingleKillmail(int killmailId, string killmailHash)
        {
            return UrlBuilder(KillmailsGetSingleKillmailRaw, "{killmail_id}", killmailId.ToString(), "{killmail_hash}", killmailHash);
        }

        #endregion

        #region Corporations

        private static string CorporationsGetRolesRaw => "/v1/corporations/{corporation_id}/roles/";

        public static string CorporationsGetRoles(long corporationId)
        {
            return UrlBuilder(CorporationsGetRolesRaw, "{corporation_id}", corporationId.ToString());
        }

        #endregion

        #region Insurance

        private static string InsuranceGetPricesRaw => "/v1/insurance/prices/";

        public static string InsuranceGetPrices()
        {
            return UrlBuilder(InsuranceGetPricesRaw);
        }

        #endregion

        #region Universe

        private static string UniverseNamesRaw => "/v2/universe/names/";
        private static string UniverseGetTypeRaw => "/v3/universe/types/{type_id}/";

        public static string UniverseNames()
        {
            return UrlBuilder(UniverseNamesRaw);
        }

        public static string UniverseGetType(long typeId)
        {
            return UrlBuilder(UniverseGetTypeRaw, "{type_id}", typeId.ToString());
        }

        #endregion
    }
}
