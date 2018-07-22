using System;
using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1CorporationRolesHistory
    {
        public DateTime ChangedAt { get; set; }
        public int CharacterId { get; set; }
        public int IssuerId { get; set; }
        public IList<CorporationRoles> NewRoles { get; set; }
        public IList<CorporationRoles> OldRoles { get; set; }
        public V1CorporationRolesHistoryRoleType RoleType { get; set; }
    }
}