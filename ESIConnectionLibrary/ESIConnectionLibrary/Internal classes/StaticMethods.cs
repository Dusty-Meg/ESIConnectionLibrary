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

            if (token.ScopesFlags == Scopes.None || !token.ScopesFlags.Has(scope))
            {
                throw new ESIException($"This token does not have {scope}");
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

        private static string SkillsSkillsRaw => "/v3/characters/{character_id}/skills/";
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

        #region Fleets

        private static string KillmailsGetSingleKillmailRaw => "/v1/killmails/{killmail_id}/{killmail_hash}/";

        public static string KillmailsGetSingleKillmail(int killmailId, string killmailHash)
        {
            return UrlBuilder(KillmailsGetSingleKillmailRaw, "{killmail_id}", killmailId.ToString(), "{killmail_hash}", killmailHash);
        }

        #endregion
    }

    public static class EnumerationExtensions
    {

        //checks if the value contains the provided type
        public static bool Has<T>(this System.Enum type, T value)
        {
            try
            {
                return (((long)(object)type & (long)(object)value) == (long)(object)value);
            }
            catch
            {
                return false;
            }
        }

        //checks if the value is only the provided type
        public static bool Is<T>(this System.Enum type, T value)
        {
            try
            {
                return (long)(object)type == (long)(object)value;
            }
            catch
            {
                return false;
            }
        }

        //appends a value
        public static T Add<T>(this System.Enum type, T value)
        {
            try
            {
                return (T)(object)(((long)(object)type | (long)(object)value));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    string.Format(
                        "Could not append value from enumerated type '{0}'.",
                        typeof(T).Name
                    ), ex);
            }
        }

        //completely removes the value
        public static T Remove<T>(this System.Enum type, T value)
        {
            try
            {
                return (T)(object)(((long)(object)type & ~(long)(object)value));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    string.Format(
                        "Could not remove value from enumerated type '{0}'.",
                        typeof(T).Name
                    ), ex);
            }
        }

    }
}
