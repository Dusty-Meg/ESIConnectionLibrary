using System;

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum MarketScopes : long
    {
        None = 0L,
        esi_markets_read_character_orders_v1 = 1L << 1,
        esi_markets_read_corporation_orders_v1 = 1L << 2,
        esi_markets_structure_markets_v1 = 1L << 3,
    }
}