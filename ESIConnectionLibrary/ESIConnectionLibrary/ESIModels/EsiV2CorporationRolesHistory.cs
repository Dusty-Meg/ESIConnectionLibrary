using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CorporationRolesHistory
    {
        [JsonProperty(PropertyName = "changed_at")]
        public DateTime ChangedAt { get; set; }

        [JsonProperty(PropertyName = "character_id")]
        public int CharacterId { get; set; }

        [JsonProperty(PropertyName = "issuer_id")]
        public int IssuerId { get; set; }

        [JsonProperty(PropertyName = "new_roles")]
        public IList<EsiCorporationRoles> NewRoles { get; set; }

        [JsonProperty(PropertyName = "old_roles")]
        public IList<EsiCorporationRoles> OldRoles { get; set; }

        [JsonProperty(PropertyName = "role_type")]
        public EsiV2CorporationRolesHistoryRoleType RoleType { get; set; }
    }
}