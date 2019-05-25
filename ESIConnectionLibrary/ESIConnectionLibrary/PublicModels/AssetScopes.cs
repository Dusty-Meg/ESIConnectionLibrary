using System;
// ReSharper disable InconsistentNaming

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum AssetScopes : long
    {
        None = 0L,
        esi_assets_read_assets_v1 = 1L << 1,
        esi_assets_read_corporation_assets_v1 = 1L << 2,
    }
}