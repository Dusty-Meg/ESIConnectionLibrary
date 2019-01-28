namespace ESIConnectionLibrary.PublicModels
{
    public class V3AssetsCorporations
    {
        public bool? IsBlueprintCopy { get; set; }
        public bool IsSingleton { get; set; }
        public long ItemId { get; set; }
        public LocationFlagCorporation LocationFlag { get; set; }
        public long LocationId { get; set; }
        public LocationType LocationType { get; set; }
        public int Quantity { get; set; }
        public int TypeId { get; set; }
    }
}