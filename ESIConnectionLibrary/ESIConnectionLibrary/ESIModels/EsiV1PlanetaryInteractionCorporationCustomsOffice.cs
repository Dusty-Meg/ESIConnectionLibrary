using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1PlanetaryInteractionCorporationCustomsOffice
    {
        [JsonProperty(PropertyName = "alliance_tax_rate")]
        public float? AllianceTaxRate { get; set; }

        [JsonProperty(PropertyName = "allow_access_with_standings")]
        public bool AllowAccessWithStandings { get; set; }

        [JsonProperty(PropertyName = "allow_alliance_access")]
        public bool AllowAllianceAccess { get; set; }

        [JsonProperty(PropertyName = "bad_standing_tax_rate")]
        public float? BadStandingTaxRate { get; set; }

        [JsonProperty(PropertyName = "corporation_tax_rate")]
        public float? CorporationTaxRate { get; set; }

        [JsonProperty(PropertyName = "excellent_standing_tax_rate")]
        public float? ExcellentStandingTaxRate { get; set; }

        [JsonProperty(PropertyName = "good_standing_tax_rate")]
        public float? GoodStandingTaxRate { get; set; }

        [JsonProperty(PropertyName = "neutral_standing_tax_rate")]
        public float? NeutralStandingTaxRate { get; set; }

        [JsonProperty(PropertyName = "office_id")]
        public long OfficeId { get; set; }

        [JsonProperty(PropertyName = "reinforce_exit_end")]
        public int ReinforceExitEnd { get; set; }

        [JsonProperty(PropertyName = "reinforce_exit_start")]
        public int ReinforceExitStart { get; set; }

        [JsonProperty(PropertyName = "standing_level")]
        public EsiV1PlanetaryInteractionCorporationCustomsOfficeStandingLevel? StandingLevel { get; set; }

        [JsonProperty(PropertyName = "system_id")]
        public int SystemId { get; set; }

        [JsonProperty(PropertyName = "terrible_standing_tax_rate")]
        public float TerribleStandingTaxRate { get; set; }
    }
}