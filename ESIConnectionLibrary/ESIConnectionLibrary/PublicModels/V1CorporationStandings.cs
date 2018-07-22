namespace ESIConnectionLibrary.PublicModels
{
    public class V1CorporationStandings
    {
        public int FromId { get; set; }
        public V1CorporationStandingsFromType FromType { get; set; }
        public float Standing { get; set; }
    }
}