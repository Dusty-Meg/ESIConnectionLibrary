using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<EsiV1WalletCorporationTransactions, V1WalletCorporationTransactions>();
            CreateMap<EsiV4WalletCorporationJournal, V4WalletCorporationJournal>();
            CreateMap<EsiV1WalletCorporationWallet, V1WalletCorporationWallet>();
            CreateMap<EsiV1WalletCharacterTransactions, V1WalletCharacterTransactions>();
            CreateMap<EsiV6WalletCharacterJournal, V6WalletCharacterJournal>();
        }
    }
}
