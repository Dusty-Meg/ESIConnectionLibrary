using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharacterRoles
    {
        [JsonProperty(PropertyName = "roles")]
        public IList<EsiCharacterRoles> Roles { get; set; }

        [JsonProperty(PropertyName = "roles_at_hq")]
        public IList<EsiCharacterRoles> RolesAtHq { get; set; }

        [JsonProperty(PropertyName = "roles_at_base")]
        public IList<EsiCharacterRoles> RolesAtBase { get; set; }

        [JsonProperty(PropertyName = "roles_at_other")]
        public IList<EsiCharacterRoles> RolesAtOther { get; set; }
    }
}
