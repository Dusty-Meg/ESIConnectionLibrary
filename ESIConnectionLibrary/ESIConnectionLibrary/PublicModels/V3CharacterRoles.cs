using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V3CharacterRoles
    {
        public IList<CharacterRoles> Roles { get; set; }

        public IList<CharacterRoles> RolesAtHq { get; set; }

        public IList<CharacterRoles> RolesAtBase { get; set; }

        public IList<CharacterRoles> RolesAtOther { get; set; }
    }
}
