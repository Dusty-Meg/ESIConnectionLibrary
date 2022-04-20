namespace ESIConnectionLibrary.PublicModels
{
    public class V2CharacterAffiliations
    {
        public int CharacterId { get; set; }

        public int CorporationId { get; set; }

        public int? AllianceId { get; set; }

        public int? FactionId { get; set; }
    }
}
