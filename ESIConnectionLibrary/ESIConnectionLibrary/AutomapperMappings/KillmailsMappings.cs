using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class GetSingleKillmailMappings : Profile
    {
        public GetSingleKillmailMappings()
        {
            CreateMap<EsiKillmail, GetSingleKillmail>()
                .ForMember(x => x.Attackers, m => m.MapFrom(a => a.attackers))
                .ForMember(x => x.KillmailId, m => m.MapFrom(a => a.killmail_id))
                .ForMember(x => x.KillmailTime, m => m.MapFrom(a => a.killmail_time))
                .ForMember(x => x.MoonId, m => m.MapFrom(a => a.moon_id))
                .ForMember(x => x.SolarSystemId, m => m.MapFrom(a => a.solar_system_id))
                .ForMember(x => x.Victim, m => m.MapFrom(a => a.victim))
                .ForMember(x => x.WarId, m => m.MapFrom(a => a.war_id))
                ;
        }
    }

    internal class GetSingleKillmailVictimMappings : Profile
    {
        public GetSingleKillmailVictimMappings()
        {
            CreateMap<EsiGetSingleKillmailVictim, GetSingleKillmailVictim>()
                .ForMember(x => x.AllianceId, m => m.MapFrom(a => a.alliance_id))
                .ForMember(x => x.CharacterId, m => m.MapFrom(a => a.character_id))
                .ForMember(x => x.CorporationId, m => m.MapFrom(a => a.corporation_id))
                .ForMember(x => x.DamageTaken, m => m.MapFrom(a => a.damage_taken))
                .ForMember(x => x.FactionId, m => m.MapFrom(a => a.faction_id))
                .ForMember(x => x.Items, m => m.MapFrom(a => a.items))
                .ForMember(x => x.Position, m => m.MapFrom(a => a.position))
                .ForMember(x => x.ShipTypeId, m => m.MapFrom(a => a.ship_type_id))
                ;
        }
    }

    internal class GetSingleKillmailPositionMappings : Profile
    {
        public GetSingleKillmailPositionMappings()
        {
            CreateMap<EsiGetSingleKillmailPosition, GetSingleKillmailPosition>()
                .ForMember(x => x.X, m => m.MapFrom(a => a.x))
                .ForMember(x => x.Y, m => m.MapFrom(a => a.y))
                .ForMember(x => x.Z, m => m.MapFrom(a => a.z))
                ;
        }
    }

    internal class GetSingleKillmailItemMappings : Profile
    {
        public GetSingleKillmailItemMappings()
        {
            CreateMap<EsiGetSingleKillmailItem, GetSingleKillmailItem>()
                .ForMember(x => x.Flag, m => m.MapFrom(a => a.flag))
                .ForMember(x => x.ItemTypeId, m => m.MapFrom(a => a.item_type_id))
                .ForMember(x => x.Items, m => m.MapFrom(a => a.items))
                .ForMember(x => x.QuantityDestroyed, m => m.MapFrom(a => a.quantity_destroyed))
                .ForMember(x => x.QuantityDropped, m => m.MapFrom(a => a.quantity_dropped))
                .ForMember(x => x.Singleton, m => m.MapFrom(a => a.singleton))
                ;
        }
    }

    internal class GetSingleKillmailAttackerMappings : Profile
    {
        public GetSingleKillmailAttackerMappings()
        {
            CreateMap<EsiGetSingleKillmailAttacker, GetSingleKillmailAttacker>()
                .ForMember(x => x.AllianceId, m => m.MapFrom(a => a.alliance_id))
                .ForMember(x => x.CharacterId, m => m.MapFrom(a => a.character_id))
                .ForMember(x => x.CorporationId, m => m.MapFrom(a => a.corporation_id))
                .ForMember(x => x.DamageDone, m => m.MapFrom(a => a.damage_done))
                .ForMember(x => x.FactionId, m => m.MapFrom(a => a.faction_id))
                .ForMember(x => x.FinalBlow, m => m.MapFrom(a => a.final_blow))
                .ForMember(x => x.SecurityStatus, m => m.MapFrom(a => a.security_status))
                .ForMember(x => x.ShipTypeId, m => m.MapFrom(a => a.ship_type_id))
                .ForMember(x => x.ShipTypeId, m => m.MapFrom(a => a.weapon_type_id))
                ;
        }
    }
}
