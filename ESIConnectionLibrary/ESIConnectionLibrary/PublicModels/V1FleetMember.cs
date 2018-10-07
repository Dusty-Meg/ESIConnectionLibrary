using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1FleetMember
    {
        public int CharacterId { get; set; }
        public DateTime JoinTime { get; set; }
        public FleetRole Role { get; set; }
        public string RoleName { get; set; }
        public int ShipTypeId { get; set; }
        public int SolarSystemId { get; set; }
        public long SquadId { get; set; }
        public long? StationId { get; set; }
        public bool TakesFleetWarp { get; set; }
        public long WingId { get; set; }
    }
}