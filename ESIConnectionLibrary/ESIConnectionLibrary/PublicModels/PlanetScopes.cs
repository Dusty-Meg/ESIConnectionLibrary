using System;
// ReSharper disable InconsistentNaming

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum PlanetScopes : long
    {
        None = 0L,
        esi_planets_manage_planets_v1 = 1L << 1,
        esi_planets_read_customs_offices_v1 = 1L << 2,
    }
}