using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class FactionWarfareProfile : Profile
    {
        public FactionWarfareProfile()
        {
            CreateMap<EsiV1FwWars, V1FwWars>();
            CreateMap<EsiV2FwSystems, V2FwSystems>();
            CreateMap<EsiV1FwFactionStats, V1FwFactionStats>();
            CreateMap<EsiV1FwFactionStatsKills, V1FwFactionStatsKills>();
            CreateMap<EsiV1FwFactionStatsVictoryPoints, V1FwFactionStatsVictoryPoints>();
            CreateMap<EsiV1FwCorporationLeaderboard, V1FwCorporationLeaderboard>();
            CreateMap<EsiV1FwCorporationLeaderboardKills, V1FwCorporationLeaderboardKills>();
            CreateMap<EsiV1FwCorporationLeaderboardKillsActiveTotal,
            V1FwCorporationLeaderboardKillsActiveTotal>();
            CreateMap<EsiV1FwCorporationLeaderboardKillsLastWeek, V1FwCorporationLeaderboardKillsLastWeek>();
            CreateMap<EsiV1FwCorporationLeaderboardKillsYesterday, V1FwCorporationLeaderboardKillsYesterday>();
            CreateMap<EsiV1FwCorporationLeaderboardVictoryPoints, V1FwCorporationLeaderboardVictoryPoints>();
            CreateMap<EsiV1FwCorporationLeaderboardVictoryPointsActiveTotal,
            V1FwCorporationLeaderboardVictoryPointsActiveTotal>();
            CreateMap<EsiV1FwCorporationLeaderboardVictoryPointsLastWeek,
            V1FwCorporationLeaderboardVictoryPointsLastWeek>();
            CreateMap<EsiV1FwCorporationLeaderboardVictoryPointsYesterday,
            V1FwCorporationLeaderboardVictoryPointsYesterday>();
            CreateMap<EsiV1FwCharacterLeaderboard, V1FwCharacterLeaderboard>();
            CreateMap<EsiV1FwCharacterLeaderboardKills, V1FwCharacterLeaderboardKills>();
            CreateMap<EsiV1FwCharacterLeaderboardKillsActiveTotal, V1FwCharacterLeaderboardKillsActiveTotal>();
            CreateMap<EsiV1FwCharacterLeaderboardKillsLastWeek, V1FwCharacterLeaderboardKillsLastWeek>();
            CreateMap<EsiV1FwCharacterLeaderboardKillsYesterday, V1FwCharacterLeaderboardKillsYesterday>();
            CreateMap<EsiV1FwCharacterLeaderboardVictoryPoints, V1FwCharacterLeaderboardVictoryPoints>();
            CreateMap<EsiV1FwCharacterLeaderboardVictoryPointsActiveTotal,
            V1FwCharacterLeaderboardVictoryPointsActiveTotal>();
            CreateMap<EsiV1FwCharacterLeaderboardVictoryPointsLastWeek,
            V1FwCharacterLeaderboardVictoryPointsLastWeek>();
            CreateMap<EsiV1FwCharacterLeaderboardVictoryPointsYesterday,
            V1FwCharacterLeaderboardVictoryPointsYesterday>();
            CreateMap<EsiV1FwFactionLeaderboard, V1FwFactionLeaderboard>();
            CreateMap<EsiV1FwFactionLeaderboardKills, V1FwFactionLeaderboardKills>();
            CreateMap<EsiV1FwFactionLeaderboardKillsActiveTotal, V1FwFactionLeaderboardKillsActiveTotal>();
            CreateMap<EsiV1FwFactionLeaderboardKillsLastWeek, V1FwFactionLeaderboardKillsLastWeek>();
            CreateMap<EsiV1FwFactionLeaderboardKillsYesterday, V1FwFactionLeaderboardKillsYesterday>();
            CreateMap<EsiV1FwFactionLeaderboardVictoryPoints, V1FwFactionLeaderboardVictoryPoints>();
            CreateMap<EsiV1FwFactionLeaderboardVictoryPointsActiveTotal,
            V1FwFactionLeaderboardVictoryPointsActiveTotal>();
            CreateMap<EsiV1FwFactionLeaderboardVictoryPointsLastWeek,
            V1FwFactionLeaderboardVictoryPointsLastWeek>();
            CreateMap<EsiV1FwFactionLeaderboardVictoryPointsYesterday,
            V1FwFactionLeaderboardVictoryPointsYesterday>();
            CreateMap<EsiV1FwCorporationStats, V1FwCorporationStats>();
            CreateMap<EsiV1FwCorporationKills, V1FwCorporationKills>();
            CreateMap<EsiV1FwCorporationVictoryPoints, V1FwCorporationVictoryPoints>();
            CreateMap<EsiV1FwCharacterStats, V1FwCharacterStats>();
            CreateMap<EsiV1FwCharacterStatsKills, V1FwCharacterStatsKills>();
            CreateMap<EsiV1FwCharacterStatsVictoryPoints, V1FwCharacterStatsVictoryPoints>();
        }
    }
}
