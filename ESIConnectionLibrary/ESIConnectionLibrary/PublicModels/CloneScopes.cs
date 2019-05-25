using System;
// ReSharper disable InconsistentNaming

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum CloneScopes : long
    {
        None = 0L,
        esi_clones_read_clones_v1 = 1L << 1,
        esi_clones_read_implants_v1 = 1L << 2,
    }
}