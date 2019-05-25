using System;
// ReSharper disable InconsistentNaming

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum SearchScopes : long
    {
        None = 0L,
        esi_search_search_structures_v1 = 1L << 1,
    }
}