namespace ESIConnectionLibrary.PublicModels
{
    public class V1FleetMemberInvite
    {
        public int CharacterId { get; set; }
        public FleetRole Role { get; set; }
        public long? SquadId { get; set; }
        public long? WingId { get; set; }
    }
}