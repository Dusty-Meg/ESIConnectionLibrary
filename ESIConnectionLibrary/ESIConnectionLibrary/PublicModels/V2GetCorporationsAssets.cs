namespace ESIConnectionLibrary.PublicModels
{
    public class V2GetCorporationsAssets
    {
        public int TypeId { get; set; }
        public int Quantity { get; set; }
        public long LocationId { get; set; }
        public LocationType LocationType { get; set; }
        public long ItemId { get; set; }
        public LocationFlagCorporation LocationFlag { get; set; }
        public bool IsSingleton { get; set; }
    }
}