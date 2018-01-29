using System;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class CharacterIndustryJobsMappings : Profile
    {
        public CharacterIndustryJobsMappings()
        {
            CreateMap<EsiCharacterIndustryJob, CharacterIndustryJob>();
        }
    }
}
