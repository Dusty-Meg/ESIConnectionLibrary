using System;
using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V2CorporationRolesHistory
    {
        public DateTime ChangedAt { get; set; }
        public int CharacterId { get; set; }
        public int IssuerId { get; set; }
        public IList<CorporationRoles> NewRoles { get; set; }
        public IList<CorporationRoles> OldRoles { get; set; }
        public V2CorporationRolesHistoryRoleType RoleType { get; set; }
    }
}