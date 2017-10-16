using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class UniverseNamesMappings : Profile
    {
        public UniverseNamesMappings()
        {
            CreateMap<EsiUniverseNames, UniverseNames>()
                .ForMember(x => x.Id, m => m.MapFrom(a => a.id))
                .ForMember(x => x.Category, m => m.MapFrom(a => a.category))
                .ForMember(x => x.Name, m => m.MapFrom(a => a.name))
                ;
        }
    }

    internal class UniverseGetTypeMappings : Profile
    {
        public UniverseGetTypeMappings()
        {
            CreateMap<EsiUniverseGetType, UniverseGetType>()
                .ForMember(x => x.Capacity, m => m.MapFrom(a => a.capacity))
                .ForMember(x => x.Description, m => m.MapFrom(a => a.description))
                .ForMember(x => x.DogmaAttributes, m => m.MapFrom(a => a.dogma_attributes))
                .ForMember(x => x.DogmaEffects, m => m.MapFrom(a => a.dogma_effects))
                .ForMember(x => x.GraphicId, m => m.MapFrom(a => a.graphic_id))
                .ForMember(x => x.GroupId, m => m.MapFrom(a => a.group_id))
                .ForMember(x => x.IconId, m => m.MapFrom(a => a.icon_id))
                .ForMember(x => x.MarketGroupId, m => m.MapFrom(a => a.market_group_id))
                .ForMember(x => x.Mass, m => m.MapFrom(a => a.mass))
                .ForMember(x => x.Name, m => m.MapFrom(a => a.name))
                .ForMember(x => x.PackagedVolume, m => m.MapFrom(a => a.packaged_volume))
                .ForMember(x => x.PortionSize, m => m.MapFrom(a => a.portion_size))
                .ForMember(x => x.Published, m => m.MapFrom(a => a.published))
                .ForMember(x => x.Radius, m => m.MapFrom(a => a.radius))
                .ForMember(x => x.TypeId, m => m.MapFrom(a => a.type_id))
                .ForMember(x => x.Volume, m => m.MapFrom(a => a.volume))
                ;
        }
    }

    internal class UniverseGetTypeDogmaAttributeMappings : Profile
    {
        public UniverseGetTypeDogmaAttributeMappings()
        {
            CreateMap<EsiUniverseGetTypeDogmaAttribute, UniverseGetTypeDogmaAttribute>()
                .ForMember(x => x.AttributeId, m => m.MapFrom(a => a.attribute_id))
                .ForMember(x => x.Value, m => m.MapFrom(a => a.value))
                ;
        }
    }

    internal class UniverseGetTypeDogmaEffectMappings : Profile
    {
        public UniverseGetTypeDogmaEffectMappings()
        {
            CreateMap<EsiUniverseGetTypeDogmaEffect, UniverseGetTypeDogmaEffect>()
                .ForMember(x => x.EffectId, m => m.MapFrom(a => a.effect_id))
                .ForMember(x => x.IsDefault, m => m.MapFrom(a => a.is_default))
                ;
        }
    }
}
