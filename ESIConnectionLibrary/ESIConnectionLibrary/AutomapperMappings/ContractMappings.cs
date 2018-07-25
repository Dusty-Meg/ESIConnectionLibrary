using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class ContractMappings : Profile
    {
        public ContractMappings()
        {
            CreateMap<EsiV1ContractsCharacter, V1ContractsCharacter>();
            CreateMap<EsiV1ContractsCharacterBids, V1ContractsCharacterBids>();
            CreateMap<EsiV1ContractsCharacterItems, V1ContractsCharacterItems>();
            CreateMap<EsiV1ContractsCorporation, V1ContractsCorporation>();
            CreateMap<EsiV1ContractsCorporationBids, V1ContractsCorporationBids>();
            CreateMap<EsiV1ContractsCorporationItems, V1ContractsCorporationItems>();
        }
    }
}
