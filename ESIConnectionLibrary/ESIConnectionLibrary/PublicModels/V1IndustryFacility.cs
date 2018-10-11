namespace ESIConnectionLibrary.PublicModels
{
    public class V1IndustryFacility
    {
        public long FacilityId { get; set; }
        public int OwnerId { get; set; }
        public int RegionId { get; set; }
        public int SolarSystemId { get; set; }
        public float? Tax { get; set; }
        public int TypeId { get; set; }
    }
}