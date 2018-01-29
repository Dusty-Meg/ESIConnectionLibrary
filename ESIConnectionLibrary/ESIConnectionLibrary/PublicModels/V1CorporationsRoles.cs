using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1CorporationsRoles
    {
        public int CharacterId { get; set; }
        public IList<string> GrantableRoles { get; set; }
        public IList<string> GrantableRolesAtBase { get; set; }
        public IList<string> GrantableRolesAtHq { get; set; }
        public IList<string> GrantableRolesAtOther { get; set; }
        public IList<string> Roles { get; set; }
        public IList<string> RolesAtBase { get; set; }
        public IList<string> RolesAtHq { get; set; }
        public IList<string> RolesAtOther { get; set; }
    }
}