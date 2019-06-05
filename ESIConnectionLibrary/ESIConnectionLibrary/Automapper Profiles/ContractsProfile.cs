using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class ContractsProfile : Profile
    {
        public ContractsProfile()
        {
            CreateMap<EsiV1ContractsPublicItem, V1ContractsPublicItem>();
            CreateMap<EsiV1ContractsPublicBid, V1ContractsPublicBid>();
            CreateMap<EsiV1ContractsPublic, V1ContractsPublic>();
            CreateMap<EsiV1ContractsCorporationItems, V1ContractsCorporationItems>();
            CreateMap<EsiV1ContractsCorporationBids, V1ContractsCorporationBids>();
            CreateMap<EsiV1ContractsCorporation, V1ContractsCorporation>();
            CreateMap<EsiV1ContractsCharacterItems, V1ContractsCharacterItems>();
            CreateMap<EsiV1ContractsCharacterBids, V1ContractsCharacterBids>();
            CreateMap<EsiV1ContractsCharacter, V1ContractsCharacter>();
        }
    }
}
