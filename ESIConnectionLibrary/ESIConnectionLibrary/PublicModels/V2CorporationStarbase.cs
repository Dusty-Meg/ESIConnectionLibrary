using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V2CorporationStarbase
    {
        public bool AllowAllianceMembers { get; set; }
        public bool AllowCorporationMembers { get; set; }
        public V2CorporationStarbaseRoles Anchor { get; set; }
        public bool AttackIfAtWar { get; set; }
        public bool AttackIfOtherSecurityStatusDropping { get; set; }
        public float? AttackSecurityStatusThreshold { get; set; }
        public float? AttackStandingThreshold { get; set; }
        public V2CorporationStarbaseRoles FuelBayTake { get; set; }
        public V2CorporationStarbaseRoles FuelBayView { get; set; }
        public IList<V2CorporationStarbaseFuels> Fuels { get; set; }
        public V2CorporationStarbaseRoles Offline { get; set; }
        public V2CorporationStarbaseRoles Online { get; set; }
        public V2CorporationStarbaseRoles Unanchor { get; set; }
        public bool UseAllianceStandings { get; set; }
    }
}