using System;

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum UniverseScopes : long
    {
        None = 0L,
        esi_universe_read_structures_v1 = 1L << 1,
    }
}