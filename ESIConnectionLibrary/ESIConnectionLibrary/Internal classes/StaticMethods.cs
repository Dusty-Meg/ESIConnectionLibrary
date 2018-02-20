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
        public static void CheckToken(SsoToken token, Scopes scope)
        {
            if (token == null)
            {
                throw new ESIException("Token can not be null");
            }

            if (token.ScopesFlags == Scopes.None || !token.ScopesFlags.HasFlag(scope))
            {
                throw new ESIException($"This token does not have {scope} {token.ScopesFlags}");
            }
        }

        public static WebHeaderCollection CreateHeaders(SsoToken token)
        {
            return new WebHeaderCollection
            {
                [HttpRequestHeader.Authorization] = $"Bearer {token.AccessToken}",
                [HttpRequestHeader.Accept] = "application/json"
            };
        }

        public static WebHeaderCollection CreateHeaders()
        {
            return new WebHeaderCollection
            {
                [HttpRequestHeader.Accept] = "application/json"
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
