using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharactersStatsCombat
    {
        [JsonProperty(PropertyName = "cap_drainedby_npc")]
        public long? CapDrainedbyNpc { get; set; }

        [JsonProperty(PropertyName = "cap_drainedby_pc")]
        public long? CapDrainedbyPc { get; set; }

        [JsonProperty(PropertyName = "cap_draining_pc")]
        public long? CapDrainingPc { get; set; }

        [JsonProperty(PropertyName = "criminal_flag_set")]
        public long? CriminalFlagSet { get; set; }

        [JsonProperty(PropertyName = "damage_from_np_cs_amount")]
        public long? DamageFromNpCsAmount { get; set; }

        [JsonProperty(PropertyName = "damage_from_np_cs_num_shots")]
        public long? DamageFromNpCsNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_bomb_amount")]
        public long? DamageFromPlayersBombAmount { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_bomb_num_shots")]
        public long? DamageFromPlayersBombNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_combat_drone_amount")]
        public long? DamageFromPlayersCombatDroneAmount { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_combat_drone_num_shots")]
        public long? DamageFromPlayersCombatDroneNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_energy_amount")]
        public long? DamageFromPlayersEnergyAmount { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_energy_num_shots")]
        public long? DamageFromPlayersEnergyNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_fighter_bomber_amount")]
        public long? DamageFromPlayersFighterBomberAmount { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_fighter_bomber_num_shots")]
        public long? DamageFromPlayersFighterBomberNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_fighter_drone_amount")]
        public long? DamageFromPlayersFighterDroneAmount { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_fighter_drone_num_shots")]
        public long? DamageFromPlayersFighterDroneNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_hybrid_amount")]
        public long? DamageFromPlayersHybridAmount { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_hybrid_num_shots")]
        public long? DamageFromPlayersHybridNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_missile_amount")]
        public long? DamageFromPlayersMissileAmount { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_missile_num_shots")]
        public long? DamageFromPlayersMissileNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_projectile_amount")]
        public long? DamageFromPlayersProjectileAmount { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_projectile_num_shots")]
        public long? DamageFromPlayersProjectileNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_smart_bomb_amount")]
        public long? DamageFromPlayersSmartBombAmount { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_smart_bomb_num_shots")]
        public long? DamageFromPlayersSmartBombNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_super_amount")]
        public long? DamageFromPlayersSuperAmount { get; set; }

        [JsonProperty(PropertyName = "damage_from_players_super_num_shots")]
        public long? DamageFromPlayersSuperNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_from_structures_total_amount")]
        public long? DamageFromStructuresTotalAmount { get; set; }

        [JsonProperty(PropertyName = "damage_from_structures_total_num_shots")]
        public long? DamageFromStructuresTotalNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_bomb_amount")]
        public long? DamageToPlayersBombAmount { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_bomb_num_shots")]
        public long? DamageToPlayersBombNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_combat_drone_amount")]
        public long? DamageToPlayersCombatDroneAmount { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_combat_drone_num_shots")]
        public long? DamageToPlayersCombatDroneNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_energy_amount")]
        public long? DamageToPlayersEnergyAmount { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_energy_num_shots")]
        public long? DamageToPlayersEnergyNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_fighter_bomber_amount")]
        public long? DamageToPlayersFighterBomberAmount { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_fighter_bomber_num_shots")]
        public long? DamageToPlayersFighterBomberNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_fighter_drone_amount")]
        public long? DamageToPlayersFighterDroneAmount { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_fighter_drone_num_shots")]
        public long? DamageToPlayersFighterDroneNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_hybrid_amount")]
        public long? DamageToPlayersHybridAmount { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_hybrid_num_shots")]
        public long? DamageToPlayersHybridNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_missile_amount")]
        public long? DamageToPlayersMissileAmount { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_missile_num_shots")]
        public long? DamageToPlayersMissileNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_projectile_amount")]
        public long? DamageToPlayersProjectileAmount { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_projectile_num_shots")]
        public long? DamageToPlayersProjectileNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_smart_bomb_amount")]
        public long? DamageToPlayersSmartBombAmount { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_smart_bomb_num_shots")]
        public long? DamageToPlayersSmartBombNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_super_amount")]
        public long? DamageToPlayersSuperAmount { get; set; }

        [JsonProperty(PropertyName = "damage_to_players_super_num_shots")]
        public long? DamageToPlayersSuperNumShots { get; set; }

        [JsonProperty(PropertyName = "damage_to_structures_total_amount")]
        public long? DamageToStructuresTotalAmount { get; set; }

        [JsonProperty(PropertyName = "damage_to_structures_total_num_shots")]
        public long? DamageToStructuresTotalNumShots { get; set; }

        [JsonProperty(PropertyName = "deaths_high_sec")]
        public long? DeathsHighSec { get; set; }

        [JsonProperty(PropertyName = "deaths_low_sec")]
        public long? DeathsLowSec { get; set; }

        [JsonProperty(PropertyName = "deaths_null_sec")]
        public long? DeathsNullSec { get; set; }

        [JsonProperty(PropertyName = "deaths_pod_high_sec")]
        public long? DeathsPodHighSec { get; set; }

        [JsonProperty(PropertyName = "deaths_pod_low_sec")]
        public long? DeathsPodLowSec { get; set; }

        [JsonProperty(PropertyName = "deaths_pod_null_sec")]
        public long? DeathsPodNullSec { get; set; }

        [JsonProperty(PropertyName = "deaths_pod_wormhole")]
        public long? DeathsPodWormhole { get; set; }

        [JsonProperty(PropertyName = "deaths_wormhole")]
        public long? DeathsWormhole { get; set; }

        [JsonProperty(PropertyName = "drone_engage")]
        public long? DroneEngage { get; set; }

        [JsonProperty(PropertyName = "dscans")]
        public long? Dscans { get; set; }

        [JsonProperty(PropertyName = "duel_requested")]
        public long? DuelRequested { get; set; }

        [JsonProperty(PropertyName = "engagement_register")]
        public long? EngagementRegister { get; set; }

        [JsonProperty(PropertyName = "kills_assists")]
        public long? KillsAssists { get; set; }

        [JsonProperty(PropertyName = "kills_high_sec")]
        public long? KillsHighSec { get; set; }

        [JsonProperty(PropertyName = "kills_low_sec")]
        public long? KillsLowSec { get; set; }

        [JsonProperty(PropertyName = "kills_null_sec")]
        public long? KillsNullSec { get; set; }

        [JsonProperty(PropertyName = "kills_pod_high_sec")]
        public long? KillsPodHighSec { get; set; }

        [JsonProperty(PropertyName = "kills_pod_low_sec")]
        public long? KillsPodLowSec { get; set; }

        [JsonProperty(PropertyName = "kills_pod_null_sec")]
        public long? KillsPodNullSec { get; set; }

        [JsonProperty(PropertyName = "kills_pod_wormhole")]
        public long? KillsPodWormhole { get; set; }

        [JsonProperty(PropertyName = "kills_wormhole")]
        public long? KillsWormhole { get; set; }

        [JsonProperty(PropertyName = "npc_flag_set")]
        public long? NpcFlagSet { get; set; }

        [JsonProperty(PropertyName = "probe_scans")]
        public long? ProbeScans { get; set; }

        [JsonProperty(PropertyName = "pvp_flag_set")]
        public long? PvpFlagSet { get; set; }

        [JsonProperty(PropertyName = "repair_armor_by_remote_amount")]
        public long? RepairArmorByRemoteAmount { get; set; }

        [JsonProperty(PropertyName = "repair_armor_remote_amount")]
        public long? RepairArmorRemoteAmount { get; set; }

        [JsonProperty(PropertyName = "repair_armor_self_amount")]
        public long? RepairArmorSelfAmount { get; set; }

        [JsonProperty(PropertyName = "repair_capacitor_by_remote_amount")]
        public long? RepairCapacitorByRemoteAmount { get; set; }

        [JsonProperty(PropertyName = "repair_capacitor_remote_amount")]
        public long? RepairCapacitorRemoteAmount { get; set; }

        [JsonProperty(PropertyName = "repair_capacitor_self_amount")]
        public long? RepairCapacitorSelfAmount { get; set; }

        [JsonProperty(PropertyName = "repair_hull_by_remote_amount")]
        public long? RepairHullByRemoteAmount { get; set; }

        [JsonProperty(PropertyName = "repair_hull_remote_amount")]
        public long? RepairHullRemoteAmount { get; set; }

        [JsonProperty(PropertyName = "repair_hull_self_amount")]
        public long? RepairHullSelfAmount { get; set; }

        [JsonProperty(PropertyName = "repair_shield_by_remote_amount")]
        public long? RepairShieldByRemoteAmount { get; set; }

        [JsonProperty(PropertyName = "repair_shield_remote_amount")]
        public long? RepairShieldRemoteAmount { get; set; }

        [JsonProperty(PropertyName = "repair_shield_self_amount")]
        public long? RepairShieldSelfAmount { get; set; }

        [JsonProperty(PropertyName = "self_destructs")]
        public long? SelfDestructs { get; set; }

        [JsonProperty(PropertyName = "warp_scramble_pc")]
        public long? WarpScramblePc { get; set; }

        [JsonProperty(PropertyName = "warp_scrambledby_npc")]
        public long? WarpScrambledbyNpc { get; set; }

        [JsonProperty(PropertyName = "warp_scrambledby_pc")]
        public long? WarpScrambledbyPc { get; set; }

        [JsonProperty(PropertyName = "weapon_flag_set")]
        public long? WeaponFlagSet { get; set; }

        [JsonProperty(PropertyName = "webifiedby_npc")]
        public long? WebifiedbyNpc { get; set; }

        [JsonProperty(PropertyName = "webifiedby_pc")]
        public long? WebifiedbyPc { get; set; }

        [JsonProperty(PropertyName = "webifying_pc")]
        public long? WebifyingPc { get; set; }
    }
}