using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharactersStatsTravel
    {
        [JsonProperty(PropertyName = "acceleration_gate_activations")]
        public long? AccelerationGateActivations { get; set; }

        [JsonProperty(PropertyName = "align_to")]
        public long? AlignTo { get; set; }

        [JsonProperty(PropertyName = "distance_warped_high_sec")]
        public long? DistanceWarpedHighSec { get; set; }

        [JsonProperty(PropertyName = "distance_warped_low_sec")]
        public long? DistanceWarpedLowSec { get; set; }

        [JsonProperty(PropertyName = "distance_warped_null_sec")]
        public long? DistanceWarpedNullSec { get; set; }

        [JsonProperty(PropertyName = "distance_warped_wormhole")]
        public long? DistanceWarpedWormhole { get; set; }

        [JsonProperty(PropertyName = "docks_high_sec")]
        public long? DocksHighSec { get; set; }

        [JsonProperty(PropertyName = "docks_low_sec")]
        public long? DocksLowSec { get; set; }

        [JsonProperty(PropertyName = "docks_null_sec")]
        public long? DocksNullSec { get; set; }

        [JsonProperty(PropertyName = "jumps_stargate_high_sec")]
        public long? JumpsStargateHighSec { get; set; }

        [JsonProperty(PropertyName = "jumps_stargate_low_sec")]
        public long? JumpsStargateLowSec { get; set; }

        [JsonProperty(PropertyName = "jumps_stargate_null_sec")]
        public long? JumpsStargateNullSec { get; set; }

        [JsonProperty(PropertyName = "jumps_wormhole")]
        public long? JumpsWormhole { get; set; }

        [JsonProperty(PropertyName = "warps_high_sec")]
        public long? WarpsHighSec { get; set; }

        [JsonProperty(PropertyName = "warps_low_sec")]
        public long? WarpsLowSec { get; set; }

        [JsonProperty(PropertyName = "warps_null_sec")]
        public long? WarpsNullSec { get; set; }

        [JsonProperty(PropertyName = "warps_to_bookmark")]
        public long? WarpsToBookmark { get; set; }

        [JsonProperty(PropertyName = "warps_to_celestial")]
        public long? WarpsToCelestial { get; set; }

        [JsonProperty(PropertyName = "warps_to_fleet_member")]
        public long? WarpsToFleetMember { get; set; }

        [JsonProperty(PropertyName = "warps_to_scan_result")]
        public long? WarpsToScanResult { get; set; }

        [JsonProperty(PropertyName = "warps_wormhole")]
        public long? WarpsWormhole { get; set; }
    }
}