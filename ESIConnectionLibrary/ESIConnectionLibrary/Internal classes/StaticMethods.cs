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
}
