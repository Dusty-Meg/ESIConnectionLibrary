using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1CorporationStarbase
    {
        [JsonProperty(PropertyName = "allow_alliance_members")]
        public bool AllowAllianceMembers { get; set; }

        [JsonProperty(PropertyName = "allow_corporation_members")]
        public bool AllowCorporationMembers { get; set; }

        [JsonProperty(PropertyName = "anchor")]
        public EsiV1CorporationStarbaseRoles Anchor { get; set; }

        [JsonProperty(PropertyName = "attack_if_at_war")]
        public bool AttackIfAtWar { get; set; }

        [JsonProperty(PropertyName = "attack_if_other_security_status_dropping")]
        public bool AttackIfOtherSecurityStatusDropping { get; set; }

        [JsonProperty(PropertyName = "attack_security_status_threshold")]
        public float? AttackSecurityStatusThreshold { get; set; }

        [JsonProperty(PropertyName = "attack_standing_threshold")]
        public float? AttackStandingThreshold { get; set; }

        [JsonProperty(PropertyName = "fuel_bay_take")]
        public EsiV1CorporationStarbaseRoles FuelBayTake { get; set; }

        [JsonProperty(PropertyName = "fuel_bay_view")]
        public EsiV1CorporationStarbaseRoles FuelBayView { get; set; }

        [JsonProperty(PropertyName = "fuels")]
        public IList<EsiV1CorporationStarbaseFuels> Fuels { get; set; }

        [JsonProperty(PropertyName = "offline")]
        public EsiV1CorporationStarbaseRoles Offline { get; set; }

        [JsonProperty(PropertyName = "online")]
        public EsiV1CorporationStarbaseRoles Online { get; set; }

        [JsonProperty(PropertyName = "unanchor")]
        public EsiV1CorporationStarbaseRoles Unanchor { get; set; }

        [JsonProperty(PropertyName = "use_alliance_standings")]
        public bool UseAllianceStandings { get; set; }
    }
}