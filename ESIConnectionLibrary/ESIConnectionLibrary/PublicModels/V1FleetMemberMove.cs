namespace ESIConnectionLibrary.PublicModels
{
    public class V1FleetMemberMove
    {
        public FleetRole Role { get; set; }
        public long? SquadId { get; set; }
        public long? WingId { get; set; }
    }
}