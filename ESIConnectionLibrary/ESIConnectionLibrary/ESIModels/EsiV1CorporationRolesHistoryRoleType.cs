using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EsiV1CorporationRolesHistoryRoleType
    {
        [EnumMember(Value = "grantable_roles")]
        GrantableRoles,

        [EnumMember(Value = "grantable_roles_at_base")]
        GrantableRolesAtBase,

        [EnumMember(Value = "grantable_roles_at_hq")]
        GrantableRolesAtHq,

        [EnumMember(Value = "grantable_roles_at_other")]
        GrantableRolesAtOther,

        [EnumMember(Value = "roles")]
        Roles,

        [EnumMember(Value = "roles_at_base")]
        RolesAtBase,

        [EnumMember(Value = "roles_at_hq")]
        RolesAtHq,

        [EnumMember(Value = "roles_at_other")]
        RolesAtOther
    }
}