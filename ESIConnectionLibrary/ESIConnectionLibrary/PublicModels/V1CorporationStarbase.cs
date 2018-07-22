using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1CorporationStarbase
    {
        public bool AllowAllianceMembers { get; set; }
        public bool AllowCorporationMembers { get; set; }
        public V1CorporationStarbaseRoles Anchor { get; set; }
        public bool AttackIfAtWar { get; set; }
        public bool AttackIfOtherSecurityStatusDropping { get; set; }
        public float? AttackSecurityStatusThreshold { get; set; }
        public float? AttackStandingThreshold { get; set; }
        public V1CorporationStarbaseRoles FuelBayTake { get; set; }
        public V1CorporationStarbaseRoles FuelBayView { get; set; }
        public IList<V1CorporationStarbaseFuels> Fuels { get; set; }
        public V1CorporationStarbaseRoles Offline { get; set; }
        public V1CorporationStarbaseRoles Online { get; set; }
        public V1CorporationStarbaseRoles Unanchor { get; set; }
        public bool UseAllianceStandings { get; set; }
    }
}