using System;
// ReSharper disable InconsistentNaming

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum IndustryScopes : long
    {
        None = 0L,
        esi_industry_read_character_jobs_v1 = 1L << 1,
        esi_industry_read_character_mining_v1 = 1L << 2,
        esi_industry_read_corporation_jobs_v1 = 1L << 3,
        esi_industry_read_corporation_mining_v1 = 1L << 4,
    }
}