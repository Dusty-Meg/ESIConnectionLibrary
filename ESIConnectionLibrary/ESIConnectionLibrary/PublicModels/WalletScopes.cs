using System;

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum WalletScopes : long
    {
        None = 0L,
        esi_wallet_read_character_wallet_v1 = 1L << 1,
        esi_wallet_read_corporation_wallet_v1 = 1L << 2,
        esi_wallet_read_corporation_wallets_v1 = 1L << 3,
    }
}