using System;
// ReSharper disable InconsistentNaming

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum ContractScopes : long
    {
        None = 0L,
        esi_contracts_read_character_contracts_v1 = 1L << 1,
        esi_contracts_read_corporation_contracts_v1 = 1L << 2,
    }
}