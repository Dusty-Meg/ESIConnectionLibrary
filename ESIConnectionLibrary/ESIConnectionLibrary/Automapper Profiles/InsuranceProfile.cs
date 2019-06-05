using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class InsuranceProfile : Profile
    {
        public InsuranceProfile()
        {
            CreateMap<EsiV1InsuranceInsurance, V1InsuranceInsurance>();
            CreateMap<EsiV1InsuranceInsuranceLevels, V1InsuranceInsuranceLevels>();
        }
    }
}
