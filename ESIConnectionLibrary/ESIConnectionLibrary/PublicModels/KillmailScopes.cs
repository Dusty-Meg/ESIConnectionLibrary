using System;

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum KillmailScopes : long
    {
        None = 0L,
        esi_killmails_read_corporation_killmails_v1 = 1L << 1,
        esi_killmails_read_killmails_v1 = 1L << 2,
    }
}