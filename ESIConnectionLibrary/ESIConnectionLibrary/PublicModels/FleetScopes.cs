using System;
// ReSharper disable InconsistentNaming

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum FleetScopes : long
    {
        None = 0L,
        esi_fleets_read_fleet_v1 = 1L << 1,
        esi_fleets_write_fleet_v1 = 1L << 2,
    }
}