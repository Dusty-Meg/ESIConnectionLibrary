using System;

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum CharacterScopes : long
    {
        None = 0L,
        esi_characters_read_agents_research_v1 = 1L << 1,
        esi_characters_read_blueprints_v1 = 1L << 2,
        esi_characters_read_chat_channels_v1 = 1L << 3,
        esi_characters_read_contacts_v1 = 1L << 4,
        esi_characters_read_corporation_roles_v1 = 1L << 5,
        esi_characters_read_fatigue_v1 = 1L << 6,
        esi_characters_read_fw_stats_v1 = 1L << 7,
        esi_characters_read_loyalty_v1 = 1L << 8,
        esi_characters_read_medals_v1 = 1L << 9,
        esi_characters_read_notifications_v1 = 1L << 10,
        esi_characters_read_opportunities_v1 = 1L << 11,
        esi_characters_read_standings_v1 = 1L << 12,
        esi_characters_read_titles_v1 = 1L << 13,
        esi_characters_write_contacts_v1 = 1L << 14,
        esi_characterstats_read_v1 = 1L << 15,
    }
}