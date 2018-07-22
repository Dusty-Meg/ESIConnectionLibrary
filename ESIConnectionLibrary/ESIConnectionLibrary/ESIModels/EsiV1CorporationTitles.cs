using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1CorporationTitles
    {
        [JsonProperty(PropertyName = "grantable_roles")]
        public IList<EsiCorporationRoles> GrantableRoles { get; set; }

        [JsonProperty(PropertyName = "grantable_roles_at_base")]
        public IList<EsiCorporationRoles> GrantableRolesAtBase { get; set; }

        [JsonProperty(PropertyName = "grantable_roles_at_hq")]
        public IList<EsiCorporationRoles> GrantableRolesAtHq { get; set; }

        [JsonProperty(PropertyName = "grantable_roles_at_other")]
        public IList<EsiCorporationRoles> GrantableRolesAtOther { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "roles")]
        public IList<EsiCorporationRoles> Roles { get; set; }

        [JsonProperty(PropertyName = "roles_at_base")]
        public IList<EsiCorporationRoles> RolesAtBase { get; set; }

        [JsonProperty(PropertyName = "roles_at_hq")]
        public IList<EsiCorporationRoles> RolesAtHq { get; set; }

        [JsonProperty(PropertyName = "roles_at_other")]
        public IList<EsiCorporationRoles> RolesAtOther { get; set; }

        [JsonProperty(PropertyName = "title_id")]
        public int? TitleId { get; set; }
    }
}