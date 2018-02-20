﻿using System;

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum Scopes : long
    {
        None = 0L,
        esi_planets_manage_planets_v1 = 1L << 0,
        esi_ui_open_window_v1 = 1L << 1,
        esi_mail_organize_mail_v1 = 1L << 2,
        esi_characters_read_agents_research_v1 = 1L << 3,
        esi_assets_read_assets_v1 = 1L << 4,
        esi_characters_read_blueprints_v1 = 1L << 5,
        esi_calendar_read_calendar_events_v1 = 1L << 6,
        esi_bookmarks_read_character_bookmarks_v1 = 1L << 7,
        esi_contracts_read_character_contracts_v1 = 1L << 8,
        esi_industry_read_character_jobs_v1 = 1L << 9,
        esi_markets_read_character_orders_v1 = 1L << 10,
        esi_wallet_read_character_wallet_v1 = 1L << 11,
        esi_characters_read_chat_channels_v1 = 1L << 12,
        esi_clones_read_clones_v1 = 1L << 13,
        esi_characters_read_contacts_v1 = 1L << 14,
        esi_killmails_read_corporation_killmails_v1 = 1L << 15,
        esi_corporations_read_corporation_membership_v1 = 1L << 16,
        esi_characters_read_corporation_roles_v1 = 1L << 17,
        esi_characters_read_fatigue_v1 = 1L << 18,
        esi_fittings_read_fittings_v1 = 1L << 19,
        esi_fleets_read_fleet_v1 = 1L << 20,
        esi_clones_read_implants_v1 = 1L << 21,
        esi_killmails_read_killmails_v1 = 1L << 22,
        esi_location_read_location_v1 = 1L << 23,
        esi_characters_read_loyalty_v1 = 1L << 24,
        esi_mail_read_mail_v1 = 1L << 25,
        esi_characters_read_medals_v1 = 1L << 26,
        esi_location_read_online_v1 = 1L << 27,
        esi_characters_read_opportunities_v1 = 1L << 28,
        esi_location_read_ship_type_v1 = 1L << 29,
        esi_skills_read_skillqueue_v1 = 1L << 30,
        esi_skills_read_skills_v1 = 1L << 31,
        esi_characters_read_standings_v1 = 1L << 32,
        esi_universe_read_structures_v1 = 1L << 33,
        esi_corporations_read_structures_v1 = 1L << 34,
        esi_calendar_respond_calendar_events_v1 = 1L << 35,
        esi_search_search_structures_v1 = 1L << 36,
        esi_mail_send_mail_v1 = 1L << 37,
        esi_markets_structure_markets_v1 = 1L << 38,
        esi_characters_write_contacts_v1 = 1L << 39,
        esi_fittings_write_fittings_v1 = 1L << 40,
        esi_fleets_write_fleet_v1 = 1L << 41,
        esi_corporations_write_structures_v1 = 1L << 42,
        esi_ui_write_waypoint_v1 = 1L << 43,
        esi_corporations_track_members_v1 = 1L << 44,
        esi_wallet_read_corporation_wallet_v1 = 1L << 45,
        esi_wallet_read_corporation_wallets_v1 = 1L << 46,
        esi_assets_read_corporation_assets_v1 = 1L << 47
    }
}