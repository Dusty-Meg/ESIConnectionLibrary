namespace ESIConnectionLibrary.PublicModels
{
    public class V1KillmailKillmailAttacker
    {
        public int? AllianceId { get; set; }
        public int? CharacterId { get; set; }
        public int? CorporationId { get; set; }
        public int DamageDone { get; set; }
        public int? FactionId { get; set; }
        public bool FinalBlow { get; set; }
        public float SecurityStatus { get; set; }
        public int? ShipTypeId { get; set; }
        public int? WeaponTypeId { get; set; }
    }
}