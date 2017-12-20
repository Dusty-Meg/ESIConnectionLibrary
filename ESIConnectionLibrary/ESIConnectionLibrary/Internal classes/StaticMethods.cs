using System;
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

        private static string EsiBaseUrl => "https://esi.tech.ccp.is";

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
