namespace ESIConnectionLibrary.PublicModels
{
    public class V2CorporationBlueprints
    {
        public long ItemId { get; set; }
        public LocationFlagCorporation LocationFlag { get; set; }
        public long LocationId { get; set; }
        public int MaterialEfficiency { get; set; }
        public int Quantity { get; set; }
        public int Runs { get; set; }
        public int TimeEfficiency { get; set; }
        public int TypeId { get; set; }
    }
}