using System;

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum AllianceScopes : long
    {
        None = 0L,
        esi_alliances_read_contacts_v1 = 1L << 1,
    }
}