namespace ESIConnectionLibrary.PublicModels
{
    public class V1PlanetaryInteractionCorporationCustomsOffice
    {
        public float? AllianceTaxRate { get; set; }
        public bool AllowAccessWithStandings { get; set; }
        public bool AllowAllianceAccess { get; set; }
        public float? BadStandingTaxRate { get; set; }
        public float? CorporationTaxRate { get; set; }
        public float? ExcellentStandingTaxRate { get; set; }
        public float? GoodStandingTaxRate { get; set; }
        public float? NeutralStandingTaxRate { get; set; }
        public long OfficeId { get; set; }
        public int ReinforceExitEnd { get; set; }
        public int ReinforceExitStart { get; set; }
        public V1PlanetaryInteractionCorporationCustomsOfficeStandingLevel? StandingLevel { get; set; }
        public int SystemId { get; set; }
        public float TerribleStandingTaxRate { get; set; }
    }
}