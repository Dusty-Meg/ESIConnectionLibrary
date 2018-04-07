namespace ESIConnectionLibrary.PublicModels
{
    public class V2CharactersBlueprints
    {
        public long ItemId { get; set; }

        public int TypeId { get; set; }

        public long LocationId { get; set; }

        public LocationFlagCharacter LocationFlag { get; set; }

        public int Quantity { get; set; }

        public int TimeEfficiency { get; set; }

        public int MaterialEfficiency { get; set; }

        public int Runs { get; set; }
    }
}
