namespace ESIConnectionLibrary.PublicModels
{
    public class V3AssetsCharacter
    {
        public int TypeId { get; set; }
        public int Quantity { get; set; }
        public long LocationId { get; set; }
        public LocationType LocationType { get; set; }
        public long ItemId { get; set; }
        public LocationFlagCharacter LocationFlag { get; set; }
        public bool IsSingleton { get; set; }
    }
}