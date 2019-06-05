using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class LoyaltyProfile : Profile
    {
        public LoyaltyProfile()
        {
            CreateMap<EsiV1LoyaltyPoint, V1LoyaltyPoint>();
            CreateMap<EsiV1LoyaltyOffer, V1LoyaltyOffer>();
            CreateMap<EsiV1LoyaltyOfferRequiredItem, V1LoyaltyOfferRequiredItem>();
        }
    }
}
