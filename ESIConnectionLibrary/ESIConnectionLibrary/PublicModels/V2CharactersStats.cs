namespace ESIConnectionLibrary.PublicModels
{
    public class V2CharactersStats
    {
        public int Year { get; set; }

        public V2CharactersStatsCharacter Character { get; set; }
        public V2CharactersStatsCombat Combat { get; set; }

        public V2CharactersStatsIndustry Industry { get; set; }

        public V2CharactersStatsInventory Inventory { get; set; }

        public V2CharactersStatsIsk Isk { get; set; }

        public V2CharactersStatsMarket Market { get; set; }

        public V2CharactersStatsMining Mining { get; set; }

        public V2CharactersStatsModule Module { get; set; }

        public V2CharactersStatsOrbital Orbital { get; set; }

        public V2CharactersStatsPve Pve { get; set; }

        public V2CharactersStatsSocial Social { get; set; }

        public V2CharactersStatsTravel Travel { get; set; }
    }
}
