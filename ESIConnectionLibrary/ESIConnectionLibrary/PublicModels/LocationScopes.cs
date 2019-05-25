using System;
// ReSharper disable InconsistentNaming

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum LocationScopes : long
    {
        None = 0L,
        esi_location_read_location_v1 = 1L << 1,
        esi_location_read_online_v1 = 1L << 2,
        esi_location_read_ship_type_v1 = 1L << 3,
    }
}