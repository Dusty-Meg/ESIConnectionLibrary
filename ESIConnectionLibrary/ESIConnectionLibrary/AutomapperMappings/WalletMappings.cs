using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class WalletMappings : Profile
    {
        public WalletMappings()
        {
            CreateMap<EsiV4WalletCharacterJournal, V4WalletCharacterJournal>();
            CreateMap<EsiV1WalletCharacterTransactions, V1WalletCharacterTransactions>();
        }
    }
}
