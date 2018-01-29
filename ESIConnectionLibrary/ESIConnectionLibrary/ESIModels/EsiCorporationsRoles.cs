using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiCorporationsRoles
    {
        [JsonProperty(PropertyName = "character_id")]
        public int CharacterId { get; set; }

        [JsonProperty(PropertyName = "grantable_roles")]
        public IList<string> GrantableRoles { get; set; }

        [JsonProperty(PropertyName = "grantable_roles_at_base")]
        public IList<string> GrantableRolesAtBase { get; set; }

        [JsonProperty(PropertyName = "grantable_roles_at_hq")]
        public IList<string> GrantableRolesAtHq { get; set; }

        [JsonProperty(PropertyName = "grantable_roles_at_other")]
        public IList<string> GrantableRolesAtOther { get; set; }

        [JsonProperty(PropertyName = "roles")]
        public IList<string> Roles { get; set; }

        [JsonProperty(PropertyName = "roles_at_base")]
        public IList<string> RolesAtBase { get; set; }

        [JsonProperty(PropertyName = "roles_at_hq")]
        public IList<string> RolesAtHq { get; set; }

        [JsonProperty(PropertyName = "roles_at_other")]
        public IList<string> RolesAtOther { get; set; }
    }
}
