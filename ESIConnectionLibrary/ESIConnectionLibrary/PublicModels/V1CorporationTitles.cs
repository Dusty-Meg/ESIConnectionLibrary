using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1CorporationTitles
    {
        public IList<CorporationRoles> GrantableRoles { get; set; }
        public IList<CorporationRoles> GrantableRolesAtBase { get; set; }
        public IList<CorporationRoles> GrantableRolesAtHq { get; set; }
        public IList<CorporationRoles> GrantableRolesAtOther { get; set; }
        public string Name { get; set; }
        public IList<CorporationRoles> Roles { get; set; }
        public IList<CorporationRoles> RolesAtBase { get; set; }
        public IList<CorporationRoles> RolesAtHq { get; set; }
        public IList<CorporationRoles> RolesAtOther { get; set; }
        public int? TitleId { get; set; }
    }
}