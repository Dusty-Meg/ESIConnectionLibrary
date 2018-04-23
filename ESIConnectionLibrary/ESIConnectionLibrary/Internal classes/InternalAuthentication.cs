using System;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.Exceptions;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalAuthentication : IInternalAuthentication
    {
        private readonly IWebClient _webClient;

        public InternalAuthentication(IWebClient webClient, string userAgent)
        {
            _webClient = webClient ?? new WebClient(userAgent);
        }

        public SsoToken MakeToken(string code, string evessokey, Guid userId)
        {
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(evessokey))
            {
                throw new ESIException("Code or EVESSOKey is null or empty");
            }

            string ssoData = "grant_type=authorization_code&code=" + code;

            OauthToken oauthToken = GetOauthToken(evessokey, ssoData);
            OauthVerify oauthVerify = GetOauthVerify(oauthToken.AccessToken);

            SsoToken token = new SsoToken
            {
                UserId = userId,
                AccessToken = oauthToken.AccessToken,
                ExpiresIn = DateTime.UtcNow.AddSeconds(oauthToken.ExpiresIn),
                RefreshToken = oauthToken.RefreshToken,
                CharacterId = oauthVerify.CharacterId,
                CharacterName = oauthVerify.CharacterName,
                TokenType = (TokenType)Enum.Parse(typeof(TokenType), oauthVerify.TokenType, true)
            };

            return CreateScopesFlags(token, oauthVerify.Scopes);
        }

        public async Task<SsoToken> MakeTokenAsync(string code, string evessokey, Guid userId)
        {
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(evessokey))
            {
                throw new ESIException("Code or EVESSOKey is null or empty");
            }

            string ssoData = "grant_type=authorization_code&code=" + code;

            OauthToken oauthToken = await GetOauthTokenAsync(evessokey, ssoData);
            OauthVerify oauthVerify = await GetOauthVerifyAsync(oauthToken.AccessToken);

            SsoToken token = new SsoToken
            {
                UserId = userId,
                AccessToken = oauthToken.AccessToken,
                ExpiresIn = DateTime.UtcNow.AddSeconds(oauthToken.ExpiresIn),
                RefreshToken = oauthToken.RefreshToken,
                CharacterId = oauthVerify.CharacterId,
                CharacterName = oauthVerify.CharacterName,
                TokenType = (TokenType)Enum.Parse(typeof(TokenType), oauthVerify.TokenType, true)
            };

            return CreateScopesFlags(token, oauthVerify.Scopes);
        }

        public SsoToken RefreshToken(SsoToken token, string evessokey)
        {
            if (token == null || string.IsNullOrEmpty(evessokey))
            {
                throw new ESIException("Token or EVESSOKey is null or empty");
            }

            string ssoData = "grant_type=refresh_token&refresh_token=" + token.RefreshToken;

            OauthToken oauthToken = GetOauthToken(evessokey, ssoData);

            token.AccessToken = oauthToken.AccessToken;
            token.ExpiresIn = DateTime.UtcNow.AddSeconds(oauthToken.ExpiresIn);
            token.RefreshToken = oauthToken.RefreshToken;

            return token;
        }

        public async Task<SsoToken> RefreshTokenAsync(SsoToken token, string evessokey)
        {
            if (token == null || string.IsNullOrEmpty(evessokey))
            {
                throw new ESIException("Token or EVESSOKey is null or empty");
            }

            string ssoData = "grant_type=refresh_token&refresh_token=" + token.RefreshToken;

            OauthToken oauthToken = await GetOauthTokenAsync(evessokey, ssoData);

            token.AccessToken = oauthToken.AccessToken;
            token.ExpiresIn = DateTime.UtcNow.AddSeconds(oauthToken.ExpiresIn);
            token.RefreshToken = oauthToken.RefreshToken;

            return token;
        }

        private OauthToken GetOauthToken(string eveSsoKey, string data)
        {
            string encodeString = Base64Encode(eveSsoKey);

            WebHeaderCollection headers = new WebHeaderCollection()
            {
                [HttpRequestHeader.Authorization] = "Basic " + encodeString,
                [HttpRequestHeader.ContentType] = StaticContentTypeHeader.ContentType,
                [HttpRequestHeader.Host] = StaticHostHeader.Login,
            };

            string ssoRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(headers, "https://login.eveonline.com/oauth/token/", data));
            return JsonConvert.DeserializeObject<OauthToken>(ssoRaw);
        }

        private async Task<OauthToken> GetOauthTokenAsync(string eveSsoKey, string data)
        {
            string encodeString = Base64Encode(eveSsoKey);

            WebHeaderCollection headers = new WebHeaderCollection
            {
                [HttpRequestHeader.Authorization] = "Basic " + encodeString,
                [HttpRequestHeader.ContentType] = StaticContentTypeHeader.ContentType,
                [HttpRequestHeader.Host] = StaticHostHeader.Login,
            };

            string ssoRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(headers, "https://login.eveonline.com/oauth/token/", data));
            return JsonConvert.DeserializeObject<OauthToken>(ssoRaw);
        }

        private OauthVerify GetOauthVerify(string accessToken)
        {
            WebHeaderCollection headers2 = new WebHeaderCollection
            {
                [HttpRequestHeader.Authorization] = "Bearer " + accessToken,
                //[HttpRequestHeader.Host] = StaticHostHeader.Login
            };

            string clientStringRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(headers2, StaticConnectionStrings.AuthenticationVerify()));
            return JsonConvert.DeserializeObject<OauthVerify>(clientStringRaw);
        }

        private async Task<OauthVerify> GetOauthVerifyAsync(string accessToken)
        {
            WebHeaderCollection headers2 = new WebHeaderCollection
            {
                [HttpRequestHeader.Authorization] = "Bearer " + accessToken,
                //[HttpRequestHeader.Host] = StaticHostHeader.Login
            };

            string clientStringRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(headers2, StaticConnectionStrings.AuthenticationVerify()));
            return JsonConvert.DeserializeObject<OauthVerify>(clientStringRaw);
        }

        private SsoToken CreateScopesFlags(SsoToken token, string scopes)
        {
            token.AllianceScopesFlags = AllianceScopes.None;
            token.AssetScopesFlags = AssetScopes.None;
            token.BookmarkScopesFlags = BookmarkScopes.None;
            token.CalendarScopesFlags = CalendarScopes.None;
            token.CharacterScopesFlags = CharacterScopes.None;
            token.CloneScopesFlags = CloneScopes.None;
            token.ContractScopesFlags = ContractScopes.None;
            token.CorporationScopesFlags = CorporationScopes.None;
            token.FittingScopesFlags = FittingScopes.None;
            token.FleetScopesFlags = FleetScopes.None;
            token.IndustryScopesFlags = IndustryScopes.None;
            token.KillmailScopesFlags = KillmailScopes.None;
            token.LocationScopesFlags = LocationScopes.None;
            token.MailScopesFlags = MailScopes.None;
            token.MarketScopesFlags = MarketScopes.None;
            token.PlanetScopesFlags = PlanetScopes.None;
            token.SearchScopesFlags = SearchScopes.None;
            token.SkillScopesFlags = SkillScopes.None;
            token.UiScopesFlags = UiScopes.None;
            token.UniverseScopesFlags = UniverseScopes.None;
            token.WalletScopesFlags = WalletScopes.None;

            string[] scopeList = scopes.Split(' ');

            foreach (string scope in scopeList)
            {
                switch (scope)
                {
                    case "esi-assets.read_assets.v1":
                        token.AssetScopesFlags |= AssetScopes.esi_assets_read_assets_v1;
                        break;
                    case "esi-bookmarks.read_character_bookmarks.v1":
                        token.BookmarkScopesFlags |= BookmarkScopes.esi_bookmarks_read_character_bookmarks_v1;
                        break;
                    case "esi-calendar.read_calendar_events.v1":
                        token.CalendarScopesFlags |= CalendarScopes.esi_calendar_read_calendar_events_v1;
                        break;
                    case "esi-calendar.respond_calendar_events.v1":
                        token.CalendarScopesFlags |= CalendarScopes.esi_calendar_respond_calendar_events_v1;
                        break;
                    case "esi-characters.read_agents_research.v1":
                        token.CharacterScopesFlags |= CharacterScopes.esi_characters_read_agents_research_v1;
                        break;
                    case "esi-characters.read_blueprints.v1":
                        token.CharacterScopesFlags |= CharacterScopes.esi_characters_read_blueprints_v1;
                        break;
                    case "esi-characters.read_chat_channels.v1":
                        token.CharacterScopesFlags |= CharacterScopes.esi_characters_read_chat_channels_v1;
                        break;
                    case "esi-characters.read_contacts.v1":
                        token.CharacterScopesFlags |= CharacterScopes.esi_characters_read_contacts_v1;
                        break;
                    case "esi-characters.read_corporation_roles.v1":
                        token.CharacterScopesFlags |= CharacterScopes.esi_characters_read_corporation_roles_v1;
                        break;
                    case "esi-characters.read_fatigue.v1":
                        token.CharacterScopesFlags |= CharacterScopes.esi_characters_read_fatigue_v1;
                        break;
                    case "esi-characters.read_loyalty.v1":
                        token.CharacterScopesFlags |= CharacterScopes.esi_characters_read_loyalty_v1;
                        break;
                    case "esi-characters.read_medals.v1":
                        token.CharacterScopesFlags |= CharacterScopes.esi_characters_read_medals_v1;
                        break;
                    case "esi-characters.read_opportunities.v1":
                        token.CharacterScopesFlags |= CharacterScopes.esi_characters_read_opportunities_v1;
                        break;
                    case "esi-characters.read_standings.v1":
                        token.CharacterScopesFlags |= CharacterScopes.esi_characters_read_standings_v1;
                        break;
                    case "esi-characters.write_contacts.v1":
                        token.CharacterScopesFlags |= CharacterScopes.esi_characters_write_contacts_v1;
                        break;
                    case "esi-clones.read_clones.v1":
                        token.CloneScopesFlags |= CloneScopes.esi_clones_read_clones_v1;
                        break;
                    case "esi-clones.read_implants.v1":
                        token.CloneScopesFlags |= CloneScopes.esi_clones_read_implants_v1;
                        break;
                    case "esi-contracts.read_character_contracts.v1":
                        token.ContractScopesFlags |= ContractScopes.esi_contracts_read_character_contracts_v1;
                        break;
                    case "esi-corporations.read_corporation_membership.v1":
                        token.CorporationScopesFlags |= CorporationScopes.esi_corporations_read_corporation_membership_v1;
                        break;
                    case "esi-corporations.read_structures.v1":
                        token.CorporationScopesFlags |= CorporationScopes.esi_corporations_read_structures_v1;
                        break;
                    case "esi-corporations.track_members.v1":
                        token.CorporationScopesFlags |= CorporationScopes.esi_corporations_track_members_v1;
                        break;
                    case "esi-corporations.write_structures.v1":
                        token.CorporationScopesFlags |= CorporationScopes.esi_corporations_write_structures_v1;
                        break;
                    case "esi-fittings.read_fittings.v1":
                        token.FittingScopesFlags |= FittingScopes.esi_fittings_read_fittings_v1;
                        break;
                    case "esi-fittings.write_fittings.v1":
                        token.FittingScopesFlags |= FittingScopes.esi_fittings_write_fittings_v1;
                        break;
                    case "esi-fleets.read_fleet.v1":
                        token.FleetScopesFlags |= FleetScopes.esi_fleets_read_fleet_v1;
                        break;
                    case "esi-fleets.write_fleet.v1":
                        token.FleetScopesFlags |= FleetScopes.esi_fleets_write_fleet_v1;
                        break;
                    case "esi-industry.read_character_jobs.v1":
                        token.IndustryScopesFlags |= IndustryScopes.esi_industry_read_character_jobs_v1;
                        break;
                    case "esi-killmails.read_corporation_killmails.v1":
                        token.KillmailScopesFlags |= KillmailScopes.esi_killmails_read_corporation_killmails_v1;
                        break;
                    case "esi-killmails.read_killmails.v1":
                        token.KillmailScopesFlags |= KillmailScopes.esi_killmails_read_killmails_v1;
                        break;
                    case "esi-location.read_location.v1":
                        token.LocationScopesFlags |= LocationScopes.esi_location_read_location_v1;
                        break;
                    case "esi-location.read_online.v1":
                        token.LocationScopesFlags |= LocationScopes.esi_location_read_online_v1;
                        break;
                    case "esi-location.read_ship_type.v1":
                        token.LocationScopesFlags |= LocationScopes.esi_location_read_ship_type_v1;
                        break;
                    case "esi-mail.organize_mail.v1":
                        token.MailScopesFlags |= MailScopes.esi_mail_organize_mail_v1;
                        break;
                    case "esi-mail.read_mail.v1":
                        token.MailScopesFlags |= MailScopes.esi_mail_read_mail_v1;
                        break;
                    case "esi-mail.send_mail.v1":
                        token.MailScopesFlags |= MailScopes.esi_mail_send_mail_v1;
                        break;
                    case "esi-markets.read_character_orders.v1":
                        token.MarketScopesFlags |= MarketScopes.esi_markets_read_character_orders_v1;
                        break;
                    case "esi-markets.structure_markets.v1":
                        token.MarketScopesFlags |= MarketScopes.esi_markets_structure_markets_v1;
                        break;
                    case "esi-planets.manage_planets.v1":
                        token.PlanetScopesFlags |= PlanetScopes.esi_planets_manage_planets_v1;
                        break;
                    case "esi-search.search_structures.v1":
                        token.SearchScopesFlags |= SearchScopes.esi_search_search_structures_v1;
                        break;
                    case "esi-skills.read_skillqueue.v1":
                        token.SkillScopesFlags |= SkillScopes.esi_skills_read_skillqueue_v1;
                        break;
                    case "esi-skills.read_skills.v1":
                        token.SkillScopesFlags |= SkillScopes.esi_skills_read_skills_v1;
                        break;
                    case "esi-ui.open_window.v1":
                        token.UiScopesFlags |= UiScopes.esi_ui_open_window_v1;
                        break;
                    case "esi-ui.write_waypoint.v1":
                        token.UiScopesFlags |= UiScopes.esi_ui_write_waypoint_v1;
                        break;
                    case "esi-universe.read_structures.v1":
                        token.UniverseScopesFlags |= UniverseScopes.esi_universe_read_structures_v1;
                        break;
                    case "esi-wallet.read_character_wallet.v1":
                        token.WalletScopesFlags |= WalletScopes.esi_wallet_read_character_wallet_v1;
                        break;
                    case "esi-wallet.read_corporation_wallet.v1":
                        token.WalletScopesFlags |= WalletScopes.esi_wallet_read_corporation_wallet_v1;
                        break;
                    case "esi-wallet.read_corporation_wallets.v1":
                        token.WalletScopesFlags |= WalletScopes.esi_wallet_read_corporation_wallets_v1;
                        break;
                    case "esi-assets.read_corporation_assets.v1":
                        token.AssetScopesFlags |= AssetScopes.esi_assets_read_corporation_assets_v1;
                        break;
                    case "esi-alliances.read_contacts.v1":
                        token.AllianceScopesFlags |= AllianceScopes.esi_alliances_read_contacts_v1;
                        break;
                    case "esi-bookmarks.read_corporation_bookmarks.v1":
                        token.BookmarkScopesFlags |= BookmarkScopes.esi_bookmarks_read_corporation_bookmarks_v1;
                        break;
                    case "esi-characters.read_fw_stats.v1":
                        token.CharacterScopesFlags |= CharacterScopes.esi_characters_read_fw_stats_v1;
                        break;
                    case "esi-characters.read_notifications.v1":
                        token.CharacterScopesFlags |= CharacterScopes.esi_characters_read_notifications_v1;
                        break;
                    case "esi-characters.read_titles.v1":
                        token.CharacterScopesFlags |= CharacterScopes.esi_characters_read_titles_v1;
                        break;
                    case "esi-characterstats.read.v1":
                        token.CharacterScopesFlags |= CharacterScopes.esi_characterstats_read_v1;
                        break;
                    case "esi-contracts.read_corporation_contracts.v1":
                        token.ContractScopesFlags |= ContractScopes.esi_contracts_read_corporation_contracts_v1;
                        break;
                    case "esi-corporations.read_blueprints.v1":
                        token.CorporationScopesFlags |= CorporationScopes.esi_corporations_read_blueprints_v1;
                        break;
                    case "esi-corporations.read_contacts.v1":
                        token.CorporationScopesFlags |= CorporationScopes.esi_corporations_read_contacts_v1;
                        break;
                    case "esi-corporations.read_container_logs.v1":
                        token.CorporationScopesFlags |= CorporationScopes.esi_corporations_read_container_logs_v1;
                        break;
                    case "esi-corporations.read_divisions.v1":
                        token.CorporationScopesFlags |= CorporationScopes.esi_corporations_read_divisions_v1;
                        break;
                    case "esi-corporations.read_facilities.v1":
                        token.CorporationScopesFlags |= CorporationScopes.esi_corporations_read_facilities_v1;
                        break;
                    case "esi-corporations.read_fw_stats.v1":
                        token.CorporationScopesFlags |= CorporationScopes.esi_corporations_read_fw_stats_v1;
                        break;
                    case "esi-corporations.read_medals.v1":
                        token.CorporationScopesFlags |= CorporationScopes.esi_corporations_read_medals_v1;
                        break;
                    case "esi-corporations.read_outposts.v1":
                        token.CorporationScopesFlags |= CorporationScopes.esi_corporations_read_outposts_v1;
                        break;
                    case "esi-corporations.read_standings.v1":
                        token.CorporationScopesFlags |= CorporationScopes.esi_corporations_read_standings_v1;
                        break;
                    case "esi-corporations.read_starbases.v1":
                        token.CorporationScopesFlags |= CorporationScopes.esi_corporations_read_starbases_v1;
                        break;
                    case "esi-corporations.read_titles.v1":
                        token.CorporationScopesFlags |= CorporationScopes.esi_corporations_read_titles_v1;
                        break;
                    case "esi-industry.read_character_mining.v1":
                        token.IndustryScopesFlags |= IndustryScopes.esi_industry_read_character_mining_v1;
                        break;
                    case "esi-industry.read_corporation_jobs.v1":
                        token.IndustryScopesFlags |= IndustryScopes.esi_industry_read_corporation_jobs_v1;
                        break;
                    case "esi-industry.read_corporation_mining.v1":
                        token.IndustryScopesFlags |= IndustryScopes.esi_industry_read_corporation_mining_v1;
                        break;
                    case "esi-markets.read_corporation_orders.v1":
                        token.MarketScopesFlags |= MarketScopes.esi_markets_read_corporation_orders_v1;
                        break;
                    case "esi-planets.read_customs_offices.v1":
                        token.PlanetScopesFlags |= PlanetScopes.esi_planets_read_customs_offices_v1;
                        break;
                }
            }

            return token;
        }

        private static string Base64Encode(string plainText)
        {
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        private static class StaticHostHeader
        {
            public static string Login = "login.eveonline.com";
        }

        private static class StaticContentTypeHeader
        {
            public static string ContentType = "application/x-www-form-urlencoded";
        }
    }
}
