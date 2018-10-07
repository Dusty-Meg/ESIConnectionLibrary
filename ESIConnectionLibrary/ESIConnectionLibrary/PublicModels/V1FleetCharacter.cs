namespace ESIConnectionLibrary.PublicModels
{
    public class V1FleetCharacter
    {
        public long FleetId { get; set; }
        public FleetRole Role { get; set; }
        public long SquadId { get; set; }
        public long WingId { get; set; }
    }
}