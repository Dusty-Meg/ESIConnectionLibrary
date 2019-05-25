using System;
// ReSharper disable InconsistentNaming

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum CorporationScopes : long
    {
        None = 0L,
        esi_corporations_read_blueprints_v1 = 1L << 1,
        esi_corporations_read_contacts_v1 = 1L << 2,
        esi_corporations_read_container_logs_v1 = 1L << 3,
        esi_corporations_read_corporation_membership_v1 = 1L << 4,
        esi_corporations_read_divisions_v1 = 1L << 5,
        esi_corporations_read_facilities_v1 = 1L << 6,
        esi_corporations_read_fw_stats_v1 = 1L << 7,
        esi_corporations_read_medals_v1 = 1L << 8,
        esi_corporations_read_outposts_v1 = 1L << 9,
        esi_corporations_read_standings_v1 = 1L << 10,
        esi_corporations_read_starbases_v1 = 1L << 11,
        esi_corporations_read_structures_v1 = 1L << 12,
        esi_corporations_read_titles_v1 = 1L << 13,
        esi_corporations_track_members_v1 = 1L << 14,
        esi_corporations_write_structures_v1 = 1L << 15,
    }
}