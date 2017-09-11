using System;
using System.Collections.Generic;
using System.Net;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.Exceptions;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalAuthentication : IInternalAuthentication
    {
        private IWebClient WebClient { get; }

        public InternalAuthentication(IWebClient webClient, string userAgent)
        {
            WebClient = webClient ?? new WebClient(userAgent);
        }

        public SsoToken MakeToken(string code, string evessokey, Guid userId)
        {
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(evessokey))
            {
                throw new ESIException("Code or EVESSOKey is null or empty");
            }

            string ssoData = "grant_type=authorization_code&code=" + code;

            OauthToken oauthToken = GetOauthToken(evessokey, ssoData);
            OauthVerify oauthVerify = GetOauthVerify(oauthToken.access_token);

            return new SsoToken
            {
                UserId = userId,
                AccessToken = oauthToken.access_token,
                ExpiresIn = DateTime.UtcNow.AddSeconds(oauthToken.expires_in),
                RefreshToken = oauthToken.refresh_token,
                CharacterId = oauthVerify.CharacterID,
                CharacterName = oauthVerify.CharacterName,
                ScopesFlags = CreateScopesFlags(oauthVerify.Scopes),
                TokenType = (TokenType)Enum.Parse(typeof(TokenType), oauthVerify.TokenType, true)
            };
        }

        public SsoToken RefreshToken(SsoToken token, string evessokey)
        {
            if (token == null || string.IsNullOrEmpty(evessokey))
            {
                throw new ESIException("Token or EVESSOKey is null or empty");
            }

            string ssoData = "grant_type=refresh_token&refresh_token=" + token.RefreshToken;

            OauthToken oauthToken = GetOauthToken(evessokey, ssoData);

            token.AccessToken = oauthToken.access_token;
            token.ExpiresIn = DateTime.UtcNow.AddSeconds(oauthToken.expires_in);
            token.RefreshToken = oauthToken.refresh_token;

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

            string ssoRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => WebClient.Post(headers, "https://login-tq.eveonline.com/oauth/token/", data));
            return JsonConvert.DeserializeObject<OauthToken>(ssoRaw);
        }

        private OauthVerify GetOauthVerify(string accessToken)
        {
            WebHeaderCollection headers2 = new WebHeaderCollection
            {
                [HttpRequestHeader.Authorization] = "Bearer " + accessToken,
                [HttpRequestHeader.Host] = StaticHostHeader.Login
            };

            string clientStringRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => WebClient.Get(headers2, @"https://login.eveonline.com/oauth/verify"));
            return JsonConvert.DeserializeObject<OauthVerify>(clientStringRaw);
        }

        private Scopes CreateScopesFlags(string scopes)
        {
            Scopes scopeCollection = Scopes.None;

            string[] scopeList = scopes.Split(' ');

            foreach (string scope in scopeList)
            {
                switch (scope)
                {
                    case "esi-assets.read_assets.v1":
                        scopeCollection.Add(Scopes.esi_assets_read_assets_v1);
                        break;
                    case "esi-bookmarks.read_character_bookmarks.v1":
                        scopeCollection.Add(Scopes.esi_bookmarks_read_character_bookmarks_v1);
                        break;
                    case "esi-calendar.read_calendar_events.v1":
                        scopeCollection.Add(Scopes.esi_calendar_read_calendar_events_v1);
                        break;
                    case "esi-calendar.respond_calendar_events.v1":
                        scopeCollection.Add(Scopes.esi_calendar_respond_calendar_events_v1);
                        break;
                    case "esi-characters.read_agents_research.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_agents_research_v1);
                        break;
                    case "esi-characters.read_blueprints.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_blueprints_v1);
                        break;
                    case "esi-characters.read_chat_channels.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_chat_channels_v1);
                        break;
                    case "esi-characters.read_contacts.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_contacts_v1);
                        break;
                    case "esi-characters.read_corporation_roles.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_corporation_roles_v1);
                        break;
                    case "esi-characters.read_fatigue.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_fatigue_v1);
                        break;
                    case "esi-characters.read_loyalty.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_loyalty_v1);
                        break;
                    case "esi-characters.read_medals.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_medals_v1);
                        break;
                    case "esi-characters.read_opportunities.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_opportunities_v1);
                        break;
                    case "esi-characters.read_standings.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_standings_v1);
                        break;
                    case "esi-characters.write_contacts.v1":
                        scopeCollection.Add(Scopes.esi_characters_write_contacts_v1);
                        break;
                    case "esi-clones.read_clones.v1":
                        scopeCollection.Add(Scopes.esi_clones_read_clones_v1);
                        break;
                    case "esi-clones.read_implants.v1":
                        scopeCollection.Add(Scopes.esi_clones_read_implants_v1);
                        break;
                    case "esi-contracts.read_character_contracts.v1":
                        scopeCollection.Add(Scopes.esi_contracts_read_character_contracts_v1);
                        break;
                    case "esi-corporations.read_corporation_membership.v1":
                        scopeCollection.Add(Scopes.esi_corporations_read_corporation_membership_v1);
                        break;
                    case "esi-corporations.read_structures.v1":
                        scopeCollection.Add(Scopes.esi_corporations_read_structures_v1);
                        break;
                    case "esi-corporations.track_members.v1":
                        scopeCollection.Add(Scopes.esi_corporations_track_members_v1);
                        break;
                    case "esi-corporations.write_structures.v1":
                        scopeCollection.Add(Scopes.esi_corporations_write_structures_v1);
                        break;
                    case "esi-fittings.read_fittings.v1":
                        scopeCollection.Add(Scopes.esi_fittings_read_fittings_v1);
                        break;
                    case "esi-fittings.write_fittings.v1":
                        scopeCollection.Add(Scopes.esi_fittings_write_fittings_v1);
                        break;
                    case "esi-fleets.read_fleet.v1":
                        scopeCollection.Add(Scopes.esi_fleets_read_fleet_v1);
                        break;
                    case "esi-fleets.write_fleet.v1":
                        scopeCollection.Add(Scopes.esi_fleets_write_fleet_v1);
                        break;
                    case "esi-industry.read_character_jobs.v1":
                        scopeCollection.Add(Scopes.esi_industry_read_character_jobs_v1);
                        break;
                    case "esi-killmails.read_corporation_killmails.v1":
                        scopeCollection.Add(Scopes.esi_killmails_read_corporation_killmails_v1);
                        break;
                    case "esi-killmails.read_killmails.v1":
                        scopeCollection.Add(Scopes.esi_killmails_read_killmails_v1);
                        break;
                    case "esi-location.read_location.v1":
                        scopeCollection.Add(Scopes.esi_location_read_location_v1);
                        break;
                    case "esi-location.read_online.v1":
                        scopeCollection.Add(Scopes.esi_location_read_online_v1);
                        break;
                    case "esi-location.read_ship_type.v1":
                        scopeCollection.Add(Scopes.esi_location_read_ship_type_v1);
                        break;
                    case "esi-mail.organize_mail.v1":
                        scopeCollection.Add(Scopes.esi_mail_organize_mail_v1);
                        break;
                    case "esi-mail.read_mail.v1":
                        scopeCollection.Add(Scopes.esi_mail_read_mail_v1);
                        break;
                    case "esi-mail.send_mail.v1":
                        scopeCollection.Add(Scopes.esi_mail_send_mail_v1);
                        break;
                    case "esi-markets.read_character_orders.v1":
                        scopeCollection.Add(Scopes.esi_markets_read_character_orders_v1);
                        break;
                    case "esi-markets.structure_markets.v1":
                        scopeCollection.Add(Scopes.esi_markets_structure_markets_v1);
                        break;
                    case "esi-planets.manage_planets.v1":
                        scopeCollection.Add(Scopes.esi_planets_manage_planets_v1);
                        break;
                    case "esi-search.search_structures.v1":
                        scopeCollection.Add(Scopes.esi_search_search_structures_v1);
                        break;
                    case "esi-skills.read_skillqueue.v1":
                        scopeCollection.Add(Scopes.esi_skills_read_skillqueue_v1);
                        break;
                    case "esi-skills.read_skills.v1":
                        scopeCollection.Add(Scopes.esi_skills_read_skills_v1);
                        break;
                    case "esi-ui.open_window.v1":
                        scopeCollection.Add(Scopes.esi_ui_open_window_v1);
                        break;
                    case "esi-ui.write_waypoint.v1":
                        scopeCollection.Add(Scopes.esi_ui_write_waypoint_v1);
                        break;
                    case "esi-universe.read_structures.v1":
                        scopeCollection.Add(Scopes.esi_universe_read_structures_v1);
                        break;
                    case "esi-wallet.read_character_wallet.v1":
                        scopeCollection.Add(Scopes.esi_wallet_read_character_wallet_v1);
                        break;
                    case "esi-wallet.read_corporation_wallet.v1":
                        scopeCollection.Add(Scopes.esi_wallet_read_corporation_wallet_v1);
                        break;
                    case "esi-wallet.read_corporation_wallets.v1":
                        scopeCollection.Add(Scopes.esi_wallet_read_corporation_wallets_v1);
                        break;
                }
            }

            return scopeCollection;
        }

        private IList<Scopes> CreateScopesList(string scopes)
        {
            IList<Scopes> scopeCollection = new List<Scopes>();

            string[] scopeList = scopes.Split(' ');

            foreach (string scope in scopeList)
            {
                switch (scope)
                {
                    case "esi-assets.read_assets.v1":
                        scopeCollection.Add(Scopes.esi_assets_read_assets_v1);
                        break;
                    case "esi-bookmarks.read_character_bookmarks.v1":
                        scopeCollection.Add(Scopes.esi_bookmarks_read_character_bookmarks_v1);
                        break;
                    case "esi-calendar.read_calendar_events.v1":
                        scopeCollection.Add(Scopes.esi_calendar_read_calendar_events_v1);
                        break;
                    case "esi-calendar.respond_calendar_events.v1":
                        scopeCollection.Add(Scopes.esi_calendar_respond_calendar_events_v1);
                        break;
                    case "esi-characters.read_agents_research.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_agents_research_v1);
                        break;
                    case "esi-characters.read_blueprints.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_blueprints_v1);
                        break;
                    case "esi-characters.read_chat_channels.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_chat_channels_v1);
                        break;
                    case "esi-characters.read_contacts.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_contacts_v1);
                        break;
                    case "esi-characters.read_corporation_roles.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_corporation_roles_v1);
                        break;
                    case "esi-characters.read_fatigue.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_fatigue_v1);
                        break;
                    case "esi-characters.read_loyalty.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_loyalty_v1);
                        break;
                    case "esi-characters.read_medals.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_medals_v1);
                        break;
                    case "esi-characters.read_opportunities.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_opportunities_v1);
                        break;
                    case "esi-characters.read_standings.v1":
                        scopeCollection.Add(Scopes.esi_characters_read_standings_v1);
                        break;
                    case "esi-characters.write_contacts.v1":
                        scopeCollection.Add(Scopes.esi_characters_write_contacts_v1);
                        break;
                    case "esi-clones.read_clones.v1":
                        scopeCollection.Add(Scopes.esi_clones_read_clones_v1);
                        break;
                    case "esi-clones.read_implants.v1":
                        scopeCollection.Add(Scopes.esi_clones_read_implants_v1);
                        break;
                    case "esi-contracts.read_character_contracts.v1":
                        scopeCollection.Add(Scopes.esi_contracts_read_character_contracts_v1);
                        break;
                    case "esi-corporations.read_corporation_membership.v1":
                        scopeCollection.Add(Scopes.esi_corporations_read_corporation_membership_v1);
                        break;
                    case "esi-corporations.read_structures.v1":
                        scopeCollection.Add(Scopes.esi_corporations_read_structures_v1);
                        break;
                    case "esi-corporations.track_members.v1":
                        scopeCollection.Add(Scopes.esi_corporations_track_members_v1);
                        break;
                    case "esi-corporations.write_structures.v1":
                        scopeCollection.Add(Scopes.esi_corporations_write_structures_v1);
                        break;
                    case "esi-fittings.read_fittings.v1":
                        scopeCollection.Add(Scopes.esi_fittings_read_fittings_v1);
                        break;
                    case "esi-fittings.write_fittings.v1":
                        scopeCollection.Add(Scopes.esi_fittings_write_fittings_v1);
                        break;
                    case "esi-fleets.read_fleet.v1":
                        scopeCollection.Add(Scopes.esi_fleets_read_fleet_v1);
                        break;
                    case "esi-fleets.write_fleet.v1":
                        scopeCollection.Add(Scopes.esi_fleets_write_fleet_v1);
                        break;
                    case "esi-industry.read_character_jobs.v1":
                        scopeCollection.Add(Scopes.esi_industry_read_character_jobs_v1);
                        break;
                    case "esi-killmails.read_corporation_killmails.v1":
                        scopeCollection.Add(Scopes.esi_killmails_read_corporation_killmails_v1);
                        break;
                    case "esi-killmails.read_killmails.v1":
                        scopeCollection.Add(Scopes.esi_killmails_read_killmails_v1);
                        break;
                    case "esi-location.read_location.v1":
                        scopeCollection.Add(Scopes.esi_location_read_location_v1);
                        break;
                    case "esi-location.read_online.v1":
                        scopeCollection.Add(Scopes.esi_location_read_online_v1);
                        break;
                    case "esi-location.read_ship_type.v1":
                        scopeCollection.Add(Scopes.esi_location_read_ship_type_v1);
                        break;
                    case "esi-mail.organize_mail.v1":
                        scopeCollection.Add(Scopes.esi_mail_organize_mail_v1);
                        break;
                    case "esi-mail.read_mail.v1":
                        scopeCollection.Add(Scopes.esi_mail_read_mail_v1);
                        break;
                    case "esi-mail.send_mail.v1":
                        scopeCollection.Add(Scopes.esi_mail_send_mail_v1);
                        break;
                    case "esi-markets.read_character_orders.v1":
                        scopeCollection.Add(Scopes.esi_markets_read_character_orders_v1);
                        break;
                    case "esi-markets.structure_markets.v1":
                        scopeCollection.Add(Scopes.esi_markets_structure_markets_v1);
                        break;
                    case "esi-planets.manage_planets.v1":
                        scopeCollection.Add(Scopes.esi_planets_manage_planets_v1);
                        break;
                    case "esi-search.search_structures.v1":
                        scopeCollection.Add(Scopes.esi_search_search_structures_v1);
                        break;
                    case "esi-skills.read_skillqueue.v1":
                        scopeCollection.Add(Scopes.esi_skills_read_skillqueue_v1);
                        break;
                    case "esi-skills.read_skills.v1":
                        scopeCollection.Add(Scopes.esi_skills_read_skills_v1);
                        break;
                    case "esi-ui.open_window.v1":
                        scopeCollection.Add(Scopes.esi_ui_open_window_v1);
                        break;
                    case "esi-ui.write_waypoint.v1":
                        scopeCollection.Add(Scopes.esi_ui_write_waypoint_v1);
                        break;
                    case "esi-universe.read_structures.v1":
                        scopeCollection.Add(Scopes.esi_universe_read_structures_v1);
                        break;
                    case "esi-wallet.read_character_wallet.v1":
                        scopeCollection.Add(Scopes.esi_wallet_read_character_wallet_v1);
                        break;
                    case "esi-wallet.read_corporation_wallet.v1":
                        scopeCollection.Add(Scopes.esi_wallet_read_corporation_wallet_v1);
                        break;
                    case "esi-wallet.read_corporation_wallets.v1":
                        scopeCollection.Add(Scopes.esi_wallet_read_corporation_wallets_v1);
                        break;
                }
            }

            return scopeCollection;
        }

        private static string Base64Encode(string plainText)
        {
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        private static class StaticAcceptHeader
        {
            public static string FleetRead = "application/vnd.ccp.eve.Fleet-v1+json";
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
