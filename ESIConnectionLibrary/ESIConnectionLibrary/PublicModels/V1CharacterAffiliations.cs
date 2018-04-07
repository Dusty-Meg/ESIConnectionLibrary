namespace ESIConnectionLibrary.PublicModels
{
    public class V1CharacterAffiliations
    {
        public int CharacterId { get; set; }

        public int CorporationId { get; set; }

        public int? AllianceId { get; set; }

        public int? FactionId { get; set; }
    }
}
