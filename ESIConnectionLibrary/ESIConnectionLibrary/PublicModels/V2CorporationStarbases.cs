using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V2CorporationStarbases
    {
        public int? MoonId { get; set; }
        public DateTime? OnlinedSince { get; set; }
        public DateTime? ReinforcedUntil { get; set; }
        public long StarbaseId { get; set; }
        public V2CorporationStarbasesState? State { get; set; }
        public int SystemId { get; set; }
        public int TypeId { get; set; }
        public DateTime? UnanchorAt { get; set; }
    }
}