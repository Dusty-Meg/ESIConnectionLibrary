using System.Collections.Generic;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiCorporationsRoles
    {
        public int character_id { get; set; }
        public IList<string> grantable_roles { get; set; }
        public IList<string> grantable_roles_at_base { get; set; }
        public IList<string> grantable_roles_at_hq { get; set; }
        public IList<string> grantable_roles_at_other { get; set; }
        public IList<string> roles { get; set; }
        public IList<string> roles_at_base { get; set; }
        public IList<string> roles_at_hq { get; set; }
        public IList<string> roles_at_other { get; set; }
    }
}
