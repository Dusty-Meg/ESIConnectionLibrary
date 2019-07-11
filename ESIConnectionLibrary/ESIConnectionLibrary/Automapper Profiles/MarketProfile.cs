using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class MarketProfile : Profile 
    {
        public MarketProfile()
        {
            CreateMap<EsiV1MarketStructure, V1MarketStructure>();
            CreateMap<EsiV1MarketPrice, V1MarketPrice>();
            CreateMap<EsiV1MarketGroupInformation, V1MarketGroupInformation>();
            CreateMap<EsiV1MarketOrders, V1MarketOrders>();
            CreateMap<EsiV1MarketHistory, V1MarketHistory>();
            CreateMap<EsiV3MarketCorporationOrdersHistoric, V3MarketCorporationOrdersHistoric>();
            CreateMap<EsiV3MarketCorporationOrders, V3MarketCorporationOrders>();
            CreateMap<EsiV1MarketCharacterHistoricOrders, V1MarketCharacterHistoricOrders>();
            CreateMap<EsiV2MarketCharactersOrders, V2MarketCharactersOrders>();
        }
    }
}
