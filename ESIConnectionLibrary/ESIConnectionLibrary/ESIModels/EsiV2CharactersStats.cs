using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharactersStats
    {
        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "character")]
        public EsiV2CharactersStatsCharacter Character { get; set; }

        [JsonProperty(PropertyName = "combat")]
        public EsiV2CharactersStatsCombat Combat { get; set; }

        [JsonProperty(PropertyName = "industry")]
        public EsiV2CharactersStatsIndustry Industry { get; set; }

        [JsonProperty(PropertyName = "inventory")]
        public EsiV2CharactersStatsInventory Inventory { get; set; }

        [JsonProperty(PropertyName = "isk")]
        public EsiV2CharactersStatsIsk Isk { get; set; }

        [JsonProperty(PropertyName = "market")]
        public EsiV2CharactersStatsMarket Market { get; set; }

        [JsonProperty(PropertyName = "mining")]
        public EsiV2CharactersStatsMining Mining { get; set; }

        [JsonProperty(PropertyName = "module")]
        public EsiV2CharactersStatsModule Module { get; set; }

        [JsonProperty(PropertyName = "orbital")]
        public EsiV2CharactersStatsOrbital Orbital { get; set; }

        [JsonProperty(PropertyName = "pve")]
        public EsiV2CharactersStatsPve Pve { get; set; }

        [JsonProperty(PropertyName = "social")]
        public EsiV2CharactersStatsSocial Social { get; set; }

        [JsonProperty(PropertyName = "travel")]
        public EsiV2CharactersStatsTravel Travel { get; set; }
    }
}
