using AutoMapper;
using ESIConnectionLibrary.ESIModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class ContractMappings : Profile
    {
        public ContractMappings()
        {
            CreateMap<EsiV1ContractsCharacterContracts, EsiV1ContractsCharacterContracts>();
        }
    }
}
