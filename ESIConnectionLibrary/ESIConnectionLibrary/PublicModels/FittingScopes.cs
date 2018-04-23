using System;

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum FittingScopes : long
    {
        None = 0L,
        esi_fittings_read_fittings_v1 = 1L << 1,
        esi_fittings_write_fittings_v1 = 1L << 2,
    }
}